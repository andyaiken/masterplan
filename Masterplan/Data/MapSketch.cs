using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a hand-drawn annotation on a map.
	/// </summary>
	[Serializable]
	public class MapSketch
	{
		/// <summary>
		/// Gets or sets the colour of the sketch.
		/// </summary>
		public Color Colour
		{
			get { return fColour; }
			set { fColour = value; }
		}
		Color fColour = Color.Black;

		/// <summary>
		/// Gets or sets the width of the sketch pen.
		/// </summary>
		public int Width
		{
			get { return fWidth; }
			set { fWidth = value; }
		}
		int fWidth = 3;

		/// <summary>
		/// Gets the list of points in the sketch line.
		/// </summary>
		public List<MapSketchPoint> Points
		{
			get { return fPoints; }
		}
		List<MapSketchPoint> fPoints = new List<MapSketchPoint>();

		/// <summary>
		/// Creates a copy of the sketch.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MapSketch Copy()
		{
			MapSketch sketch = new MapSketch();

			sketch.Colour = fColour;
			sketch.Width = fWidth;

			foreach (MapSketchPoint msp in fPoints)
				sketch.Points.Add(msp.Copy());

			return sketch;
		}
	}

	/// <summary>
	/// Class representing a point in a map sketch.
	/// </summary>
	[Serializable]
	public class MapSketchPoint
	{
		/// <summary>
		/// Gets or sets the map square containing the point.
		/// </summary>
		public Point Square
		{
			get { return fSquare; }
			set { fSquare = value; }
		}
		Point fSquare = new Point(0, 0);

		/// <summary>
		/// Gets or sets the location of the point in the square.
		/// </summary>
		public PointF Location
		{
			get { return fLocation; }
			set { fLocation = value; }
		}
		PointF fLocation = new PointF(0, 0);

		/// <summary>
		/// Creates a copy of the point.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MapSketchPoint Copy()
		{
			MapSketchPoint msp = new MapSketchPoint();

			msp.Square = new Point(fSquare.X, fSquare.Y);
			msp.Location = new PointF(fLocation.X, fLocation.Y);

			return msp;
		}
	}
}
