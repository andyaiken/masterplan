#nullable disable

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// ============================================================================================
// KEEP IN SYNC: this file exists in two projects with identical code (only the namespace differs):
//   - MasterplanXP.MigrationTool:  Services\Utils\ImageCompression.cs
//   - Masterplan (M14.1):             Tools\ImageCompression.cs
// The two projects are in the same repository but build separately (different .NET versions and
// namespaces), so they cannot share one file. If you change the logic or the size caps in one copy, make the same change in the other, so a file
// converted by the migration tool and a file saved by M14.1 store images the same way.
// ============================================================================================
namespace Masterplan.Tools
{
    /// <summary>
    /// What an image is used for. Each role has its own maximum size (see ImageCompression).
    /// </summary>
    public enum ImageRole
    {
        /// <summary>A creature's picture (library creatures, custom creatures, NPCs).</summary>
        Creature,

        /// <summary>A custom map token or overlay picture.</summary>
        Token,

        /// <summary>A hero's portrait.</summary>
        Portrait,

        /// <summary>A map tile. Its cap is per grid square, so pass the tile's size in squares.</summary>
        Tile,

        /// <summary>A picture attached to an encyclopedia entry.</summary>
        Encyclopedia,

        /// <summary>A whole regional map.</summary>
        RegionalMap
    }

    /// <summary>
    /// How aggressively images are shrunk. Regular is the default in both tools.
    /// </summary>
    public enum ImageSizeLevel
    {
        /// <summary>Smallest files (good for sharing); tokens and tiles look softer when zoomed in.</summary>
        Low,

        /// <summary>The default: sharp in normal use, much smaller than oversized originals.</summary>
        Regular,

        /// <summary>For large player-view screens or detailed artwork; bigger files.</summary>
        High
    }

    /// <summary>
    /// Makes images smaller for saving while keeping transparency.
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// Library and project files were getting very large, mostly because of images that were far
    /// bigger than Masterplan ever shows them (e.g. a 3000-pixel picture used as a token). The old
    /// "JPEG compression" option made files smaller but turned every transparent area black, because
    /// JPEG has no transparency. This class does it safely:
    ///   1. SHRINK: downscale (never upscale) to a maximum size that depends on what the image is for
    ///      (ImageRole) and the chosen level (ImageSizeLevel). See the table in MaxLongestSide.
    ///   2. CHOOSE THE FORMAT: an image that actually uses transparency is always saved as PNG.
    ///      A fully opaque image is saved as JPEG only if that comes out smaller than PNG.
    /// Both formats are read by M13, M14 and the migration tool (GDI+), so files stay compatible.
    ///
    /// ORIGINAL BYTES (used by M14.1): Decode() remembers the exact bytes each image was loaded from.
    /// When an unchanged image is saved again, those bytes are written back as they were
    /// (TryGetOriginal), instead of compressing it again. That avoids JPEG quality loss on every
    /// save, stops JPEGs being re-saved as larger PNGs, and makes saving faster. Only new or replaced
    /// images (new objects) are compressed.
    /// </remarks>
    public static class ImageCompression
    {
        #region Size caps

        /// <summary>
        /// The longest side, in pixels, an image of this role may have at this level.
        /// For tiles this is PER GRID SQUARE (multiplied by the tile's size in squares).
        /// </summary>
        /// <remarks>
        ///   Role                              Low     Regular   High
        ///   Creature / Token / Portrait       256     512       1024
        ///   Tile (per grid square)            64      128       256
        ///   Encyclopedia                      512     1024      2048
        ///   Regional map                      2048    4096      6144
        /// Regional maps stop at 6144 on High: GDI+ keeps a whole image in memory at 4 bytes per
        /// pixel, so an 8192-pixel map can need about 256 MB and risk out-of-memory errors.
        /// </remarks>
        public static int MaxLongestSide(ImageRole role, ImageSizeLevel level)
        {
            int index = (int)level;   // Low = 0, Regular = 1, High = 2
            switch (role)
            {
                case ImageRole.Creature:
                case ImageRole.Token:
                case ImageRole.Portrait:
                    return new[] { 256, 512, 1024 }[index];
                case ImageRole.Tile:
                    return new[] { 64, 128, 256 }[index];
                case ImageRole.Encyclopedia:
                    return new[] { 512, 1024, 2048 }[index];
                case ImageRole.RegionalMap:
                    return new[] { 2048, 4096, 6144 }[index];
                default:
                    return new[] { 512, 1024, 2048 }[index];
            }
        }

        /// <summary>JPEG quality used for fully opaque images at each level.</summary>
        public static long JpegQuality(ImageSizeLevel level)
        {
            return new long[] { 75, 85, 92 }[(int)level];
        }

        #endregion

        #region Encoding (saving)

        /// <summary>
        /// Shrinks the image if it is bigger than its cap, then returns PNG or JPEG bytes, whichever
        /// is smaller, but never JPEG for an image that uses transparency.
        /// </summary>
        /// <param name="img">The image to save. It is not modified.</param>
        /// <param name="role">What the image is used for (decides the size cap).</param>
        /// <param name="level">How aggressively to shrink.</param>
        /// <param name="tile_squares">For tiles only: the tile's size in grid squares.</param>
        /// <returns>The encoded bytes, or null if img is null. Never throws.</returns>
        public static byte[] Encode(Image img, ImageRole role, ImageSizeLevel level, Size tile_squares = default)
        {
            if (img == null)
                return null;

            try
            {
                Size target = TargetSize(img.Size, role, level, tile_squares);
                bool may_have_alpha = MayHaveAlpha(img);

                // Copy into a 32-bit image with transparency at the target size (same size if no
                // shrinking is needed). Working on a copy means the caller's image is never changed.
                using (Bitmap work = CopyToArgb(img, target))
                {
                    byte[] png = Save(work, ImageFormat.Png);

                    // Transparent images must stay PNG: JPEG would turn transparent areas black.
                    if (may_have_alpha && HasTransparentPixel(work))
                        return png;

                    byte[] jpg = SaveJpeg(work, JpegQuality(level));
                    return ((jpg != null) && (png == null || jpg.Length < png.Length)) ? jpg : png;
                }
            }
            catch (Exception ex)
            {
                // Never lose an image because compression failed: fall back to a plain PNG.
                LogSystem.Trace(ex);
                return EncodePng(img);
            }
        }

        /// <summary>
        /// Saves the image as PNG exactly as it is (no shrinking). Used when compression is turned off.
        /// </summary>
        /// <returns>The PNG bytes, or null if img is null or cannot be saved. Never throws.</returns>
        public static byte[] EncodePng(Image img)
        {
            if (img == null)
                return null;

            try
            {
                return Save(img, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                return null;
            }
        }

        /// <summary>The size to shrink to: the original size if it already fits the cap.</summary>
        static Size TargetSize(Size original, ImageRole role, ImageSizeLevel level, Size tile_squares)
        {
            if ((original.Width <= 0) || (original.Height <= 0))
                return original;

            int cap = MaxLongestSide(role, level);
            int max_w = cap, max_h = cap;

            // A tile's cap is per grid square, e.g. a 2x3-square tile at Regular may be 256x384 px.
            if (role == ImageRole.Tile)
            {
                max_w = cap * Math.Max(1, tile_squares.Width);
                max_h = cap * Math.Max(1, tile_squares.Height);
            }

            double scale = Math.Min(1.0, Math.Min((double)max_w / original.Width, (double)max_h / original.Height));
            if (scale >= 1.0)
                return original;   // never enlarge

            return new Size(Math.Max(1, (int)Math.Round(original.Width * scale)),
                            Math.Max(1, (int)Math.Round(original.Height * scale)));
        }

        /// <summary>Draws the image into a new 32-bit (with transparency) bitmap of the given size.</summary>
        static Bitmap CopyToArgb(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // SourceCopy keeps transparent pixels transparent; the rest gives a high-quality resize.
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes attrs = new ImageAttributes())
                {
                    // Prevents a faint border appearing along the edges when resizing.
                    attrs.SetWrapMode(WrapMode.TileFlipXY);
                    g.DrawImage(img, new Rectangle(0, 0, size.Width, size.Height),
                                0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attrs);
                }
            }
            return bmp;
        }

        /// <summary>
        /// True if the image's format can hold transparency at all (an alpha channel, or a palette
        /// with a transparent entry, e.g. a GIF). If false, the pixel scan can be skipped.
        /// </summary>
        static bool MayHaveAlpha(Image img)
        {
            return Image.IsAlphaPixelFormat(img.PixelFormat)
                || ((img.Flags & (int)ImageFlags.HasAlpha) != 0)
                || ((img.PixelFormat & PixelFormat.Indexed) != 0);
        }

        /// <summary>True if any pixel of a 32-bit ARGB bitmap is not fully opaque.</summary>
        static bool HasTransparentPixel(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                // Each pixel is 4 bytes in the order Blue, Green, Red, Alpha; alpha 255 = opaque.
                byte[] row = new byte[bmp.Width * 4];
                for (int y = 0; y < bmp.Height; ++y)
                {
                    Marshal.Copy(IntPtr.Add(data.Scan0, y * data.Stride), row, 0, row.Length);
                    for (int x = 3; x < row.Length; x += 4)
                    {
                        if (row[x] != 255)
                            return true;
                    }
                }
                return false;
            }
            finally
            {
                bmp.UnlockBits(data);
            }
        }

        static byte[] Save(Image img, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, format);
                return ms.ToArray();
            }
        }

        static byte[] SaveJpeg(Image img, long quality)
        {
            ImageCodecInfo encoder = null;
            foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())
            {
                if (codec.FormatID == ImageFormat.Jpeg.Guid)
                    encoder = codec;
            }
            if (encoder == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            using (EncoderParameters parameters = new EncoderParameters(1))
            {
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                img.Save(ms, encoder, parameters);
                return ms.ToArray();
            }
        }

        #endregion

        #region Decoding (loading) and original bytes

        /// <summary>The exact bytes each loaded image came from (see the class remarks).</summary>
        static readonly ConditionalWeakTable<Image, byte[]> fOriginals = new ConditionalWeakTable<Image, byte[]>();

        /// <summary>
        /// Loads an image from saved bytes, and remembers those bytes so an unchanged image is saved
        /// back exactly as it was.
        /// </summary>
        /// <remarks>
        /// The decoded image is copied into a new Bitmap. GDI+ requires the stream an image was
        /// loaded from to stay open for the image's whole life; closing it (as the old code did) can
        /// cause "A generic error occurred in GDI+" later. The copy no longer needs the stream.
        /// </remarks>
        /// <returns>The image, or null if the bytes are empty or not an image. Never throws.</returns>
        public static Image Decode(byte[] data)
        {
            if ((data == null) || (data.Length == 0))
                return null;

            try
            {
                using (MemoryStream ms = new MemoryStream(data))
                using (Image loaded = Image.FromStream(ms))
                {
                    Bitmap copy = new Bitmap(loaded);
                    Remember(copy, data);
                    return copy;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                return null;
            }
        }

        /// <summary>Records the bytes an image was loaded from (or was last saved as).</summary>
        public static void Remember(Image img, byte[] data)
        {
            if ((img != null) && (data != null))
                fOriginals.AddOrUpdate(img, data);
        }

        /// <summary>
        /// Gets the bytes this exact image object was loaded from (or last saved as), if any.
        /// </summary>
        /// <remarks>
        /// This assumes images are not drawn on in place after loading. Masterplan replaces an image
        /// with a new object when the user picks a different picture, so a changed picture is always
        /// a new object (with no remembered bytes) and gets compressed.
        /// </remarks>
        public static bool TryGetOriginal(Image img, out byte[] data)
        {
            data = null;
            return (img != null) && fOriginals.TryGetValue(img, out data);
        }

        #endregion
    }
}
