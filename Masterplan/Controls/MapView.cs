using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Events;
using Masterplan.Tools;

namespace Masterplan.Controls
{
	#region Enumerations

	/// <summary>
	/// Settings for displaying a MapView control.
	/// </summary>
	public enum MapViewMode
	{
		/// <summary>
		/// A fully interactive MapView.
		/// </summary>
		Normal,

		/// <summary>
		/// The MapView will be non-interactive with a plain background.
		/// </summary>
		Plain,

		/// <summary>
		/// A non-interactive MapView.
		/// </summary>
		Thumbnail,

		/// <summary>
		/// The map is to be shown on the player view.
		/// </summary>
		PlayerView
	}

	/// <summary>
	/// Controls how portions of a MapView control is displayed.
	/// </summary>
	public enum MapDisplayType
	{
		/// <summary>
		/// Not shown.
		/// </summary>
		None,

		/// <summary>
		/// Slightly transparent.
		/// </summary>
		Dimmed,

		/// <summary>
		/// Opaque.
		/// </summary>
		Opaque
	}

	/// <summary>
	/// Controls how creature tokens are shown on a MapView control.
	/// </summary>
	public enum CreatureViewMode
	{
		/// <summary>
		/// All creature tokens are shown.
		/// </summary>
		All,

		/// <summary>
		/// Only visible creature tokens are shown.
		/// </summary>
		Visible,

		/// <summary>
		/// No creature tokens are shown.
		/// </summary>
		None
	}

	/// <summary>
	/// Controls how the grid is shown on a MapView control.
	/// </summary>
	public enum MapGridMode
	{
		/// <summary>
		/// No gridlines.
		/// </summary>
		None,

		/// <summary>
		/// Gridlines are shown behind map tiles.
		/// </summary>
		Behind,

		/// <summary>
		/// Gridlines are shown in front of map tiles.
		/// </summary>
		Overlay
	}

	#endregion

	/// <summary>
	/// Control for displaying a Map object.
	/// </summary>
	public partial class MapView : UserControl
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MapView()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint
				| ControlStyles.Selectable, true);

			fCentred.Alignment = StringAlignment.Center;
			fCentred.LineAlignment = StringAlignment.Center;
			fCentred.Trimming = StringTrimming.EllipsisWord;

			fTop.Alignment = StringAlignment.Center;
			fTop.LineAlignment = StringAlignment.Near;
			fTop.Trimming = StringTrimming.EllipsisCharacter;

			fBottom.Alignment = StringAlignment.Center;
			fBottom.LineAlignment = StringAlignment.Far;
			fBottom.Trimming = StringTrimming.EllipsisCharacter;

			fLeft.Alignment = StringAlignment.Near;
			fLeft.LineAlignment = StringAlignment.Center;
			fLeft.Trimming = StringTrimming.EllipsisCharacter;

			fRight.Alignment = StringAlignment.Far;
			fRight.LineAlignment = StringAlignment.Center;
			fRight.Trimming = StringTrimming.EllipsisCharacter;
		}

		#region Properties

		/// <summary>
		/// Gets or sets the Map to be displayed.
		/// </summary>
		[Category("Data"), Description("The map to be displayed.")]
		public Map Map
		{
			get { return fMap; }
			set
			{
				fMap = value;
				fLayoutData = null;

				Invalidate();
			}
		}
		Map fMap = null;

		/// <summary>
		/// Gets or sets the Map to be displayed.
		/// </summary>
		[Category("Data"), Description("The map to be displayed in the background.")]
		public Map BackgroundMap
		{
			get { return fBackgroundMap; }
			set
			{
				fBackgroundMap = (value != null) ? value.Copy() : null;
				fLayoutData = null;

				Invalidate();
			}
		}
		Map fBackgroundMap = null;

		/// <summary>
		/// Gets or sets the Encounter containing creature locations.
		/// </summary>
		[Category("Data"), Description("The encounter to be displayed.")]
		public Encounter Encounter
		{
			get { return fEncounter; }
			set
			{
				fEncounter = value;
				Invalidate();
			}
		}
		Encounter fEncounter = null;

		/// <summary>
		/// Gets or sets the Encounter containing creature locations.
		/// </summary>
		[Category("Appearance"), Description("Whether we should show all waves, or only active waves.")]
		public bool ShowAllWaves
		{
			get { return fShowAllWaves; }
			set
			{
				fShowAllWaves = value;
				Invalidate();
			}
		}
		bool fShowAllWaves = false;

		/// <summary>
		/// Gets or sets the plot containing map-related plot points.
		/// </summary>
		[Category("Data"), Description("The plot to be displayed.")]
		public Plot Plot
		{
			get { return fPlot; }
			set
			{
				fPlot = value;
				Invalidate();
			}
		}
		Plot fPlot = null;

		/// <summary>
		/// Gets or sets the tile co-ordinates to zoom into, or Rectangle.Empty to display the full map.
		/// </summary>
		[Category("Appearance"), Description("The tile co-ordinates to view.")]
		public Rectangle Viewpoint
		{
			get { return fViewpoint; }
			set
			{
				fViewpoint = value;
				fLayoutData = null;

				Invalidate();
			}
		}
		Rectangle fViewpoint = Rectangle.Empty;

		/// <summary>
		/// Gets or sets the mode in which to display the map.
		/// </summary>
		[Category("Appearance"), Description("The mode in which to display the map.")]
		public MapViewMode Mode
		{
			get { return fMode; }
			set
			{
				fMode = value;
				Invalidate();
			}
		}
		MapViewMode fMode = MapViewMode.Normal;

		/// <summary>
		/// Gets or sets a value indicating whether map tokens can be moved around the map.
		/// </summary>
		[Category("Behavior"), Description("Determines whether map tokens can be moved around the map.")]
		public bool Tactical
		{
			get { return fTactical; }
			set
			{
				fTactical = value;
				Invalidate();
			}
		}
		bool fTactical = false;

		/// <summary>
		/// Gets or sets a value indicating whether map areas are highlighted.
		/// </summary>
		[Category("Appearance"), Description("Determines whether areas are highlighted.")]
		public bool HighlightAreas
		{
			get { return fHighlightAreas; }
			set
			{
				fHighlightAreas = value;
				Invalidate();
			}
		}
		bool fHighlightAreas = false;

		/// <summary>
		/// Gets or sets a value indicating how gridlines are drawn on the map.
		/// </summary>
		[Category("Appearance"), Description("Determines how gridlines are shown.")]
		public MapGridMode ShowGrid
		{
			get { return fShowGrid; }
			set
			{
				fShowGrid = value;
				Invalidate();
			}
		}
		MapGridMode fShowGrid = MapGridMode.None;

		/// <summary>
		/// Gets or sets a value indicating whether the map grid has labels.
		/// </summary>
		[Category("Appearance"), Description("Determines whether grid rows and columns are labelled.")]
		public bool ShowGridLabels
		{
			get { return fShowGridLabels; }
			set
			{
				fShowGridLabels = value;
				Invalidate();
			}
		}
		bool fShowGridLabels = false;

		/// <summary>
		/// Gets or sets a value indicating whether token images are shown as tokens.
		/// </summary>
		[Category("Appearance"), Description("Determines whether token images are shown as tokens.")]
		public bool ShowPictureTokens
		{
			get { return fShowPictureTokens; }
			set
			{
				fShowPictureTokens = value;
				Invalidate();
			}
		}
		bool fShowPictureTokens = true;

		/// <summary>
		/// Gets or sets the number of tiles to be drawn around the map.
		/// </summary>
		[Category("Appearance"), Description("The number of squares to be drawn around the viewpoint.")]
		public int BorderSize
		{
			get { return fBorderSize; }
			set
			{
				fBorderSize = value;
				Invalidate();
			}
		}
		int fBorderSize = 0;

		/// <summary>
		/// Gets or sets the selected tiles.
		/// </summary>
		[Category("Data"), Description("The list of selected tiles.")]
		public List<TileData> SelectedTiles
		{
			get { return fSelectedTiles; }
			set
			{
				fSelectedTiles = value;

				Invalidate();
			}
		}
		List<TileData> fSelectedTiles = null;

		/// <summary>
		/// Gets the list of boxed tokens.
		/// </summary>
		[Category("Data"), Description("The list of boxed map tokens.")]
		public List<IToken> BoxedTokens
		{
			get { return fBoxedTokens; }
		}
		List<IToken> fBoxedTokens = new List<IToken>();

		/// <summary>
		/// Gets the list of selected tokens.
		/// </summary>
		[Category("Appearance"), Description("The list of selected map tokens.")]
		public List<IToken> SelectedTokens
		{
			get { return fSelectedTokens; }
		}
		List<IToken> fSelectedTokens = new List<IToken>();

		/// <summary>
		/// Gets the hovered token.
		/// </summary>
		[Category("Appearance"), Description("The hovered map token.")]
		public IToken HoverToken
		{
			get { return fHoverToken; }
			set
			{
				fHoverToken = value;
				Invalidate();
			}
		}
		IToken fHoverToken = null;

		/// <summary>
		/// Gets the hovered token link.
		/// </summary>
		[Category("Appearance"), Description("The hovered token link.")]
		public TokenLink HoverTokenLink
		{
			get { return fHoverTokenLink; }
			set
			{
				fHoverTokenLink = value;
				Invalidate();
			}
		}
		TokenLink fHoverTokenLink = null;

		/// <summary>
		/// Gets or sets the selected region.
		/// </summary>
		[Category("Appearance"), Description("The rubber-band selected rectangle.")]
		public Rectangle Selection
		{
			get { return fCurrentOutline; }
			set
			{
				fCurrentOutline = value;
				Invalidate();
			}
		}
		Rectangle fCurrentOutline = Rectangle.Empty;

		/// <summary>
		/// Gets or sets how creatures should be displayed.
		/// </summary>
		[Category("Appearance"), Description("Determines how creatures should be displayed.")]
		public CreatureViewMode ShowCreatures
		{
			get { return fShowCreatures; }
			set
			{
				fShowCreatures = value;
				Invalidate();
			}
		}
		CreatureViewMode fShowCreatures = CreatureViewMode.All;

		/// <summary>
		/// Gets or sets a value indicating whether creatures should be displayed with a label based on their name.
		/// </summary>
		[Category("Appearance"), Description("Whether creatures should be shown with abbreviated labels.")]
		public bool ShowCreatureLabels
		{
			get { return fShowCreatureLabels; }
			set
			{
				fShowCreatureLabels = value;
				Invalidate();
			}
		}
		bool fShowCreatureLabels = true;

		/// <summary>
		/// Gets or sets a value indicating whether creatures should be displayed with a bar showing their HP.
		/// </summary>
		[Category("Appearance"), Description("Whether creatures should be shown with an HP bar.")]
		public bool ShowHealthBars
		{
			get { return fShowHealthBars; }
			set
			{
				fShowHealthBars = value;
				Invalidate();
			}
		}
		bool fShowHealthBars = false;

		/// <summary>
		/// Gets or sets a value indicating whether condition badges should be displayed on tokens.
		/// </summary>
		[Category("Appearance"), Description("Whether condition badges should be shown.")]
		public bool ShowConditions
		{
			get { return fShowConditions; }
			set
			{
				fShowConditions = value;
				Invalidate();
			}
		}
		bool fShowConditions = true;

		/// <summary>
		/// Gets or sets a value indicating whether creature auras should be displayed on the map.
		/// </summary>
		[Category("Appearance"), Description("Whether creature auras should be shown.")]
		public bool ShowAuras
		{
			get { return fShowAuras; }
			set
			{
				fShowAuras = value;
				Invalidate();
			}
		}
		bool fShowAuras = true;

		/// <summary>
		/// Gets the highlighted MapArea.
		/// </summary>
		[Category("Appearance"), Description("The highlighted MapArea.")]
		public MapArea HighlightedArea
		{
			get { return fHighlightedArea; }
		}
		MapArea fHighlightedArea = null;

		/// <summary>
		/// Gets or sets the selected MapArea.
		/// </summary>
		[Category("Appearance"), Description("The selected MapArea.")]
		public MapArea SelectedArea
		{
			get { return fSelectedArea; }
			set
			{
				fSelectedArea = value;
				Invalidate();
			}
		}
		MapArea fSelectedArea = null;

		/// <summary>
		/// Gets or sets a value indicating whether links between tokens can be created using drag and drop.
		/// </summary>
		[Category("Behavior"), Description("Determines whether links between tokens can be created.")]
		public bool AllowLinkCreation
		{
			get { return fAllowLinkCreation; }
			set { fAllowLinkCreation = value; }
		}
		bool fAllowLinkCreation = false;

		/// <summary>
		/// Gets or sets the list of token links.
		/// </summary>
		[Category("Data"), Description("The list of links between map tokens.")]
		public List<TokenLink> TokenLinks
		{
			get { return fTokenLinks; }
			set
			{
				fTokenLinks = value;
				Invalidate();
			}
		}
		List<TokenLink> fTokenLinks = null;

		Dictionary<TokenLink, RectangleF> fTokenLinkRegions = new Dictionary<TokenLink, RectangleF>();

		/// <summary>
		/// Gets or sets a value indicating whether scrolling the map is allowed.
		/// </summary>
		[Category("Behavior"), Description("Determines whether the map can be scrolled.")]
		public bool AllowScrolling
		{
			get { return fAllowScrolling; }
			set
			{
				fAllowScrolling = value;

				if (fAllowScrolling == false)
				{
					if (fScalingFactor != 1)
						fViewpoint = get_current_zoom_rect(false);

					fScalingFactor = 1;
				}

				Cursor = (fAllowScrolling) ? Cursors.SizeAll : Cursors.Default;
				Invalidate();

				if (!fAllowScrolling)
					OnCancelledScrolling();
			}
		}
		bool fAllowScrolling = false;

		/// <summary>
		/// Gets or sets the map scaling factor.
		/// </summary>
		[Category("Appearance"), Description("The scaling factor for the map; this can be used to zoom in and out.")]
		public double ScalingFactor
		{
			get { return fScalingFactor; }
			set
			{
				fScalingFactor = value;
				Invalidate();
			}
		}
		double fScalingFactor = 1.0;

		/// <summary>
		/// Gets or sets how frames are displayed around the Viewpoint.
		/// </summary>
		[Category("Appearance"), Description("The appearance of the frame around the viewpoint.")]
		public MapDisplayType FrameType
		{
			get { return fFrameType; }
			set
			{
				fFrameType = value;
				Invalidate();
			}
		}
		MapDisplayType fFrameType = MapDisplayType.Dimmed;

		/// <summary>
		/// Gets or sets whether line of sight is indicated.
		/// </summary>
		[Category("Appearance"), Description("How the line of sight is displayed.")]
		public bool LineOfSight
		{
			get { return fLineOfSight; }
			set
			{
				fLineOfSight = value;
				Invalidate();
				if (!fLineOfSight)
					OnCancelledLOS();
			}
		}
		bool fLineOfSight = false;

		/// <summary>
		/// Gets or sets whether drawing on the map is permitted.
		/// </summary>
		public bool AllowDrawing
		{
			get { return fDrawing != null; }
			set
			{
				if (value)
					fDrawing = new DrawingData();
				else
					fDrawing = null;

				Cursor = (fDrawing == null) ? Cursors.Default : Cursors.Cross;

				Invalidate();

				if (fDrawing == null)
					OnCancelledDrawing();
			}
		}
		DrawingData fDrawing = null;

		/// <summary>
		/// Gets the list of map sketches.
		/// </summary>
		public List<MapSketch> Sketches
		{
			get { return fSketches; }
		}
		List<MapSketch> fSketches = new List<MapSketch>();

		/// <summary>
		/// Gets or sets the map caption.
		/// </summary>
		public string Caption
		{
			get { return fCaption; }
			set { fCaption = value; }
		}
		string fCaption = "";

		/// <summary>
		/// Gets the object containing layout logic for this map.
		/// </summary>
		internal MapData LayoutData
		{
			get
			{
				if (fLayoutData == null)
					fLayoutData = new MapData(this, fScalingFactor);

				return fLayoutData;
			}
		}
		MapData fLayoutData = null;

		NewTile fNewTile = null;
		TileData fHoverTile = null;
		DraggedTiles fDraggedTiles = null;

		NewToken fNewToken = null;
		DraggedToken fDraggedToken = null;

		StringFormat fCentred = new StringFormat();
		StringFormat fTop = new StringFormat();
		StringFormat fBottom = new StringFormat();
		StringFormat fLeft = new StringFormat();
		StringFormat fRight = new StringFormat();

		DraggedOutline fDraggedOutline = null;

		ScrollingData fScrollingData = null;

		Dictionary<Guid, List<Rectangle>> fSlotRegions = new Dictionary<Guid, List<Rectangle>>();

		#endregion

		#region Methods

		/// <summary>
		/// Updates the MapView control.
		/// </summary>
		public void MapChanged()
		{
			fLayoutData = null;
			Invalidate();
		}

		/// <summary>
		/// This method is used to notify the MapView that a user has pressed an arrow key.
		/// </summary>
		/// <param name="e">Event arguments</param>
		public void Nudge(KeyEventArgs e)
		{
			OnKeyDown(e);
		}

		/// <summary>
		/// Called in response to the Resize event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnResize(EventArgs e)
		{
			// Resized; we'll need to recalculate everything
			fLayoutData = null;
			Invalidate();
		}

		/// <summary>
		/// Sets information about the currently dragged map token.
		/// </summary>
		/// <param name="old_point">The dragged token's original location</param>
		/// <param name="new_point">The dragged token's new location</param>
		public void SetDragInfo(Point old_point, Point new_point)
		{
			if ((old_point == CombatData.NoPoint))
			{
				fDraggedToken = null;
				Invalidate();
			}
			else
			{
				Pair<IToken, Rectangle> pair = get_token_at(old_point);
				if (pair != null)
				{
					fDraggedToken = new DraggedToken();

					fDraggedToken.Token = pair.First;
					fDraggedToken.Start = old_point;
					fDraggedToken.Location = new_point;

					Invalidate();
				}
			}
		}

		/// <summary>
		/// Selects a set of map tokens.
		/// </summary>
		/// <param name="tokens">The map tokens to select.</param>
		/// <param name="raise_event">Whether the SelectedTokenChanged event should be raised.</param>
		public void SelectTokens(List<IToken> tokens, bool raise_event)
		{
			if (tokens == null)
			{
				fSelectedTokens.Clear();
				return;
			}

			foreach (IToken token in tokens)
			{
				if (!fSelectedTokens.Contains(token))
					fSelectedTokens.Add(token);
			}

			List<IToken> obsolete = new List<IToken>();
			foreach (IToken token in fSelectedTokens)
			{
				if (!tokens.Contains(token))
					obsolete.Add(token);
			}

			foreach (IToken token in obsolete)
				fSelectedTokens.Remove(token);

			Invalidate();

			if (raise_event)
				OnSelectedTokensChanged();
		}

		#endregion

		#region Events

		/// <summary>
		/// This is called when a tile or token has been removed from the map.
		/// </summary>
		[Category("Action"), Description("Called when a tile or token is removed from the map.")]
		public event EventHandler ItemRemoved;

		/// <summary>
		/// Raises the ItemRemoved event.
		/// </summary>
		protected void OnItemRemoved()
		{
			if (ItemRemoved != null)
				ItemRemoved(this, new EventArgs());
		}

		/// <summary>
		/// This is called when a tile or token is dropped onto the map.
		/// </summary>
		[Category("Action"), Description("Called when a tile or token is dropped onto the map.")]
		public event EventHandler ItemDropped;

		/// <summary>
		/// Raises the ItemDropped event.
		/// </summary>
		protected void OnItemDropped()
		{
			if (ItemDropped != null)
				ItemDropped(this, new EventArgs());
		}

		/// <summary>
		/// This is called when a tile or token is moved around the map.
		/// </summary>
		[Category("Action"), Description("Called when a tile or token is moved around the map.")]
		public event MovementEventHandler ItemMoved;

		/// <summary>
		/// Raises the ItemMoved event.
		/// </summary>
		protected void OnItemMoved(int distance)
		{
			if (ItemMoved != null)
				ItemMoved(this, new MovementEventArgs(distance));
		}

		/// <summary>
		/// This is called when an area has been selected.
		/// </summary>
		[Category("Action"), Description("Called when an area has been selected.")]
		public event EventHandler RegionSelected;

		/// <summary>
		/// Raises the RegionSelected event.
		/// </summary>
		protected void OnRegionSelected()
		{
			if (RegionSelected != null)
				RegionSelected(this, new EventArgs());
		}

		/// <summary>
		/// This is called when a context menu should be displayed on the selected tile.
		/// </summary>
		[Category("Action"), Description("Called when a context menu should be displayed.")]
		public event EventHandler TileContext;

		/// <summary>
		/// Raises the TileContext event.
		/// </summary>
		/// <param name="tile">The tile.</param>
		protected void OnTileContext(TileData tile)
		{
			if (TileContext != null)
				TileContext(this, new TileEventArgs(tile));
		}

		/// <summary>
		/// This is called when the hovered token has changed.
		/// </summary>
		[Category("Property Changed"), Description("Occurs when the hovered token has changed.")]
		public event EventHandler HoverTokenChanged;

		/// <summary>
		/// Raises the HoverTokenChanged event.
		/// </summary>
		protected void OnHoverTokenChanged()
		{
			if (HoverTokenChanged != null)
				HoverTokenChanged(this, new EventArgs());
		}

		/// <summary>
		/// This is called when the selected tokens have changed.
		/// </summary>
		[Category("Property Changed"), Description("Occurs when the selected tokens have changed.")]
		public event EventHandler SelectedTokensChanged;

		/// <summary>
		/// Raises the SelectedTokensChanged event.
		/// </summary>
		protected void OnSelectedTokensChanged()
		{
			if (SelectedTokensChanged != null)
				SelectedTokensChanged(this, new EventArgs());
		}

		/// <summary>
		/// This is called when the highlighted MapArea has changed.
		/// </summary>
		[Category("Property Changed"), Description("Occurs when the highlighted map area has changed.")]
		public event EventHandler HighlightedAreaChanged;

		/// <summary>
		/// Raises the HighlightedAreaChanged event.
		/// </summary>
		protected void OnHighlightedAreaChanged()
		{
			// Don't call if we're not showing areas
			if (!fHighlightAreas)
				return;

			// Don't call if we're zoomed into that area
			if ((fHighlightedArea != null) && (fViewpoint == fHighlightedArea.Region))
				return;

			if (HighlightedAreaChanged != null)
				HighlightedAreaChanged(this, new EventArgs());
		}

		/// <summary>
		/// This is called when a token is double-clicked.
		/// </summary>
		[Category("Action"), Description("Occurs when a map token is double-clicked.")]
		public event TokenEventHandler TokenActivated;

		/// <summary>
		/// Raises the TokenActivated event.
		/// </summary>
		/// <param name="token">The token.</param>
		protected void OnTokenActivated(IToken token)
		{
			if (TokenActivated != null)
				TokenActivated(this, new TokenEventArgs(token));
		}

		/// <summary>
		/// This is called when a token is dragged.
		/// </summary>
		[Category("Action"), Description("Occurs when a map token is dragged.")]
		public event DraggedTokenEventHandler TokenDragged;

		/// <summary>
		/// Raises the TokenDragged event.
		/// </summary>
		// /// <param name="token">The token.</param>
		protected void OnTokenDragged()
		{
			if (TokenDragged != null)
			{
				Point old_loc = (fDraggedToken != null) ? fDraggedToken.Start : CombatData.NoPoint;
				Point new_loc = (fDraggedToken != null) ? fDraggedToken.Location : CombatData.NoPoint;
				TokenDragged(this, new DraggedTokenEventArgs(old_loc, new_loc));
			}
		}

		/// <summary>
		/// This is called when a map area is clicked.
		/// </summary>
		[Category("Action"), Description("Occurs when a map area is clicked.")]
		public event MapAreaEventHandler AreaSelected;

		/// <summary>
		/// Raises the AreaSelected event.
		/// </summary>
		/// <param name="area">The map area.</param>
		protected void OnAreaSelected(MapArea area)
		{
			if (AreaSelected != null)
				AreaSelected(this, new MapAreaEventArgs(area));
		}

		/// <summary>
		/// This is called when a map area is double-clicked.
		/// </summary>
		[Category("Action"), Description("Occurs when a map area is double-clicked.")]
		public event MapAreaEventHandler AreaActivated;

		/// <summary>
		/// Raises the AreaActivated event.
		/// </summary>
		/// <param name="area">The map area.</param>
		protected void OnAreaActivated(MapArea area)
		{
			if (AreaActivated != null)
				AreaActivated(this, new MapAreaEventArgs(area));
		}

		/// <summary>
		/// This is called when a link between tokens should be created.
		/// </summary>
		[Category("Action"), Description("Occurs when a link should be created.")]
		public event CreateTokenLinkEventHandler CreateTokenLink;

		/// <summary>
		/// Raises the CreateTokenLink event.
		/// </summary>
		/// <param name="tokens">The list of tokens.</param>
		protected TokenLink OnCreateTokenLink(List<IToken> tokens)
		{
			if (CreateTokenLink != null)
				return CreateTokenLink(this, new TokenListEventArgs(tokens));

			return null;
		}

		/// <summary>
		/// This is called when a link between tokens should be edited.
		/// </summary>
		[Category("Action"), Description("Occurs when a link should be edited.")]
		public event TokenLinkEventHandler EditTokenLink;

		/// <summary>
		/// Raises the EditTokenLink event.
		/// </summary>
		/// <param name="link">The token link to be edited.</param>
		protected TokenLink OnEditTokenLink(TokenLink link)
		{
			if (EditTokenLink != null)
				return EditTokenLink(this, new TokenLinkEventArgs(link));

			return null;
		}

		/// <summary>
		/// This is called when a new sketch is created.
		/// </summary>
		[Category("Action"), Description("Occurs when a sketch is created.")]
		public event MapSketchEventHandler SketchCreated;

		/// <summary>
		/// Raises the SketchCreated event.
		/// </summary>
		/// <param name="sketch">The new sketch.</param>
		protected void OnSketchCreated(MapSketch sketch)
		{
			if (SketchCreated != null)
				SketchCreated(this, new MapSketchEventArgs(sketch));
		}

		/// <summary>
		/// This is called when the mouse wheel is scrolled.
		/// </summary>
		[Category("Action"), Description("Occurs when the mouse wheel is scrolled.")]
		public event MouseEventHandler MouseZoomed;

		/// <summary>
		/// Raises the MouseScrolled event.
		/// </summary>
		/// <param name="args">Mouse event arguments.</param>
		protected void OnMouseZoom(MouseEventArgs args)
		{
			if (MouseZoomed != null)
				MouseZoomed(this, args);
		}

		/// <summary>
		/// This is called when the LOS mode is cancelled.
		/// </summary>
		[Category("Action"), Description("Called when the LOS mode is cancelled.")]
		public event EventHandler CancelledLOS;

		/// <summary>
		/// Raises the CancelledLOS event.
		/// </summary>
		protected void OnCancelledLOS()
		{
			if (CancelledLOS != null)
				CancelledLOS(this, new EventArgs());
		}

		/// <summary>
		/// This is called when the drawing mode is cancelled.
		/// </summary>
		[Category("Action"), Description("Called when the drawing mode is cancelled.")]
		public event EventHandler CancelledDrawing;

		/// <summary>
		/// Raises the CancelledDrawing event.
		/// </summary>
		protected void OnCancelledDrawing()
		{
			if (CancelledDrawing != null)
				CancelledDrawing(this, new EventArgs());
		}

		/// <summary>
		/// This is called when the scrolling mode is cancelled.
		/// </summary>
		[Category("Action"), Description("Called when the scrolling mode is cancelled.")]
		public event EventHandler CancelledScrolling;

		/// <summary>
		/// Raises the CancelledScrolling event.
		/// </summary>
		protected void OnCancelledScrolling()
		{
			if (CancelledScrolling != null)
				CancelledScrolling(this, new EventArgs());
		}

		#endregion

		#region Painting

		/// <summary>
		/// Called in response to the Paint event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (fLayoutData == null)
				fLayoutData = new MapData(this, fScalingFactor);

			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			#region Background

			switch (fMode)
			{
				case MapViewMode.Normal:
					{
						using (Brush background = new SolidBrush(Color.FromArgb(70, 100, 170)))
						{
							e.Graphics.FillRectangle(background, ClientRectangle);
						}
					}
					break;
				case MapViewMode.Thumbnail:
					{
						Color top = Color.FromArgb(240, 240, 240);
						Color bottom = Color.FromArgb(170, 170, 170);
						using (Brush background = new LinearGradientBrush(ClientRectangle, top, bottom, LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(background, ClientRectangle);
						}
					}
					break;
				case MapViewMode.Plain:
					{
						e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
					}
					break;
				case MapViewMode.PlayerView:
					{
						e.Graphics.FillRectangle(Brushes.Black, ClientRectangle);
					}
					break;
			}

			#endregion

			#region No map

			if (fMap == null)
			{
				Brush b = SystemBrushes.WindowText;
				if (fMode == MapViewMode.Normal)
					b = Brushes.White;

				e.Graphics.DrawString("(no map selected)", Font, b, ClientRectangle, fCentred);
				return;
			}

			#endregion

			#region Grid (background)

			// Draw grid
			if ((fShowGrid == MapGridMode.Behind) && (fLayoutData.SquareSize >= 10))
			{
				using (Pen light_p = new Pen(Color.FromArgb(100, 140, 190)))
				{
					using (Pen heavy_p = new Pen(Color.FromArgb(150, 200, 230)))
					{
						float x = 0;
						float offset_x = fLayoutData.MapOffset.Width % fLayoutData.SquareSize;
						int x_step = 0;
						while (x <= ClientRectangle.Width)
						{
							if (x_step % 4 == 0)
								e.Graphics.DrawLine(heavy_p, x + offset_x, 0, x + offset_x, ClientRectangle.Height);
							else
								e.Graphics.DrawLine(light_p, x + offset_x, 0, x + offset_x, ClientRectangle.Height);

							x += fLayoutData.SquareSize;
							x_step += 1;
						}

						float y = 0;
						float offset_y = fLayoutData.MapOffset.Height % fLayoutData.SquareSize;
						int y_step = 0;
						while (y <= ClientRectangle.Height)
						{
							if (y_step % 4 == 0)
								e.Graphics.DrawLine(heavy_p, 0, y + offset_y, ClientRectangle.Width, y + offset_y);
							else
								e.Graphics.DrawLine(light_p, 0, y + offset_y, ClientRectangle.Width, y + offset_y);

							y += fLayoutData.SquareSize;
							y_step += 1;
						}
					}
				}
			}

			#endregion

			#region Calculate slot regions

			if (fEncounter != null)
			{
				fSlotRegions.Clear();

				foreach (EncounterSlot slot in fEncounter.AllSlots)
				{
					fSlotRegions[slot.ID] = new List<Rectangle>();

					ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
					if (creature == null)
						continue;

					int size = Creature.GetSize(creature.Size);

					foreach (CombatData cd in slot.CombatData)
						fSlotRegions[slot.ID].Add(new Rectangle(cd.Location, new Size(size, size)));
				}
			}

			#endregion

			#region Map areas

			if (fHighlightAreas)
			{
				foreach (MapArea area in fMap.Areas)
				{
					RectangleF rect = fLayoutData.GetRegion(area.Region.Location, area.Region.Size);

					Brush b = null;
					if (area == fSelectedArea)
					{
						b = Brushes.LightBlue;
					}
					else
					{
						Color top = Color.FromArgb(255, 255, 255);
						Color bottom = Color.FromArgb(210, 210, 210);
						b = new LinearGradientBrush(ClientRectangle, top, bottom, LinearGradientMode.Vertical);
					}

					if (fPlot != null)
					{
						PlotPoint point = fPlot.FindPointForMapArea(fMap, area);
						if (point == null)
						{
							// There's no plot point for this map area
							b = null;
						}
					}

					if (b != null)
						e.Graphics.FillRectangle(b, rect);
				}
			}

			#endregion

			#region Outline

			if (fCurrentOutline != Rectangle.Empty)
			{
				RectangleF rect = fLayoutData.GetRegion(fCurrentOutline.Location, fCurrentOutline.Size);
				e.Graphics.FillRectangle(Brushes.LightBlue, rect);
			}

			#endregion

			#region Tiles

			// Draw background tiles
			if (fBackgroundMap != null)
			{
				foreach (TileData td in fBackgroundMap.Tiles)
				{
					if (!fLayoutData.Tiles.ContainsKey(td))
						continue;

					Tile tile = fLayoutData.Tiles[td];

					// Draw this tile
					RectangleF tile_rect = fLayoutData.TileRegions[td];
					draw_tile(e.Graphics, tile, td.Rotations, tile_rect, true);
				}
			}

			// Draw tiles
			foreach (TileData td in fMap.Tiles)
			{
				if ((fDraggedTiles != null) && (fDraggedTiles.Tiles.Contains(td)))
					continue;

				if (!fLayoutData.Tiles.ContainsKey(td))
					continue;

				Tile tile = fLayoutData.Tiles[td];

				// Draw this tile
				RectangleF tile_rect = fLayoutData.TileRegions[td];
				draw_tile(e.Graphics, tile, td.Rotations, tile_rect, false);

				if ((fSelectedTiles != null) && (fSelectedTiles.Contains(td)))
				{
					// Highlight selected tile
					e.Graphics.DrawRectangle(Pens.Blue, tile_rect.X, tile_rect.Y, tile_rect.Width, tile_rect.Height);
				}
				else if (td == fHoverTile)
				{
					// Highlight hover tile
					e.Graphics.DrawRectangle(Pens.DarkBlue, tile_rect.X, tile_rect.Y, tile_rect.Width, tile_rect.Height);
				}
			}

			if (fNewTile != null)
			{
				// Draw dragged tile
				draw_tile(e.Graphics, fNewTile.Tile, 0, fNewTile.Region, false);
			}

			if (fDraggedTiles != null)
			{
				// Draw dragged tiles
				foreach (TileData td in fDraggedTiles.Tiles)
				{
					Tile t = fLayoutData.Tiles[td];
					draw_tile(e.Graphics, t, td.Rotations, fDraggedTiles.Region, false);
				}
			}

			#endregion

			#region Grid (overlay)

			if ((fShowGrid == MapGridMode.Overlay) && (fLayoutData.SquareSize >= 10))
			{
				Pen p = Pens.DarkGray;

				float x = 0;
				float offset_x = fLayoutData.MapOffset.Width % fLayoutData.SquareSize;
				while (x <= ClientRectangle.Width)
				{
					e.Graphics.DrawLine(p, x + offset_x, 0, x + offset_x, ClientRectangle.Height);

					x += fLayoutData.SquareSize;
				}

				float y = 0;
				float offset_y = fLayoutData.MapOffset.Height % fLayoutData.SquareSize;
				while (y <= ClientRectangle.Height)
				{
					e.Graphics.DrawLine(p, 0, y + offset_y, ClientRectangle.Width, y + offset_y);

					y += fLayoutData.SquareSize;
				}
			}

			if (fShowGridLabels)
			{
				string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

				float size = fLayoutData.SquareSize / 4f;
				Font label = new Font(Font.FontFamily, size);

				for (int x = fLayoutData.MinX; x <= fLayoutData.MaxX; ++x)
				{
					int dx = x - fLayoutData.MinX + 1;
					string str = dx.ToString();

					RectangleF top = fLayoutData.GetRegion(new Point(x, fLayoutData.MinY), new Size(1, 1));
					draw_grid_label(e.Graphics, str, label, top, fTop);

					RectangleF bottom = fLayoutData.GetRegion(new Point(x, fLayoutData.MaxY), new Size(1, 1));
					draw_grid_label(e.Graphics, str, label, bottom, fBottom);
				}

				for (int y = fLayoutData.MinY; y <= fLayoutData.MaxY; ++y)
				{
					int dy = y - fLayoutData.MinY;

					string str = "";
					if (dy >= alphabet.Length)
					{
						int first = dy / alphabet.Length;
						str += alphabet.Substring(first - 1, 1);
					}
					int second = dy % alphabet.Length;
					str += alphabet.Substring(second, 1);

					RectangleF left = fLayoutData.GetRegion(new Point(fLayoutData.MinX, y), new Size(1, 1));
					draw_grid_label(e.Graphics, str, label, left, fLeft);

					RectangleF right = fLayoutData.GetRegion(new Point(fLayoutData.MaxX, y), new Size(1, 1));
					draw_grid_label(e.Graphics, str, label, right, fRight);
				}
			}

			#endregion

			#region Map area outlines

			if (fHighlightAreas)
			{
				foreach (MapArea area in fMap.Areas)
				{
					PlotPointState state = PlotPointState.Normal;
					if (fPlot != null)
					{
						PlotPoint point = fPlot.FindPointForMapArea(fMap, area);
						if (point != null)
							state = point.State;
					}

					RectangleF rect = fLayoutData.GetRegion(area.Region.Location, area.Region.Size);

					Pen p = Pens.DarkGray;
					if ((area == fHighlightedArea) || (area == fSelectedArea))
						p = Pens.DarkBlue;

					e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width, rect.Height);

					if ((state == PlotPointState.Completed) || (state == PlotPointState.Skipped))
					{
						PointF top_left = new PointF(rect.Left, rect.Top);
						PointF top_right = new PointF(rect.Right, rect.Top);
						PointF bottom_left = new PointF(rect.Left, rect.Bottom);
						PointF bottom_right = new PointF(rect.Right, rect.Bottom);

						Pen x_pen = new Pen(Color.DarkGray, 2);

						e.Graphics.DrawLine(x_pen, top_left, bottom_right);
						e.Graphics.DrawLine(x_pen, bottom_left, top_right);
					}

					// Draw area name
					if ((fViewpoint == Rectangle.Empty) && (area.Name != "") && (fNewTile == null) && (fDraggedTiles == null))
					{
						Font text_font = Font;
						if (state == PlotPointState.Skipped)
							text_font = new Font(text_font, text_font.Style | FontStyle.Strikeout);

						float delta = 8;
						SizeF size = e.Graphics.MeasureString(area.Name, text_font);
						size = new SizeF(size.Width + delta, size.Height + delta);

						float dx = (rect.Width - size.Width) / 2;
						float dy = (rect.Height - size.Height) / 2;

						RectangleF text_rect = new RectangleF(rect.Left + dx, rect.Top + dy, size.Width, size.Height);

						GraphicsPath path = RoundedRectangle.Create(text_rect, text_rect.Height / 3);
						using (Brush b = new SolidBrush(Color.FromArgb(200, Color.Black)))
						{
							e.Graphics.FillPath(b, path);
						}
						e.Graphics.DrawPath(Pens.Black, path);
						e.Graphics.DrawString(area.Name, text_font, Brushes.White, text_rect, fCentred);
					}
				}
			}
			else
			{
				if (fPlot != null)
				{
					foreach (MapArea area in fMap.Areas)
					{
						PlotPoint point = fPlot.FindPointForMapArea(fMap, area);
						if ((point != null) && (point.State == PlotPointState.Completed))
							continue;

						// Fill unexplored regions in black
						RectangleF rect = fLayoutData.GetRegion(area.Region.Location, area.Region.Size);
						e.Graphics.FillRectangle(Brushes.Black, rect);
					}
				}
			}

			#endregion

			#region Auras

			if (fShowAuras)
			{
				List<IToken> tokens = new List<IToken>();
				tokens.AddRange(fSelectedTokens);
				if (fHoverToken != null)
					tokens.Add(fHoverToken);

				foreach (IToken token in tokens)
				{
					Dictionary<Aura, Rectangle> aura_list = new Dictionary<Aura, Rectangle>();

					CreatureToken ct = token as CreatureToken;
					if (ct != null)
					{
						if (ct.Data.Location == CombatData.NoPoint)
							continue;

						List<Aura> auras = new List<Aura>();
						foreach (OngoingCondition oc in ct.Data.Conditions)
						{
							if (oc.Type == OngoingType.Aura)
								auras.Add(oc.Aura);
						}

						EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
						if (slot != null)
							auras.AddRange(slot.Card.Auras);

						if (slot != null)
						{
							ICreature c = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
							int creature_size = (c != null) ? Creature.GetSize(c.Size) : 1;

							foreach (Aura aura in auras)
							{
								int dimension = aura.Radius + creature_size + aura.Radius;
								Point aura_loc = new Point(ct.Data.Location.X - aura.Radius, ct.Data.Location.Y - aura.Radius);
								Size aura_size = new Size(dimension, dimension);

								aura_list[aura] = new Rectangle(aura_loc, aura_size);
							}
						}

					}

					// Custom tokens: you can't add effects to custom tokens

					Hero hero = token as Hero;
					if (hero != null)
					{
						// Get size
						int creature_size = Creature.GetSize(hero.Size);

						// Get auras from CombatData
						//CombatData cd = fHeroData[hero.ID];
						CombatData cd = hero.CombatData;
						if (cd != null)
						{
							foreach (OngoingCondition oc in cd.Conditions)
							{
								if (oc.Type == OngoingType.Aura)
								{
									int dimension = oc.Aura.Radius + creature_size + oc.Aura.Radius;
									Point aura_loc = new Point(cd.Location.X - oc.Aura.Radius, cd.Location.Y - oc.Aura.Radius);
									Size aura_size = new Size(dimension, dimension);

									aura_list[oc.Aura] = new Rectangle(aura_loc, aura_size);
								}
							}
						}
					}

					foreach (Aura aura in aura_list.Keys)
					{
						Rectangle rect = aura_list[aura];
						RectangleF aura_rect = fLayoutData.GetRegion(rect.Location, rect.Size);

						float rounding = fLayoutData.SquareSize * 0.8f;
						GraphicsPath path = RoundedRectangle.Create(aura_rect, rounding);

						using (Pen p = new Pen(Color.FromArgb(200, Color.Red)))
						{
							e.Graphics.DrawPath(p, path);
						}

						using (Brush b = new SolidBrush(Color.FromArgb(15, Color.Red)))
						{
							e.Graphics.FillPath(b, path);
						}
					}
				}
			}

			#endregion

			#region Links

			if (fTokenLinks != null)
			{
				foreach (TokenLink link in fTokenLinks)
				{
					// Draw link

					IToken lhs = link.Tokens[0];
					IToken rhs = link.Tokens[1];

					CombatData cd_lhs = get_combat_data(lhs);
					CombatData cd_rhs = get_combat_data(rhs);
					if (cd_lhs.Visible && cd_rhs.Visible)
					{
						RectangleF rect_lhs = get_token_rect(lhs);
						RectangleF rect_rhs = get_token_rect(rhs);

						if ((rect_lhs == RectangleF.Empty) || (rect_rhs == RectangleF.Empty))
							continue;

						Color c = (link == fHoverTokenLink) ? Color.Navy : Color.Black;

						PointF pt_lhs = new PointF((rect_lhs.Left + rect_lhs.Right) / 2, (rect_lhs.Top + rect_lhs.Bottom) / 2);
						PointF pt_rhs = new PointF((rect_rhs.Left + rect_rhs.Right) / 2, (rect_rhs.Top + rect_rhs.Bottom) / 2);
						using (Pen link_pen = new Pen(c, 2))
						{
							e.Graphics.DrawLine(link_pen, pt_lhs, pt_rhs);
						}
					}
				}
			}

			#endregion

			#region Tokens

			if (fEncounter != null)
			{
				// Draw custom overlays
				foreach (CustomToken ct in fEncounter.CustomTokens)
				{
					if (ct.Type != CustomTokenType.Overlay)
						continue;

					if (!is_visible(ct.Data))
						continue;

					if (ct.CreatureID != Guid.Empty)
					{
						CreatureSize size = CreatureSize.Medium;

						CombatData cd = fEncounter.FindCombatData(ct.CreatureID);
						if (cd != null)
						{
							ct.Data.Location = cd.Location;

							EncounterSlot slot = fEncounter.FindSlot(cd);
							ICreature c = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
							size = c.Size;
						}

						Hero hero = Session.Project.FindHero(ct.CreatureID);
						if (hero != null)
						{
							//ct.Data.Location = fHeroData[ct.CreatureID].Location;
							ct.Data.Location = hero.CombatData.Location;

							//Hero hero = Session.Project.FindHero(ct.CreatureID);
							size = hero.Size;
						}

						if (ct.Data.Location != CombatData.NoPoint)
						{
							// Centre on the creature
							int creature_size = (Creature.GetSize(size) + 1) / 2;
							int x = ct.Data.Location.X - ((ct.OverlaySize.Width - creature_size) / 2);
							int y = ct.Data.Location.Y - ((ct.OverlaySize.Height - creature_size) / 2);
							ct.Data.Location = new Point(x, y);
						}
					}

					if (ct.Data.Location == CombatData.NoPoint)
						continue;

					bool selected = fSelectedTokens.Contains(ct);
					bool hovered = false;
					if (fHoverToken != null)
						hovered = (get_combat_data(fHoverToken).ID == ct.Data.ID);

					draw_custom(e.Graphics, ct.Data.Location, ct, selected, hovered, false);
				}

				// Draw custom tokens
				foreach (CustomToken ct in fEncounter.CustomTokens)
				{
					if (ct.Type != CustomTokenType.Token)
						continue;

					if (ct.Data.Location == CombatData.NoPoint)
						continue;

					if (!is_visible(ct.Data))
						continue;

					if ((fDraggedToken != null) && (fDraggedToken.Token is CustomToken))
					{
						CustomToken token = fDraggedToken.Token as CustomToken;
						if (token.Type == CustomTokenType.Token)
						{
							if ((ct.ID == token.ID) && (ct.Data.Location == fDraggedToken.Start))
							{
								if (ct.Data.Location != fDraggedToken.Location)
									draw_token_placeholder(e.Graphics, ct.Data.Location, fDraggedToken.Location, ct.TokenSize, false);

								continue;
							}
						}
					}

					bool selected = fSelectedTokens.Contains(ct);
					bool hovered = false;
					if (fHoverToken != null)
						hovered = (get_combat_data(fHoverToken).ID == ct.Data.ID);

					draw_custom(e.Graphics, ct.Data.Location, ct, selected, hovered, false);
				}

				// Draw creature tokens
				foreach (EncounterSlot slot in fEncounter.AllSlots)
				{
					// Ignore this slot if we're not supposed to be showing it
					EncounterWave ew = fEncounter.FindWave(slot);
					if ((ew != null) && (ew.Active == false) && (fShowAllWaves == false))
						continue;

					foreach (CombatData cd in slot.CombatData)
					{
						if (cd.Location == CombatData.NoPoint)
							continue;

						if (!is_visible(cd))
							continue;

						if ((fDraggedToken != null) && (fDraggedToken.Token is CreatureToken))
						{
							CreatureToken token = fDraggedToken.Token as CreatureToken;
							if ((slot.ID == token.SlotID) && (cd.Location == fDraggedToken.Start))
							{
								if (cd.Location != fDraggedToken.Location)
								{
									ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
									bool has_picture = (creature.Image != null);
									draw_token_placeholder(e.Graphics, cd.Location, fDraggedToken.Location, creature.Size, has_picture);
								}

								continue;
							}
						}

						bool selected = false;
						foreach (IToken token in fSelectedTokens)
						{
							CreatureToken ct = token as CreatureToken;
							if (ct == null)
								continue;

							if (cd == ct.Data)
								selected = true;
						}

						bool hovered = false;
						CreatureToken hover_token = fHoverToken as CreatureToken;
						if (hover_token != null)
						{
							if (cd == hover_token.Data)
								hovered = true;
						}

						draw_creature(e.Graphics, cd.Location, slot.Card, cd, selected, hovered, false);
					}
				}
			}

			// Draw heroes
			if (fEncounter != null)
			{
				foreach (Hero h in Session.Project.Heroes)
				//foreach (Guid hero_id in fHeroData.Keys)
				{
					//Hero h = Session.Project.FindHero(hero_id);
					if (h == null)
						continue;

					if (h.CombatData.Location == CombatData.NoPoint)
						continue;

					if ((fDraggedToken != null) && (fDraggedToken.Token is Hero))
					{
						Hero hero = fDraggedToken.Token as Hero;
						if ((h.ID == hero.ID) && (h.CombatData.Location == fDraggedToken.Start))
						{
							if (h.CombatData.Location != fDraggedToken.Location)
							{
								bool has_picture = (h.Portrait != null);
								draw_token_placeholder(e.Graphics, h.CombatData.Location, fDraggedToken.Location, h.Size, has_picture);
							}

							continue;
						}
					}

					bool selected = fSelectedTokens.Contains(h);
					bool hovered = (h == fHoverToken);
					draw_hero(e.Graphics, h.CombatData.Location, h, selected, hovered, false);
				}
			}

			if (fNewToken != null)
			{
				if (fNewToken.Token is CreatureToken)
				{
					// Draw dragged creature
					CreatureToken token = fNewToken.Token as CreatureToken;
					EncounterSlot slot = fEncounter.FindSlot(token.SlotID);
					ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
					draw_creature(e.Graphics, fNewToken.Location, slot.Card, token.Data, true, true, true);
				}

				if (fNewToken.Token is Hero)
				{
					// Draw dragged hero
					Hero hero = fNewToken.Token as Hero;
					draw_hero(e.Graphics, fNewToken.Location, hero, true, true, true);
				}

				if (fNewToken.Token is CustomToken)
				{
					// Draw dragged custom token
					CustomToken ct = fNewToken.Token as CustomToken;
					draw_custom(e.Graphics, fNewToken.Location, ct, true, true, true);
				}
			}

			if (fDraggedToken != null)
			{
				if (fDraggedToken.Token is CreatureToken)
				{
					CreatureToken token = fDraggedToken.Token as CreatureToken;

					EncounterSlot slot = fEncounter.FindSlot(token.SlotID);
					CombatData cd = slot.FindCombatData(fDraggedToken.Start);

					draw_creature(e.Graphics, fDraggedToken.Location, slot.Card, cd, true, true, true);
				}

				if (fDraggedToken.Token is Hero)
				{
					Hero hero = fDraggedToken.Token as Hero;
					draw_hero(e.Graphics, fDraggedToken.Location, hero, true, true, true);
				}

				if (fDraggedToken.Token is CustomToken)
				{
					CustomToken ct = fDraggedToken.Token as CustomToken;
					draw_custom(e.Graphics, fDraggedToken.Location, ct, true, true, true);
				}

				if (fDraggedToken.LinkedToken != null)
				{
					Pen p = new Pen(Color.Red, 2);
					RectangleF rect = get_token_rect(fDraggedToken.LinkedToken);
					e.Graphics.DrawRectangle(p, rect.X, rect.Y, rect.Width, rect.Height);
				}
			}

			#endregion

			#region Link text

			fTokenLinkRegions.Clear();
			if (fTokenLinks != null)
			{
				foreach (TokenLink link in fTokenLinks)
				{
					if (link.Text == "")
						continue;

					IToken lhs = link.Tokens[0];
					IToken rhs = link.Tokens[1];

					CombatData cd_lhs = get_combat_data(lhs);
					CombatData cd_rhs = get_combat_data(rhs);
					if (cd_lhs.Visible && cd_rhs.Visible)
					{
						Point loc_lhs = get_token_location(lhs);
						Point loc_rhs = get_token_location(rhs);

						if ((loc_lhs == CombatData.NoPoint) || (loc_rhs == CombatData.NoPoint))
							continue;

						RectangleF rect_lhs = get_token_rect(lhs);
						RectangleF rect_rhs = get_token_rect(rhs);

						PointF pt_lhs = new PointF((rect_lhs.Left + rect_lhs.Right) / 2, (rect_lhs.Top + rect_lhs.Bottom) / 2);
						PointF pt_rhs = new PointF((rect_rhs.Left + rect_rhs.Right) / 2, (rect_rhs.Top + rect_rhs.Bottom) / 2);

						string str = link.Text;

						float fontsize = Math.Min(Font.Size, fLayoutData.SquareSize / 4);
						using (Font linkfont = new Font(Font.FontFamily, fontsize))
						{
							SizeF text_size = e.Graphics.MeasureString(str, linkfont);
							text_size = new SizeF(text_size.Width * 1.2f, text_size.Height * 1.2f);

							PointF centre = new PointF((pt_lhs.X + pt_rhs.X) / 2, (pt_lhs.Y + pt_rhs.Y) / 2);
							PointF text_pt = new PointF(centre.X - (text_size.Width / 2), centre.Y - (text_size.Height / 2));
							RectangleF text_rect = new RectangleF(text_pt, text_size);

							Pen outline = (link == fHoverTokenLink) ? Pens.Blue : Pens.Navy;

							e.Graphics.FillRectangle(Brushes.White, text_rect);
							e.Graphics.DrawString(str, linkfont, Brushes.Navy, text_rect, fCentred);
							e.Graphics.DrawRectangle(outline, text_rect.X, text_rect.Y, text_rect.Width, text_rect.Height);

							fTokenLinkRegions[link] = text_rect;
						}
					}
				}
			}

			#endregion

			#region Sketches

			foreach (MapSketch sketch in fSketches)
				draw_sketch(e.Graphics, sketch);

			if (fDrawing != null)
			{
				if (fDrawing.CurrentSketch != null)
					draw_sketch(e.Graphics, fDrawing.CurrentSketch);
			}

			#endregion

			#region LOS

			if (fLineOfSight)
			{
				Point mouse = PointToClient(Cursor.Position);
				if (ClientRectangle.Contains(mouse))
				{
					PointF vertex = get_closest_vertex(mouse);

					float radius = Math.Max(fLayoutData.SquareSize / 10, 3);

					foreach (IToken token in fSelectedTokens)
					{
						RectangleF rect = get_token_rect(token);

						List<PointF> points = new List<PointF>();
						points.Add(new PointF(rect.Left, rect.Top));
						points.Add(new PointF(rect.Left, rect.Bottom));
						points.Add(new PointF(rect.Right, rect.Top));
						points.Add(new PointF(rect.Right, rect.Bottom));

						foreach (PointF point in points)
						{
							e.Graphics.DrawLine(Pens.Blue, vertex, point);

							RectangleF point_rect = new RectangleF(point.X - radius, point.Y - radius, radius * 2, radius * 2);
							e.Graphics.FillEllipse(Brushes.LightBlue, point_rect);
							e.Graphics.DrawEllipse(Pens.Blue, point_rect);
						}
					}

					RectangleF vertex_rect = new RectangleF(vertex.X - radius, vertex.Y - radius, radius * 2, radius * 2);
					e.Graphics.FillEllipse(Brushes.LightBlue, vertex_rect);
					e.Graphics.DrawEllipse(Pens.Blue, vertex_rect);
				}
			}

			#endregion

			#region Outlines

			if (fDraggedOutline != null)
			{
				RectangleF rect = fLayoutData.GetRegion(fDraggedOutline.Region.Location, fDraggedOutline.Region.Size);
				e.Graphics.DrawRectangle(Pens.DarkBlue, rect.X, rect.Y, rect.Width, rect.Height);

				string str = fDraggedOutline.Region.Width + "x" + fDraggedOutline.Region.Height;

				SizeF text_size = e.Graphics.MeasureString(str, Font);
				text_size.Width = Math.Min(rect.Width, text_size.Width);
				text_size.Height = Math.Min(rect.Height, text_size.Height);

				float dx = (rect.Width - text_size.Width) / 2;
				float dy = (rect.Height - text_size.Height) / 2;
				RectangleF text_rect = new RectangleF(rect.X + dx, rect.Y + dy, text_size.Width, text_size.Height);

				using (Brush b = new SolidBrush(Color.FromArgb(150, Color.White)))
				{
					e.Graphics.FillRectangle(b, text_rect);
				}

				e.Graphics.DrawString(str, Font, Brushes.DarkBlue, rect, fCentred);
			}

			if (fCurrentOutline != null)
			{
				RectangleF rect = fLayoutData.GetRegion(fCurrentOutline.Location, fCurrentOutline.Size);
				e.Graphics.DrawRectangle(Pens.LightBlue, rect.X, rect.Y, rect.Width, rect.Height);
			}

			#endregion

			#region Frame

			if ((fFrameType != MapDisplayType.None) && (fViewpoint != Rectangle.Empty) && (!fAllowScrolling))
			{
				Color frame_colour = Color.Black;
				if (fMode == MapViewMode.Plain)
					frame_colour = Color.White;

				int frame_alpha = 255;
				switch (fFrameType)
				{
					case MapDisplayType.Dimmed:
						frame_alpha = 160;
						break;
					case MapDisplayType.Opaque:
						frame_alpha = 255;
						break;
				}

				RectangleF rect = fLayoutData.GetRegion(fViewpoint.Location, fViewpoint.Size);

				using (Brush sides = new SolidBrush(Color.FromArgb(frame_alpha, frame_colour)))
				{
					e.Graphics.FillRectangle(sides, 0, 0, ClientRectangle.Width, rect.Top);
					e.Graphics.FillRectangle(sides, 0, rect.Bottom, ClientRectangle.Width, ClientRectangle.Height);
					e.Graphics.FillRectangle(sides, 0, rect.Top, rect.Left, rect.Height);
					e.Graphics.FillRectangle(sides, rect.Right, rect.Top, ClientRectangle.Width - rect.Right, rect.Height);
				}

				if (fHighlightAreas)
					e.Graphics.DrawRectangle(SystemPens.ControlLight, rect.X, rect.Y, rect.Width, rect.Height);
			}

			#endregion

			#region Caption

			string caption = fCaption;
			if (caption == "")
			{
				if ((fMode == MapViewMode.Normal) && (fMap.Areas.Count == 0))
					caption = "To create map areas (rooms etc), right-click on the map and drag.";
				if (fMap.Name == "")
					caption = "You need to give this map a name.";
				if ((fMode == MapViewMode.Normal) && (fMap.Tiles.Count == 0))
					caption = "To begin, drag tiles from the list on the right onto the blueprint.";
				if (fAllowScrolling)
					caption = "Map is in scroll / zoom mode; double-click to return to tactical mode.";
				if (fDrawing != null)
					caption = "Map is in drawing mode; double-click to return to tactical mode.";
				if (fLineOfSight)
					caption = "Map is in line of sight mode; select tokens to check sightlines, or double-click to return to tactical mode.";

				if (fDraggedToken != null)
				{
					if (fDraggedToken.LinkedToken != null)
					{
						TokenLink link = find_link(fDraggedToken.Token, fDraggedToken.LinkedToken);
						if (link == null)
						{
							caption = "Release here to create a link.";
						}
						else
						{
							string linktext = (link.Text == "") ? "link" : "'" + link.Text + "' link";
							caption = "Release here to remove the " + linktext + ".";
						}
					}
				}
			}

			if (caption != "")
			{
				float delta = 10;
				float width = ClientRectangle.Width - (2 * delta);
				SizeF size = e.Graphics.MeasureString(caption, Font, (int)width);
				float height = size.Height * 2;

				RectangleF rect = new RectangleF(delta, delta, width, height);
				GraphicsPath path = RoundedRectangle.Create(rect, height / 3);
				using (Brush b = new SolidBrush(Color.FromArgb(200, Color.Black)))
				{
					e.Graphics.FillPath(b, path);
				}
				e.Graphics.DrawPath(Pens.Black, path);
				e.Graphics.DrawString(caption, Font, Brushes.White, rect, fCentred);
			}

			#endregion
		}

		void draw_grid_label(Graphics g, string str, Font font, RectangleF rect, StringFormat sf)
		{
			for (int dx = -2; dx <= 2; ++dx)
			{
				for (int dy = -2; dy <= 2; ++dy)
				{
					RectangleF outline_rect = new RectangleF(rect.X + dx, rect.Y + dy, rect.Width, rect.Height);
					using (Brush outline = new SolidBrush(Color.FromArgb(50, Color.White)))
					{
						g.DrawString(str, font, outline, outline_rect, sf);
					}
				}
			}

			g.DrawString(str, font, Brushes.Black, rect, sf);
		}

		void draw_tile(Graphics g, Tile tile, int rotation, RectangleF rect, bool ghost)
		{
			try
			{
				Image tile_img = tile.Image;
				if (tile_img == null)
					tile_img = tile.BlankImage;

				ImageAttributes ia = new ImageAttributes();
				if (ghost)
				{
					ColorMatrix cm = new ColorMatrix();
					cm.Matrix33 = 0.4F;
					ia.SetColorMatrix(cm);
				}

				Rectangle tile_rect = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);

				int turns = rotation % 4;
				switch (turns)
				{
					case 0:
						{
							using (Bitmap img = new Bitmap(tile_img))
							{
								g.DrawImage(img, tile_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
							}
						}
						break;
					case 1:
						{
							using (Bitmap img = new Bitmap(tile_img))
							{
								img.RotateFlip(RotateFlipType.Rotate90FlipNone);
								g.DrawImage(img, tile_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
								//img.RotateFlip(RotateFlipType.RotateNoneFlipNone);
							}
						}
						break;
					case 2:
						{
							using (Bitmap img = new Bitmap(tile_img))
							{
								img.RotateFlip(RotateFlipType.Rotate180FlipNone);
								g.DrawImage(img, tile_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
								//img.RotateFlip(RotateFlipType.RotateNoneFlipNone);
							}
						}
						break;
					case 3:
						{
							using (Bitmap img = new Bitmap(tile_img))
							{
								img.RotateFlip(RotateFlipType.Rotate270FlipNone);
								g.DrawImage(img, tile_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
								//img.RotateFlip(RotateFlipType.RotateNoneFlipNone);
							}
						}
						break;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void draw_creature(Graphics g, Point pt, EncounterCard card, CombatData data, bool selected, bool hovered, bool ghost)
		{
			ICreature creature = Session.FindCreature(card.CreatureID, SearchType.Global);
			if (creature == null)
				return;

			Color c = Color.Black;

			if (creature is NPC)
				c = Color.DarkBlue;

			if (data != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(data);
				CreatureState state = slot.GetState(data);
				switch (state)
				{
					case CreatureState.Bloodied:
						c = Color.Maroon;
						break;
					case CreatureState.Defeated:
						c = Color.Gray;
						break;
				}
			}

			bool boxed = false;
			foreach (IToken token in fBoxedTokens)
			{
				if (token is CreatureToken)
				{
					CreatureToken ct = token as CreatureToken;
					if (ct.Data.ID == data.ID)
					{
						boxed = true;
						break;
					}
				}
			}

			bool visible = data.Visible;
			if ((!visible) && (fShowCreatures == CreatureViewMode.Visible))
				return;

			string name = "";
			if (fShowCreatureLabels)
			{
				name = data.DisplayName;
			}
			else
			{
				name = creature.Category;
			}
			string caption = TextHelper.Abbreviation(name);

			ghost = ghost || !visible;
			draw_token(g, pt, creature.Size, creature.Image, c, caption, selected, boxed, hovered, ghost, data.Conditions, data.Altitude);

			if ((fShowHealthBars) && (data != null))
			{
				int creature_size = Creature.GetSize(creature.Size);
				Size size = new Size(creature_size, creature_size);

				RectangleF rect = fLayoutData.GetRegion(pt, size);
				draw_health_bar(g, rect, data, card.HP);
			}
		}

		void draw_hero(Graphics g, Point pt, Hero hero, bool selected, bool hovered, bool ghost)
		{
			Color c = Color.FromArgb(0, 80, 0);

			//CombatData data = hero.CombatData;
			//if ((fHeroData != null) && (fHeroData.ContainsKey(hero.ID)))
			{
				//data = fHeroData[hero.ID];
				//if (data != null)
				{
					int hp_max = hero.HP;
					if (hp_max != 0)
					{
						int hp_bloodied = hp_max / 2;
						int hp_current = hp_max + hero.CombatData.TempHP - hero.CombatData.Damage;

						if (hp_current <= 0)
							c = Color.Gray;
						else if (hp_current <= hp_max / 2)
							c = Color.Maroon;
					}
				}
			}

			bool boxed = fBoxedTokens.Contains(hero);
			string caption = TextHelper.Abbreviation(hero.Name);

			bool visible = true;
			if ((!visible) && (fShowCreatures == CreatureViewMode.Visible))
				return;

			ghost = ghost || !visible;
			draw_token(g, pt, hero.Size, hero.Portrait, c, caption, selected, boxed, hovered, ghost, hero.CombatData.Conditions, hero.CombatData.Altitude);

			if ((fShowHealthBars) && (hero.CombatData != null) && (hero.HP != 0))
			{
				int sz = Creature.GetSize(hero.Size);
				Size size = new Size(sz, sz);

				RectangleF rect = fLayoutData.GetRegion(pt, size);
				draw_health_bar(g, rect, hero.CombatData, hero.HP);
			}
		}

		void draw_custom(Graphics g, Point pt, CustomToken ct, bool selected, bool hovered, bool ghost)
		{
			bool boxed = fBoxedTokens.Contains(ct);
			string caption = TextHelper.Abbreviation(ct.Name);

			bool visible = ct.Data.Visible;
			if ((!visible) && (fShowCreatures == CreatureViewMode.Visible))
				return;

			switch (ct.Type)
			{
				case CustomTokenType.Token:
					{
						ghost = ghost || !visible;
						List<OngoingCondition> conditions = new List<OngoingCondition>();
						draw_token(g, pt, ct.TokenSize, ct.Image, ct.Colour, caption, selected, boxed, hovered, ghost, conditions, 0);
					}
					break;
				case CustomTokenType.Overlay:
					{
						RectangleF rect = fLayoutData.GetRegion(pt, ct.OverlaySize);

						RoundedRectangle.RectangleCorners corners = RoundedRectangle.RectangleCorners.All;
						int alpha = boxed ? 220 : 140;
						if (ct.OverlayStyle == OverlayStyle.Block)
						{
							corners = RoundedRectangle.RectangleCorners.None;
							alpha = 255;
						}

						float rounding = fLayoutData.SquareSize * 0.3f;
						GraphicsPath path = RoundedRectangle.Create(rect, rounding, corners);

						if (ct.Image == null)
						{
							using (Brush b = new SolidBrush(Color.FromArgb(alpha, ct.Colour)))
							{
								g.FillPath(b, path);
							}

							if (fShowCreatureLabels)
							{
								Pen p = (selected || hovered) ? Pens.White : new Pen(ct.Colour);
								g.DrawPath(p, path);
							}
						}
						else
						{
							if (ct.OverlayStyle == OverlayStyle.Rounded)
							{
								ColorMatrix cm = new ColorMatrix();
								cm.Matrix33 = 0.4F;

								ImageAttributes ia = new ImageAttributes();
								ia.SetColorMatrix(cm);

								Rectangle img_rect = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
								g.SetClip(path);
								g.DrawImage(ct.Image, img_rect, 0, 0, ct.Image.Width, ct.Image.Height, GraphicsUnit.Pixel, ia);
								g.ResetClip();
							}
							else
							{
								g.DrawImage(ct.Image, rect);
							}

							bool outline = (selected || hovered);
							if (outline && fShowCreatureLabels)
							{
								using (Pen p = new Pen(Color.FromArgb(alpha, Color.White)))
								{
									g.DrawPath(p, path);
								}
							}
						}

						#region Difficult terrain

						if (ct.DifficultTerrain)
						{
							for (int x = pt.X; x < (pt.X + ct.OverlaySize.Width); ++x)
							{
								for (int y = pt.Y; y < (pt.Y + ct.OverlaySize.Height); ++y)
								{
									// Draw difficult terrain mark

									RectangleF square = fLayoutData.GetRegion(new Point(x, y), new Size(1, 1));
									float delta = square.Width / 10;
									float side = square.Width / 5;

									float x_right = square.X + square.Width - delta;
									float y_bottom = square.Y + side + delta;

									PointF top = new PointF(x_right - (side / 2), y_bottom - side);
									PointF left = new PointF(x_right - side, y_bottom);
									PointF right = new PointF(x_right, y_bottom);

									using (Brush b = new SolidBrush(Color.FromArgb(180, Color.White)))
									{
										g.FillPolygon(b, new PointF[] { top, left, right });
									}

									g.DrawPolygon(Pens.DarkGray, new PointF[] { top, left, right });
								}
							}
						}

						#endregion

						#region Label

						if ((fSelectedTokens.Contains(ct)) && (fShowCreatureLabels))
						{
							StringFormat format = fCentred;
							if (rect.Height > rect.Width)
							{
								format = new StringFormat(fCentred);
								format.FormatFlags = format.FormatFlags | StringFormatFlags.DirectionVertical;
							}

							using (Font f = new Font(Font.FontFamily, fLayoutData.SquareSize / 5))
							{
								SizeF text_size = g.MeasureString(ct.Name, f, rect.Size, format);
								text_size += new SizeF(4F, 4F);

								RectangleF text_rect = new RectangleF(rect.X + (rect.Width - text_size.Width) / 2, rect.Y + (rect.Height - text_size.Height) / 2, text_size.Width, text_size.Height);

								g.DrawRectangle(Pens.Black, text_rect.X, text_rect.Y, text_rect.Width, text_rect.Height);

								using (Brush brush = new SolidBrush(Color.FromArgb(210, Color.White)))
								{
									g.FillRectangle(brush, text_rect);
								}

								g.DrawString(ct.Name, f, Brushes.Black, text_rect, format);
							}
						}

						#endregion
					}
					break;
			}
		}

		void draw_token(Graphics g, Point pt, CreatureSize size, Image img, Color c, string text, bool selected, bool boxed, bool hovered, bool ghost, List<OngoingCondition> conditions, int altitude)
		{
			try
			{
				int sz = Creature.GetSize(size);

				RectangleF square_rect = fLayoutData.GetRegion(pt, new Size(sz, sz));
				RectangleF token_rect = square_rect;

				if (boxed)
				{
					g.FillRectangle(Brushes.Blue, token_rect);
				}

				if ((size == CreatureSize.Small) || (size == CreatureSize.Tiny))
				{
					float delta = token_rect.Width / 7;
					token_rect = new RectangleF(token_rect.X + delta, token_rect.Y + delta, token_rect.Width - (2 * delta), token_rect.Height - (2 * delta));
				}

				if (img == null)
				{
					Pen outline = Pens.White;
					if (selected || hovered)
						outline = Pens.Red;

					float delta = 2;
					RectangleF inner = new RectangleF(token_rect.X + delta, token_rect.Y + delta, token_rect.Width - (2 * delta), token_rect.Height - (2 * delta));

					int alpha = ghost ? 140 : 255;
					using (Brush b = new SolidBrush(Color.FromArgb(alpha, c)))
					{
						g.FillEllipse(b, token_rect);
					}

					g.DrawEllipse(outline, inner);

					// Label it
					float font_size = (fLayoutData.SquareSize * sz) / 6;
					if (font_size > 0)
					{
						using (Font f = new Font(Font.FontFamily, font_size))
						{
							g.DrawString(text, f, Brushes.White, token_rect, fCentred);
						}
					}
				}
				else
				{
					ImageAttributes ia = new ImageAttributes();
					if (ghost)
					{
						ColorMatrix cm = new ColorMatrix();
						cm.Matrix33 = 0.4F;
						ia.SetColorMatrix(cm);
					}

					Rectangle img_rect = new Rectangle((int)token_rect.X, (int)token_rect.Y, (int)token_rect.Width, (int)token_rect.Height);

					if (fShowPictureTokens)
					{
						float rounding = Math.Min(token_rect.Width, fLayoutData.SquareSize) * 0.5f;
						GraphicsPath path = RoundedRectangle.Create(token_rect, rounding);

						g.SetClip(path);
						g.DrawImage(img, img_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
						g.ResetClip();

						Color border_colour = Color.Black;
						float border_width = 2;
						if (selected || hovered)
						{
							border_colour = Color.Red;
							border_width = 1;
						}

						using (Pen border = new Pen(border_colour, border_width))
						{
							g.DrawPath(border, path);
						}

						if (c == Color.Maroon)
						{
							Color overlay = Color.FromArgb(100, Color.Red);
							using (Brush b = new SolidBrush(overlay))
							{
								g.FillPath(b, path);
							}
						}
					}
					else
					{
						// Just draw the image
						g.DrawImage(img, img_rect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);

						if (c == Color.Maroon)
						{
							Color overlay = Color.FromArgb(100, Color.Red);
							using (Brush b = new SolidBrush(overlay))
							{
								g.FillRectangle(b, img_rect);
							}
						}
					}
				}

				if (boxed)
				{
					using (Pen p = new Pen(Color.White, 2))
					{
						g.DrawRectangle(p, square_rect.X, square_rect.Y, square_rect.Width, square_rect.Height);
					}
				}

				if ((fShowConditions) && (conditions.Count != 0))
				{
					// Get badge size
					float diameter = fLayoutData.SquareSize * 0.4f;

					// Get badge location
					PointF badge_topleft = new PointF(square_rect.Right - diameter, square_rect.Top);

					// Get badge rectangle
					RectangleF badge_rect = new RectangleF(badge_topleft.X, badge_topleft.Y, diameter, diameter);

					// Draw badge
					using (Brush b = new SolidBrush(Color.FromArgb(200, 0, 0)))
					{
						g.FillEllipse(b, badge_rect);
					}
					using (Font font = new Font(Font.FontFamily, diameter / 3, Font.Style | FontStyle.Bold))
					{
						g.DrawString(conditions.Count.ToString(), font, Brushes.White, badge_rect, fCentred);
					}
					using (Pen p = new Pen(Color.White, 2))
					{
						g.DrawEllipse(p, badge_rect);
					}
				}

				if (altitude != 0)
				{
					// Get badge size
					float diameter = fLayoutData.SquareSize * 0.4f;

					// Get badge location
					PointF badge_topleft = new PointF(square_rect.Left, square_rect.Top);

					// Get badge rectangle
					RectangleF badge_rect = new RectangleF(badge_topleft.X, badge_topleft.Y, diameter, diameter);

					string alt = (altitude > 0 ? "↑" : "↓") + Math.Abs(altitude);

					// Draw badge
					using (Brush b = new SolidBrush(Color.FromArgb(80, 80, 80)))
					{
						g.FillEllipse(b, badge_rect);
					}
					using (Font font = new Font(Font.FontFamily, diameter / 3, Font.Style | FontStyle.Bold))
					{
						g.DrawString(alt, font, Brushes.White, badge_rect, fCentred);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void draw_token_placeholder(Graphics g, Point start_location, Point new_location, CreatureSize size, bool has_picture)
		{
			int sz = Creature.GetSize(size);

			RectangleF start_rect = fLayoutData.GetRegion(start_location, new Size(sz, sz));
			RectangleF new_rect = fLayoutData.GetRegion(new_location, new Size(sz, sz));

			if ((size == CreatureSize.Small) || (size == CreatureSize.Tiny))
			{
				float d = start_rect.Width / 7;
				start_rect = new RectangleF(start_rect.X + d, start_rect.Y + d, start_rect.Width - (2 * d), start_rect.Height - (2 * d));
			}

			int delta = 2;
			RectangleF inner = new RectangleF(start_rect.X + delta, start_rect.Y + delta, start_rect.Width - (2 * delta), start_rect.Height - (2 * delta));

			if (has_picture)
			{
				float rounding = Math.Min(start_rect.Width, fLayoutData.SquareSize) * 0.5f;
				GraphicsPath path = RoundedRectangle.Create(start_rect, rounding);

				using (Brush b = new SolidBrush(Color.FromArgb(180, Color.White)))
				{
					g.FillPath(b, path);
					g.DrawPath(Pens.Red, path);
				}
			}
			else
			{
				using (Brush b = new SolidBrush(Color.FromArgb(180, Color.White)))
				{
					g.FillEllipse(b, inner);
					g.DrawEllipse(Pens.Red, inner);
				}
			}

			using (Font f = new Font(Font.FontFamily, (fLayoutData.SquareSize * sz) / 4))
			{
				int squares = get_distance(start_location, new_location);
				g.DrawString(squares.ToString(), f, Brushes.Red, inner, fCentred);
			}

			PointF from_pt = new PointF(start_rect.X + (start_rect.Width / 2), start_rect.Y + (start_rect.Height / 2));
			PointF to_pt = new PointF(new_rect.X + (new_rect.Width / 2), new_rect.Y + (new_rect.Height / 2));

			double radius = inner.Width / 2;
			if (new_location.X == start_location.X)
			{
				from_pt.Y += (new_location.Y > start_location.Y) ? (float)radius : -(float)radius;
				to_pt.Y += (new_location.Y > start_location.Y) ? -(float)radius : (float)radius;
			}
			else
			{
				double theta = Math.Atan((double)(new_location.Y - start_location.Y) / (double)(new_location.X - start_location.X));
				float x = (float)(radius * Math.Cos(theta));
				float y = (float)(radius * Math.Sin(theta));

				from_pt.X += (new_location.X > start_location.X) ? x : -x;
				from_pt.Y += (new_location.X > start_location.X) ? y : -y;

				to_pt.X += (new_location.X > start_location.X) ? -x : x;
				to_pt.Y += (new_location.X > start_location.X) ? -y : y;
			}

			g.DrawLine(Pens.Red, from_pt, to_pt);
		}

		void draw_sketch(Graphics g, MapSketch sketch)
		{
			using (Pen p = new Pen(sketch.Colour, sketch.Width))
			{
				for (int index = 1; index < sketch.Points.Count; ++index)
				{
					PointF pt1 = get_point(sketch.Points[index - 1]);
					PointF pt2 = get_point(sketch.Points[index]);

					g.DrawLine(p, pt1, pt2);
				}
			}
		}

		void draw_health_bar(Graphics g, RectangleF rect, CombatData data, int hp_full)
		{
			int hp_max = hp_full + data.TempHP;
			int hp_current = hp_full - data.Damage;

			Color bar_colour = Color.Green;
			if (hp_current <= 0)
				bar_colour = Color.Black;
			int hp_bloodied = hp_full / 2;
			if (hp_current <= hp_bloodied)
				bar_colour = Color.Maroon;

			hp_current = Math.Max(hp_current, 0);
			float thp_fraction = (float)(hp_current + data.TempHP) / hp_max;
			float hp_fraction = (float)(hp_current) / hp_max;

			float bar_height = Math.Max(rect.Height / 12, 4);
			RectangleF bar_rect = new RectangleF(rect.X, rect.Bottom - bar_height, rect.Width, bar_height);
			g.FillRectangle(Brushes.White, bar_rect);

			if (data.TempHP > 0)
			{
				RectangleF thp_rect = new RectangleF(bar_rect.X, bar_rect.Y, bar_rect.Width * thp_fraction, bar_rect.Height);
				g.FillRectangle(Brushes.Blue, thp_rect);
			}

			using (Brush b = new SolidBrush(bar_colour))
			{
				RectangleF hp_rect = new RectangleF(bar_rect.X, bar_rect.Y, bar_rect.Width * hp_fraction, bar_rect.Height);
				g.FillRectangle(b, hp_rect);
			}

			g.DrawRectangle(Pens.Black, bar_rect.X, bar_rect.Y, bar_rect.Width, bar_rect.Height);
		}

		#endregion

		#region Mouse

		/// <summary>
		/// Called in response to the MouseDown event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			try
			{
				Focus();

				if (fMap == null)
					return;

				if (fLayoutData == null)
					fLayoutData = new MapData(this, fScalingFactor);

				if (fDrawing != null)
				{
					if (fDrawing.CurrentSketch == null)
						fDrawing.CurrentSketch = new MapSketch();

					return;
				}

				Point cursor = PointToClient(Cursor.Position);
				Point square = fLayoutData.GetSquareAtPoint(cursor);

				if (fAllowScrolling)
				{
					if (fViewpoint == Rectangle.Empty)
					{
						// Set the zoom area
						fViewpoint = get_current_zoom_rect(true);

						fLayoutData = null;
						Invalidate();
					}

					// Start scrolling
					fScrollingData = new ScrollingData();
					fScrollingData.Start = square;

					return;
				}

				if (fTactical && (fEncounter != null))
				{
					// Is there a creature here?
					Pair<IToken, Rectangle> slot_data = get_token_at(square);
					if (slot_data != null)
					{
						bool shift = (ModifierKeys & Keys.Shift) == Keys.Shift;
						bool ctrl = (ModifierKeys & Keys.Control) == Keys.Control;
						bool right = e.Button == MouseButtons.Right;

						CreatureToken creature = slot_data.First as CreatureToken;
						CustomToken custom = slot_data.First as CustomToken;
						if ((creature != null) && (!is_visible(creature.Data)))
						{
							if (!shift && !ctrl && !right)
								fSelectedTokens.Clear();
						}
						else if ((custom != null) && (!is_visible(custom.Data)))
						{
							if (!shift && !ctrl && !right)
								fSelectedTokens.Clear();
						}
						else if ((custom != null) && (custom.CreatureID != Guid.Empty))
						{
							if (!shift && !ctrl && !right)
								fSelectedTokens.Clear();
						}
						else
						{
							if (shift || ctrl)
							{
								if (e.Button == MouseButtons.Left)
								{
									// Add to / remove from highlighted tokens

									bool was_selected = false;
									foreach (IToken token in fSelectedTokens)
									{
										if (get_token_location(token) == get_token_location(slot_data.First))
										{
											was_selected = true;
											fSelectedTokens.Remove(token);
											break;
										}
									}

									if (!was_selected)
										fSelectedTokens.Add(slot_data.First);

									OnSelectedTokensChanged();
								}
							}
							else
							{
								// Begin dragging it
								fDraggedToken = new DraggedToken();
								fDraggedToken.Token = slot_data.First;
								fDraggedToken.Start = slot_data.Second.Location;
								fDraggedToken.Location = fDraggedToken.Start;
								fDraggedToken.Offset = new Size(square.X - slot_data.Second.Location.X, square.Y - slot_data.Second.Location.Y);

								// Is this token selected?
								bool selected = false;
								CombatData cd1 = get_combat_data(slot_data.First);
								foreach (IToken token in fSelectedTokens)
								{
									CombatData cd2 = get_combat_data(token);

									if (cd1.ID == cd2.ID)
									{
										selected = true;
										break;
									}
								}

								if (!selected)
								{
									fSelectedTokens.Clear();
									fSelectedTokens.Add(slot_data.First);

									OnSelectedTokensChanged();
								}
							}
						}
					}
					else
					{
						fSelectedTokens.Clear();
						OnSelectedTokensChanged();
					}
				}

				if (fMode != MapViewMode.Normal)
					return;

				// Set selected tile
				if (fSelectedTiles == null)
					fSelectedTiles = new List<TileData>();
				bool add_to_selection = ((ModifierKeys == Keys.Control) || (ModifierKeys == Keys.Shift));
				if (!add_to_selection)
					fSelectedTiles.Clear();
				TileData td = fLayoutData.GetTileAtSquare(square);
				if ((td != null) && (fMap.Tiles.Contains(td)))
					fSelectedTiles.Add(td);

				switch (e.Button)
				{
					case MouseButtons.Left:
						{
							if (fSelectedTiles.Count != 0)
							{
								// Start dragging
								fDraggedTiles = new DraggedTiles();
								fDraggedTiles.Tiles = fSelectedTiles;
								fDraggedTiles.Start = cursor;
							}
						}
						break;
					case MouseButtons.Right:
						{
							// Draw region outline
							fCurrentOutline = Rectangle.Empty;
							fDraggedOutline = new DraggedOutline();
							fDraggedOutline.Start = cursor;
							fDraggedOutline.Region = new Rectangle(square, new Size(1, 1));
						}
						break;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the MouseMove event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			try
			{
				if (fMap == null)
					return;

				if (fLayoutData == null)
					fLayoutData = new MapData(this, fScalingFactor);

				Point cursor = PointToClient(Cursor.Position);
				Point square = fLayoutData.GetSquareAtPoint(cursor);

				if (fDrawing != null)
				{
					if (fDrawing.CurrentSketch != null)
					{
						RectangleF square_rect = fLayoutData.GetRegion(square, new Size(1, 1));
						float dx = (cursor.X - square_rect.X) / square_rect.Width;
						float dy = (cursor.Y - square_rect.Y) / square_rect.Height;

						MapSketchPoint msp = new MapSketchPoint();
						msp.Square = square;
						msp.Location = new PointF(dx, dy);

						PointF pt = get_point(msp);
						Console.WriteLine(pt);

						fDrawing.CurrentSketch.Points.Add(msp);
						Invalidate();
					}

					return;
				}

				if (fAllowScrolling)
				{
					if (fScrollingData != null)
					{
						if (fViewpoint != Rectangle.Empty)
						{
							if (fScrollingData.Start != square)
							{
								int dx = fScrollingData.Start.X - square.X;
								int dy = fScrollingData.Start.Y - square.Y;

								fViewpoint.X += dx;
								fViewpoint.Y += dy;

								fLayoutData = null;
								Invalidate();
							}
						}
					}

					return;
				}

				if (fTactical)
				{
					bool hover_changed = false;

					if (fDraggedToken == null)
					{
						if ((ModifierKeys & Keys.Control) == Keys.Control)
						{
							// Ignore this
						}
						else
						{
							fHoverTokenLink = null;
							foreach (TokenLink link in fTokenLinkRegions.Keys)
							{
								RectangleF rect = fTokenLinkRegions[link];
								if (rect.Contains(cursor))
									fHoverTokenLink = link;
							}

							Pair<IToken, Rectangle> slot_data = get_token_at(square);
							if (slot_data != null)
							{
								CreatureToken creature = slot_data.First as CreatureToken;
								CustomToken custom = slot_data.First as CustomToken;
								if ((creature != null) && (!is_visible(creature.Data)))
								{
									// Ignore this
								}
								else if ((custom != null) && (!is_visible(custom.Data)))
								{
									// Ignore this
								}
								else
								{
									if (fHoverToken == null)
									{
										hover_changed = true;
									}
									else
									{
										if (slot_data.First is CreatureToken)
										{
											CreatureToken token1 = fHoverToken as CreatureToken;
											CreatureToken token2 = slot_data.First as CreatureToken;

											hover_changed = ((token1 == null) || (token1.Data.ID != token2.Data.ID));
										}

										if (slot_data.First is CustomToken)
										{
											CustomToken token1 = fHoverToken as CustomToken;
											CustomToken token2 = slot_data.First as CustomToken;

											hover_changed = ((token1 == null) || (token1.Data.ID != token2.Data.ID));
										}

										if (slot_data.First is Hero)
										{
											Hero token1 = fHoverToken as Hero;
											Hero token2 = slot_data.First as Hero;

											hover_changed = ((token1 == null) || (token1.ID != token2.ID));
										}
									}

									//fHighlightedTokens.Clear();
									//fHighlightedTokens.Add(slot_data.First);

									fHoverToken = slot_data.First;
								}
							}
							else
							{
								//hover_changed = (fHighlightedTokens.Count != 0);
								//fHighlightedTokens.Clear();

								if (fHoverToken != null)
								{
									hover_changed = true;
									fHoverToken = null;
								}
							}
						}
					}

					if (fDraggedToken != null)
					{
						fDraggedToken.LinkedToken = null;

						Point pt = square - fDraggedToken.Offset;
						Size size = get_token_size(fDraggedToken.Token);
						Rectangle creature_rect = new Rectangle(pt, size);

						CustomToken ct = fDraggedToken.Token as CustomToken;
						bool dragging_overlay = ((ct != null) && (ct.Type == CustomTokenType.Overlay));

						if ((dragging_overlay) || (allow_creature_move(creature_rect, fDraggedToken.Start)))
						{
							fDraggedToken.Location = pt;
							OnTokenDragged();
						}
						else if (fAllowLinkCreation)
						{
							Pair<IToken, Rectangle> slot_data = get_token_at(square);
							if (slot_data != null)
							{
								fDraggedToken.Location = fDraggedToken.Start;
								fDraggedToken.LinkedToken = slot_data.First;
								OnTokenDragged();
							}
						}
					}

					if (hover_changed)
						OnHoverTokenChanged();

					Invalidate();
				}

				MapArea hover_area = null;
				foreach (MapArea area in fMap.Areas)
				{
					if (area.Region.Contains(square))
						hover_area = area;
				}

				if (fHighlightedArea != hover_area)
				{
					fHighlightedArea = hover_area;
					OnHighlightedAreaChanged();

					Invalidate();
				}

				if (fMode != MapViewMode.Normal)
					return;

				if (fDraggedTiles != null)
				{
					// Move selected tiles

					foreach (TileData td in fDraggedTiles.Tiles)
					{
						Tile t = fLayoutData.Tiles[td];

						int dx = (int)((cursor.X - fDraggedTiles.Start.X) / fLayoutData.SquareSize);
						int dy = (int)((cursor.Y - fDraggedTiles.Start.Y) / fLayoutData.SquareSize);
						fDraggedTiles.Offset = new Size(dx, dy);

						Point sq = new Point(td.Location.X + dx, td.Location.Y + dy);
						Size tilesize = t.Size;
						if (td.Rotations % 2 != 0)
							tilesize = new Size(t.Size.Height, t.Size.Width);
						fDraggedTiles.Region = fLayoutData.GetRegion(sq, tilesize);
					}

					Invalidate();
				}
				else if (fDraggedOutline != null)
				{
					// Update region outline

					Point start_square = fLayoutData.GetSquareAtPoint(fDraggedOutline.Start);
					Point current_square = fLayoutData.GetSquareAtPoint(cursor);

					int x = Math.Min(current_square.X, start_square.X);
					int y = Math.Min(current_square.Y, start_square.Y);
					int width = Math.Abs(current_square.X - start_square.X) + 1;
					int height = Math.Abs(current_square.Y - start_square.Y) + 1;

					fDraggedOutline.Region = new Rectangle(x, y, width, height);

					Invalidate();
				}
				else
				{
					fHoverTile = fLayoutData.GetTileAtSquare(square);

					Invalidate();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the MouseUp event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			try
			{
				if (fMap == null)
					return;

				if (fLayoutData == null)
					fLayoutData = new MapData(this, fScalingFactor);

				if (fDrawing != null)
				{
					if (fDrawing.CurrentSketch != null)
					{
						fSketches.Add(fDrawing.CurrentSketch);
						OnSketchCreated(fDrawing.CurrentSketch);
					}

					fDrawing.CurrentSketch = null;
					Invalidate();

					return;
				}

				Point cursor = PointToClient(Cursor.Position);

				if (fScrollingData != null)
				{
					if (fViewpoint != Rectangle.Empty)
					{
						// Set the new zoom rectangle
						fViewpoint = get_current_zoom_rect(true);

						fLayoutData = null;
						Invalidate();
					}

					// Stop scrolling
					fScrollingData = null;

					return;
				}

				if (fTactical)
				{
					if ((fDraggedToken != null) && (fDraggedToken.Location != fDraggedToken.Start))
					{
						// Finish dragging the token
						int distance = get_distance(fDraggedToken.Location, fDraggedToken.Start);

						if (fDraggedToken.Token is CreatureToken)
						{
							CreatureToken token = fDraggedToken.Token as CreatureToken;
							EncounterSlot slot = fEncounter.FindSlot(token.SlotID);
							CombatData cd = slot.FindCombatData(fDraggedToken.Start);
							cd.Location = fDraggedToken.Location;
						}

						if (fDraggedToken.Token is Hero)
						{
							Hero hero = fDraggedToken.Token as Hero;
							//fHeroData[hero.ID].Location = fDraggedToken.Location;
							hero.CombatData.Location = fDraggedToken.Location;
						}

						if (fDraggedToken.Token is CustomToken)
						{
							CustomToken ct = fDraggedToken.Token as CustomToken;
							ct.Data.Location = fDraggedToken.Location;
						}

						fDraggedToken = null;
						OnItemMoved(distance);
					}

					if ((fDraggedToken != null) && (fDraggedToken.LinkedToken != null))
					{
						//RectangleF r1 = get_token_rect(fDraggedToken.Token);
						//RectangleF r2 = get_token_rect(fDraggedToken.LinkedToken);

						TokenLink current_link = find_link(fDraggedToken.Token, fDraggedToken.LinkedToken);

						/*
						foreach (TokenLink link in fTokenLinks)
						{
							RectangleF r3 = get_token_rect(link.Tokens[0]);
							RectangleF r4 = get_token_rect(link.Tokens[1]);

							bool first = ((r1 == r3) || (r2 == r3));
							bool second = ((r1 == r4) || (r2 == r4));
							if (first && second)
							{
								current_link = link;
								break;
							}
						}
						*/

						if (current_link == null)
						{
							if (fDraggedToken.Token != fDraggedToken.LinkedToken)
							{
								// Add a link between these tokens
								List<IToken> tokens = new List<IToken>();
								tokens.Add(fDraggedToken.Token);
								tokens.Add(fDraggedToken.LinkedToken);

								TokenLink link = OnCreateTokenLink(tokens);
								if (link != null)
									fTokenLinks.Add(link);
							}
						}
						else
						{
							fTokenLinks.Remove(current_link);
						}

						fDraggedToken = null;
					}

					fDraggedToken = null;
					OnTokenDragged();

					Invalidate();
				}

				Point square = fLayoutData.GetSquareAtPoint(cursor);
				MapArea selected_area = null;
				foreach (MapArea area in fMap.Areas)
				{
					if (area.Region.Contains(square))
						selected_area = area;
				}
				if (fSelectedArea != selected_area)
				{
					fSelectedArea = selected_area;
					OnAreaSelected(fSelectedArea);

					Invalidate();
				}

				if (fMode != MapViewMode.Normal)
					return;

				if (fDraggedTiles != null)
				{
					// Did we drag it at all?
					if (cursor != fDraggedTiles.Start)
					{
						int distance = get_distance(cursor, fDraggedTiles.Start);

						foreach (TileData td in fDraggedTiles.Tiles)
						{
							// Finish dragging the tile
							int x = td.Location.X + fDraggedTiles.Offset.Width;
							int y = td.Location.Y + fDraggedTiles.Offset.Height;
							td.Location = new Point(x, y);

							// Move it to the end of the list
							fMap.Tiles.Remove(td);
							fMap.Tiles.Add(td);
						}

						OnItemMoved(distance);
					}

					fDraggedTiles = null;

					fLayoutData = null;
					Invalidate();
				}
				else if (fDraggedOutline != null)
				{
					// Did we drag it at all?
					if (cursor != fDraggedOutline.Start)
					{
						// Set the outline
						fCurrentOutline = fDraggedOutline.Region;
						OnRegionSelected();
					}
					else
					{
						Point pt = fLayoutData.GetSquareAtPoint(cursor);
						TileData td = fLayoutData.GetTileAtSquare(pt);
						if (td != null)
						{
							fSelectedTiles = new List<TileData>();
							fSelectedTiles.Add(td);

							OnTileContext(td);
						}
					}

					fDraggedOutline = null;

					Invalidate();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the MouseLeave event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
			try
			{
				if (fDrawing != null)
				{
					if (fDrawing.CurrentSketch != null)
					{
						fSketches.Add(fDrawing.CurrentSketch);
						OnSketchCreated(fDrawing.CurrentSketch);
					}

					fDrawing.CurrentSketch = null;
					Invalidate();

					return;
				}

				if (fAllowScrolling)
					return;

				if (fTactical)
				{
					fDraggedToken = null;
					OnTokenDragged();

					Invalidate();
				}

				if (fMode != MapViewMode.Normal)
					return;

				fHoverTile = null;
				fHoverToken = null;
				fHoverTokenLink = null;

				if (fSelectedTokens.Count != 0)
				{
					fSelectedTokens.Clear();
					OnSelectedTokensChanged();
				}

				if (fHighlightedArea != null)
				{
					fHighlightedArea = null;
					OnHighlightedAreaChanged();
				}

				// Cancel dragging and region outlining
				fDraggedTiles = null;
				fDraggedOutline = null;

				Invalidate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the DoubleClick event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnDoubleClick(EventArgs e)
		{
			try
			{
				if (fLineOfSight)
				{
					LineOfSight = false;
					return;
				}

				if (fDrawing != null)
				{
					AllowDrawing = false;
					return;
				}

				if (fAllowScrolling)
				{
					AllowScrolling = false;
					return;
				}

				if (fSelectedTokens.Count == 1)
					OnTokenActivated(fSelectedTokens[0]);

				if (fHighlightedArea != null)
					OnAreaActivated(fHighlightedArea);

				if (fHoverTokenLink != null)
				{
					int index = fTokenLinks.IndexOf(fHoverTokenLink);

					TokenLink link = OnEditTokenLink(fHoverTokenLink);
					if (link != null)
					{
						fTokenLinks[index] = link;
						Invalidate();
					}
				}

				base.OnDoubleClick(e);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the MouseWheel event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			fAllowScrolling = true;

			OnMouseZoom(e);
		}

		#endregion

		#region Keyboard

		/// <summary>
		/// Returns whether a given keypress can be handled by the MapView control.
		/// </summary>
		/// <param name="key">The key to check.</param>
		/// <returns>Returns true if the key was handled, false otherwise.</returns>
		public bool HandleKey(Keys key)
		{
			if ((key == Keys.Left)
				|| (key == Keys.Right)
				|| (key == (Keys.Left | Keys.Shift))
				|| (key == (Keys.Right | Keys.Shift))
				|| (key == Keys.Up)
				|| (key == Keys.Down)
				|| (key == Keys.Delete))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Determines whether the given key is an input key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>True if the key is an input key; false otherwise.</returns>
		protected override bool IsInputKey(Keys key)
		{
			if (HandleKey(key))
				return true;

			return base.IsInputKey(key);
		}

		/// <summary>
		/// Called in response to the KeyDown event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			bool removed = false;
			bool moved = false;

			switch (e.KeyCode)
			{
				case Keys.Left:
					if ((fSelectedTiles != null) && (fSelectedTiles.Count != 0))
					{
						if (e.Shift)
						{
							foreach (TileData td in fSelectedTiles)
								td.Rotations -= 1;
							moved = true;
						}
						else
						{
							foreach (TileData td in fSelectedTiles)
								td.Location = new Point(td.Location.X - 1, td.Location.Y);
							moved = true;
						}
					}
					break;
				case Keys.Right:
					if ((fSelectedTiles != null) && (fSelectedTiles.Count != 0))
					{
						if (e.Shift)
						{
							foreach (TileData td in fSelectedTiles)
								td.Rotations += 1;
							moved = true;
						}
						else
						{
							foreach (TileData td in fSelectedTiles)
								td.Location = new Point(td.Location.X + 1, td.Location.Y);
							moved = true;
						}
					}
					break;
				case Keys.Up:
					if ((fSelectedTiles != null) && (fSelectedTiles.Count != 0))
					{
						foreach (TileData td in fSelectedTiles)
							td.Location = new Point(td.Location.X, td.Location.Y - 1);
						moved = true;
					}
					break;
				case Keys.Down:
					if ((fSelectedTiles != null) && (fSelectedTiles.Count != 0))
					{
						foreach (TileData td in fSelectedTiles)
							td.Location = new Point(td.Location.X, td.Location.Y + 1);
						moved = true;
					}
					break;
				case Keys.Delete:
					if ((fSelectedTiles != null) && (fSelectedTiles.Count != 0))
					{
						foreach (TileData td in fSelectedTiles)
							fMap.Tiles.Remove(td);
						removed = true;
					}
					break;
			}

			fLayoutData = null;
			Invalidate();

			if (moved)
				OnItemMoved(1);

			if (removed)
				OnItemRemoved();
		}

		#endregion

		#region Drag and drop

		/// <summary>
		/// Called in response to the DragOver event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnDragOver(DragEventArgs e)
		{
			Point cursor = PointToClient(Cursor.Position);
			Point square = fLayoutData.GetSquareAtPoint(cursor);

			Tile tile = e.Data.GetData(typeof(Tile)) as Tile;
			if (tile != null)
			{
				e.Effect = DragDropEffects.Copy;

				fNewTile = new NewTile();
				fNewTile.Tile = tile;

				// Work out where the dragged tile is
				fNewTile.Location = fLayoutData.GetSquareAtPoint(cursor);
				fNewTile.Region = fLayoutData.GetRegion(fNewTile.Location, tile.Size);

				Invalidate();
			}

			CreatureToken token = e.Data.GetData(typeof(CreatureToken)) as CreatureToken;
			if (token != null)
			{
				EncounterSlot slot = fEncounter.FindSlot(token.SlotID);

				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				int size = Creature.GetSize(creature.Size);

				// Disallow drop if not over a tile
				if (allow_creature_move(new Rectangle(square, new Size(size, size)), CombatData.NoPoint))
				{
					fNewToken = new NewToken();
					fNewToken.Token = token;
					fNewToken.Location = square;

					e.Effect = DragDropEffects.Move;

					Invalidate();
				}
			}

			Hero hero = e.Data.GetData(typeof(Hero)) as Hero;
			if (hero != null)
			{
				int size = Creature.GetSize(hero.Size);

				// Disallow drop if not over a tile
				if (allow_creature_move(new Rectangle(square, new Size(size, size)), CombatData.NoPoint))
				{
					fNewToken = new NewToken();
					fNewToken.Token = hero;
					fNewToken.Location = square;

					e.Effect = DragDropEffects.Move;

					Invalidate();
				}
			}

			CustomToken custom = e.Data.GetData(typeof(CustomToken)) as CustomToken;
			if (custom != null)
			{
				// Disallow drop if not over a tile
				//if (allow_creature_move(new Rectangle(square, new Size(custom.Size, custom.Size)), CombatData.NoPoint))
				{
					fNewToken = new NewToken();
					fNewToken.Token = custom;
					fNewToken.Location = square;

					e.Effect = DragDropEffects.Move;

					Invalidate();
				}
			}
		}

		/// <summary>
		/// Called in response to the DragLeave event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnDragLeave(EventArgs e)
		{
			fNewTile = null;
			fNewToken = null;

			Invalidate();
		}

		/// <summary>
		/// Called in response to the DragDrop event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnDragDrop(DragEventArgs e)
		{
			Tile tile = e.Data.GetData(typeof(Tile)) as Tile;
			if (tile != null)
			{
				// Stop dragging the dragged tile; add it to the map

				TileData td = new TileData();
				td.TileID = fNewTile.Tile.ID;
				td.Location = fNewTile.Location;

				fNewTile = null;

				fMap.Tiles.Add(td);
				fSelectedTiles = new List<TileData>();
				fSelectedTiles.Add(td);

				fLayoutData = null;

				Invalidate();
				OnItemDropped();
			}

			CreatureToken data = e.Data.GetData(typeof(CreatureToken)) as CreatureToken;
			if (data != null)
			{
				// Stop dragging the creature; set this location

				data.Data.Location = fNewToken.Location;

				fNewToken = null;

				Invalidate();
				OnItemDropped();
			}

			Hero hero = e.Data.GetData(typeof(Hero)) as Hero;
			if (hero != null)
			{
				// Stop dragging the hero; set this location
				Hero h = fNewToken.Token as Hero;
				//fHeroData[h.ID].Location = fNewToken.Location;
				h.CombatData.Location = fNewToken.Location;

				fNewToken = null;

				Invalidate();
				OnItemDropped();
			}

			CustomToken custom = e.Data.GetData(typeof(CustomToken)) as CustomToken;
			if (custom != null)
			{
				// Stop dragging the creature; set this location

				custom.Data.Location = fNewToken.Location;

				fNewToken = null;

				Invalidate();
				OnItemDropped();
			}
		}

		#endregion

		#region Helper methods

		int get_distance(Point from, Point to)
		{
			int dx = Math.Abs(from.X - to.X);
			int dy = Math.Abs(from.Y - to.Y);
			return Math.Max(dx, dy);
		}

		Pair<IToken, Rectangle> get_token_at(Point square)
		{
			if (fEncounter == null)
				return null;

			foreach (Guid slot_id in fSlotRegions.Keys)
			{
				// Find the size of the creature
				List<Rectangle> rects = fSlotRegions[slot_id];
				foreach (Rectangle rect in rects)
				{
					if (rect.Contains(square))
					{
						EncounterSlot slot = fEncounter.FindSlot(slot_id);
						CombatData data = slot.FindCombatData(rect.Location);

						CreatureToken token = new CreatureToken();
						token.SlotID = slot_id;
						token.Data = data;

						return new Pair<IToken, Rectangle>(token, rect);
					}
				}
			}

			//if (fHeroData != null)
			{
				foreach (Hero h in Session.Project.Heroes)
				//foreach (Guid hero_id in fHeroData.Keys)
				{
					//Hero h = Session.Project.FindHero(hero_id);
					if (h == null)
						return null;

					// Find the hero rectangle
					int size = Creature.GetSize(h.Size);
					Rectangle rect = new Rectangle(h.CombatData.Location, new Size(size, size));

					if (rect.Contains(square))
						return new Pair<IToken, Rectangle>(h, rect);
				}
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
			{
				if (ct.Type == CustomTokenType.Token)
				{
					// Find the hero rectangle
					Size size = ct.OverlaySize;
					if (ct.Type == CustomTokenType.Token)
					{
						int sz = Creature.GetSize(ct.TokenSize);
						size = new Size(sz, sz);
					}
					Rectangle rect = new Rectangle(ct.Data.Location, size);

					if (rect.Contains(square))
						return new Pair<IToken, Rectangle>(ct, rect);
				}
			}

			foreach (CustomToken ct in fEncounter.CustomTokens)
			{
				if (ct.Type == CustomTokenType.Overlay)
				{
					// Find the hero rectangle
					Size size = ct.OverlaySize;
					if (ct.Type == CustomTokenType.Token)
					{
						int sz = Creature.GetSize(ct.TokenSize);
						size = new Size(sz, sz);
					}
					Rectangle rect = new Rectangle(ct.Data.Location, size);

					if (rect.Contains(square))
						return new Pair<IToken, Rectangle>(ct, rect);
				}
			}

			return null;
		}

		bool allow_creature_move(Rectangle target_rect, Point initial_location)
		{
			for (int x = 0; x != target_rect.Width; ++x)
			{
				for (int y = 0; y != target_rect.Height; ++y)
				{
					Point pt = new Point(x + target_rect.X, y + target_rect.Y);

					// Disallow if outside the viewpoint
					if ((fViewpoint != Rectangle.Empty) && (!fViewpoint.Contains(pt)))
						return false;

					// Disallow if off the map
					if (fLayoutData.GetTileAtSquare(pt) == null)
						return false;

					// Disallow if over another token
					Pair<IToken, Rectangle> slot_data = get_token_at(pt);
					if ((slot_data != null) && (slot_data.Second.Location != initial_location))
					{
						CustomToken ct = slot_data.First as CustomToken;
						bool overlay = ((ct != null) && (ct.Type == CustomTokenType.Overlay));

						// We can drag over an overlay, but not any other token
						if (!overlay)
							return false;
					}
				}
			}

			return true;
		}

		bool is_visible(CombatData cd)
		{
			if (cd == null)
				return false;

			switch (fShowCreatures)
			{
				case CreatureViewMode.All:
					return true;
				case CreatureViewMode.Visible:
					return cd.Visible;
				case CreatureViewMode.None:
					return false;
			}

			return false;
		}

		Point get_token_location(IToken token)
		{
			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				return ct.Data.Location;
			}

			if (token is Hero)
			{
				//if (fHeroData == null)
				//	return CombatData.NoPoint;

				Hero h = token as Hero;
				//if (!fHeroData.ContainsKey(h.ID))
				//	return CombatData.NoPoint;

				//return fHeroData[h.ID].Location;
				return h.CombatData.Location;
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;
				return ct.Data.Location;
			}

			return CombatData.NoPoint;
		}

		Size get_token_size(IToken token)
		{
			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				EncounterSlot slot = fEncounter.FindSlot(ct.SlotID);
				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				int size = Creature.GetSize(creature.Size);
				return new Size(size, size);
			}

			if (token is Hero)
			{
				Hero h = token as Hero;
				int size = Creature.GetSize(h.Size);
				return new Size(size, size);
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;

				if (ct.Type == CustomTokenType.Token)
				{
					int size = Creature.GetSize(ct.TokenSize);
					return new Size(size, size);
				}

				if (ct.Type == CustomTokenType.Overlay)
					return ct.OverlaySize;
			}

			return new Size(1, 1);
		}

		RectangleF get_token_rect(IToken token)
		{
			Point location = get_token_location(token);
			if (location == CombatData.NoPoint)
				return RectangleF.Empty;

			Size size = get_token_size(token);
			return fLayoutData.GetRegion(location, size);
		}

		Rectangle get_current_zoom_rect(bool use_scaling)
		{
			MapData data = (use_scaling) ? new MapData(this, 1.0) : fLayoutData;

			Point topright = data.GetSquareAtPoint(new Point(1, 1));
			Point bottomleft = data.GetSquareAtPoint(new Point(ClientRectangle.Right - 1, ClientRectangle.Bottom - 1));

			int width = 1 + (bottomleft.X - topright.X);
			int height = 1 + (bottomleft.Y - topright.Y);
			Size size = new Size(width, height);

			return new Rectangle(topright, size);
		}

		PointF get_point(MapSketchPoint msp)
		{
			RectangleF square = fLayoutData.GetRegion(msp.Square, new Size(1, 1));

			float dx = square.Width * msp.Location.X;
			float dy = square.Height * msp.Location.Y;

			return new PointF(square.X + dx, square.Y + dy);
		}

		CombatData get_combat_data(IToken token)
		{
			if (token is CreatureToken)
			{
				CreatureToken ct = token as CreatureToken;
				return ct.Data;
			}

			if (token is CustomToken)
			{
				CustomToken ct = token as CustomToken;
				return ct.Data;
			}

			if (token is Hero)
			{
				Hero hero = token as Hero;
				return hero.CombatData;
				//if (fHeroData.ContainsKey(hero.ID))
				//	return fHeroData[hero.ID];
			}

			return null;
		}

		TokenLink find_link(IToken t1, IToken t2)
		{
			RectangleF r1 = get_token_rect(t1);
			RectangleF r2 = get_token_rect(t2);

			foreach (TokenLink link in fTokenLinks)
			{
				RectangleF r3 = get_token_rect(link.Tokens[0]);
				RectangleF r4 = get_token_rect(link.Tokens[1]);

				bool first = ((r1 == r3) || (r2 == r3));
				bool second = ((r1 == r4) || (r2 == r4));

				if (first && second)
					return link;
			}

			return null;
		}

		PointF get_closest_vertex(Point pt)
		{
			Point square = fLayoutData.GetSquareAtPoint(pt);
			RectangleF rect = fLayoutData.GetRegion(square, new Size(1, 1));

			List<PointF> points = new List<PointF>();
			points.Add(new PointF(rect.Left, rect.Top));
			points.Add(new PointF(rect.Left, rect.Bottom - 1));
			points.Add(new PointF(rect.Right - 1, rect.Top));
			points.Add(new PointF(rect.Right - 1, rect.Bottom - 1));

			double min_distance = double.MaxValue;
			PointF nearest = PointF.Empty;

			foreach (PointF point in points)
			{
				float dx = point.X - pt.X;
				float dy = point.Y - pt.Y;
				double distance = Math.Sqrt((dx * dx) + (dy * dy));

				if (distance < min_distance)
				{
					nearest = point;
					min_distance = distance;
				}
			}

			return nearest;
		}

		#endregion

		#region Helper classes

		class NewTile
		{
			public Tile Tile = null;
			public Point Location = CombatData.NoPoint;
			public RectangleF Region = RectangleF.Empty;
		}

		class DraggedTiles
		{
			public List<TileData> Tiles = new List<TileData>();
			public Point Start = CombatData.NoPoint;
			public Size Offset = Size.Empty;
			public RectangleF Region = RectangleF.Empty;
		}

		class DraggedOutline
		{
			public Point Start = CombatData.NoPoint;
			public Rectangle Region = Rectangle.Empty;
		}

		class NewToken
		{
			public IToken Token = null;
			public Point Location = CombatData.NoPoint;
		}

		class DraggedToken
		{
			public IToken Token = null;
			public Point Start = CombatData.NoPoint;
			public Size Offset = Size.Empty;
			public Point Location = CombatData.NoPoint;
			public IToken LinkedToken = null;
		}

		class ScrollingData
		{
			public Point Start = Point.Empty;
		}

		class DrawingData
		{
			public MapSketch CurrentSketch = null;
		}

		#endregion
	}

	class MapData
	{
		public MapData(MapView mapview, double scaling_factor)
		{
			ScalingFactor = scaling_factor;

			// Work out max and min x and max and min y
			if (((mapview.Map != null) && (mapview.Map.Tiles.Count != 0)) || ((mapview.BackgroundMap != null) && (mapview.BackgroundMap.Tiles.Count != 0)))
			{
				List<TileData> tiles = new List<TileData>();
				tiles.AddRange(mapview.Map.Tiles);
				if (mapview.BackgroundMap != null)
					tiles.AddRange(mapview.BackgroundMap.Tiles);

				foreach (TileData td in tiles)
				{
					Tile t = Session.FindTile(td.TileID, SearchType.Global);
					if (t == null)
						continue;

					Tiles[td] = t;

					// Work out the squares covered by this tile
					Rectangle tile_rect;
					if (td.Rotations % 2 == 0)
					{
						tile_rect = new Rectangle(td.Location.X, td.Location.Y, t.Size.Width, t.Size.Height);
					}
					else
					{
						tile_rect = new Rectangle(td.Location.X, td.Location.Y, t.Size.Height, t.Size.Width);
					}
					TileSquares[td] = tile_rect;

					// Set max / min x and y

					if (tile_rect.X < MinX)
						MinX = tile_rect.X;

					if (tile_rect.Y < MinY)
						MinY = tile_rect.Y;

					int right = tile_rect.X + tile_rect.Width - 1;
					if (right > MaxX)
						MaxX = right;

					int bottom = tile_rect.Y + tile_rect.Height - 1;
					if (bottom > MaxY)
						MaxY = bottom;
				}
			}
			else
			{
				MinX = 0;
				MinY = 0;
				MaxX = 0;
				MaxY = 0;
			}

			if ((mapview.Map != null) && (mapview.Viewpoint != Rectangle.Empty))
			{
				// Override this
				MinX = mapview.Viewpoint.X;
				MinY = mapview.Viewpoint.Y;
				MaxX = mapview.Viewpoint.X + mapview.Viewpoint.Width - 1;
				MaxY = mapview.Viewpoint.Y + mapview.Viewpoint.Height - 1;
			}
			else
			{
				// Add a border round the edge
				MinX -= mapview.BorderSize;
				MinY -= mapview.BorderSize;
				MaxX += mapview.BorderSize;
				MaxY += mapview.BorderSize;
			}

			// Work out square dimensions
			float square_width = (float)mapview.ClientRectangle.Width / Width;
			float square_height = (float)mapview.ClientRectangle.Height / Height;
			SquareSize = Math.Min(square_width, square_height);
			SquareSize *= (float)ScalingFactor;

			// Work out the map offset
			float x_used = Width * SquareSize;
			float y_used = Height * SquareSize;
			float x_diff = mapview.ClientRectangle.Width - x_used;
			float y_diff = mapview.ClientRectangle.Height - y_used;
			MapOffset = new SizeF(x_diff / 2, y_diff / 2);

			if (mapview.Map != null)
			{
				// Work out painting region for each tile
				foreach (TileData td in Tiles.Keys)
				{
					Rectangle squares = TileSquares[td];
					TileRegions[td] = GetRegion(squares.Location, squares.Size);
				}
			}
		}

		~MapData()
		{
			Tiles.Clear();
			TileSquares.Clear();
			TileRegions.Clear();
		}

		public Dictionary<TileData, Tile> Tiles = new Dictionary<TileData, Tile>();

		public Dictionary<TileData, Rectangle> TileSquares = new Dictionary<TileData, Rectangle>();
		public Dictionary<TileData, RectangleF> TileRegions = new Dictionary<TileData, RectangleF>();

		public double ScalingFactor = 0.0F;
		public float SquareSize = 0.0F;

		// How far, in pixels, the top-left corner of the map is from the top-left corner of the control
		public SizeF MapOffset = new SizeF();

		public int MinX = int.MaxValue;
		public int MinY = int.MaxValue;
		public int MaxX = int.MinValue;
		public int MaxY = int.MinValue;

		public int Width
		{
			get { return MaxX - MinX + 1; }
		}

		public int Height
		{
			get { return MaxY - MinY + 1; }
		}

		public Point GetSquareAtPoint(Point pt)
		{
			// Remove the map offset
			int x = (int)(pt.X - MapOffset.Width);
			int y = (int)(pt.Y - MapOffset.Height);

			x = (int)(x / SquareSize);
			y = (int)(y / SquareSize);

			return new Point(x + MinX, y + MinY);
		}

		public TileData GetTileAtSquare(Point square)
		{
			TileData result = null;

			foreach (TileData td in TileSquares.Keys)
			{
				Rectangle squares = TileSquares[td];
				if (squares.Contains(square))
					result = td;
			}

			return result;
		}

		public RectangleF GetRegion(Point square, Size size)
		{
			float x = ((square.X - MinX) * SquareSize) + MapOffset.Width;
			float y = ((square.Y - MinY) * SquareSize) + MapOffset.Height;

			float tile_width = size.Width * SquareSize;
			float tile_height = size.Height * SquareSize;

			return new RectangleF(x, y, tile_width + 1, tile_height + 1);
		}
	}
}
