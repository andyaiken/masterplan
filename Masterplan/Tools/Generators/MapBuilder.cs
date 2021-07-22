using System;
using System.Collections.Generic;
using System.Drawing;

using Masterplan.Data;

namespace Masterplan.Tools.Generators
{
	enum MapAutoBuildType { Warren, FilledArea, Freeform }
	enum Orientation { Any, NorthSouth, EastWest }
	enum Direction { North, East, South, West }

	class MapBuilderData
	{
		public MapAutoBuildType Type = MapAutoBuildType.Warren;
		public bool DelveOnly = false;

		public List<Library> Libraries = new List<Library>();

		public int MaxAreaCount = 10;
		public int MinAreaCount = 4;

		public int Width = 20;
		public int Height = 15;
	}

	class Endpoint
	{
		public TileCategory Category = TileCategory.Plain;
		public Direction Direction = Direction.North;
		public Point TopLeft = Point.Empty;
		public Point BottomRight = Point.Empty;

		public int Size
		{
			get
			{
				int dx = BottomRight.X - TopLeft.X;
				int dy = BottomRight.Y - TopLeft.Y;
				return Math.Max(dx, dy);
			}
		}

		public Orientation Orientation
		{
			get
			{
				if (TopLeft.X == BottomRight.X)
					return Orientation.NorthSouth;

				return Orientation.EastWest;
			}
		}
	}

	class MapBuilder
	{
		static MapBuilderData fData = null;
		static Map fMap = null;

		public static void BuildMap(MapBuilderData data, Map map, EventHandler callback)
		{
			fData = data;
			fMap = map;

			fMap.Tiles.Clear();
			fMap.Areas.Clear();

			switch (fData.Type)
			{
				case MapAutoBuildType.Warren:
					{
						fEndpoints.Clear();
						build_tile_lists();

						build_warren(callback);
					}
					break;
				case MapAutoBuildType.FilledArea:
					{
						build_filled_area(callback);
					}
					break;
				case MapAutoBuildType.Freeform:
					{
						build_freeform_area(callback);
					}
					break;
			}
		}

		#region Warren

		static Dictionary<TileCategory, List<Tile>> fTiles = new Dictionary<TileCategory, List<Tile>>();
		static List<Tile> fRoomTiles = new List<Tile>();
		static List<Tile> fCorridorTiles = new List<Tile>();
		static List<Endpoint> fEndpoints = new List<Endpoint>();

		static void build_tile_lists()
		{
			fTiles.Clear();

			foreach (TileCategory cat in Enum.GetValues(typeof(TileCategory)))
				fTiles[cat] = new List<Tile>();

			foreach (Library lib in fData.Libraries)
			{
				foreach (Tile t in lib.Tiles)
					fTiles[t.Category].Add(t);
			}

			fRoomTiles.Clear();
			fCorridorTiles.Clear();
			foreach (Tile t in fTiles[TileCategory.Plain])
			{
				int size = Math.Min(t.Size.Width, t.Size.Height);

				if (size == 2)
					fCorridorTiles.Add(t);

				if (size > 2)
					fRoomTiles.Add(t);
			}
		}

		static void build_warren(EventHandler callback)
		{
			begin_map();

			int failures = 0;
			while (fMap.Areas.Count < fData.MaxAreaCount)
			{
				if (fEndpoints.Count == 0)
					break;

				if (failures == 100)
					break;

				// Take a random corridor endpoint from the list
				int index = Session.Random.Next() % fEndpoints.Count;
				Endpoint ep = fEndpoints[index];

				// Add an area, corridor or stairway
				bool ok = true;
				switch (Session.Random.Next() % 10)
				{
					case 0:
					case 1:
					case 2:
						try
						{
							// Add an area
							ok = add_area(ep);
						}
						catch (Exception ex)
						{
							LogSystem.Trace(ex);
							ok = false;
						}
						break;
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
						try
						{
							// Add a corridor
							ok = add_corridor(ep, false);
						}
						catch (Exception ex)
						{
							LogSystem.Trace(ex);
							ok = false;
						}
						break;
					case 8:
						try
						{
							// Add a doorway
							if (ep.Category != TileCategory.Doorway)
								ok = add_doorway(ep);
						}
						catch (Exception ex)
						{
							LogSystem.Trace(ex);
							ok = false;
						}
						break;
					case 9:
						try
						{
							// Add a stairway
							ok = add_stairway(ep);
						}
						catch (Exception ex)
						{
							LogSystem.Trace(ex);
							ok = false;
						}
						break;
				}

				if (ok)
				{
					fEndpoints.Remove(ep);
					failures = 0;

					callback(null, null);
				}
				else
				{
					failures += 1;
				}
			}

			// Clean the map
			List<TileData> obsolete = new List<TileData>();
			foreach (TileData td in fMap.Tiles)
			{
				// Remove any tiles that somehow don't exist
				Tile tile = Session.FindTile(td.TileID, SearchType.Global);
				if (tile == null)
				{
					obsolete.Add(td);
					continue;
				}

				// Remove doors which don't go anywhere
				if (tile.Category == TileCategory.Doorway)
				{
					Rectangle tile_rect = get_rect(tile, td);

					int clear_sides = 0;
					
					// North
					for (int x = tile_rect.Left; x != tile_rect.Right; ++x)
					{
						int y = tile_rect.Top - 1;
						Point pt = new Point(x, y);

						if (tile_at_point(pt) == null)
						{
							clear_sides += 1;
							break;
						}
					}

					// South
					for (int x = tile_rect.Left; x != tile_rect.Right; ++x)
					{
						int y = tile_rect.Bottom + 1;
						Point pt = new Point(x, y);

						if (tile_at_point(pt) == null)
						{
							clear_sides += 1;
							break;
						}
					}

					// West
					for (int y = tile_rect.Top; y != tile_rect.Bottom; ++y)
					{
						int x = tile_rect.Left - 1;
						Point pt = new Point(x, y);

						if (tile_at_point(pt) == null)
						{
							clear_sides += 1;
							break;
						}
					}

					// East
					for (int y = tile_rect.Top; y != tile_rect.Bottom; ++y)
					{
						int x = tile_rect.Right + 1;
						Point pt = new Point(x, y);

						if (tile_at_point(pt) == null)
						{
							clear_sides += 1;
							break;
						}
					}

					if (clear_sides != 2)
						obsolete.Add(td);
				}
			}
			foreach (TileData td in obsolete)
			{
				fMap.Tiles.Remove(td);
				callback(null, null);
			}
		}

		static void begin_map()
		{
			List<TileCategory> options = new List<TileCategory>();
			if (fCorridorTiles.Count != 0)
				options.Add(TileCategory.Plain);
			if (fTiles[TileCategory.Stairway].Count != 0)
				options.Add(TileCategory.Stairway);

			if (options.Count == 0)
				return;

			int n = Session.Random.Next() % options.Count;
			TileCategory option = options[n];
			switch (option)
			{
				case TileCategory.Plain:
					// Start with a corridor
					add_corridor(null, false);
					break;
				case TileCategory.Stairway:
					// Start with a stairway
					add_stairway(null);
					break;
			}
		}

		static bool add_area(Endpoint ep)
		{
			if (fRoomTiles.Count == 0)
				return false;

			// Start with an open area with 1-5 room tiles
			List<Tile> tiles = new List<Tile>();
			int tile_count = 1 + Session.Random.Next() % 5;
			while (tiles.Count != tile_count)
			{
				int index = Session.Random.Next() % fRoomTiles.Count;
				Tile t = fRoomTiles[index];
				tiles.Add(t);
			}

			// Add the tiles to the map
			List<Endpoint> endpoints = new List<Endpoint>();
			endpoints.Add(ep);
			List<Pair<Tile, TileData>> tile_set = new List<Pair<Tile, TileData>>();
			foreach (Tile t in tiles)
			{
				if (endpoints.Count == 0)
					break;

				// Pick an endpoint
				int index = Session.Random.Next() % endpoints.Count;
				Endpoint current = endpoints[index];

				Pair<TileData, Direction> pair = add_tile(t, current, false, false);
				if (pair != null)
				{
					endpoints.Remove(current);
					tile_set.Add(new Pair<Tile, TileData>(t, pair.First));

					if (pair.Second != Direction.South)
					{
						// Add northern endpoint
						endpoints.Add(get_endpoint(t, pair.First, Direction.North));
					}

					if (pair.Second != Direction.West)
					{
						// Add eastern endpoint
						endpoints.Add(get_endpoint(t, pair.First, Direction.East));
					}

					if (pair.Second != Direction.North)
					{
						// Add southern endpoint
						endpoints.Add(get_endpoint(t, pair.First, Direction.South));
					}

					if (pair.Second != Direction.East)
					{
						// Add western endpoint
						endpoints.Add(get_endpoint(t, pair.First, Direction.West));
					}
				}
			}

			if (tile_set.Count != 0)
			{
				// Add the area to the map
				add_map_area(tile_set);

				List<Tile> feature_tiles = fTiles[TileCategory.Feature];
				if (feature_tiles.Count != 0)
				{
					int total_area = 0;
					foreach (Pair<Tile, TileData> pair in tile_set)
						total_area += pair.First.Area;

					int feature_count = Session.Random.Next() % (total_area / 10);
					int features = 0;
					int feature_failures = 0;
					List<Pair<Tile, TileData>> feature_set = new List<Pair<Tile, TileData>>();
					while (features != feature_count)
					{
						if (feature_failures == 1000)
							break;

						// Pick a tile
						int index = Session.Random.Next() % feature_tiles.Count;
						Tile t = feature_tiles[index];

						TileData td = new TileData();
						td.TileID = t.ID;
						td.Rotations = Session.Random.Next() % 4;

						int feature_width = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
						int feature_height = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;

						// Look for tiles it fits on
						List<Pair<Tile, TileData>> candidates = new List<Pair<Tile, TileData>>();
						foreach (Pair<Tile, TileData> pair in tile_set)
						{
							int target_width = (pair.Second.Rotations % 2 == 0) ? pair.First.Size.Width : pair.First.Size.Height;
							int target_height = (pair.Second.Rotations % 2 == 0) ? pair.First.Size.Height : pair.First.Size.Width;

							int dx = target_width - feature_width;
							int dy = target_height - feature_height;

							if ((dx >= 0) && (dy >= 0))
								candidates.Add(pair);
						}

						bool added = false;
						if (candidates.Count != 0)
						{
							int target_index = Session.Random.Next() % candidates.Count;
							Pair<Tile, TileData> target = candidates[target_index];

							int target_width = (target.Second.Rotations % 2 == 0) ? target.First.Size.Width : target.First.Size.Height;
							int target_height = (target.Second.Rotations % 2 == 0) ? target.First.Size.Height : target.First.Size.Width;

							int dx = target_width - feature_width;
							int dy = target_height - feature_height;
							if ((dx >= 0) && (dy >= 0))
							{
								int x = target.Second.Location.X;
								if (dx != 0)
									x += Session.Random.Next() % dx;

								int y = target.Second.Location.Y;
								if (dy != 0)
									y += Session.Random.Next() % dy;

								td.Location = new Point(x, y);

								// Check other features don't obstruct
								bool ok = true;
								Rectangle new_feature = get_rect(t, td);
								foreach (Pair<Tile, TileData> feature in feature_set)
								{
									Rectangle existing = get_rect(feature.First, feature.Second);
									if (existing.IntersectsWith(new_feature))
									{
										ok = false;
										break;
									}
								}

								if (ok)
								{
									fMap.Tiles.Add(td);
									feature_set.Add(new Pair<Tile, TileData>(t, td));

									added = true;
									break;
								}
							}
						}

						if (added)
						{
							features += 1;
							feature_failures = 0;
						}
						else
						{
							feature_failures += 1;
						}
					}
				}

				// Create some exits off this room
				int exit_count = 1 + Session.Random.Next() % 3;
				int exits = 0;
				int exit_failures = 0;
				while (exits != exit_count)
				{
					if (endpoints.Count == 0)
						break;

					if (exit_failures == 1000)
						break;

					int index = Session.Random.Next() % endpoints.Count;
					Endpoint point = endpoints[index];

					bool ok = true;
					switch (Session.Random.Next() % 2)
					{
						case 0:
							ok = add_doorway(point);
							break;
						case 1:
							ok = add_corridor(point, true);
							break;
					}

					if (ok)
					{
						exits += 1;
						endpoints.Remove(point);
						exit_failures = 0;
					}
					else
					{
						exit_failures += 1;
					}
				}
			}

			return (tile_set.Count != 0);
		}

		static void add_map_area(List<Pair<Tile, TileData>> tiles)
		{
			int min_x = int.MaxValue;
			int min_y = int.MaxValue;
			int max_x = int.MinValue;
			int max_y = int.MinValue;

			foreach (Pair<Tile, TileData> pair in tiles)
			{
				Rectangle rect = get_rect(pair.First, pair.Second);

				if (rect.Left < min_x)
					min_x = rect.Left;

				if (rect.Right > max_x)
					max_x = rect.Right;

				if (rect.Top < min_y)
					min_y = rect.Top;

				if (rect.Bottom > max_y)
					max_y = rect.Bottom;
			}

			min_x -= 1;
			min_y -= 1;
			max_x += 1;
			max_y += 1;

			MapArea area = new MapArea();
			area.Name = "Area " + (fMap.Areas.Count + 1);
			area.Region = new Rectangle(min_x, min_y, max_x - min_x, max_y - min_y);
			fMap.Areas.Add(area);
		}

		static bool add_corridor(Endpoint ep, bool follow)
		{
			if (fCorridorTiles.Count == 0)
				return false;

			int index = Session.Random.Next() % fCorridorTiles.Count;
			Tile t = fCorridorTiles[index];

			if (ep == null)
			{
				TileData td = add_first_tile(t);

				Orientation orient = get_orientation(t, td);
				Direction dir = get_starting_direction(orient);
				fEndpoints.Add(get_endpoint(t, td, dir));
			}
			else
			{
				// Add the tile anywhere on the endpoint
				Pair<TileData, Direction> pair = add_tile(t, ep, follow, true);
				if (pair == null)
					return false;

				// Add the endpoint
				fEndpoints.Add(get_endpoint(t, pair.First, pair.Second));
			}

			return true;
		}

		static bool add_doorway(Endpoint ep)
		{
			List<Tile> doors = fTiles[TileCategory.Doorway];
			if (doors.Count == 0)
				return false;

			int index = Session.Random.Next() % doors.Count;
			Tile t = doors[index];

			if (ep == null)
			{
				/*
				TileData td = add_first_tile(t);

				Orientation orient = get_orientation(t, td);
				if (orient == Orientation.NorthSouth)
					orient = Orientation.EastWest;
				else
					orient = Orientation.NorthSouth;

				Direction dir = get_starting_direction(orient);
				fEndpoints.Add(get_endpoint(t, td, dir));
				*/
			}
			else
			{
				// Add the tile anywhere on the endpoint
				Pair<TileData, Direction> pair = add_tile(t, ep, true, true);
				if (pair == null)
					return false;

				// Add the endpoint
				fEndpoints.Add(get_endpoint(t, pair.First, pair.Second));
			}

			return true;
		}

		static bool add_stairway(Endpoint ep)
		{
			List<Tile> stairs = fTiles[TileCategory.Stairway];
			if (stairs.Count == 0)
				return false;

			int index = Session.Random.Next() % stairs.Count;
			Tile t = stairs[index];

			if (ep == null)
			{
				TileData td = add_first_tile(t);

				Orientation orient = get_orientation(t, td);
				Direction dir = get_starting_direction(orient);
				fEndpoints.Add(get_endpoint(t, td, dir));
			}
			else
			{
				// Add the tile following the endpoint
				Pair<TileData, Direction> pair = add_tile(t, ep, true, true);
				if (pair == null)
					return false;
			}

			return true;
		}

		static TileData add_first_tile(Tile t)
		{
			TileData td = new TileData();
			td.TileID = t.ID;

			td.Location = new Point(0, 0);
			td.Rotations = Session.Random.Next() % 4;

			fMap.Tiles.Add(td);
			return td;
		}

		static Pair<TileData, Direction> add_tile(Tile t, Endpoint ep, bool follow_direction, bool not_alongside)
		{
			TileData td = new TileData();
			td.TileID = t.ID;

			Direction dir = ep.Direction;
			if (!follow_direction)
			{
				List<Direction> dirs = new List<Direction>();
				if (ep.Direction != Direction.North)
					dirs.Add(Direction.South);
				if (ep.Direction != Direction.East)
					dirs.Add(Direction.West);
				if (ep.Direction != Direction.South)
					dirs.Add(Direction.North);
				if (ep.Direction != Direction.West)
					dirs.Add(Direction.East);

				int index = Session.Random.Next() % dirs.Count;
				dir = dirs[index];
			}

			if (follow_direction)
			{
				// Since we're following the previous direction, make sure it's oriented properly

				int min = Math.Min(t.Size.Width, t.Size.Height);

				if ((dir == Direction.North) || (dir == Direction.South))
				{
					if (min > 1)
					{
						if (t.Size.Width > t.Size.Height)
							td.Rotations = 1;
					}
					else
					{
						if (t.Size.Width < t.Size.Height)
							td.Rotations = 1;
					}
				}

				if ((dir == Direction.East) || (dir == Direction.West))
				{
					if (min > 1)
					{
						if (t.Size.Height > t.Size.Width)
							td.Rotations = 1;
					}
					else
					{
						if (t.Size.Height < t.Size.Width)
							td.Rotations = 1;
					}
				}
			}
			else
			{
				// We can rotate as many times as we like
				td.Rotations = Session.Random.Next() % 4;
			}

			int width = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
			int height = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;

			switch (ep.Direction)
			{
				case Direction.North:
					{
						td.Location = new Point(ep.TopLeft.X, ep.TopLeft.Y - (height - 1));
					}
					break;
				case Direction.East:
					{
						td.Location = ep.TopLeft;
					}
					break;
				case Direction.South:
					{
						td.Location = ep.TopLeft;
					}
					break;
				case Direction.West:
					{
						td.Location = new Point(ep.TopLeft.X - (width - 1), ep.TopLeft.Y);
					}
					break;
			}

			Rectangle rect = get_rect(t, td);
			if (not_alongside)
			{
				switch (dir)
				{
					case Direction.North:
					case Direction.South:
						// Increase width
						rect = new Rectangle(rect.X - 1, rect.Y, rect.Width + 2, rect.Height);
						break;
					case Direction.East:
					case Direction.West:
						// Increase height
						rect = new Rectangle(rect.X, rect.Y - 1, rect.Width, rect.Height + 2);
						break;
				}
			}
			if (!check_rect_is_empty(rect))
				return null;

			fMap.Tiles.Add(td);
			return new Pair<TileData, Direction>(td, dir);
		}

		static Direction get_starting_direction(Orientation orient)
		{
			switch (orient)
			{
				case Orientation.NorthSouth:
					return Direction.South;
				case Orientation.EastWest:
					return Direction.East;
			}

			return (Session.Random.Next() % 2 == 0) ? Direction.East : Direction.South;
		}

		static Endpoint get_endpoint(Tile t, TileData td, Direction dir)
		{
			Endpoint ep = new Endpoint();
			ep.Category = t.Category;
			ep.Direction = dir;

			int width = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
			int height = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;

			switch (dir)
			{
				case Direction.North:
					ep.TopLeft = new Point(td.Location.X, td.Location.Y - 1);
					ep.BottomRight = new Point(td.Location.X + width - 1, td.Location.Y - 1);
					break;
				case Direction.East:
					ep.TopLeft = new Point(td.Location.X + width, td.Location.Y);
					ep.BottomRight = new Point(td.Location.X + width, td.Location.Y + height - 1);
					break;
				case Direction.South:
					ep.TopLeft = new Point(td.Location.X, td.Location.Y + height);
					ep.BottomRight = new Point(td.Location.X + width - 1, td.Location.Y + height);
					break;
				case Direction.West:
					ep.TopLeft = new Point(td.Location.X - 1, td.Location.Y);
					ep.BottomRight = new Point(td.Location.X - 1, td.Location.Y + height - 1);
					break;
			}

			return ep;
		}

		static Orientation get_orientation(Tile t, TileData td)
		{
			bool wide = (t.Size.Width >= t.Size.Height);
			if (td.Rotations % 2 == 0)
				return wide ? Orientation.EastWest : Orientation.NorthSouth;
			else
				return wide ? Orientation.NorthSouth : Orientation.EastWest;
		}

		#endregion

		#region Filled Area

		static void build_filled_area(EventHandler callback)
		{
			List<Tile> tiles = new List<Tile>();
			List<Tile> one_tiles = new List<Tile>();
			foreach (Library lib in fData.Libraries)
			{
				foreach (Tile t in lib.Tiles)
				{
					if ((t.Category == TileCategory.Plain) || (t.Category == TileCategory.Feature))
					{
						tiles.Add(t);

						if (t.Area == 1)
							one_tiles.Add(t);
					}
				}
			}
			if ((tiles.Count == 0) || (one_tiles.Count == 0))
				return;

			MapArea ma = new MapArea();
			ma.Name = "Area";
			ma.Region = new Rectangle(0, 0, fData.Width, fData.Height);
			fMap.Areas.Add(ma);

			int filled_area = 0;
			int fails = 0;
			while (true)
			{
				bool one_by_one = (Session.Random.Next(20) == 0);

				// Pick a tile at random
				List<Tile> tile_list = (one_by_one ? one_tiles : tiles);
				int tile_index = Session.Random.Next(tile_list.Count);
				Tile tile = tile_list[tile_index];

				// Rotate it randomly
				TileData td = new TileData();
				td.TileID = tile.ID;
				td.Rotations = Session.Random.Next(4);

				// Find its dimensions
				int width = tile.Size.Width;
				int height = tile.Size.Height;
				if ((td.Rotations == 1) || (td.Rotations == 3))
				{
					width = tile.Size.Height;
					height = tile.Size.Width;
				}

				// Find points where we can place this tile
				List<Point> points = new List<Point>();
				if (one_by_one)
				{
					// Find squares where a 1x1 tile is needed

					for (int x = 0; x <= fData.Width; ++x)
					{
						for (int y = 0; y <= fData.Height; ++y)
						{
							Point pt = new Point(x, y);
							if (tile_at_point(pt) != null)
								continue;

							int borders = 0;
							if (tile_at_point(new Point(x + 1, y)) != null)
								borders += 1;
							if (tile_at_point(new Point(x - 1, y)) != null)
								borders += 1;
							if (tile_at_point(new Point(x, y + 1)) != null)
								borders += 1;
							if (tile_at_point(new Point(x, y - 1)) != null)
								borders += 1;

							if (borders >= 3)
								points.Add(pt);
						}
					}
				}
				else
				{
					int increment = (tile.Area < 4) ? 1 : 2;
					for (int x = 0; x <= fData.Width; x += increment)
					{
						for (int y = 0; y <= fData.Height; y += increment)
						{
							Rectangle rect = new Rectangle(x, y, width, height);

							if ((rect.Right > fData.Width) || (rect.Bottom > fData.Height))
								continue;

							if (check_rect_is_empty(rect))
							{
								Point pt = new Point(x, y);
								points.Add(pt);
							}
						}
					}
				}

				if (points.Count != 0)
				{
					// Pick a point at random
					int point_index = Session.Random.Next(points.Count);
					Point pt = points[point_index];

					// Place the tile
					td.Location = pt;
					fMap.Tiles.Add(td);

					filled_area += tile.Area;
				}
				else
				{
					fails += 1;
					if (fails >= 100)
					{
						fails = 0;

						if (fMap.Tiles.Count != 0)
						{
							// Remove a tile at random
							int remove_index = Session.Random.Next(fMap.Tiles.Count);
							TileData remove_td = fMap.Tiles[remove_index];
							fMap.Tiles.Remove(remove_td);

							Tile remove_tile = Session.FindTile(remove_td.TileID, SearchType.Global);
							filled_area -= remove_tile.Area;
						}
					}
				}

				callback(null, null);

				int full_area = fData.Width * fData.Height;
				if (filled_area == full_area)
				{
					fMap.Areas.Clear();
					break;
				}
			}
		}

		#endregion

		#region Freeform Area

		static void build_freeform_area(EventHandler callback)
		{
			List<Tile> tiles = new List<Tile>();
			foreach (Library lib in fData.Libraries)
			{
				foreach (Tile t in lib.Tiles)
				{
					if ((t.Category == TileCategory.Plain) || (t.Category == TileCategory.Feature))
						tiles.Add(t);
				}
			}
			if (tiles.Count == 0)
				return;

			int area = fData.Height * fData.Width;
			while (area > 0)
			{
				callback(null, null);

				// TODO: Find an enclosed space
				bool enclosed = false;
				if (enclosed)
				{
					// Pick a tile that might fit
					Tile tile = null;

					if (tile == null)
						continue;

					// Place this tile
					Point location = new Point(0, 0);

					TileData tiledata = new TileData();
					tiledata.TileID = tile.ID;
					tiledata.Location = location;
					fMap.Tiles.Add(tiledata);

					// Update the available area
					area -= tile.Area;
				}
				else
				{
					// Otherwise, pick a tile and add it contiguously
					int index = Session.Random.Next() % tiles.Count;
					Tile tile = tiles[index];

					Point location = new Point(0, 0);
					if (fMap.Tiles.Count != 0)
					{
						// Pick a current tile
						int td_index = Session.Random.Next() % fMap.Tiles.Count;
						TileData td = fMap.Tiles[td_index];
						Tile t = Session.FindTile(td.TileID, SearchType.Global);

						// Find rectangles next to this tile
						List<Rectangle> rects = new List<Rectangle>();
						int x_min = td.Location.X - (tile.Size.Width - 1);
						int x_max = td.Location.X + (t.Size.Width - 1);
						int y_min = td.Location.Y - (tile.Size.Height - 1);
						int y_max = td.Location.Y + (t.Size.Height - 1);
						for (int x = x_min; x <= x_max; ++x)
						{
							// North
							int y = td.Location.Y - tile.Size.Height;
							Rectangle rect = new Rectangle(x, y, tile.Size.Width, tile.Size.Height);
							rects.Add(rect);
						}
						for (int x = x_min; x <= x_max; ++x)
						{
							// South
							int y = td.Location.Y + t.Size.Height;
							Rectangle rect = new Rectangle(x, y, tile.Size.Width, tile.Size.Height);
							rects.Add(rect);
						}
						for (int y = y_min; y <= y_max; ++y)
						{
							// West
							int x = td.Location.X - t.Size.Width;
							Rectangle rect = new Rectangle(x, y, tile.Size.Width, tile.Size.Height);
							rects.Add(rect);
						}
						for (int y = y_min; y <= y_max; ++y)
						{
							// East
							int x = td.Location.X + t.Size.Width;
							Rectangle rect = new Rectangle(x, y, tile.Size.Width, tile.Size.Height);
							rects.Add(rect);
						}
						List<Rectangle> candidates = new List<Rectangle>();
						foreach (Rectangle rect in rects)
						{
							if (check_rect_is_empty(rect))
								candidates.Add(rect);
						}

						if (candidates.Count == 0)
							continue;

						int rect_index = Session.Random.Next() % candidates.Count;
						Rectangle r = candidates[rect_index];
						location = r.Location;
					}

					TileData tiledata = new TileData();
					tiledata.TileID = tile.ID;
					tiledata.Location = location;
					fMap.Tiles.Add(tiledata);

					// Update the available area
					area -= tile.Area;
				}
			}

			int left = 0;
			int right = 0;
			int top = 0;
			int bottom = 0;
			foreach (TileData td in fMap.Tiles)
			{
				Tile tile = Session.FindTile(td.TileID, SearchType.Global);
				Rectangle rect = new Rectangle(td.Location, tile.Size);

				left = Math.Min(left, rect.Left);
				right = Math.Max(right, rect.Right);
				top = Math.Min(top, rect.Top);
				bottom = Math.Max(bottom, rect.Bottom);
			}

			MapArea ma = new MapArea();
			ma.Name = "Area";
			ma.Region = new Rectangle(left, top, right - left, bottom - top);
			fMap.Areas.Add(ma);
		}

		#endregion

		#region Helper methods

		static bool check_rect_is_empty(Rectangle rect)
		{
			foreach (TileData td in fMap.Tiles)
			{
				Tile t = Session.FindTile(td.TileID, SearchType.Global);
				Rectangle tile_rect = get_rect(t, td);

				if (tile_rect.IntersectsWith(rect))
					return false;
			}

			return true;
		}

		static TileData tile_at_point(Point pt)
		{
			foreach (TileData td in fMap.Tiles)
			{
				Tile t = Session.FindTile(td.TileID, SearchType.Global);
				Rectangle tile_rect = get_rect(t, td);

				if (tile_rect.Contains(pt))
					return td;
			}

			return null;
		}

		static Rectangle get_rect(Tile t, TileData td)
		{
			int width = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
			int height = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;

			return new Rectangle(td.Location.X, td.Location.Y, width, height);
		}

		#endregion
	}
}
