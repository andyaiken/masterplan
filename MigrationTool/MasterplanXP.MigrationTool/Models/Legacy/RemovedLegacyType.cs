#nullable disable

using System;
using System.Runtime.Serialization;

namespace MasterplanXP.MigrationTool.Models.Legacy
{
    /// <summary>
    /// Catch-all stand-in for any OLD Masterplan class that no longer exists (a removed feature,
    /// e.g. Masterplan 11's "5x5" campaign planner, Masterplan.Data.FiveByFiveData). Its data is
    /// discarded so the rest of the file can still be read.
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// Projects saved by older Masterplan versions can contain objects of classes that later versions
    /// deleted. BinaryFormatter cannot rebuild a class that does not exist, so before this the WHOLE
    /// file failed to load. LegacySerializationBinder now hands back this class for any old Masterplan
    /// type name ("Masterplan.*" from the "Masterplan" assembly) it cannot map, and logs it as
    /// discarded (the audit summary lists every discarded type per file).
    ///
    /// It implements ISerializable, so the saved values are passed to the constructor below, which
    /// ignores them whatever they are. That is safe for removed features: the newer classes have no
    /// field to store that data in, so it would be dropped anyway.
    ///
    /// LIMIT: if a removed class was stored where the newer classes expect a specific type (e.g. an
    /// old player-option class inside a List&lt;IPlayerOption&gt;), this stand-in does not fit there and
    /// that file still fails; the audit shows it as a read error.
    ///
    /// PartyGoals.cs is an earlier, dedicated stand-in for one such class; it is kept for its notes.
    /// </remarks>
    [Serializable]
    public class RemovedLegacyType : ISerializable
    {
        /// <summary>Default constructor (not used when reading files).</summary>
        public RemovedLegacyType()
        {
        }

        // The formatter-based ISerializable members are marked obsolete in .NET 8 (SYSLIB0051), but
        // reading these old files is exactly what they are still for, so the warning is suppressed.
#pragma warning disable SYSLIB0051

        /// <summary>
        /// Called by BinaryFormatter when reading an old file. The saved values are ignored on purpose.
        /// </summary>
        protected RemovedLegacyType(SerializationInfo info, StreamingContext context)
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
