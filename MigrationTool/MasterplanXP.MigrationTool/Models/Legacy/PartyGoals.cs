#nullable disable

using System;
using System.Runtime.Serialization;

namespace MasterplanXP.MigrationTool.Models.Legacy
{
    /// <summary>
    /// Stand-in for the Masterplan 11.x "PartyGoals" class, which later versions removed.
    /// It exists only so old .masterplan files that contain it can be read; its data is discarded.
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// Projects saved by Masterplan 11.8 - 11.11 contain a Masterplan.Data.PartyGoals object. The
    /// class does not exist in Masterplan 12 or in any copy of the code we have, so BinaryFormatter
    /// could not rebuild it and the WHOLE project failed to load ("Unable to find assembly
    /// 'Masterplan, Version=11...'"). LegacySerializationBinder already maps Masterplan.Data.* onto
    /// this namespace, so having a class with this name lets those projects load.
    ///
    /// We do not know which fields the original class had, so it implements ISerializable: the
    /// formatter hands the saved values to the constructor below, which simply ignores them, whatever
    /// they are. Nothing is lost that M14 could use: neither the Project model here nor M14 has
    /// anywhere to keep party goals, so they would be dropped during conversion anyway.
    ///
    /// If the original class held other Masterplan-11-only types, an audit run reports them as
    /// "FAILED to resolve Masterplan.Data.X"; they can be handled with a stand-in like this one.
    /// </remarks>
    [Serializable]
    public class PartyGoals : ISerializable
    {
        /// <summary>Default constructor (not used when reading files).</summary>
        public PartyGoals()
        {
        }

        // The formatter-based ISerializable members are marked obsolete in .NET 8 (SYSLIB0051), but
        // reading these old files is exactly what they are still for, so the warning is suppressed.
#pragma warning disable SYSLIB0051

        /// <summary>
        /// Called by BinaryFormatter when reading an old file. The saved values are ignored on purpose.
        /// </summary>
        protected PartyGoals(SerializationInfo info, StreamingContext context)
        {
        }

        /// <summary>
        /// Required by ISerializable. This tool never writes the old format, so there is nothing to save.
        /// </summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

#pragma warning restore SYSLIB0051
    }
}
