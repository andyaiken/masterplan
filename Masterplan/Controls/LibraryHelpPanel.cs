using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class LibraryHelpPanel : UserControl
	{
		public LibraryHelpPanel()
		{
			InitializeComponent();

			Browser.DocumentText = get_html();
		}

		string get_html()
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<P>This is the Libraries screen.</P>");

			lines.Add("<P><B>What is a library?</B> A library is a file containing a collection of reusable items such as creatures, traps and hazards, magic items and map tiles. On the left you can see the list of libraries that are currently installed. When you select one of these libraries you can see the items it contains.</P>");

			lines.Add("<P><B>I have a library file, how do I install it?</B> First, find the folder containing Masterplan; there will be a sub-folder called Libraries. Move your library file into this folder, and restart Masterplan.</P>");

			lines.Add("<P><B>How do I import a creature from Adventure Tools?</B> If you have exported a .monster file from Adventure Tools you can import them into a library. Choose the library you want to add the creature to, and select it on the left. On the Creatures tab, press the down-arrow beside the Add button, and select Import from Adventure Tools to bring up a file browser. Select the .monster file, and it will be imported into your library.</P>");

			lines.Add("<P><B>How do I create map tiles from image files?</B> If you have a selection of image files that you want to use as map tiles, you can import them into a library. Choose the library you want to add the tiles to, and select it on the left. On the Map Tiles tab, press the Add button to bring up a file browser. Select the image files to import them into your library. Masterplan will try to work out the dimensions of each tile, but you can edit any that are incorrect by right-clicking on the tile and selecting Set Size. You can also set the category of each tile – this is particularly useful if you want to use the Map AutoBuild feature to build random dungeon maps automatically.</P>");

			return HTML.Concatenate(lines);
		}
	}
}
