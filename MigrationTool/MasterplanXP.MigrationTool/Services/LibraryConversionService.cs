using MasterplanXP.MigrationTool.Models.Legacy;
using MasterplanXP.MigrationTool.Models.DTO;
using MasterplanXP.MigrationTool.Services.Utils;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis; // NotNullIfNotNull (nullable annotations only)
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;  // Added due to recommendation to handle image
using System.IO;
using System.Linq;

namespace MasterplanXP.MigrationTool.Services
{
    /// <summary>
    /// Service responsible for mapping between legacy domain objects and MessagePack-ready DTOs.
    /// Supports the "Parallel Track" workflow for OMP to MPXP migration.
    /// </summary>
    /// <remarks>
    /// NULLABLE ANNOTATIONS (same approach as Masterplan M14's copy of this class):
    /// "Foo?" means "a Foo, or null". Most mappers below follow one pattern: null in, null out, e.g.
    ///     [return: NotNullIfNotNull(nameof(dto))]
    ///     private Hero? MapToHero(HeroDto? dto) { if (dto == null) return null; ... }
    /// The attribute tells the compiler "the result is only null when dto was null", so callers that
    /// pass a real object do not have to check the result. A few mappers can return null for other
    /// reasons too (an unknown element or log entry type); those have "?" without the attribute.
    /// These annotations only change what the compiler checks; nothing runs differently.
    /// </remarks>
    public class LibraryConversionService
    {
        private static LibraryConversionService? _instance; // created on first use (Instance)
        public static LibraryConversionService Instance => _instance ??= new LibraryConversionService();

        #region X-Format Cycle (MessagePack)
        public bool SaveXLibrary(Library lib, string targetPath)
        {
            try
            {
                var dto = MapToLibraryDto(lib);
                var data = MessagePackSerializer.Serialize(dto);
                File.WriteAllBytes(targetPath, data);
                return true;
            }
            catch (Exception ex) { LogSystem.Trace(ex); return false; }
        }

        public bool SaveXProject(Project p, string targetPath)
        {
            try
            {
                var dto = MapToProjectDto(p);
                var data = MessagePackSerializer.Serialize(dto);
                File.WriteAllBytes(targetPath, data);
                return true;
            }
            catch (Exception ex) { LogSystem.Trace(ex); return false; }
        }

        public Library? LoadXLibrary(string filePath)   // null if the file is missing or unreadable
        {
            if (!File.Exists(filePath)) return null;
            try
            {
                byte[] data = File.ReadAllBytes(filePath);
                var dto = MessagePackSerializer.Deserialize<LibraryDto>(data);
                //DumpDtoAsJson(dto, "LibraryDto_in");
                // Program.SplashScreen.CurrentSubAction = "Loading MPX: " + FileName.Name(filePath);
                return MapToLibrary(dto);
            }
            catch (Exception ex)
            {
                LogSystem.Trace($"LoadXLibrary failed for {filePath}: {ex.Message}");
                return null;
            }
        }

        public Project? LoadXProject(string filePath)   // null if the file is missing or unreadable
        {
            if (!File.Exists(filePath)) return null;
            try
            {
                byte[] data = File.ReadAllBytes(filePath);
                var dto = MessagePackSerializer.Deserialize<ProjectDto>(data);
                //DumpDtoAsJson(dto, "ProjectDto_in");

                var project = MapToProject(dto);

                try
                {
                    var rt = MapToProjectDto(project);
                    //DumpDtoAsJson(rt, "ProjectDto_roundtrip");
                }
                catch { }

                return project;
            }
            catch (Exception ex)
            {
                LogSystem.Trace($"LoadXProject failed for {filePath}: {ex.Message}");
                return null;
            }
        }
        #endregion

        #region Project Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        public Project? MapToProject(ProjectDto? dto)
        {
            if (dto == null) return null;
            var p = new Project
            {
                Name = dto.Name,
                Author = dto.Author,
                Password = dto.Password,
                PasswordHint = dto.PasswordHint
            };

            if (dto.Party != null)
            {
                p.Party.Size = dto.Party.Size;
                p.Party.Level = dto.Party.Level;
                p.Party.XP = dto.Party.XP;
            }
            else
            {
                LogSystem.Trace("[Conversion] Project missing Party data. Using defaults.");
            }

            if (dto.Heroes != null) foreach (var h in dto.Heroes) { var mapped = MapToHero(h); if (mapped != null) p.Heroes.Add(mapped); else LogSystem.Trace("[Conversion] Null hero skipped."); }
            if (dto.InactiveHeroes != null) foreach (var h in dto.InactiveHeroes) { var mapped = MapToHero(h); if (mapped != null) p.InactiveHeroes.Add(mapped); else LogSystem.Trace("[Conversion] Null inactive hero skipped."); }
            if (dto.Plot != null) p.Plot = MapToPlot(dto.Plot);
            if (dto.Encyclopedia != null) p.Encyclopedia = MapToEncyclopedia(dto.Encyclopedia);
            if (dto.Notes != null) foreach (var n in dto.Notes) if (n != null) p.Notes.Add(new Note { ID = n.ID, Content = n.Content, Category = n.Category });
            if (dto.Maps != null) foreach (var m in dto.Maps) { var mapped = MapToMap(m); if (mapped != null) p.Maps.Add(mapped); else LogSystem.Trace("[Conversion] Null map skipped."); }
            if (dto.RegionalMaps != null) foreach (var rm in dto.RegionalMaps) { var mapped = MapToRegionalMap(rm); if (mapped != null) p.RegionalMaps.Add(mapped); else LogSystem.Trace("[Conversion] Null regional map skipped."); }
            if (dto.Decks != null) foreach (var d in dto.Decks) { var mapped = MapToDeck(d); if (mapped != null) p.Decks.Add(mapped); else LogSystem.Trace("[Conversion] Null deck skipped."); }
            if (dto.NPCs != null) foreach (var npc in dto.NPCs) { var mapped = MapToNPC(npc); if (mapped != null) p.NPCs.Add(mapped); else LogSystem.Trace("[Conversion] Null NPC skipped."); }
            if (dto.CustomCreatures != null) foreach (var cc in dto.CustomCreatures) { var mapped = MapToCustomCreature(cc); if (mapped != null) p.CustomCreatures.Add(mapped); else LogSystem.Trace("[Conversion] Null custom creature skipped."); }
            if (dto.Calendars != null) foreach (var c in dto.Calendars) { var mapped = MapToCalendar(c); if (mapped != null) p.Calendars.Add(mapped); else LogSystem.Trace("[Conversion] Null calendar skipped."); }
            if (dto.Attachments != null) foreach (var a in dto.Attachments) if (a != null) p.Attachments.Add(MapToAttachment(a));
            if (dto.Backgrounds != null) foreach (var b in dto.Backgrounds) if (b != null) p.Backgrounds.Add(MapToBackground(b));
            if (dto.TreasureParcels != null) foreach (var tp in dto.TreasureParcels) if (tp != null) p.TreasureParcels.Add(MapToParcel(tp));
            if (dto.CampaignSettings != null) p.CampaignSettings = MapToCampaignSettings(dto.CampaignSettings);
            if (dto.Library != null) p.Library = MapToLibrary(dto.Library);
            if (dto.SavedCombats != null) foreach (var sc in dto.SavedCombats) { var mapped = MapToCombatState(sc, p); if (mapped != null) p.SavedCombats.Add(mapped); else LogSystem.Trace("[Conversion] Null saved combat skipped."); }
            if (dto.AddInData != null) foreach (var kv in dto.AddInData) p.AddInData[kv.Key] = kv.Value;

            if (dto.PlayerOptions != null) foreach (var po in dto.PlayerOptions) { var mapped = MapToPlayerOption(po); if (mapped != null) p.PlayerOptions.Add(mapped); else LogSystem.Trace("[Conversion] Null player option skipped."); }

            return p;
        }

        [return: NotNullIfNotNull(nameof(p))]
        public ProjectDto? MapToProjectDto(Project? p)
        {
            if (p == null) return null;
            var dto = new ProjectDto
            {
                Name = p.Name,
                Author = p.Author,
                Password = p.Password,
                PasswordHint = p.PasswordHint,
                Party = new PartyDto { Size = p.Party.Size, Level = p.Party.Level, XP = p.Party.XP },
                Library = MapToLibraryDto(p.Library)
            };

            foreach (var h in p.Heroes) dto.Heroes.Add(MapToHeroDto(h));
            foreach (var h in p.InactiveHeroes) dto.InactiveHeroes.Add(MapToHeroDto(h));
            dto.Plot = MapToPlotDto(p.Plot);
            dto.Encyclopedia = MapToEncyclopediaDto(p.Encyclopedia);
            foreach (var n in p.Notes) dto.Notes.Add(new NoteDto { ID = n.ID, Name = n.Name, Content = n.Content, Category = n.Category });
            foreach (var m in p.Maps) dto.Maps.Add(MapToMapDto(m));
            foreach (var rm in p.RegionalMaps) dto.RegionalMaps.Add(MapToRegionalMapDto(rm));
            foreach (var d in p.Decks) dto.Decks.Add(MapToDeckDto(d));
            foreach (var npc in p.NPCs) dto.NPCs.Add(MapToNPCDto(npc));
            foreach (var cc in p.CustomCreatures) dto.CustomCreatures.Add(MapToCreatureDto(cc));
            foreach (var c in p.Calendars) dto.Calendars.Add(MapToCalendarDto(c));
            foreach (var a in p.Attachments) dto.Attachments.Add(MapToAttachmentDto(a));
            foreach (var b in p.Backgrounds) dto.Backgrounds.Add(MapToBackgroundDto(b));
            foreach (var tp in p.TreasureParcels) dto.TreasureParcels.Add(MapToParcelDto(tp));
            dto.CampaignSettings = MapToCampaignSettingsDto(p.CampaignSettings);
            foreach (var sc in p.SavedCombats) dto.SavedCombats.Add(MapToCombatStateDto(sc));
            if (p.AddInData != null) foreach (var kv in p.AddInData) dto.AddInData[kv.Key] = kv.Value;

            foreach (var pp in p.AllPlotPoints) dto.AllPlotPoints.Add(MapToPlotPointDto(pp));
            foreach (var tp in p.AllTreasureParcels) dto.AllTreasureParcels.Add(MapToParcelDto(tp));
            foreach (var po in p.PlayerOptions) dto.PlayerOptions.Add(MapToPlayerOptionDto(po));

            return dto;
        }

        private void DumpDtoAsJson(object dto, string prefix)
        {
            if (dto == null) return;
            try
            {
                byte[] bytes = MessagePackSerializer.Serialize(dto);
                string json = MessagePackSerializer.ConvertToJson(bytes);
                Directory.CreateDirectory("diagnostics");
                string name = Path.Combine("diagnostics", $"{prefix}_{DateTime.UtcNow:yyyyMMddHHmmssfff}.json");
                File.WriteAllText(name, json);
            }
            catch { }
        }
        #endregion

        #region Player Option Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        private IPlayerOption? MapToPlayerOption(PlayerOptionDto? dto)
        {
            if (dto == null) return null;
            switch (dto.Type)
            {
                case "Class":
                    var c = new Class { ID = dto.ID, Name = dto.Name ?? "", Quote = dto.Quote ?? "", Role = dto.Role ?? "", PowerSource = dto.PowerSource ?? "", KeyAbilities = dto.KeyAbilities ?? "", ArmourProficiencies = dto.ArmourProficiencies ?? "", WeaponProficiencies = dto.WeaponProficiencies ?? "", Implements = dto.Implements ?? "", DefenceBonuses = dto.DefenceBonuses ?? "", HPFirst = dto.HPFirst, HPSubsequent = dto.HPSubsequent, HealingSurges = dto.HealingSurges, TrainedSkills = dto.TrainedSkills ?? "", Description = dto.Description ?? "", OverviewCharacteristics = dto.OverviewCharacteristics ?? "", OverviewReligion = dto.OverviewReligion ?? "", OverviewRaces = dto.OverviewRaces ?? "", FeatureData = MapToLevelData(dto.FeatureData) };
                    if (dto.Levels != null) foreach (var l in dto.Levels) c.Levels.Add(MapToLevelData(l));
                    return c;
                case "Race":
                    var r = new Race { ID = dto.ID, Name = dto.Name ?? "", Quote = dto.Quote ?? "", HeightRange = dto.HeightRange ?? "", WeightRange = dto.WeightRange ?? "", AbilityScores = dto.AbilityScores ?? "", Size = SafeParseEnum<CreatureSize>(dto.Size, CreatureSize.Medium, "Race Size"), Speed = dto.Speed ?? "", Vision = dto.Vision ?? "", Languages = dto.Languages ?? "", SkillBonuses = dto.SkillBonuses ?? "", Details = dto.Details ?? "" };
                    if (dto.Features != null) foreach (var f in dto.Features) r.Features.Add(new Feature { ID = f.ID, Name = f.Name ?? "", Details = f.Details ?? "" });
                    if (dto.Powers != null) foreach (var p in dto.Powers) r.Powers.Add(MapToPlayerPower(p));
                    return r;
                case "Feat":
                    return new Feat { ID = dto.ID, Name = dto.Name ?? "", Tier = SafeParseEnum<Tier>(dto.Tier, Tier.Heroic, "Feat Tier"), Prerequisites = dto.Prerequisites ?? "", Benefits = dto.Benefits ?? "" };
                case "Background":
                    return new PlayerBackground { ID = dto.ID, Name = dto.Name ?? "", Details = dto.Details ?? "", AssociatedSkills = dto.AssociatedSkills ?? "", RecommendedFeats = dto.RecommendedFeats ?? "" };
                case "Theme":
                    var th = new Theme { ID = dto.ID, Name = dto.Name ?? "", Quote = dto.Quote ?? "", Prerequisites = dto.Prerequisites ?? "", SecondaryRole = dto.SecondaryRole ?? "", PowerSource = dto.PowerSource ?? "", GrantedPower = MapToPlayerPower(dto.GrantedPower) ?? new PlayerPower(), Details = dto.Details ?? "" };
                    if (dto.Levels != null) foreach (var l in dto.Levels) th.Levels.Add(MapToLevelData(l));
                    return th;
                case "ParagonPath":
                    var pp = new ParagonPath { ID = dto.ID, Name = dto.Name ?? "", Quote = dto.Quote ?? "", Prerequisites = dto.Prerequisites ?? "", Details = dto.Details ?? "" };
                    if (dto.Levels != null) foreach (var l in dto.Levels) pp.Levels.Add(MapToLevelData(l));
                    return pp;
                case "EpicDestiny":
                    var ed = new EpicDestiny { ID = dto.ID, Name = dto.Name ?? "", Quote = dto.Quote ?? "", Prerequisites = dto.Prerequisites ?? "", Details = dto.Details ?? "", Immortality = dto.Immortality ?? "" };
                    if (dto.Levels != null) foreach (var l in dto.Levels) ed.Levels.Add(MapToLevelData(l));
                    return ed;
                case "Weapon":
                    return new Weapon { ID = dto.ID, Name = dto.Name ?? "", Category = SafeParseEnum<WeaponCategory>(dto.WeaponCategory, WeaponCategory.Simple, "Weapon Category"), Type = SafeParseEnum<WeaponType>(dto.WeaponType, WeaponType.Melee, "Weapon Type"), TwoHanded = dto.TwoHanded.GetValueOrDefault(), Proficiency = dto.Proficiency.GetValueOrDefault(), Damage = dto.Damage ?? "", Range = dto.Range ?? "", Price = dto.Price ?? "", Weight = dto.Weight ?? "", Group = dto.Group ?? "", Properties = dto.Properties ?? "", Description = dto.Description ?? "" };
                case "Ritual":
                    return new Ritual { ID = dto.ID, Name = dto.Name ?? "", ReadAloud = dto.ReadAloud ?? "", Level = dto.Level.GetValueOrDefault(1), Category = SafeParseEnum<RitualCategory>(dto.RitualCategory, RitualCategory.Binding, "Ritual Category"), Time = dto.Time ?? "", Duration = dto.Duration ?? "", ComponentCost = dto.ComponentCost ?? "", MarketPrice = dto.MarketPrice ?? "", KeySkill = dto.KeySkill ?? "", Details = dto.Details ?? "" };
                case "CreatureLore":
                    var cl = new CreatureLore { ID = dto.ID, Name = dto.Name ?? "", SkillName = dto.SkillName ?? "" };
                    if (dto.Information != null) foreach (var info in dto.Information) cl.Information.Add(new Pair<int, string>(info.First, info.Second ?? ""));
                    return cl;
                case "Disease":
                    var d = new Disease { ID = dto.ID, Name = dto.Name ?? "", Level = dto.DiseaseLevel ?? "", Details = dto.Details ?? "", Attack = dto.Attack ?? "", ImproveDC = dto.ImproveDC ?? "", MaintainDC = dto.MaintainDC ?? "" };
                    if (dto.DiseaseLevels != null) d.Levels.AddRange(dto.DiseaseLevels);
                    return d;
                case "Poison":
                    var poi = new Poison { ID = dto.ID, Name = dto.Name ?? "", Level = dto.Level.GetValueOrDefault(1), Details = dto.Details ?? "" };
                    if (dto.Sections != null) foreach (var s in dto.Sections) poi.Sections.Add(new PlayerPowerSection { ID = s.ID, Header = s.Header ?? "", Details = s.Details ?? "", Indent = s.Indent });
                    return poi;
                case "PlayerPower":
                    return MapToPlayerPower(new PlayerPowerDto { ID = dto.ID, Name = dto.Name, Type = dto.UsageType, ReadAloud = dto.ReadAloud, Keywords = dto.Keywords, Action = dto.Action, Range = dto.Range, Sections = dto.Sections });
                default:
                    // Fallback to Class as it was the previous default behavior
                    var def = new Class { ID = dto.ID, Name = dto.Name ?? "", Quote = dto.Quote ?? "", Role = dto.Role ?? "", PowerSource = dto.PowerSource ?? "", KeyAbilities = dto.KeyAbilities ?? "", ArmourProficiencies = dto.ArmourProficiencies ?? "", WeaponProficiencies = dto.WeaponProficiencies ?? "", Implements = dto.Implements ?? "", DefenceBonuses = dto.DefenceBonuses ?? "", HPFirst = dto.HPFirst, HPSubsequent = dto.HPSubsequent, HealingSurges = dto.HealingSurges, TrainedSkills = dto.TrainedSkills ?? "", Description = dto.Description ?? "", OverviewCharacteristics = dto.OverviewCharacteristics ?? "", OverviewReligion = dto.OverviewReligion ?? "", OverviewRaces = dto.OverviewRaces ?? "", FeatureData = MapToLevelData(dto.FeatureData) };
                    if (dto.Levels != null) foreach (var l in dto.Levels) def.Levels.Add(MapToLevelData(l));
                    return def;
            }
        }

        [return: NotNullIfNotNull(nameof(option))]
        private PlayerOptionDto? MapToPlayerOptionDto(IPlayerOption? option)
        {
            if (option == null) return null;
            var dto = new PlayerOptionDto { ID = option.ID, Name = option.Name };
            if (option is Class c)
            {
                dto.Type = "Class";
                dto.Quote = c.Quote;
                dto.Role = c.Role;
                dto.PowerSource = c.PowerSource;
                dto.KeyAbilities = c.KeyAbilities;
                dto.ArmourProficiencies = c.ArmourProficiencies;
                dto.WeaponProficiencies = c.WeaponProficiencies;
                dto.Implements = c.Implements;
                dto.DefenceBonuses = c.DefenceBonuses;
                dto.HPFirst = c.HPFirst;
                dto.HPSubsequent = c.HPSubsequent;
                dto.HealingSurges = c.HealingSurges;
                dto.TrainedSkills = c.TrainedSkills;
                dto.Description = c.Description;
                dto.OverviewCharacteristics = c.OverviewCharacteristics;
                dto.OverviewReligion = c.OverviewReligion;
                dto.OverviewRaces = c.OverviewRaces;
                dto.FeatureData = MapToLevelDataDto(c.FeatureData);
                foreach (var l in c.Levels) dto.Levels.Add(MapToLevelDataDto(l));
            }
            else if (option is Race r)
            {
                dto.Type = "Race";
                dto.Quote = r.Quote;
                dto.HeightRange = r.HeightRange;
                dto.WeightRange = r.WeightRange;
                dto.AbilityScores = r.AbilityScores;
                dto.Size = r.Size.ToString();
                dto.Speed = r.Speed;
                dto.Vision = r.Vision;
                dto.Languages = r.Languages;
                dto.SkillBonuses = r.SkillBonuses;
                dto.Details = r.Details;
                foreach (var f in r.Features) dto.Features.Add(new FeatureDto { ID = f.ID, Name = f.Name, Details = f.Details });
                foreach (var p in r.Powers) dto.Powers.Add(MapToPlayerPowerDto(p));
            }
            else if (option is Feat ft)
            {
                dto.Type = "Feat";
                dto.Tier = ft.Tier.ToString();
                dto.Prerequisites = ft.Prerequisites;
                dto.Benefits = ft.Benefits;
            }
            else if (option is PlayerBackground bg)
            {
                dto.Type = "Background";
                dto.Details = bg.Details;
                dto.AssociatedSkills = bg.AssociatedSkills;
                dto.RecommendedFeats = bg.RecommendedFeats;
            }
            else if (option is Theme th)
            {
                dto.Type = "Theme";
                dto.Quote = th.Quote;
                dto.Prerequisites = th.Prerequisites;
                dto.SecondaryRole = th.SecondaryRole;
                dto.PowerSource = th.PowerSource;
                dto.GrantedPower = MapToPlayerPowerDto(th.GrantedPower);
                dto.Details = th.Details;
                foreach (var l in th.Levels) dto.Levels.Add(MapToLevelDataDto(l));
            }
            else if (option is ParagonPath pp)
            {
                dto.Type = "ParagonPath";
                dto.Quote = pp.Quote;
                dto.Prerequisites = pp.Prerequisites;
                dto.Details = pp.Details;
                foreach (var l in pp.Levels) dto.Levels.Add(MapToLevelDataDto(l));
            }
            else if (option is EpicDestiny ed)
            {
                dto.Type = "EpicDestiny";
                dto.Quote = ed.Quote;
                dto.Prerequisites = ed.Prerequisites;
                dto.Details = ed.Details;
                dto.Immortality = ed.Immortality;
                foreach (var l in ed.Levels) dto.Levels.Add(MapToLevelDataDto(l));
            }
            else if (option is Weapon w)
            {
                dto.Type = "Weapon";
                dto.WeaponCategory = w.Category.ToString();
                dto.WeaponType = w.Type.ToString();
                dto.TwoHanded = w.TwoHanded;
                dto.Proficiency = w.Proficiency;
                dto.Damage = w.Damage;
                dto.Range = w.Range;
                dto.Price = w.Price;
                dto.Weight = w.Weight;
                dto.Group = w.Group;
                dto.Properties = w.Properties;
                dto.Description = w.Description;
            }
            else if (option is Ritual rit)
            {
                dto.Type = "Ritual";
                dto.ReadAloud = rit.ReadAloud;
                dto.Level = rit.Level;
                dto.RitualCategory = rit.Category.ToString();
                dto.Time = rit.Time;
                dto.Duration = rit.Duration;
                dto.ComponentCost = rit.ComponentCost;
                dto.MarketPrice = rit.MarketPrice;
                dto.KeySkill = rit.KeySkill;
                dto.Details = rit.Details;
            }
            else if (option is CreatureLore cl)
            {
                dto.Type = "CreatureLore";
                dto.SkillName = cl.SkillName;
                foreach (var info in cl.Information) dto.Information.Add(new PairDto<int, string> { First = info.First, Second = info.Second });
            }
            else if (option is Disease dis)
            {
                dto.Type = "Disease";
                dto.DiseaseLevel = dis.Level;
                dto.Details = dis.Details;
                dto.Attack = dis.Attack;
                dto.ImproveDC = dis.ImproveDC;
                dto.MaintainDC = dis.MaintainDC;
                dto.DiseaseLevels = dis.Levels.ToList();
            }
            else if (option is Poison poi)
            {
                dto.Type = "Poison";
                dto.Level = poi.Level;
                dto.Details = poi.Details;
                foreach (var s in poi.Sections) dto.Sections.Add(new PlayerPowerSectionDto { ID = s.ID, Header = s.Header, Details = s.Details, Indent = s.Indent });
            }
            else if (option is PlayerPower pow)
            {
                dto.Type = "PlayerPower";
                dto.ReadAloud = pow.ReadAloud;
                dto.Keywords = pow.Keywords;
                dto.Action = pow.Action.ToString();
                dto.Range = pow.Range;
                foreach (var s in pow.Sections) dto.Sections.Add(new PlayerPowerSectionDto { ID = s.ID, Header = s.Header, Details = s.Details, Indent = s.Indent });
            }
            return dto;
        }

        private LevelData MapToLevelData(LevelDataDto? dto)   // never null: empty LevelData for null
        {
            if (dto == null) return new LevelData();
            var ld = new LevelData { Level = dto.Level };
            if (dto.Features != null) foreach (var f in dto.Features) ld.Features.Add(new Feature { ID = f.ID, Name = f.Name ?? "", Details = f.Details ?? "" });
            if (dto.Powers != null) foreach (var p in dto.Powers) ld.Powers.Add(MapToPlayerPower(p));
            return ld;
        }

        [return: NotNullIfNotNull(nameof(ld))]
        private LevelDataDto? MapToLevelDataDto(LevelData? ld)
        {
            if (ld == null) return null;
            var dto = new LevelDataDto { Level = ld.Level };
            foreach (var f in ld.Features) dto.Features.Add(new FeatureDto { ID = f.ID, Name = f.Name, Details = f.Details });
            foreach (var p in ld.Powers) dto.Powers.Add(MapToPlayerPowerDto(p));
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private PlayerPower? MapToPlayerPower(PlayerPowerDto? dto)
        {
            if (dto == null) return null;
            var p = new PlayerPower
            {
                ID = dto.ID,
                Name = dto.Name ?? "",
                Type = SafeParseEnum<PlayerPowerType>(dto.Type, PlayerPowerType.AtWill, "PlayerPower Type"),
                Action = SafeParseEnum<ActionType>(dto.Action, ActionType.Standard, "PlayerPower Action"),
                Range = dto.Range ?? "",
                ReadAloud = dto.ReadAloud ?? "",
                Keywords = dto.Keywords ?? ""
            };
            if (dto.Sections != null) foreach (var s in dto.Sections) p.Sections.Add(new PlayerPowerSection { ID = s.ID, Header = s.Header ?? "", Details = s.Details ?? "", Indent = s.Indent });
            return p;
        }

        [return: NotNullIfNotNull(nameof(p))]
        private PlayerPowerDto? MapToPlayerPowerDto(PlayerPower? p)
        {
            if (p == null) return null;
            var dto = new PlayerPowerDto
            {
                ID = p.ID,
                Name = p.Name,
                Type = p.Type.ToString(),
                Action = p.Action.ToString(),
                Range = p.Range,
                ReadAloud = p.ReadAloud,
                Keywords = p.Keywords
            };
            foreach (var s in p.Sections) dto.Sections.Add(new PlayerPowerSectionDto { ID = s.ID, Header = s.Header, Details = s.Details, Indent = s.Indent });
            return dto;
        }
        #endregion

        #region Combat State Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        private CombatState? MapToCombatState(CombatStateDto? dto, Project context)
        {
            if (dto == null) return null;
            var cs = new CombatState
            {
                Timestamp = dto.Timestamp,
                PartyLevel = dto.PartyLevel,
                Encounter = MapToEncounter(dto.Encounter),
                CurrentRound = dto.CurrentRound,
                RemovedCreatureXP = dto.RemovedCreatureXP,
                CurrentActor = dto.CurrentActor,
                Viewpoint = new Rectangle(dto.ViewpointX, dto.ViewpointY, dto.ViewpointWidth, dto.ViewpointHeight),
                Log = MapToEncounterLog(dto.Log)
            };

            if (dto.HeroData != null) foreach (var kv in dto.HeroData) cs.HeroData[kv.Key] = MapToCombatData(kv.Value);
            if (dto.TrapData != null) foreach (var kv in dto.TrapData) cs.TrapData[kv.Key] = MapToCombatData(kv.Value);
            if (dto.TokenLinks != null) foreach (var tl in dto.TokenLinks) cs.TokenLinks.Add(MapToTokenLink(tl, context));
            if (dto.Sketches != null) foreach (var s in dto.Sketches) cs.Sketches.Add(MapToMapSketch(s));
            if (dto.QuickEffects != null) foreach (var qe in dto.QuickEffects) cs.QuickEffects.Add(MapToOngoingCondition(qe));

            return cs;
        }

        [return: NotNullIfNotNull(nameof(cs))]
        private CombatStateDto? MapToCombatStateDto(CombatState? cs)
        {
            if (cs == null) return null;
            var dto = new CombatStateDto
            {
                Timestamp = cs.Timestamp,
                PartyLevel = cs.PartyLevel,
                Encounter = MapToEncounterDto(cs.Encounter),
                CurrentRound = cs.CurrentRound,
                RemovedCreatureXP = cs.RemovedCreatureXP,
                CurrentActor = cs.CurrentActor,
                ViewpointX = cs.Viewpoint.X, ViewpointY = cs.Viewpoint.Y, ViewpointWidth = cs.Viewpoint.Width, ViewpointHeight = cs.Viewpoint.Height,
                Log = MapToEncounterLogDto(cs.Log)
            };

            foreach (var kv in cs.HeroData) dto.HeroData[kv.Key] = MapToCombatDataDto(kv.Value);
            foreach (var kv in cs.TrapData) dto.TrapData[kv.Key] = MapToCombatDataDto(kv.Value);
            foreach (var tl in cs.TokenLinks) dto.TokenLinks.Add(MapToTokenLinkDto(tl));
            foreach (var s in cs.Sketches) dto.Sketches.Add(MapToMapSketchDto(s));
            foreach (var qe in cs.QuickEffects) dto.QuickEffects.Add(MapToOngoingConditionDto(qe));

            return dto;
        }

        private TokenLink MapToTokenLink(TokenLinkDto dto, Project context)
        {
            var tl = new TokenLink { Text = dto.Text };
            if (dto.Tokens != null) foreach (var t in dto.Tokens) tl.Tokens.Add(MapToToken(t, context));
            return tl;
        }

        private TokenLinkDto MapToTokenLinkDto(TokenLink tl)
        {
            var dto = new TokenLinkDto { Text = tl.Text };
            foreach (var t in tl.Tokens) dto.Tokens.Add(MapToTokenDto(t));
            return dto;
        }

        // Null for an unknown token type, or a hero that is not in the project.
        private IToken? MapToToken(TokenDto dto, Project context)
        {
            if (dto.Type == "Creature") return new CreatureToken(dto.SlotID, MapToCombatData(dto.Data));
            if (dto.Type == "Custom") return MapToCustomToken(dto.CustomToken);
            if (dto.Type == "Hero") return context?.FindHero(dto.HeroID);
            return null;
        }

        // Only null for a null token: every IToken class (CreatureToken, CustomToken, Hero) is handled
        // below. If a new IToken class is ever added, it must be added here too.
        [return: NotNullIfNotNull(nameof(token))]
        private TokenDto? MapToTokenDto(IToken? token)
        {
            if (token is CreatureToken ct) return new TokenDto { Type = "Creature", SlotID = ct.SlotID, Data = MapToCombatDataDto(ct.Data) };
            if (token is CustomToken cust) return new TokenDto { Type = "Custom", CustomToken = MapToCustomTokenDto(cust) };
            if (token is Hero h) return new TokenDto { Type = "Hero", HeroID = h.ID };
            return null;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private CustomToken? MapToCustomToken(CustomTokenDto? dto)
        {
            if (dto == null) return null;
            return new CustomToken
            {
                ID = dto.ID,
                Type = SafeParseEnum<CustomTokenType>(dto.Type, default(CustomTokenType)),
                Name = dto.Name,
                Details = dto.Details,
                TokenSize = SafeParseEnum<CreatureSize>(dto.TokenSize, default(CreatureSize)),
                OverlaySize = new Size(dto.OverlaySizeWidth, dto.OverlaySizeHeight),
                OverlayStyle = SafeParseEnum<OverlayStyle>(dto.OverlayStyle, default(OverlayStyle)),
                Colour = Color.FromArgb(dto.ARGB),
                Image = ByteArrayToImage(dto.ImageData),
                DifficultTerrain = dto.DifficultTerrain,
                Opaque = dto.Opaque,
                Data = MapToCombatData(dto.Data),
                TerrainPower = MapToTerrainPower(dto.TerrainPower),
                CreatureID = dto.CreatureID
            };
        }

        [return: NotNullIfNotNull(nameof(ct))]
        private CustomTokenDto? MapToCustomTokenDto(CustomToken? ct)
        {
            if (ct == null) return null;
            return new CustomTokenDto
            {
                ID = ct.ID,
                Type = ct.Type.ToString(),
                Name = ct.Name,
                Details = ct.Details,
                TokenSize = ct.TokenSize.ToString(),
                OverlaySizeWidth = ct.OverlaySize.Width, OverlaySizeHeight = ct.OverlaySize.Height,
                OverlayStyle = ct.OverlayStyle.ToString(),
                ARGB = ct.Colour.ToArgb(),
                ImageData = ImageToByteArray(ct.Image, ImageRole.Token),
                DifficultTerrain = ct.DifficultTerrain,
                Opaque = ct.Opaque,
                Data = MapToCombatDataDto(ct.Data),
                TerrainPower = MapToTerrainPowerDto(ct.TerrainPower),
                CreatureID = ct.CreatureID
            };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private MapSketch? MapToMapSketch(MapSketchDto? dto)
        {
            if (dto == null) return null;
            var s = new MapSketch { Colour = Color.FromArgb(dto.ARGB), Width = dto.Width };
            if (dto.Points != null) foreach (var p in dto.Points) s.Points.Add(new MapSketchPoint { Square = new Point(p.SquareX, p.SquareY), Location = new PointF(p.LocationX, p.LocationY) });
            return s;
        }

        [return: NotNullIfNotNull(nameof(s))]
        private MapSketchDto? MapToMapSketchDto(MapSketch? s)
        {
            if (s == null) return null;
            var dto = new MapSketchDto { ARGB = s.Colour.ToArgb(), Width = s.Width };
            foreach (var p in s.Points) dto.Points.Add(new MapSketchPointDto { SquareX = p.Square.X, SquareY = p.Square.Y, LocationX = p.Location.X, LocationY = p.Location.Y });
            return dto;
        }
        #endregion

        #region Hero Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        private Hero? MapToHero(HeroDto? dto)
        {
            if (dto == null) return null;
            var h = new Hero
            {
                ID = dto.ID,
                Name = dto.Name,
                Player = dto.Player,
                Size = SafeParseEnum<CreatureSize>(dto.Size, CreatureSize.Medium, "Hero Size"),
                Race = dto.Race,
                Class = dto.Class,
                Level = dto.Level,
                ParagonPath = dto.ParagonPath,
                EpicDestiny = dto.EpicDestiny,
                PowerSource = dto.PowerSource,
                Role = SafeParseEnum<HeroRoleType>(dto.Role, HeroRoleType.Striker, "Hero Role"),
                HP = dto.HP,
                AC = dto.AC,
                Fortitude = dto.Fortitude,
                Reflex = dto.Reflex,
                Will = dto.Will,
                InitBonus = dto.InitBonus,
                PassivePerception = dto.PassivePerception,
                PassiveInsight = dto.PassiveInsight,
                Languages = dto.Languages,
                Portrait = ByteArrayToImage(dto.PortraitData),
                CombatData = MapToCombatData(dto.CombatData)
            };
            if (dto.Tokens != null) foreach (var t in dto.Tokens) h.Tokens.Add(MapToCustomToken(t));
            if (dto.Effects != null) foreach (var e in dto.Effects) h.Effects.Add(MapToOngoingCondition(e));
            return h;
        }

        [return: NotNullIfNotNull(nameof(h))]
        private HeroDto? MapToHeroDto(Hero? h)
        {
            if (h == null) return null;
            var dto = new HeroDto
            {
                ID = h.ID, Name = h.Name, Player = h.Player, Size = h.Size.ToString(), Race = h.Race, Class = h.Class, Level = h.Level,
                ParagonPath = h.ParagonPath, EpicDestiny = h.EpicDestiny, PowerSource = h.PowerSource, Role = h.Role.ToString(),
                HP = h.HP, AC = h.AC, Fortitude = h.Fortitude, Reflex = h.Reflex, Will = h.Will,
                InitBonus = h.InitBonus, PassivePerception = h.PassivePerception, PassiveInsight = h.PassiveInsight,
                Languages = h.Languages, PortraitData = ImageToByteArray(h.Portrait, ImageRole.Portrait), Info = h.Info,
                CombatData = MapToCombatDataDto(h.CombatData)
            };
            foreach (var t in h.Tokens) dto.Tokens.Add(MapToCustomTokenDto(t));
            foreach (var c in h.Effects) dto.Effects.Add(MapToOngoingConditionDto(c));
            return dto;
        }
        #endregion

        #region Library Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        public Library? MapToLibrary(LibraryDto? dto)
        {
            if (dto == null) return null;
            var lib = new Library { ID = dto.ID, Name = dto.Name };

            if (dto.Creatures != null) foreach (var c in dto.Creatures) { var creature = MapToCreature(c) as Creature; if (creature != null) lib.Creatures.Add(creature); }
            if (dto.Traps != null) foreach (var t in dto.Traps) lib.Traps.Add(MapToTrap(t));
            if (dto.SkillChallenges != null) foreach (var sc in dto.SkillChallenges) lib.SkillChallenges.Add(MapToSkillChallenge(sc));
            if (dto.MagicItems != null) foreach (var mi in dto.MagicItems) lib.MagicItems.Add(MapToMagicItem(mi));
            if (dto.Artifacts != null) foreach (var a in dto.Artifacts) lib.Artifacts.Add(MapToArtifact(a));
            if (dto.Templates != null) foreach (var t in dto.Templates) lib.Templates.Add(MapToTemplate(t));
            if (dto.Themes != null) foreach (var th in dto.Themes) lib.Themes.Add(MapToTheme(th));
            if (dto.Tiles != null) foreach (var t in dto.Tiles) lib.Tiles.Add(MapToTile(t));
            if (dto.TerrainPowers != null) foreach (var tp in dto.TerrainPowers) lib.TerrainPowers.Add(MapToTerrainPower(tp));

            return lib;
        }

        [return: NotNullIfNotNull(nameof(lib))]
        public LibraryDto? MapToLibraryDto(Library? lib)
        {
            if (lib == null) return null;
            var dto = new LibraryDto { ID = lib.ID, Name = lib.Name, ShowInAutoBuild = lib.ShowInAutoBuild };

            foreach (var c in lib.Creatures) dto.Creatures.Add(MapToCreatureDto(c));
            foreach (var t in lib.Traps) dto.Traps.Add(MapToTrapDto(t));
            foreach (var sc in lib.SkillChallenges) dto.SkillChallenges.Add(MapToSkillChallengeDto(sc));
            foreach (var mi in lib.MagicItems) dto.MagicItems.Add(MapToMagicItemDto(mi));
            foreach (var a in lib.Artifacts) dto.Artifacts.Add(MapToArtifactDto(a));
            foreach (var t in lib.Templates) dto.Templates.Add(MapToTemplateDto(t));
            foreach (var th in lib.Themes) dto.Themes.Add(MapToThemeDto(th));
            foreach (var t in lib.Tiles) dto.Tiles.Add(MapToTileDto(t));
            foreach (var tp in lib.TerrainPowers) dto.TerrainPowers.Add(MapToTerrainPowerDto(tp));

            return dto;
        }
        #endregion

        #region Creature Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        private ICreature? MapToCreature(CreatureDto? dto)
        {
            if (dto == null) return null;
            var c = new Creature();
            MapICreatureProperties(c, dto);
            c.Category = dto.Category;
            return c;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private CustomCreature? MapToCustomCreature(CreatureDto? dto)
        {
            if (dto == null) return null;
            var c = new CustomCreature();
            MapICreatureProperties(c, dto);
            return c;
        }

        [return: NotNullIfNotNull(nameof(c))]
        private CreatureDto? MapToCreatureDto(ICreature? c)
        {
            if (c == null) return null;
            var dto = new CreatureDto();
            MapICreatureDtoProperties(dto, c);
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private NPC? MapToNPC(NPCDto? dto)
        {
            if (dto == null) return null;
            var npc = new NPC { TemplateID = dto.TemplateID };
            MapICreatureProperties(npc, dto);
            npc.InitiativeModifier = dto.InitiativeModifier;
            npc.HPModifier = dto.HPModifier;
            npc.ACModifier = dto.ACModifier;
            npc.FortitudeModifier = dto.FortitudeModifier;
            npc.ReflexModifier = dto.ReflexModifier;
            npc.WillModifier = dto.WillModifier;
            return npc;
        }

        [return: NotNullIfNotNull(nameof(npc))]
        private NPCDto? MapToNPCDto(NPC? npc)
        {
            if (npc == null) return null;
            var dto = new NPCDto { TemplateID = npc.TemplateID };
            MapICreatureDtoProperties(dto, npc);
            dto.InitiativeModifier = npc.InitiativeModifier;
            dto.HPModifier = npc.HPModifier;
            dto.ACModifier = npc.ACModifier;
            dto.FortitudeModifier = npc.FortitudeModifier;
            dto.ReflexModifier = npc.ReflexModifier;
            dto.WillModifier = npc.WillModifier;
            return dto;
        }

        private void MapICreatureProperties(ICreature? c, CreatureDto? dto)
        {
            if (dto == null || c == null) return;
            c.ID = dto.ID;
            c.Name = dto.Name;
            c.Details = dto.Details;
            c.Size = SafeParseEnum<CreatureSize>(dto.Size, default(CreatureSize), "Creature Size");
            c.Origin = SafeParseEnum<CreatureOrigin>(dto.Origin, default(CreatureOrigin), "Creature Origin");
            c.Type = SafeParseEnum<CreatureType>(dto.Type, default(CreatureType), "Creature Type");
            c.Keywords = dto.Keywords;
            c.Level = dto.Level;
            c.Role = MapToRole(dto.Role);
            c.Senses = dto.Senses;
            c.Movement = dto.Movement;
            c.Alignment = dto.Alignment;
            c.Languages = dto.Languages;
            c.Skills = dto.Skills;
            c.Equipment = dto.Equipment;

            c.Strength = new Ability { Score = dto.Strength != null ? dto.Strength.Score : 10 };
            c.Constitution = new Ability { Score = dto.Constitution != null ? dto.Constitution.Score : 10 };
            c.Dexterity = new Ability { Score = dto.Dexterity != null ? dto.Dexterity.Score : 10 };
            c.Intelligence = new Ability { Score = dto.Intelligence != null ? dto.Intelligence.Score : 10 };
            c.Wisdom = new Ability { Score = dto.Wisdom != null ? dto.Wisdom.Score : 10 };
            c.Charisma = new Ability { Score = dto.Charisma != null ? dto.Charisma.Score : 10 };

            c.HP = dto.HP;
            c.Initiative = dto.Initiative;
            c.AC = dto.AC;
            c.Fortitude = dto.Fortitude;
            c.Reflex = dto.Reflex;
            c.Will = dto.Will;
            c.Regeneration = MapToRegeneration(dto.Regeneration);
            c.Resist = dto.Resist;
            c.Vulnerable = dto.Vulnerable;
            c.Immune = dto.Immune;
            c.Tactics = dto.Tactics;
            c.Image = ByteArrayToImage(dto.ImageData);

            if (dto.Auras != null) foreach (var a in dto.Auras) c.Auras.Add(MapToAura(a));
            if (dto.Powers != null) foreach (var p in dto.Powers) c.CreaturePowers.Add(MapToPower(p));
            if (dto.DamageModifiers != null) foreach (var dm in dto.DamageModifiers) c.DamageModifiers.Add(MapToDamageModifier(dm));
        }

        private void MapICreatureDtoProperties(CreatureDto? dto, ICreature? c)
        {
            if (dto == null || c == null) return;
            dto.ID = c.ID;
            dto.Name = c.Name;
            dto.Details = c.Details;
            dto.Size = c.Size.ToString();
            dto.Origin = c.Origin.ToString();
            dto.Type = c.Type.ToString();
            dto.Keywords = c.Keywords;
            dto.Level = c.Level;
            dto.Role = MapToRoleDto(c.Role);
            dto.Senses = c.Senses;
            dto.Movement = c.Movement;
            dto.Alignment = c.Alignment;
            dto.Languages = c.Languages;
            dto.Skills = c.Skills;
            dto.Equipment = c.Equipment;
            dto.Category = c.Category;
            dto.Strength = new AbilityScoreDto { Score = c.Strength.Score };
            dto.Constitution = new AbilityScoreDto { Score = c.Constitution.Score };
            dto.Dexterity = new AbilityScoreDto { Score = c.Dexterity.Score };
            dto.Intelligence = new AbilityScoreDto { Score = c.Intelligence.Score };
            dto.Wisdom = new AbilityScoreDto { Score = c.Wisdom.Score };
            dto.Charisma = new AbilityScoreDto { Score = c.Charisma.Score };
            dto.HP = c.HP;
            dto.Initiative = c.Initiative;
            dto.AC = c.AC;
            dto.Fortitude = c.Fortitude;
            dto.Reflex = c.Reflex;
            dto.Will = c.Will;
            dto.Regeneration = MapToRegenerationDto(c.Regeneration);
            dto.Resist = c.Resist;
            dto.Vulnerable = c.Vulnerable;
            dto.Immune = c.Immune;
            dto.Tactics = c.Tactics;
            dto.ImageData = ImageToByteArray(c.Image, ImageRole.Creature);
            dto.Info = c.Info;
            dto.Phenotype = c.Phenotype;

            // These DTO lists are declared "may be null" (List<...>?) because LOADING an older file can
            // give null for a missing list. A DTO created with "new" already has them (= new() in
            // DtoModels), so these lines normally do nothing; they make sure the lists exist whoever
            // created the DTO. (Same as Masterplan M14.)
            dto.Auras ??= new List<AuraDto>();
            dto.Powers ??= new List<CreaturePowerDto>();
            dto.DamageModifiers ??= new List<DamageModifierDto>();

            foreach (var a in c.Auras) dto.Auras.Add(MapToAuraDto(a));
            foreach (var p in c.CreaturePowers) dto.Powers.Add(MapToPowerDto(p));
            foreach (var dm in c.DamageModifiers) dto.DamageModifiers.Add(MapToDamageModifierDto(dm));
        }
        #endregion

        #region Component Mapping
        [return: NotNullIfNotNull(nameof(dto))]
        private Artifact? MapToArtifact(ArtifactDto? dto)
        {
            if (dto == null) return null;
            var a = new Artifact { ID = dto.ID, Name = dto.Name, Tier = SafeParseEnum<Tier>(dto.Tier, Tier.Heroic, "Artifact Tier"), Description = dto.Description, Details = dto.Details, Goals = dto.Goals, RoleplayingTips = dto.RoleplayingTips };
            if (dto.Sections != null) foreach (var s in dto.Sections) a.Sections.Add(new MagicItemSection { Header = s.Header, Details = s.Details });
            if (dto.ConcordanceLevels != null) foreach (var cl in dto.ConcordanceLevels) a.ConcordanceLevels.Add(MapToArtifactConcordance(cl));
            if (dto.ConcordanceRules != null) foreach (var rule in dto.ConcordanceRules) a.ConcordanceRules.Add(new Pair<string?, string?>(rule.First, rule.Second));   // either text may be missing (null) in a file
            return a;
        }

        [return: NotNullIfNotNull(nameof(a))]
        private ArtifactDto? MapToArtifactDto(Artifact? a)
        {
            if (a == null) return null;
            var dto = new ArtifactDto { ID = a.ID, Name = a.Name, Tier = a.Tier.ToString(), Description = a.Description, Details = a.Details, Goals = a.Goals, RoleplayingTips = a.RoleplayingTips };
            foreach (var s in a.Sections) dto.Sections.Add(new SectionDto { Header = s.Header, Details = s.Details });
            foreach (var cl in a.ConcordanceLevels) dto.ConcordanceLevels.Add(MapToArtifactConcordanceDto(cl));
            foreach (var rule in a.ConcordanceRules) dto.ConcordanceRules.Add(new PairDto<string, string> { First = rule.First, Second = rule.Second });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private ArtifactConcordance? MapToArtifactConcordance(ArtifactConcordanceDto? dto)
        {
            if (dto == null) return null;
            var ac = new ArtifactConcordance { Name = dto.Name, ValueRange = dto.ValueRange, Quote = dto.Quote, Description = dto.Description };
            if (dto.Sections != null) foreach (var s in dto.Sections) ac.Sections.Add(new MagicItemSection { Header = s.Header, Details = s.Details });
            return ac;
        }

        [return: NotNullIfNotNull(nameof(ac))]
        private ArtifactConcordanceDto? MapToArtifactConcordanceDto(ArtifactConcordance? ac)
        {
            if (ac == null) return null;
            var dto = new ArtifactConcordanceDto { Name = ac.Name, ValueRange = ac.ValueRange, Quote = ac.Quote, Description = ac.Description };
            foreach (var s in ac.Sections) dto.Sections.Add(new SectionDto { Header = s.Header, Details = s.Details });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private MonsterTheme? MapToTheme(ThemeDto? dto)
        {
            if (dto == null) return null;
            var th = new MonsterTheme { ID = dto.ID, Name = dto.Name };
            if (dto.Powers != null) foreach (var p in dto.Powers) th.Powers.Add(new ThemePowerData { Power = MapToPower(p.Power), Type = SafeParseEnum<PowerType>(p.Type, PowerType.Attack, "Theme PowerType"), Roles = p.Roles.Select(r => SafeParseEnum<RoleType>(r, RoleType.Artillery, "Theme RoleType")).ToList() });
            if (dto.SkillBonuses != null) foreach (var sb in dto.SkillBonuses) th.SkillBonuses.Add(new Pair<string?, int>(sb.First, sb.Second));   // skill name may be missing (null) in a file
            return th;
        }

        [return: NotNullIfNotNull(nameof(th))]
        private ThemeDto? MapToThemeDto(MonsterTheme? th)
        {
            if (th == null) return null;
            var dto = new ThemeDto { ID = th.ID, Name = th.Name };
            foreach (var p in th.Powers) dto.Powers.Add(new ThemePowerDataDto { Power = MapToPowerDto(p.Power), Type = p.Type.ToString(), Roles = p.Roles.Select(r => r.ToString()).ToList() });
            foreach (var sb in th.SkillBonuses) dto.SkillBonuses.Add(new PairDto<string, int> { First = sb.First, Second = sb.Second });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private CreatureTemplate? MapToTemplate(TemplateDto? dto)
        {
            if (dto == null) return null;
            var t = new CreatureTemplate
            {
                ID = dto.ID, Name = dto.Name,
                Type = SafeParseEnum<CreatureTemplateType>(dto.Type, default(CreatureTemplateType), "Template Type"),
                Role = SafeParseEnum<RoleType>(dto.Role, default(RoleType), "Template Role"),
                Leader = dto.Leader, Senses = dto.Senses, Movement = dto.Movement, HP = dto.HP, Initiative = dto.Initiative,
                AC = dto.AC, Fortitude = dto.Fortitude, Reflex = dto.Reflex, Will = dto.Will,
                Regeneration = MapToRegeneration(dto.Regeneration), Resist = dto.Resist, Vulnerable = dto.Vulnerable, Immune = dto.Immune, Tactics = dto.Tactics
            };
            if (dto.Auras != null) foreach (var a in dto.Auras) t.Auras.Add(new Aura { ID = a.ID, Name = a.Name, Keywords = a.Keywords, Details = a.Details });
            if (dto.Powers != null) foreach (var p in dto.Powers) t.CreaturePowers.Add(MapToPower(p));
            if (dto.DamageModifierTemplates != null) foreach (var dm in dto.DamageModifierTemplates) t.DamageModifierTemplates.Add(new DamageModifierTemplate { Type = SafeParseEnum<DamageType>(dm.Type, DamageType.Untyped, "Template DamageModifier Type"), HeroicValue = dm.HeroicValue, ParagonValue = dm.ParagonValue, EpicValue = dm.EpicValue });
            return t;
        }

        [return: NotNullIfNotNull(nameof(t))]
        private TemplateDto? MapToTemplateDto(CreatureTemplate? t)
        {
            if (t == null) return null;
            var dto = new TemplateDto
            {
                ID = t.ID, Name = t.Name, Type = t.Type.ToString(), Role = t.Role.ToString(), Leader = t.Leader,
                Senses = t.Senses, Movement = t.Movement, HP = t.HP, Initiative = t.Initiative,
                AC = t.AC, Fortitude = t.Fortitude, Reflex = t.Reflex, Will = t.Will,
                Regeneration = MapToRegenerationDto(t.Regeneration), Resist = t.Resist, Vulnerable = t.Vulnerable, Immune = t.Immune, Tactics = t.Tactics
            };
            foreach (var a in t.Auras) dto.Auras.Add(new AuraDto { ID = a.ID, Name = a.Name, Keywords = a.Keywords, Details = a.Details });
            foreach (var p in t.CreaturePowers) dto.Powers.Add(MapToPowerDto(p));
            foreach (var dm in t.DamageModifierTemplates) dto.DamageModifierTemplates.Add(new DamageModifierTemplateDto { Type = dm.Type.ToString(), HeroicValue = dm.HeroicValue, ParagonValue = dm.ParagonValue, EpicValue = dm.EpicValue });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Tile? MapToTile(TileDto? dto)
        {
            if (dto == null) return null;
            return new Tile
            {
                ID = dto.ID, Category = SafeParseEnum<TileCategory>(dto.Category, default(TileCategory), "Tile Category"),
                Size = new Size(dto.Width, dto.Height), Image = ByteArrayToImage(dto.ImageData),
                Keywords = dto.Keywords, BlankColour = Color.FromArgb(dto.ARGB)
            };
        }

        [return: NotNullIfNotNull(nameof(t))]
        private TileDto? MapToTileDto(Tile? t)
        {
            if (t == null) return null;
            return new TileDto { ID = t.ID, Category = t.Category.ToString(), Width = t.Size.Width, Height = t.Size.Height, ImageData = ImageToByteArray(t.Image, ImageRole.Tile, t.Size), Keywords = t.Keywords, ARGB = t.BlankColour.ToArgb() };
        }

        private Plot MapToPlot(PlotDto dto)
        {
            var plot = new Plot();
            if (dto != null && dto.Points != null) foreach (var p in dto.Points) plot.Points.Add(MapToPlotPoint(p));
            return plot;
        }

        private PlotDto MapToPlotDto(Plot plot)
        {
            var dto = new PlotDto();
            if (plot != null) foreach (var p in plot.Points) dto.Points.Add(MapToPlotPointDto(p));
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private PlotPoint? MapToPlotPoint(PlotPointDto? dto)
        {
            if (dto == null) return null;
            var pp = new PlotPoint(dto.Name) { ID = dto.ID, Details = dto.Details, ReadAloud = dto.ReadAloud };
            pp.State = SafeParseEnum<PlotPointState>(dto.State, default(PlotPointState));
            pp.Colour = SafeParseEnum<PlotPointColour>(dto.Colour, default(PlotPointColour));
            if (dto.Subplot != null) pp.Subplot = MapToPlot(dto.Subplot);
            if (dto.Element != null) pp.Element = MapToElement(dto.Element);
            if (dto.Parcels != null) foreach (var p in dto.Parcels) pp.Parcels.Add(MapToParcel(p));
            if (dto.Links != null) pp.Links.AddRange(dto.Links);
            if (dto.EncyclopediaEntryIDs != null) pp.EncyclopediaEntryIDs.AddRange(dto.EncyclopediaEntryIDs);
            if (dto.Date != null) pp.Date = MapToCalendarDate(dto.Date);
            pp.RegionalMapID = dto.RegionalMapID;
            pp.MapLocationID = dto.MapLocationID;
            pp.AdditionalXP = dto.AdditionalXP;
            return pp;
        }

        [return: NotNullIfNotNull(nameof(pp))]
        private PlotPointDto? MapToPlotPointDto(PlotPoint? pp)
        {
            if (pp == null) return null;
            var dto = new PlotPointDto { ID = pp.ID, Name = pp.Name, Details = pp.Details, ReadAloud = pp.ReadAloud, State = pp.State.ToString(), Colour = pp.Colour.ToString(), Subplot = MapToPlotDto(pp.Subplot), Element = MapToElementDto(pp.Element), Date = MapToCalendarDateDto(pp.Date), RegionalMapID = pp.RegionalMapID, MapLocationID = pp.MapLocationID, AdditionalXP = pp.AdditionalXP };
            foreach (var p in pp.Parcels) dto.Parcels.Add(MapToParcelDto(p));
            dto.Links.AddRange(pp.Links);
            dto.EncyclopediaEntryIDs.AddRange(pp.EncyclopediaEntryIDs);
            return dto;
        }

        // Null for a null dto, and also for an unknown element type (so no NotNullIfNotNull here).
        private IElement? MapToElement(ElementDto? dto)
        {
            if (dto == null) return null;
            switch (dto.Type)
            {
                case "Encounter": return MapToEncounter(MessagePackSerializer.Deserialize<EncounterDto>(dto.Data));
                case "SkillChallenge": return MapToSkillChallenge(MessagePackSerializer.Deserialize<SkillChallengeDto>(dto.Data));
                // A trap element's map placement lives on the ElementDto itself, not in the TrapDto
                // (see the comment on ElementDto.MapID). Files without it give Guid.Empty ("not placed").
                case "Trap": return new TrapElement { Trap = MapToTrap(MessagePackSerializer.Deserialize<TrapDto>(dto.Data)), MapID = dto.MapID, MapAreaID = dto.MapAreaID };
                case "Quest": return MapToQuest(MessagePackSerializer.Deserialize<QuestDto>(dto.Data));
                case "Map": return MapToMapElement(MessagePackSerializer.Deserialize<MapElementDto>(dto.Data));
                default: return null;
            }
        }

        // Null for a null element, and also for an unknown element type (so no NotNullIfNotNull here).
        private ElementDto? MapToElementDto(IElement? element)
        {
            if (element == null) return null;
            if (element is Encounter enc) return new ElementDto { Type = "Encounter", Data = MessagePackSerializer.Serialize(MapToEncounterDto(enc)) };
            if (element is SkillChallenge sc) return new ElementDto { Type = "SkillChallenge", Data = MessagePackSerializer.Serialize(MapToSkillChallengeDto(sc)) };
            // Data stays a plain TrapDto so other programs can still read it; the trap's map placement
            // (MapID / MapAreaID from the old file) goes in the ElementDto's own keys 2 and 3.
            // Before this, every converted project lost its trap map links.
            if (element is TrapElement te) return new ElementDto { Type = "Trap", Data = MessagePackSerializer.Serialize(MapToTrapDto(te.Trap)), MapID = te.MapID, MapAreaID = te.MapAreaID };
            if (element is Quest q) return new ElementDto { Type = "Quest", Data = MessagePackSerializer.Serialize(MapToQuestDto(q)) };
            if (element is MapElement me) return new ElementDto { Type = "Map", Data = MessagePackSerializer.Serialize(MapToMapElementDto(me)) };
            return null;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Quest? MapToQuest(QuestDto? dto)
        {
            if (dto == null) return null;
            return new Quest { Level = dto.Level, Type = SafeParseEnum<QuestType>(dto.Type, default(QuestType)), XP = dto.XP };
        }

        [return: NotNullIfNotNull(nameof(q))]
        private QuestDto? MapToQuestDto(Quest? q)
        {
            if (q == null) return null;
            return new QuestDto { Level = q.Level, Type = q.Type.ToString(), XP = q.XP };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private MapElement? MapToMapElement(MapElementDto? dto)
        {
            if (dto == null) return null;
            return new MapElement(dto.MapID, dto.MapAreaID);
        }

        [return: NotNullIfNotNull(nameof(me))]
        private MapElementDto? MapToMapElementDto(MapElement? me)
        {
            if (me == null) return null;
            return new MapElementDto { MapID = me.MapID, MapAreaID = me.MapAreaID };
        }

        private Encounter MapToEncounter(EncounterDto? dto)   // never null: empty Encounter for null
        {
            if (dto == null) return new Encounter();
            var enc = new Encounter { MapID = dto.MapID, MapAreaID = dto.MapAreaID };
            if (dto.Slots != null) foreach (var s in dto.Slots) enc.Slots.Add(MapToEncounterSlot(s));
            if (dto.Traps != null) foreach (var t in dto.Traps) enc.Traps.Add(MapToTrap(t));
            if (dto.SkillChallenges != null) foreach (var sc in dto.SkillChallenges) enc.SkillChallenges.Add(MapToSkillChallenge(sc));
            if (dto.CustomTokens != null) foreach (var ct in dto.CustomTokens) enc.CustomTokens.Add(MapToCustomToken(ct));
            if (dto.Notes != null) foreach (var n in dto.Notes) enc.Notes.Add(new EncounterNote { ID = n.ID, Title = n.Title, Contents = n.Contents });
            if (dto.Waves != null) foreach (var w in dto.Waves) enc.Waves.Add(MapToEncounterWave(w));
            return enc;
        }

        [return: NotNullIfNotNull(nameof(enc))]
        private EncounterDto? MapToEncounterDto(Encounter? enc)
        {
            if (enc == null) return null;
            var dto = new EncounterDto { MapID = enc.MapID, MapAreaID = enc.MapAreaID };
            foreach (var s in enc.Slots) dto.Slots.Add(MapToEncounterSlotDto(s));
            foreach (var t in enc.Traps) dto.Traps.Add(MapToTrapDto(t));
            foreach (var sc in enc.SkillChallenges) dto.SkillChallenges.Add(MapToSkillChallengeDto(sc));
            foreach (var ct in enc.CustomTokens) dto.CustomTokens.Add(MapToCustomTokenDto(ct));
            foreach (var n in enc.Notes) dto.Notes.Add(new EncounterNoteDto { ID = n.ID, Title = n.Title, Contents = n.Contents });
            foreach (var w in enc.Waves) dto.Waves.Add(MapToEncounterWaveDto(w));
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private EncounterSlot? MapToEncounterSlot(EncounterSlotDto? dto)
        {
            if (dto == null) return null;
            var slot = new EncounterSlot { ID = dto.ID, Type = SafeParseEnum<EncounterSlotType>(dto.Type, default(EncounterSlotType)) };
            if (dto.Card != null)
            {
                ICreature? libCreature = (dto.Card.CreatureID != Guid.Empty) ? Session.FindCreature(dto.Card.CreatureID, SearchType.Global) : null;
                if (libCreature != null)
                {
                    slot.Card = new EncounterCard { CreatureID = dto.Card.CreatureID, TemplateIDs = dto.Card.TemplateIDs ?? new List<Guid>(), LevelAdjustment = dto.Card.LevelAdjustment, ThemeID = dto.Card.ThemeID, ThemeAttackPowerID = dto.Card.ThemeAttackPowerID, ThemeUtilityPowerID = dto.Card.ThemeUtilityPowerID, Drawn = dto.Card.Drawn };
                }
                else
                {
                    var ghost = new CustomCreature
                    {
                        ID = dto.Card.CreatureID, Name = dto.Card.Title ?? "Unknown Creature", Level = dto.Card.Level, HP = dto.Card.HP, AC = dto.Card.AC, Fortitude = dto.Card.Fortitude, Reflex = dto.Card.Reflex, Will = dto.Card.Will, Initiative = dto.Card.Initiative,
                        Senses = dto.Card.Senses ?? "", Movement = dto.Card.Movement ?? "", Regeneration = MapToRegeneration(dto.Card.Regeneration), Resist = dto.Card.Resist ?? "", Vulnerable = dto.Card.Vulnerable ?? "", Immune = dto.Card.Immune ?? "", Tactics = dto.Card.Tactics ?? "", Skills = dto.Card.Skills ?? "", Equipment = dto.Card.Equipment ?? "", Category = dto.Card.Category ?? "", Details = dto.Card.Info ?? ""
                    };
                    string roleType = dto.Card.Roles != null && dto.Card.Roles.Count > 0 ? dto.Card.Roles[0] : "Artillery";
                    ghost.Role = MapToRole(new RoleDto { Type = roleType, Flag = dto.Card.Flag ?? "Standard", Leader = dto.Card.Leader });
                    if (dto.Card.Auras != null) foreach (var a in dto.Card.Auras) ghost.Auras.Add(MapToAura(a));
                    if (dto.Card.CreaturePowers != null) foreach (var p in dto.Card.CreaturePowers) ghost.CreaturePowers.Add(MapToPower(p));
                    if (dto.Card.DamageModifiers != null) foreach (var dm in dto.Card.DamageModifiers) ghost.DamageModifiers.Add(MapToDamageModifier(dm));
                    slot.Card = new EncounterCard(ghost) { ThemeID = dto.Card.ThemeID, ThemeAttackPowerID = dto.Card.ThemeAttackPowerID, ThemeUtilityPowerID = dto.Card.ThemeUtilityPowerID, Drawn = dto.Card.Drawn };
                }
            }
            if (dto.CombatData != null) foreach (var cd in dto.CombatData) slot.CombatData.Add(MapToCombatData(cd));
            return slot;
        }

        [return: NotNullIfNotNull(nameof(slot))]
        private EncounterSlotDto? MapToEncounterSlotDto(EncounterSlot? slot)
        {
            if (slot == null) return null;
            var dto = new EncounterSlotDto { ID = slot.ID, Type = slot.Type.ToString() };
            if (slot.Card != null)
            {
                dto.Card = new EncounterCardDto
                {
                    CreatureID = slot.Card.CreatureID, TemplateIDs = slot.Card.TemplateIDs, LevelAdjustment = slot.Card.LevelAdjustment, ThemeID = slot.Card.ThemeID, ThemeAttackPowerID = slot.Card.ThemeAttackPowerID, ThemeUtilityPowerID = slot.Card.ThemeUtilityPowerID, Drawn = slot.Card.Drawn, Title = slot.Card.Title, XP = slot.Card.XP, HP = slot.Card.HP, AC = slot.Card.AC, Fortitude = slot.Card.Fortitude, Reflex = slot.Card.Reflex, Will = slot.Card.Will, Initiative = slot.Card.Initiative, Level = slot.Card.Level, Info = slot.Card.Info,
                    Roles = slot.Card.Roles.Select(r => r.ToString()).ToList(), Flag = slot.Card.Flag.ToString(), Leader = slot.Card.Leader, Regeneration = MapToRegenerationDto(slot.Card.Regeneration), Auras = slot.Card.Auras.Select(a => MapToAuraDto(a)).ToList(), Senses = slot.Card.Senses, Movement = slot.Card.Movement, Equipment = slot.Card.Equipment, Category = slot.Card.Category.ToString(), CreaturePowers = slot.Card.CreaturePowers.Select(p => MapToPowerDto(p)).ToList(), DamageModifiers = slot.Card.DamageModifiers.Select(dm => MapToDamageModifierDto(dm)).ToList(), Resist = slot.Card.Resist, Vulnerable = slot.Card.Vulnerable, Immune = slot.Card.Immune, Tactics = slot.Card.Tactics, Skills = slot.Card.Skills
                };
            }
            dto.XP = slot.XP;
            foreach (var cd in slot.CombatData) dto.CombatData.Add(MapToCombatDataDto(cd));
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private EncounterWave? MapToEncounterWave(EncounterWaveDto? dto)
        {
            if (dto == null) return null;
            var w = new EncounterWave { ID = dto.ID, Name = dto.Name, Active = dto.Active };
            if (dto.Slots != null) foreach (var s in dto.Slots) w.Slots.Add(MapToEncounterSlot(s));
            return w;
        }

        [return: NotNullIfNotNull(nameof(w))]
        private EncounterWaveDto? MapToEncounterWaveDto(EncounterWave? w)
        {
            if (w == null) return null;
            var dto = new EncounterWaveDto { ID = w.ID, Name = w.Name, Active = w.Active };
            foreach (var s in w.Slots) dto.Slots.Add(MapToEncounterSlotDto(s));
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private CombatData? MapToCombatData(CombatDataDto? dto)
        {
            if (dto == null) return null;
            var cd = new CombatData { ID = dto.ID, DisplayName = dto.DisplayName, Location = new Point(dto.X, dto.Y), Visible = dto.Visible, Initiative = dto.Initiative, Delaying = dto.Delaying, Damage = dto.Damage, TempHP = dto.TempHP, Altitude = dto.Altitude };
            if (dto.UsedPowers != null) cd.UsedPowers.AddRange(dto.UsedPowers);
            if (dto.Conditions != null) foreach (var c in dto.Conditions) cd.Conditions.Add(MapToOngoingCondition(c));
            return cd;
        }

        [return: NotNullIfNotNull(nameof(cd))]
        private CombatDataDto? MapToCombatDataDto(CombatData? cd)
        {
            if (cd == null) return null;
            var dto = new CombatDataDto { ID = cd.ID, DisplayName = cd.DisplayName, X = cd.Location.X, Y = cd.Location.Y, Visible = cd.Visible, Initiative = cd.Initiative, Delaying = cd.Delaying, Damage = cd.Damage, TempHP = cd.TempHP, Altitude = cd.Altitude };
            if (cd.UsedPowers != null) dto.UsedPowers.AddRange(cd.UsedPowers);
            foreach (var c in cd.Conditions) dto.Conditions.Add(MapToOngoingConditionDto(c));
            return dto;
        }

        private Encyclopedia MapToEncyclopedia(EncyclopediaDto dto)
        {
            var e = new Encyclopedia();
            if (dto == null) return e;
            if (dto.Entries != null) foreach (var entry in dto.Entries) e.Entries.Add(MapToEncyclopediaEntry(entry));
            if (dto.Links != null) foreach (var link in dto.Links) e.Links.Add(new EncyclopediaLink { EntryIDs = link.EntryIDs.ToList() });
            if (dto.Groups != null) foreach (var group in dto.Groups) e.Groups.Add(new EncyclopediaGroup { ID = group.ID, Name = group.Name, EntryIDs = group.EntryIDs.ToList() });
            return e;
        }

        private EncyclopediaDto MapToEncyclopediaDto(Encyclopedia e)
        {
            var dto = new EncyclopediaDto();
            if (e == null) return dto;
            foreach (var entry in e.Entries) dto.Entries.Add(MapToEncyclopediaEntryDto(entry));
            foreach (var link in e.Links) dto.Links.Add(new EncyclopediaLinkDto { EntryIDs = link.EntryIDs.ToList() });
            foreach (var group in e.Groups) dto.Groups.Add(new EncyclopediaGroupDto { ID = group.ID, Name = group.Name, EntryIDs = group.EntryIDs.ToList() });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private EncyclopediaEntry? MapToEncyclopediaEntry(EncyclopediaEntryDto? dto)
        {
            if (dto == null) return null;
            var entry = new EncyclopediaEntry { ID = dto.ID, Name = dto.Name, Category = dto.Category, Details = dto.Details, DMInfo = dto.DMInfo, AttachmentID = dto.AttachmentID };
            if (dto.Images != null) foreach (var img in dto.Images) entry.Images.Add(new EncyclopediaImage { ID = img.ID, Name = img.Name, Image = ByteArrayToImage(img.ImageData) });
            return entry;
        }

        [return: NotNullIfNotNull(nameof(entry))]
        private EncyclopediaEntryDto? MapToEncyclopediaEntryDto(EncyclopediaEntry? entry)
        {
            if (entry == null) return null;
            var dto = new EncyclopediaEntryDto { ID = entry.ID, Name = entry.Name, Category = entry.Category, Details = entry.Details, DMInfo = entry.DMInfo, AttachmentID = entry.AttachmentID };
            foreach (var img in entry.Images) dto.Images.Add(new EncyclopediaImageDto { ID = img.ID, Name = img.Name, ImageData = ImageToByteArray(img.Image, ImageRole.Encyclopedia) });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Map? MapToMap(MapDto? dto)
        {
            if (dto == null) return null;
            var m = new Map { ID = dto.ID, Name = dto.Name, Category = dto.Category };
            if (dto.Tiles != null) foreach (var t in dto.Tiles) m.Tiles.Add(new TileData { ID = t.ID, TileID = t.TileID, Location = new Point(t.X, t.Y), Rotations = t.Rotations });
            if (dto.Areas != null) foreach (var a in dto.Areas) m.Areas.Add(new MapArea { ID = a.ID, Name = a.Name, Details = a.Details, Region = new Rectangle(a.X, a.Y, a.Width, a.Height) });
            return m;
        }

        [return: NotNullIfNotNull(nameof(m))]
        private MapDto? MapToMapDto(Map? m)
        {
            if (m == null) return null;
            var dto = new MapDto { ID = m.ID, Name = m.Name, Category = m.Category };
            foreach (var t in m.Tiles) dto.Tiles.Add(new MapTileDto { ID = t.ID, TileID = t.TileID, X = t.Location.X, Y = t.Location.Y, Rotations = t.Rotations });
            foreach (var a in m.Areas) dto.Areas.Add(new MapAreaDto { ID = a.ID, Name = a.Name, Details = a.Details, X = a.Region.X, Y = a.Region.Y, Width = a.Region.Width, Height = a.Region.Height });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private RegionalMap? MapToRegionalMap(RegionalMapDto? dto)
        {
            if (dto == null) return null;
            var rm = new RegionalMap { ID = dto.ID, Name = dto.Name, Image = ByteArrayToImage(dto.ImageData) };
            if (dto.Locations != null) foreach (var l in dto.Locations) rm.Locations.Add(new MapLocation { ID = l.ID, Name = l.Name, Category = l.Category, Point = new PointF(l.X, l.Y) });
            return rm;
        }

        [return: NotNullIfNotNull(nameof(rm))]
        private RegionalMapDto? MapToRegionalMapDto(RegionalMap? rm)
        {
            if (rm == null) return null;
            var dto = new RegionalMapDto { ID = rm.ID, Name = rm.Name, ImageData = ImageToByteArray(rm.Image, ImageRole.RegionalMap) };
            foreach (var l in rm.Locations) dto.Locations.Add(new MapLocationDto { ID = l.ID, Name = l.Name, Category = l.Category, X = l.Point.X, Y = l.Point.Y });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private EncounterDeck? MapToDeck(DeckDto? dto)
        {
            if (dto == null) return null;
            var d = new EncounterDeck { ID = dto.ID, Name = dto.Name, Level = dto.Level };
            if (dto.Cards != null) foreach (var c in dto.Cards) d.Cards.Add(new EncounterCard { CreatureID = c.CreatureID, TemplateIDs = c.TemplateIDs ?? new List<Guid>(), LevelAdjustment = c.LevelAdjustment, ThemeID = c.ThemeID });
            return d;
        }

        [return: NotNullIfNotNull(nameof(d))]
        private DeckDto? MapToDeckDto(EncounterDeck? d)
        {
            if (d == null) return null;
            var dto = new DeckDto { ID = d.ID, Name = d.Name, Level = d.Level };
            foreach (var c in d.Cards) dto.Cards.Add(new EncounterCardDto { CreatureID = c.CreatureID, TemplateIDs = c.TemplateIDs, LevelAdjustment = c.LevelAdjustment, ThemeID = c.ThemeID, Title = c.Title, XP = c.XP });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Calendar? MapToCalendar(CalendarDto? dto)
        {
            if (dto == null) return null;
            var c = new Calendar { ID = dto.ID, Name = dto.Name, Details = dto.Details, CampaignYear = dto.CampaignYear };
            if (dto.Months != null) foreach (var m in dto.Months) c.Months.Add(MapToMonthInfo(m));
            if (dto.Days != null) foreach (var d in dto.Days) c.Days.Add(MapToDayInfo(d));
            if (dto.Seasons != null) foreach (var s in dto.Seasons) c.Seasons.Add(MapToCalendarEvent(s));
            if (dto.Events != null) foreach (var e in dto.Events) c.Events.Add(MapToCalendarEvent(e));
            if (dto.Satellites != null) foreach (var s in dto.Satellites) c.Satellites.Add(MapToSatellite(s));
            return c;
        }

        [return: NotNullIfNotNull(nameof(c))]
        private CalendarDto? MapToCalendarDto(Calendar? c)
        {
            if (c == null) return null;
            var dto = new CalendarDto { ID = c.ID, Name = c.Name, Details = c.Details, CampaignYear = c.CampaignYear };
            foreach (var m in c.Months) dto.Months.Add(MapToMonthInfoDto(m));
            foreach (var d in c.Days) dto.Days.Add(MapToDayInfoDto(d));
            foreach (var s in c.Seasons) dto.Seasons.Add(MapToCalendarEventDto(s));
            foreach (var e in c.Events) dto.Events.Add(MapToCalendarEventDto(e));
            foreach (var s in c.Satellites) dto.Satellites.Add(MapToSatelliteDto(s));
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private MonthInfo? MapToMonthInfo(MonthInfoDto? dto) => dto != null ? new MonthInfo { ID = dto.ID, Name = dto.Name, DayCount = dto.DayCount, LeapModifier = dto.LeapModifier, LeapPeriod = dto.LeapPeriod } : null;
        [return: NotNullIfNotNull(nameof(mi))]
        private MonthInfoDto? MapToMonthInfoDto(MonthInfo? mi) => mi != null ? new MonthInfoDto { ID = mi.ID, Name = mi.Name, DayCount = mi.DayCount, LeapModifier = mi.LeapModifier, LeapPeriod = mi.LeapPeriod } : null;
        [return: NotNullIfNotNull(nameof(dto))]
        private DayInfo? MapToDayInfo(DayInfoDto? dto) => dto != null ? new DayInfo { ID = dto.ID, Name = dto.Name } : null;
        [return: NotNullIfNotNull(nameof(di))]
        private DayInfoDto? MapToDayInfoDto(DayInfo? di) => di != null ? new DayInfoDto { ID = di.ID, Name = di.Name } : null;
        [return: NotNullIfNotNull(nameof(dto))]
        private CalendarEvent? MapToCalendarEvent(CalendarEventDto? dto) => dto != null ? new CalendarEvent { ID = dto.ID, Name = dto.Name, MonthID = dto.MonthID, DayIndex = dto.DayIndex } : null;
        [return: NotNullIfNotNull(nameof(ce))]
        private CalendarEventDto? MapToCalendarEventDto(CalendarEvent? ce) => ce != null ? new CalendarEventDto { ID = ce.ID, Name = ce.Name, MonthID = ce.MonthID, DayIndex = ce.DayIndex } : null;
        [return: NotNullIfNotNull(nameof(dto))]
        private Satellite? MapToSatellite(SatelliteDto? dto) => dto != null ? new Satellite { ID = dto.ID, Name = dto.Name, Period = dto.Period, Offset = dto.Offset } : null;
        [return: NotNullIfNotNull(nameof(s))]
        private SatelliteDto? MapToSatelliteDto(Satellite? s) => s != null ? new SatelliteDto { ID = s.ID, Name = s.Name, Period = s.Period, Offset = s.Offset } : null;

        [return: NotNullIfNotNull(nameof(dto))]
        private CalendarDate? MapToCalendarDate(CalendarDateDto? dto) => dto != null ? new CalendarDate { ID = dto.ID, CalendarID = dto.CalendarID, Year = dto.Year, MonthID = dto.MonthID, DayIndex = dto.DayIndex } : null;
        [return: NotNullIfNotNull(nameof(cd))]
        private CalendarDateDto? MapToCalendarDateDto(CalendarDate? cd) => cd != null ? new CalendarDateDto { ID = cd.ID, CalendarID = cd.CalendarID, Year = cd.Year, MonthID = cd.MonthID, DayIndex = cd.DayIndex } : null;

        [return: NotNullIfNotNull(nameof(dto))]
        private Attachment? MapToAttachment(AttachmentDto? dto)
        {
            if (dto == null) return null;
            return new Attachment { ID = dto.ID, Name = dto.Name, Contents = dto.Contents };
        }

        [return: NotNullIfNotNull(nameof(a))]
        private AttachmentDto? MapToAttachmentDto(Attachment? a)
        {
            if (a == null) return null;
            return new AttachmentDto { ID = a.ID, Name = a.Name, Contents = a.Contents };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Background? MapToBackground(BackgroundDto? dto)
        {
            if (dto == null) return null;
            return new Background { ID = dto.ID, Title = dto.Title, Details = dto.Details };
        }

        [return: NotNullIfNotNull(nameof(b))]
        private BackgroundDto? MapToBackgroundDto(Background? b)
        {
            if (b == null) return null;
            return new BackgroundDto { ID = b.ID, Title = b.Title, Details = b.Details };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Parcel? MapToParcel(ParcelDto? dto)
        {
            if (dto == null) return null;
            return new Parcel { Name = dto.Name, Details = dto.Details, Value = dto.Value, MagicItemID = dto.MagicItemID, ArtifactID = dto.ArtifactID, HeroID = dto.HeroID };
        }

        [return: NotNullIfNotNull(nameof(p))]
        private ParcelDto? MapToParcelDto(Parcel? p)
        {
            if (p == null) return null;
            return new ParcelDto { Name = p.Name, Details = p.Details, Value = p.Value, MagicItemID = p.MagicItemID, ArtifactID = p.ArtifactID, HeroID = p.HeroID };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private CampaignSettings? MapToCampaignSettings(CampaignSettingsDto? dto)
        {
            if (dto == null) return null;
            return new CampaignSettings { HP = dto.HP, XP = dto.XP, AttackBonus = dto.AttackBonus, Damage = dto.Damage, ACBonus = dto.ACBonus, NADBonus = dto.NADBonus };
        }

        [return: NotNullIfNotNull(nameof(cs))]
        private CampaignSettingsDto? MapToCampaignSettingsDto(CampaignSettings? cs)
        {
            if (cs == null) return null;
            return new CampaignSettingsDto { HP = cs.HP, XP = cs.XP, AttackBonus = cs.AttackBonus, Damage = cs.Damage, ACBonus = cs.ACBonus, NADBonus = cs.NADBonus };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private MagicItem? MapToMagicItem(MagicItemDto? dto)
        {
            if (dto == null) return null;
            var mi = new MagicItem { ID = dto.ID, Name = dto.Name, Type = dto.Type, Rarity = SafeParseEnum<MagicItemRarity>(dto.Rarity, MagicItemRarity.Common, "MagicItem Rarity"), Level = dto.Level, Description = dto.Description };
            if (dto.Sections != null) foreach (var s in dto.Sections) mi.Sections.Add(new MagicItemSection { Header = s.Header, Details = s.Details });
            return mi;
        }

        [return: NotNullIfNotNull(nameof(mi))]
        private MagicItemDto? MapToMagicItemDto(MagicItem? mi)
        {
            if (mi == null) return null;
            var dto = new MagicItemDto { ID = mi.ID, Name = mi.Name, Type = mi.Type, Rarity = mi.Rarity.ToString(), Level = mi.Level, Description = mi.Description, Info = mi.Info };
            foreach (var s in mi.Sections) dto.Sections.Add(new SectionDto { Header = s.Header, Details = s.Details });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private TerrainPower? MapToTerrainPower(TerrainPowerDto? dto)
        {
            if (dto == null) return null;
            return new TerrainPower
            {
                ID = dto.ID, Name = dto.Name, Type = SafeParseEnum<TerrainPowerType>(dto.Type, default(TerrainPowerType)), FlavourText = dto.FlavourText, Action = SafeParseEnum<ActionType>(dto.Action, default(ActionType)), Requirement = dto.Requirement, Check = dto.Check, Success = dto.Success, Failure = dto.Failure, Target = dto.Target, Attack = dto.Attack, Hit = dto.Hit, Miss = dto.Miss, Effect = dto.Effect
            };
        }

        [return: NotNullIfNotNull(nameof(tp))]
        private TerrainPowerDto? MapToTerrainPowerDto(TerrainPower? tp)
        {
            if (tp == null) return null;
            return new TerrainPowerDto { ID = tp.ID, Name = tp.Name, Type = tp.Type.ToString(), FlavourText = tp.FlavourText, Action = tp.Action.ToString(), Requirement = tp.Requirement, Check = tp.Check, Success = tp.Success, Failure = tp.Failure, Target = tp.Target, Attack = tp.Attack, Hit = tp.Hit, Miss = tp.Miss, Effect = tp.Effect };
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Trap? MapToTrap(TrapDto? dto)
        {
            if (dto == null) return null;
            var t = new Trap { ID = dto.ID, Name = dto.Name, Type = SafeParseEnum<TrapType>(dto.Type, default(TrapType)), Level = dto.Level, Role = MapToRole(dto.Role), ReadAloud = dto.ReadAloud, Description = dto.Description, Details = dto.Details, Initiative = dto.Initiative, Trigger = dto.Trigger };
            if (dto.Skills != null) foreach (var s in dto.Skills) t.Skills.Add(new TrapSkillData { ID = s.ID, SkillName = s.SkillName, DC = s.DC, Details = s.Details });
            if (dto.Attack != null) t.Attack = MapToTrapAttack(dto.Attack);
            if (dto.Attacks != null) foreach (var a in dto.Attacks) t.Attacks.Add(MapToTrapAttack(a));
            if (dto.Countermeasures != null) t.Countermeasures.AddRange(dto.Countermeasures);
            return t;
        }

        [return: NotNullIfNotNull(nameof(t))]
        private TrapDto? MapToTrapDto(Trap? t)
        {
            if (t == null) return null;
            var dto = new TrapDto { ID = t.ID, Name = t.Name, Type = t.Type.ToString(), Level = t.Level, Role = MapToRoleDto(t.Role), ReadAloud = t.ReadAloud, Description = t.Description, Details = t.Details, Initiative = t.Initiative, Trigger = t.Trigger, Info = t.Info, XP = t.XP };
            foreach (var s in t.Skills) dto.Skills.Add(new TrapSkillDto { ID = s.ID, SkillName = s.SkillName, DC = s.DC, Details = s.Details });
            if (t.Attack != null) dto.Attack = MapToTrapAttackDto(t.Attack);
            foreach (var a in t.Attacks) dto.Attacks.Add(MapToTrapAttackDto(a));
            dto.Countermeasures = t.Countermeasures.ToList();
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private TrapAttack? MapToTrapAttack(TrapAttackDto? dto)
        {
            if (dto == null) return null;
            var a = new TrapAttack { ID = dto.ID, Name = dto.Name, Trigger = dto.Trigger, Action = SafeParseEnum<ActionType>(dto.Action, default(ActionType)), Range = dto.Range, Keywords = dto.Keywords, Target = dto.Target, HasInitiative = dto.HasInitiative, Initiative = dto.Initiative, OnHit = dto.OnHit, OnMiss = dto.OnMiss, Effect = dto.Effect, Notes = dto.Notes };
            if (dto.Attack != null) a.Attack = new PowerAttack { Bonus = dto.Attack.Bonus, Defence = SafeParseEnum<DefenceType>(dto.Attack.Defence, default(DefenceType)) };
            return a;
        }

        [return: NotNullIfNotNull(nameof(a))]
        private TrapAttackDto? MapToTrapAttackDto(TrapAttack? a)
        {
            if (a == null) return null;
            var dto = new TrapAttackDto { ID = a.ID, Name = a.Name, Trigger = a.Trigger, Action = a.Action.ToString(), Range = a.Range, Keywords = a.Keywords, Target = a.Target, HasInitiative = a.HasInitiative, Initiative = a.Initiative, OnHit = a.OnHit, OnMiss = a.OnMiss, Effect = a.Effect, Notes = a.Notes };
            if (a.Attack != null) dto.Attack = new PowerAttackDto { Bonus = a.Attack.Bonus, Defence = a.Attack.Defence.ToString() };
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private SkillChallenge? MapToSkillChallenge(SkillChallengeDto? dto)
        {
            if (dto == null) return null;
            var sc = new SkillChallenge { ID = dto.ID, Name = dto.Name, Level = dto.Level, Complexity = dto.Complexity, Success = dto.Success, Failure = dto.Failure, Notes = dto.Notes, MapID = dto.MapID, MapAreaID = dto.MapAreaID };
            if (dto.Skills != null) foreach (var s in dto.Skills) sc.Skills.Add(new SkillChallengeData { SkillName = s.SkillName, Difficulty = SafeParseEnum<Difficulty>(s.Difficulty, Difficulty.Moderate, "SkillChallenge Difficulty"), DCModifier = s.DCModifier, Details = s.Details, Success = s.Success, Failure = s.Failure });
            return sc;
        }

        [return: NotNullIfNotNull(nameof(sc))]
        private SkillChallengeDto? MapToSkillChallengeDto(SkillChallenge? sc)
        {
            if (sc == null) return null;
            var dto = new SkillChallengeDto { ID = sc.ID, Name = sc.Name, Level = sc.Level, Complexity = sc.Complexity, Success = sc.Success, Failure = sc.Failure, Notes = sc.Notes, MapID = sc.MapID, MapAreaID = sc.MapAreaID, Successes = sc.Successes, Info = sc.Info };
            foreach (var s in sc.Skills) dto.Skills.Add(new SkillChallengeDataDto { SkillName = s.SkillName, Difficulty = s.Difficulty.ToString(), DCModifier = s.DCModifier, Details = s.Details, Success = s.Success, Failure = s.Failure });
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private OngoingCondition? MapToOngoingCondition(OngoingConditionDto? dto)
        {
            if (dto == null) return null;
            var oc = new OngoingCondition
            {
                Type = SafeParseEnum<OngoingType>(dto.Type, OngoingType.Damage, "OngoingCondition Type"), Data = dto.Data, DamageType = SafeParseEnum<DamageType>(dto.DamageType, DamageType.Untyped, "OngoingCondition DamageType"), Value = dto.Value, DefenceMod = dto.DefenceMod, Regeneration = MapToRegeneration(dto.Regeneration) ?? new Regeneration(), DamageModifier = MapToDamageModifier(dto.DamageModifier) ?? new DamageModifier(), Aura = MapToAura(dto.Aura) ?? new Aura(), Duration = SafeParseEnum<DurationType>(dto.Duration, DurationType.SaveEnds, "OngoingCondition Duration"), DurationCreatureID = dto.DurationCreatureID, DurationRound = dto.DurationRound, SavingThrowModifier = dto.SavingThrowModifier
            };
            if (dto.Defences != null) foreach (var d in dto.Defences) oc.Defences.Add(SafeParseEnum<DefenceType>(d, DefenceType.AC, "OngoingCondition Defence"));
            return oc;
        }

        [return: NotNullIfNotNull(nameof(oc))]
        private OngoingConditionDto? MapToOngoingConditionDto(OngoingCondition? oc)
        {
            if (oc == null) return null;
            var dto = new OngoingConditionDto { Type = oc.Type.ToString(), Data = oc.Data, DamageType = oc.DamageType.ToString(), Value = oc.Value, DefenceMod = oc.DefenceMod, Regeneration = MapToRegenerationDto(oc.Regeneration), DamageModifier = MapToDamageModifierDto(oc.DamageModifier), Aura = MapToAuraDto(oc.Aura), Duration = oc.Duration.ToString(), DurationCreatureID = oc.DurationCreatureID, DurationRound = oc.DurationRound, SavingThrowModifier = oc.SavingThrowModifier };
            foreach (var d in oc.Defences) dto.Defences.Add(d.ToString());
            return dto;
        }

        private EncounterLog MapToEncounterLog(EncounterLogDto? dto)   // never null: empty log for null
        {
            if (dto == null) return new EncounterLog();
            var log = new EncounterLog { Active = dto.Active };
            if (dto.Entries != null) foreach (var e in dto.Entries) log.Entries.Add(MapToLogEntry(e));
            return log;
        }

        [return: NotNullIfNotNull(nameof(log))]
        private EncounterLogDto? MapToEncounterLogDto(EncounterLog? log)
        {
            if (log == null) return null;
            var dto = new EncounterLogDto { Active = log.Active };
            foreach (var e in log.Entries) dto.Entries.Add(MapToLogEntryDto(e));
            return dto;
        }

        // Null for a null dto, and also for an unknown entry type (so no NotNullIfNotNull here).
        private IEncounterLogEntry? MapToLogEntry(LogEntryDto? dto)
        {
            if (dto == null) return null;
            switch (dto.Type)
            {
                case "StartRound": var sr = MessagePackSerializer.Deserialize<StartRoundEntryDto>(dto.Data); return new StartRoundLogEntry { Timestamp = dto.Timestamp, Round = sr.Round };
                case "StartTurn": return new StartTurnLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp };
                case "Damage": var d = MessagePackSerializer.Deserialize<DamageEntryDto>(dto.Data); return new DamageLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, Amount = d.Amount, Types = d.Types != null ? d.Types.Select(t => SafeParseEnum<DamageType>(t, DamageType.Untyped, "Log DamageType")).ToList() : new List<DamageType>() };
                case "State": var s = MessagePackSerializer.Deserialize<StateEntryDto>(dto.Data); return new StateLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, State = SafeParseEnum<CreatureState>(s.State, default(CreatureState), "Log CreatureState") };
                case "Effect": var ef = MessagePackSerializer.Deserialize<EffectEntryDto>(dto.Data); return new EffectLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, EffectText = ef.EffectText, Added = ef.Added };
                case "Power": var p = MessagePackSerializer.Deserialize<PowerEntryDto>(dto.Data); return new PowerLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, PowerName = p.PowerName, Added = p.Added };
                case "Skill": var sk = MessagePackSerializer.Deserialize<SkillEntryDto>(dto.Data); return new SkillLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, SkillName = sk.SkillName };
                case "SkillChallenge": var sc = MessagePackSerializer.Deserialize<SkillChallengeLogEntryDto>(dto.Data); return new SkillChallengeLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, Success = sc.Success };
                case "Move": var m = MessagePackSerializer.Deserialize<MoveEntryDto>(dto.Data); return new MoveLogEntry { CombatantID = dto.CombatantID, Timestamp = dto.Timestamp, Distance = m.Distance, Details = m.Details };
                case "Pause": return new PauseLogEntry { Timestamp = dto.Timestamp };
                case "Resume": return new ResumeLogEntry { Timestamp = dto.Timestamp };
                default: return null;
            }
        }

        [return: NotNullIfNotNull(nameof(entry))]
        private LogEntryDto? MapToLogEntryDto(IEncounterLogEntry? entry)
        {
            if (entry == null) return null;
            var dto = new LogEntryDto { CombatantID = entry.CombatantID, Timestamp = entry.Timestamp };
            if (entry is StartRoundLogEntry sr) { dto.Type = "StartRound"; dto.Data = MessagePackSerializer.Serialize(new StartRoundEntryDto { Round = sr.Round }); }
            else if (entry is StartTurnLogEntry) { dto.Type = "StartTurn"; }
            else if (entry is DamageLogEntry d) { dto.Type = "Damage"; dto.Data = MessagePackSerializer.Serialize(new DamageEntryDto { Amount = d.Amount, Types = d.Types != null ? d.Types.Select(t => t.ToString()).ToList() : new List<string>() }); }
            else if (entry is StateLogEntry s) { dto.Type = "State"; dto.Data = MessagePackSerializer.Serialize(new StateEntryDto { State = s.State.ToString() }); }
            else if (entry is EffectLogEntry ef) { dto.Type = "Effect"; dto.Data = MessagePackSerializer.Serialize(new EffectEntryDto { EffectText = ef.EffectText, Added = ef.Added }); }
            else if (entry is PowerLogEntry p) { dto.Type = "Power"; dto.Data = MessagePackSerializer.Serialize(new PowerEntryDto { PowerName = p.PowerName, Added = p.Added }); }
            else if (entry is SkillLogEntry sk) { dto.Type = "Skill"; dto.Data = MessagePackSerializer.Serialize(new SkillEntryDto { SkillName = sk.SkillName }); }
            else if (entry is SkillChallengeLogEntry sc) { dto.Type = "SkillChallenge"; dto.Data = MessagePackSerializer.Serialize(new SkillChallengeLogEntryDto { Success = sc.Success }); }
            else if (entry is MoveLogEntry m) { dto.Type = "Move"; dto.Data = MessagePackSerializer.Serialize(new MoveEntryDto { Distance = m.Distance, Details = m.Details }); }
            else if (entry is PauseLogEntry) { dto.Type = "Pause"; }
            else if (entry is ResumeLogEntry) { dto.Type = "Resume"; }
            return dto;
        }

        private T SafeParseEnum<T>(string? value, T defaultValue, string context = "") where T : struct, Enum   // null or "" gives defaultValue
        {
            if (string.IsNullOrEmpty(value)) return defaultValue;
            if (Enum.TryParse<T>(value, true, out T result)) return result;
            LogSystem.Trace($"[Conversion] Failed to parse enum '{typeof(T).Name}' with value '{value}'. Context: {context}. Using default: {defaultValue}");
            return defaultValue;
        }

        private IRole MapToRole(RoleDto? dto)   // never null: a default ComplexRole for null
        {
            if (dto == null) return new ComplexRole();
            if (dto.IsMinion) return new Minion { HasRole = dto.MinionHasRole, Type = SafeParseEnum<RoleType>(dto.Type, RoleType.Artillery, "Minion RoleType") };
            return new ComplexRole { Type = SafeParseEnum<RoleType>(dto.Type, RoleType.Artillery, "ComplexRole RoleType"), Flag = SafeParseEnum<RoleFlag>(dto.Flag, RoleFlag.Standard, "ComplexRole RoleFlag"), Leader = dto.Leader };
        }

        [return: NotNullIfNotNull(nameof(role))]
        private RoleDto? MapToRoleDto(IRole? role)
        {
            if (role == null) return null;
            var dto = new RoleDto();
            if (role is Minion m) { dto.IsMinion = true; dto.MinionHasRole = m.HasRole; dto.Type = m.Type.ToString(); }
            else if (role is ComplexRole cr) { dto.IsMinion = false; dto.Type = cr.Type.ToString(); dto.Flag = cr.Flag.ToString(); dto.Leader = cr.Leader; }
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private CreaturePower? MapToPower(CreaturePowerDto? dto)
        {
            if (dto == null) return null;
            var p = new CreaturePower { ID = dto.ID, Name = dto.Name, Keywords = dto.Keywords, Condition = dto.Condition, Range = dto.Range, Description = dto.Description, Details = dto.Details };
            if (dto.Action != null) p.Action = new PowerAction { Action = SafeParseEnum<ActionType>(dto.Action.Action, ActionType.Standard, "PowerAction Action"), Trigger = dto.Action.Trigger, SustainAction = SafeParseEnum<ActionType>(dto.Action.SustainAction, ActionType.Standard, "PowerAction SustainAction"), Use = SafeParseEnum<PowerUseType>(dto.Action.Use, PowerUseType.AtWill, "PowerAction Use"), Recharge = dto.Action.Recharge };
            if (dto.Attack != null) p.Attack = new PowerAttack { Bonus = dto.Attack.Bonus, Defence = SafeParseEnum<DefenceType>(dto.Attack.Defence, DefenceType.AC, "PowerAttack Defence") };
            return p;
        }

        [return: NotNullIfNotNull(nameof(p))]
        private CreaturePowerDto? MapToPowerDto(CreaturePower? p)
        {
            if (p == null) return null;
            var dto = new CreaturePowerDto { ID = p.ID, Name = p.Name, Keywords = p.Keywords, Condition = p.Condition, Range = p.Range, Description = p.Description, Details = p.Details, Damage = p.Damage, Category = p.Category.ToString() };
            if (p.Action != null) dto.Action = new PowerActionDto { Action = p.Action.Action.ToString(), Trigger = p.Action.Trigger, SustainAction = p.Action.SustainAction.ToString(), Use = p.Action.Use.ToString(), Recharge = p.Action.Recharge };
            if (p.Attack != null) dto.Attack = new PowerAttackDto { Bonus = p.Attack.Bonus, Defence = p.Attack.Defence.ToString() };
            return dto;
        }

        [return: NotNullIfNotNull(nameof(dto))]
        private Regeneration? MapToRegeneration(RegenerationDto? dto) => dto != null ? new Regeneration(dto.Value, dto.Details) : null;
        [return: NotNullIfNotNull(nameof(r))]
        private RegenerationDto? MapToRegenerationDto(Regeneration? r) => r != null ? new RegenerationDto { Value = r.Value, Details = r.Details } : null;
        [return: NotNullIfNotNull(nameof(dto))]
        private DamageModifier? MapToDamageModifier(DamageModifierDto? dto) => dto != null ? new DamageModifier { Type = SafeParseEnum<DamageType>(dto.Type, DamageType.Untyped, "DamageModifier Type"), Value = dto.Value } : null;
        [return: NotNullIfNotNull(nameof(dm))]
        private DamageModifierDto? MapToDamageModifierDto(DamageModifier? dm) => dm != null ? new DamageModifierDto { Type = dm.Type.ToString(), Value = dm.Value } : null;
        [return: NotNullIfNotNull(nameof(dto))]
        private Aura? MapToAura(AuraDto? dto) => dto != null ? new Aura { ID = dto.ID, Name = dto.Name, Keywords = dto.Keywords, Details = dto.Details } : null;
        [return: NotNullIfNotNull(nameof(a))]
        private AuraDto? MapToAuraDto(Aura? a) => a != null ? new AuraDto { ID = a.ID, Name = a.Name, Keywords = a.Keywords, Details = a.Details } : null;

        /// <summary>
        /// Whether images are compressed while converting (the "Compress images" switch; default ON).
        /// </summary>
        /// <remarks>
        /// Replaces the old UseJpeg / JpegQuality settings. The old option saved EVERY image as JPEG,
        /// which turned transparent areas of tokens and tiles black. Compression now shrinks images
        /// to a size cap for their role and keeps transparency (see Services/Utils/ImageCompression.cs).
        /// With compression off, images are saved as PNG unchanged (the previous default behaviour).
        /// </remarks>
        public bool CompressImages { get; set; } = true;

        /// <summary>How much images are shrunk when CompressImages is on (the "Image size" choice).</summary>
        public ImageSizeLevel ImageSizeLevel { get; set; } = ImageSizeLevel.Regular;

        /// <summary>
        /// Turns an image into bytes for the converted file.
        /// </summary>
        /// <param name="img">The image (may be null).</param>
        /// <param name="role">What the image is used for; decides its size cap.</param>
        /// <param name="tile_squares">For tiles only: the tile's size in grid squares.</param>
        [return: NotNullIfNotNull(nameof(img))]
        private byte[]? ImageToByteArray(Image? img, ImageRole role, Size tile_squares = default)
        {
            if (img == null) return null;

            return CompressImages
                ? ImageCompression.Encode(img, role, ImageSizeLevel, tile_squares)
                : ImageCompression.EncodePng(img);
        }

        /// <summary>
        /// Turns saved bytes back into an image. ImageCompression.Decode copies the image so it no
        /// longer depends on the (closed) stream, which avoids GDI+ "generic error" failures later.
        /// </summary>
        private Image? ByteArrayToImage(byte[]? data) => ImageCompression.Decode(data); // null/empty data gives null

        #endregion
    }
}
