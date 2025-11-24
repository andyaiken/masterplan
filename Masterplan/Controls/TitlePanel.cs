#nullable disable

using Masterplan.Tools;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using Svg.Skia; // <-- ADDED for SVG processing
using SkiaSharp; // <-- ADDED for low-level drawing
using System.IO; // <-- ADDED for reading embedded resource streams

namespace Masterplan.Controls
{
    partial class TitlePanel : UserControl
    {
        public enum TitlePanelMode
        {
            WelcomeScreen,
            PlayerView
        }

        // NEW FIELD: Store the Svg.Skia object (the vector data)
        private SKSvg fMasterPlanSvg;

        // IMPORTANT: Update this to match the resource path for your embedded SVG file
        private const string MasterPlanResourceName = "Masterplan.Resources.masterplan_scroll.svg";

        public TitlePanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint, true);

            fFormat.Alignment = StringAlignment.Center;
            fFormat.LineAlignment = StringAlignment.Center;
            fFormat.Trimming = StringTrimming.EllipsisWord;

            LoadSvgResource(); // <-- NEW CALL to load SVG
            FadeTimer.Enabled = true;
        }

        // NEW METHOD: Load the SVG vector data once
        private void LoadSvgResource()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(MasterPlanResourceName))
                {
                    if (stream == null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error: Embedded resource '{MasterPlanResourceName}' not found. Make sure 'masterplan.svg' is added as an Embedded Resource.");
                        return;
                    }
                    fMasterPlanSvg = new SKSvg();
                    fMasterPlanSvg.Load(stream);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading SVG: {ex.Message}");
            }
        }

        [Category("Appearance")]
        public string Title
        {
            get { return fTitle; }
            set { fTitle = value; }
        }
        string fTitle = "";

        [Category("Layout")]
        public TitlePanelMode Mode
        {
            get { return fMode; }
            set
            {
                fMode = value;
                Invalidate();
            }
        }
        TitlePanelMode fMode = TitlePanelMode.WelcomeScreen;

        [Category("Behavior")]
        public bool Zooming
        {
            get { return fZooming; }
            set { fZooming = value; }
        }
        bool fZooming = false;

        string fVersion = get_version_string();

        Rectangle fTitleRect = Rectangle.Empty;
        Rectangle fVersionRect = Rectangle.Empty;

        StringFormat fFormat = new StringFormat();

        int fAlpha = 0;
        const int MAX_ALPHA = 255;
        const int MAX_COLOR = 60;

        public event EventHandler FadeFinished;

        protected void OnFadeFinished()
        {
            if (FadeFinished != null)
                FadeFinished(this, new EventArgs());
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            reset_view();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            reset_view();
        }

        void reset_view()
        {
            fTitleRect = Rectangle.Empty;
            fVersionRect = Rectangle.Empty;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                if (fTitleRect == Rectangle.Empty)
                {
                    Rectangle rect = ClientRectangle;
                    SizeF version_size = e.Graphics.MeasureString(fVersion, Font);
                    double version_height = version_size.Height + (Height / 10);

                    fTitleRect = new Rectangle(rect.Left, rect.Top, rect.Width - 1, (int)(rect.Height - version_height - 1));
                    fVersionRect = new Rectangle(rect.Left, fTitleRect.Bottom, rect.Width - 1, (int)version_height);
                }

                if (fMode == TitlePanelMode.WelcomeScreen && fMasterPlanSvg?.Picture != null)
                {
                    // --- SVG DRAWING LOGIC (Using manual SKCanvas rendering to bypass ToBitmap overloads) ---

                    SKRect svgBounds = fMasterPlanSvg.Picture.CullRect;

                    // 1. Determine target dimensions for the image based on client area (same logic as original PNG)
                    int y_start = ClientRectangle.Y + (int)(ClientRectangle.Height * 0.1);
                    int max_height = (int)(ClientRectangle.Height * 0.8);

                    float aspect_ratio = svgBounds.Width / svgBounds.Height;
                    int img_height = max_height;
                    int img_width = (int)(img_height * aspect_ratio);

                    // Adjust if image is too wide for the panel
                    if (img_width > ClientRectangle.Width)
                    {
                        img_width = ClientRectangle.Width;
                        img_height = (int)(img_width / aspect_ratio);
                    }
                    int x_start = ClientRectangle.X + ((ClientRectangle.Width - img_width) / 2);

                    Rectangle img_rect = new Rectangle(x_start, y_start, img_width, img_height);

                    // 2. Define the target rendering surface information
                    var info = new SKImageInfo(img_width, img_height, SKColorType.Rgba8888, SKAlphaType.Premul);

                    // 3. Create the SKBitmap and SKCanvas manually
                    using (SKBitmap skBitmap = new SKBitmap(info))
                    using (SKCanvas skCanvas = new SKCanvas(skBitmap))
                    {
                        // Set the drawing environment
                        skCanvas.Clear(SKColors.Transparent);

                        // Calculate scale to fit the determined pixel size
                        float scaleX = (float)img_width / svgBounds.Width;
                        float scaleY = (float)img_height / svgBounds.Height;
                        float scale = Math.Min(scaleX, scaleY);

                        // Apply transformation and transparency based on fAlpha
                        SKMatrix matrix = SKMatrix.CreateScale(scale, scale);

                        using (SKPaint paint = new SKPaint())
                        {
                            // Set the calculated alpha (transparency)
                            // Original formula: (0.25F * fAlpha) / MAX_ALPHA
                            // We scale this to a byte value (0-255) for SKPaint
                            byte alpha_byte = (byte)((0.25F * fAlpha / MAX_ALPHA) * 255);
                            paint.Color = paint.Color.WithAlpha(alpha_byte);

                            // 4. Draw the vector picture onto the canvas
                            skCanvas.DrawPicture(fMasterPlanSvg.Picture, in matrix, paint);
                        }

                        // 5. Convert the SKBitmap to a System.Drawing.Bitmap for GDI+ drawing
                        using (SKImage image = SKImage.FromBitmap(skBitmap))
                        using (SKData data = image.Encode(SkiaSharp.SKEncodedImageFormat.Png, 100))
                        using (MemoryStream ms = new MemoryStream(data.ToArray()))
                        {
                            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
                            e.Graphics.DrawImage(bitmap, img_rect);
                            // Use bitmap with GDI+

                        }
                        
                    }
                }
                // --- END SVG DRAWING LOGIC ---

                using (Brush title_brush = new SolidBrush(Color.FromArgb(fAlpha, ForeColor)))
                {
                    float text_height = fTitleRect.Height / 2F;
                    float text_width = fTitleRect.Width / fTitle.Length;
                    float text_size = Math.Min(text_height, text_width);

                    if (fZooming)
                    {
                        float delta = 0.1F * fAlpha / MAX_ALPHA;
                        text_size *= (0.9F + delta);
                    }

                    if (text_height > 0)
                    {
                        using (Font title_font = new Font(Font.FontFamily, text_size))
                        {
                            e.Graphics.DrawString(fTitle, title_font, title_brush, fTitleRect, fFormat);
                        }
                    }

                    if (fMode == TitlePanelMode.WelcomeScreen)
                        e.Graphics.DrawString(fVersion, Font, title_brush, fVersionRect, fFormat);
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            fAlpha = Math.Min(fAlpha + 4, MAX_ALPHA);

            Invalidate();

            if (fAlpha == MAX_ALPHA)
            {
                FadeTimer.Enabled = false;
                OnFadeFinished();

                if (fMode == TitlePanelMode.PlayerView)
                {
                    PulseTimer.Enabled = true;
                }
            }
        }

        private void PulseTimer_Tick(object sender, EventArgs e)
        {
            fAlpha = Math.Max(fAlpha - 1, 0);

            if (Session.Random.Next() % 10 == 0)
                BackColor = change_colour(BackColor);

            Invalidate();
        }

        public void Wake()
        {
            if (PulseTimer.Enabled)
            {
                PulseTimer.Enabled = false;
                FadeTimer.Enabled = true;
            }
        }

        static string get_version_string()
        {
            string str = "Adventure Design Studio";

            Assembly ass = Assembly.GetEntryAssembly();
            if (ass != null)
            {
                Version version = ass.GetName().Version;
                if (version != null)
                {
                    if (str != "")
                        str += Environment.NewLine;

                    str += "Version " + version.Major;

                    if (version.Build != 0)
                    {
                        str += "." + version.Minor + "." + version.Build;
                    }
                    else if (version.Minor != 0)
                    {
                        str += "." + version.Minor;
                    }
                }
            }

            if (Program.IsBeta)
            {
                if (str != "")
                    str += Environment.NewLine + Environment.NewLine;

                str += "BETA";
            }

            return str;
        }

        Color change_colour(Color colour)
        {
            int r = colour.R;
            int g = colour.G;
            int b = colour.B;

            switch (Session.Random.Next() % 4)
            {
                case 0:
                    r = Math.Min(MAX_COLOR, r + 1);
                    break;
                case 1:
                    g = Math.Min(MAX_COLOR, g + 1);
                    break;
                case 2:
                    b = Math.Min(MAX_COLOR, b + 1);
                    break;
                case 3:
                    r = Math.Max(0, r - 1);
                    break;
                case 4:
                    g = Math.Max(0, g - 1);
                    break;
                case 5:
                    b = Math.Max(0, b - 1);
                    break;
            }

            return Color.FromArgb(r, g, b);
        }
    }
}