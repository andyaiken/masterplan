using System.Drawing;
using System.Drawing.Drawing2D;

namespace Masterplan.Tools
{
	/// <summary>
	/// Class for creating rectangles with rounded corners.
	/// </summary>
	public abstract class RoundedRectangle
	{
		/// <summary>
		/// Enumeration for rounded rectangle corners.
		/// </summary>
		public enum RectangleCorners
		{
			/// <summary>
			/// No corners.
			/// </summary>
			None = 0,

			/// <summary>
			/// Top left corner.
			/// </summary>
			TopLeft = 1,

			/// <summary>
			/// Top right corner.
			/// </summary>
			TopRight = 2,

			/// <summary>
			/// Bottom left corner.
			/// </summary>
			BottomLeft = 4,

			/// <summary>
			/// Bottom right corner.
			/// </summary>
			BottomRight = 8,

			/// <summary>
			/// All four corners.
			/// </summary>
			All = TopLeft | TopRight | BottomLeft | BottomRight
		}

		/// <summary>
		/// Creates a GraphicsPath object for a rounded rectangle.
		/// </summary>
		/// <param name="x">The x co-ordinate of the rectangle.</param>
		/// <param name="y">The y co-ordinate of the rectangle.</param>
		/// <param name="width">The width of the rectangle.</param>
		/// <param name="height">The height of the rectangle.</param>
		/// <param name="radius">The radius of the rounded corners.</param>
		/// <param name="corners">The corners to round.</param>
		/// <returns>Returns the graphics path representing the rounded rectangle.</returns>
		public static GraphicsPath Create(float x, float y, float width, float height, float radius, RectangleCorners corners)
		{
			float xw = x + width;
			float yh = y + height;
			float xwr = xw - radius;
			float yhr = yh - radius;
			float xr = x + radius;
			float yr = y + radius;
			float r2 = radius * 2;
			float xwr2 = xw - r2;
			float yhr2 = yh - r2;

			GraphicsPath path = new GraphicsPath();
			path.StartFigure();

			// Top Left Corner
			if ((RectangleCorners.TopLeft & corners) == RectangleCorners.TopLeft)
			{
				path.AddArc(x, y, r2, r2, 180, 90);
			}
			else
			{
				path.AddLine(x, yr, x, y);
				path.AddLine(x, y, xr, y);
			}

			// Top Edge
			path.AddLine(xr, y, xwr, y);

			// Top Right Corner
			if ((RectangleCorners.TopRight & corners) == RectangleCorners.TopRight)
			{
				path.AddArc(xwr2, y, r2, r2, 270, 90);
			}
			else
			{
				path.AddLine(xwr, y, xw, y);
				path.AddLine(xw, y, xw, yr);
			}

			// Right Edge
			path.AddLine(xw, yr, xw, yhr);

			// Bottom Right Corner
			if ((RectangleCorners.BottomRight & corners) == RectangleCorners.BottomRight)
			{
				path.AddArc(xwr2, yhr2, r2, r2, 0, 90);
			}
			else
			{
				path.AddLine(xw, yhr, xw, yh);
				path.AddLine(xw, yh, xwr, yh);
			}

			// Bottom Edge
			path.AddLine(xwr, yh, xr, yh);

			// Bottom Left Corner
			if ((RectangleCorners.BottomLeft & corners) == RectangleCorners.BottomLeft)
			{
				path.AddArc(x, yhr2, r2, r2, 90, 90);
			}
			else
			{
				path.AddLine(xr, yh, x, yh);
				path.AddLine(x, yh, x, yhr);
			}

			// Left Edge
			path.AddLine(x, yhr, x, yr);

			path.CloseFigure();
			return path;
		}

		/// <summary>
		/// Creates a GraphicsPath object for a rounded rectangle.
		/// </summary>
		/// <param name="rect">The rectangle to use as the basis of the rounded rectangle.</param>
		/// <param name="radius">The radius of the rounded corners.</param>
		/// <param name="corners">The corners to round.</param>
		/// <returns>Returns the graphics path representing the rounded rectangle.</returns>
		public static GraphicsPath Create(RectangleF rect, float radius, RectangleCorners corners)
		{
			return Create(rect.X, rect.Y, rect.Width, rect.Height, radius, corners);
		}

		/// <summary>
		/// Creates a GraphicsPath object for a rounded rectangle.
		/// </summary>
		/// <param name="x">The x co-ordinate of the rectangle.</param>
		/// <param name="y">The x co-ordinate of the rectangle.</param>
		/// <param name="width">The width of the rectangle.</param>
		/// <param name="height">The height of the rectangle.</param>
		/// <param name="radius">The radius of the rounded corners.</param>
		/// <returns>Returns the graphics path representing the rounded rectangle.</returns>
		public static GraphicsPath Create(float x, float y, float width, float height, float radius)
		{
			return Create(x, y, width, height, radius, RectangleCorners.All);
		}

		/// <summary>
		/// Creates a GraphicsPath object for a rounded rectangle.
		/// </summary>
		/// <param name="rect">The rectangle to use as the basis of the rounded rectangle.</param>
		/// <param name="radius">The radius of the rounded corners.</param>
		/// <returns>Returns the graphics path representing the rounded rectangle.</returns>
		public static GraphicsPath Create(RectangleF rect, float radius)
		{
			return Create(rect.X, rect.Y, rect.Width, rect.Height, radius);
		}
	}
}
