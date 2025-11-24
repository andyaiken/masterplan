#nullable disable

using System.Buffers; // Added for ReadOnlySequence<byte> functionality
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using MessagePack;
using MessagePack.Formatters;

namespace Masterplan.Tools
{
    /// <summary>
    /// Custom MessagePack formatter for System.Drawing.Bitmap.
    /// This resolves serialization errors by converting the Bitmap to a PNG byte array 
    /// for saving and reconstructing it on loading.
    /// </summary>
    public class BitmapFormatter : IMessagePackFormatter<Bitmap>
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly BitmapFormatter Instance = new BitmapFormatter();

        private BitmapFormatter() { }

        /// <summary>
        /// Serializes the Bitmap as a PNG byte array.
        /// </summary>
        public void Serialize(ref MessagePackWriter writer, Bitmap value, MessagePackSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNil();
                return;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                // Save the Bitmap to the memory stream as a PNG image
                value.Save(ms, ImageFormat.Png);
                byte[] bytes = ms.ToArray();

                // Write the byte array as MessagePack binary data.
                writer.Write(bytes);
            }
        }

        /// <summary>
        /// Deserializes the PNG byte array back into a Bitmap object.
        /// </summary>
        public Bitmap Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            // ReadBytes() returns ReadOnlySequence<byte>?, which is the source of the error.
            ReadOnlySequence<byte>? sequence = reader.ReadBytes();

            if (!sequence.HasValue || sequence.Value.IsEmpty)
            {
                return null;
            }

            ReadOnlySequence<byte> bytesSequence = sequence.Value;

            // FIX: Manually copy the ReadOnlySequence to a contiguous byte array.
            // This is a robust way to handle the conversion when the compiler 
            // fails to resolve the specific ToArray() extension method.
            byte[] bytes = new byte[bytesSequence.Length];
            bytesSequence.CopyTo(bytes);

            if (bytes.Length == 0)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                // Load the Bitmap from the memory stream
                return new Bitmap(ms);
            }
        }
    }
}