using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MessagePack;
using MessagePack.Formatters;

namespace Masterplan.Tools
{
    /// <summary>
    /// Custom MessagePack formatter for System.Drawing.Color.
    /// This resolves the "can't find matched constructor" error by serializing 
    /// Color as its fundamental ARGB integer value.
    /// </summary>
    public class ColorFormatter : IMessagePackFormatter<Color>
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly ColorFormatter Instance = new ColorFormatter();

        private ColorFormatter() { }

        /// <summary>
        /// Serializes the Color as its ARGB integer.
        /// </summary>
        public void Serialize(ref MessagePackWriter writer, Color value, MessagePackSerializerOptions options)
        {
            // Serialize Color as its 32-bit ARGB integer value (ToArgb()).
            writer.WriteInt32(value.ToArgb());
        }

        /// <summary>
        /// Deserializes the ARGB integer back into a Color object.
        /// </summary>
        public Color Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            // Deserialize the ARGB integer back into a Color object using FromArgb().
            int argb = reader.ReadInt32();
            return Color.FromArgb(argb);
        }
    }
}