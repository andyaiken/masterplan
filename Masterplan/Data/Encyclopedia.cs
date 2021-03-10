using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing the project encyclopedia.
	/// </summary>
	[Serializable]
	public class Encyclopedia
	{
		/// <summary>
		/// Gets or sets the list of encyclopedia entries.
		/// </summary>
		public List<EncyclopediaEntry> Entries
		{
			get { return fEntries; }
			set { fEntries = value; }
		}
		List<EncyclopediaEntry> fEntries = new List<EncyclopediaEntry>();

		/// <summary>
		/// Gets or sets the list of links between encyclopedia entries.
		/// </summary>
		public List<EncyclopediaLink> Links
		{
			get { return fLinks; }
			set { fLinks = value; }
		}
		List<EncyclopediaLink> fLinks = new List<EncyclopediaLink>();

		/// <summary>
		/// Gets or sets the list of encyclopedia groups.
		/// </summary>
		public List<EncyclopediaGroup> Groups
		{
			get { return fGroups; }
			set { fGroups = value; }
		}
		List<EncyclopediaGroup> fGroups = new List<EncyclopediaGroup>();

		/// <summary>
		/// Finds an encyclopedia entry by ID.
		/// </summary>
		/// <param name="entry_id">The ID of the required entry.</param>
		/// <returns>Returns the entry with the given id, or null if no such entry exists.</returns>
		public EncyclopediaEntry FindEntry(Guid entry_id)
		{
			foreach (EncyclopediaEntry entry in fEntries)
			{
				if (entry.ID == entry_id)
					return entry;
			}

			return null;
		}

		/// <summary>
		/// Finds an encyclopedia entry by name.
		/// </summary>
		/// <param name="name">The name of the required entry.</param>
		/// <returns>Returns the entry with the given name, or null if no such entry exists.</returns>
		public EncyclopediaEntry FindEntry(string name)
		{
			foreach (EncyclopediaEntry entry in fEntries)
			{
				if (entry.Name.ToLower() == name.ToLower())
					return entry;
			}

			return null;
		}

		/// <summary>
		/// Finds an encyclopedia group by ID.
		/// </summary>
		/// <param name="entry_id">The ID of the required group.</param>
		/// <returns>Returns the group with the given id, or null if no such group exists.</returns>
		public EncyclopediaGroup FindGroup(Guid entry_id)
		{
			foreach (EncyclopediaGroup group in fGroups)
			{
				if (group.ID == entry_id)
					return group;
			}

			return null;
		}

		/// <summary>
		/// Finds a link by the IDs of the entries linked.
		/// </summary>
		/// <param name="entry_id_1">The first entry ID.</param>
		/// <param name="entry_id_2">The second entry ID.</param>
		/// <returns>Returns the link with the given ids, or null if no such link exists.</returns>
		public EncyclopediaLink FindLink(Guid entry_id_1, Guid entry_id_2)
		{
			foreach (EncyclopediaLink link in fLinks)
			{
				if (link.EntryIDs.Contains(entry_id_1) && link.EntryIDs.Contains(entry_id_2))
					return link;
			}

			return null;
		}

		/// <summary>
		/// Finds the entry associated with the given attachment.
		/// </summary>
		/// <param name="attachment_id">The ID of the attachment.</param>
		/// <returns>Returns the entry, or null if no such entry exists.</returns>
		public EncyclopediaEntry FindEntryForAttachment(Guid attachment_id)
		{
			foreach (EncyclopediaEntry ee in Session.Project.Encyclopedia.Entries)
			{
				if (ee.AttachmentID == attachment_id)
					return ee;
			}

			return null;
		}

		/// <summary>
		/// Creates a copy of the encyclopedia.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Encyclopedia Copy()
		{
			Encyclopedia e = new Encyclopedia();

			foreach (EncyclopediaEntry entry in fEntries)
				e.Entries.Add(entry.Copy());

			foreach (EncyclopediaLink link in fLinks)
				e.Links.Add(link.Copy());

			foreach (EncyclopediaGroup group in fGroups)
				e.Groups.Add(group.Copy());

			return e;
		}

		/// <summary>
		/// Imports the data from another encyclopedia into this one.
		/// </summary>
		/// <param name="enc">The encyclopedia to import from.</param>
		public void Import(Encyclopedia enc)
		{
			if (enc == null)
				return;

			foreach (EncyclopediaEntry entry in enc.Entries)
			{
				// Remove any previous entry
				EncyclopediaEntry ee = FindEntry(entry.ID);
				if (ee != null)
					Entries.Remove(ee);

				Entries.Add(entry);
			}

			foreach (EncyclopediaGroup group in enc.Groups)
			{
				// Remove any previous group
				EncyclopediaGroup eg = FindGroup(group.ID);
				if (eg != null)
					Groups.Remove(eg);

				Groups.Add(group);
			}

			foreach (EncyclopediaLink link in enc.Links)
			{
				// Remove any previous link
				EncyclopediaLink el = FindLink(link.EntryIDs[0], link.EntryIDs[1]);
				if (el != null)
					Links.Remove(el);

				Links.Add(link);
			}
		}
	}

	/// <summary>
	/// Interface implemented by EncyclopediaEntry and EncyclopediaGroup.
	/// </summary>
	public interface IEncyclopediaItem
	{
		/// <summary>
		/// Gets or sets the unique ID of the item.
		/// </summary>
		Guid ID { get; set; }
	}

	/// <summary>
	/// Class representing an encyclopedia entry.
	/// </summary>
	[Serializable]
	public class EncyclopediaEntry : IEncyclopediaItem, IComparable<EncyclopediaEntry>
	{
		/// <summary>
		/// Gets or sets the entry name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the unique ID of the entry.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the entry category.
		/// </summary>
		public string Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		string fCategory = "";

		/// <summary>
		/// Gets or sets the ID of the PC, NPC, custom creature or regional location this entry is associated with.
		/// </summary>
		public Guid AttachmentID
		{
			get { return fAttachmentID; }
			set { fAttachmentID = value; }
		}
		Guid fAttachmentID = Guid.Empty;

		/// <summary>
		/// Gets or sets the entry details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the DM-only information about this entry
		/// </summary>
		public string DMInfo
		{
			get { return fDM; }
			set { fDM = value; }
		}
		string fDM = "";

		/// <summary>
		/// Gets or sets entry images.
		/// </summary>
		public List<EncyclopediaImage> Images
		{
			get { return fImages; }
			set { fImages = value; }
		}
		List<EncyclopediaImage> fImages = new List<EncyclopediaImage>();

		/// <summary>
		/// Finds the image with the given ID.
		/// </summary>
		/// <param name="id">The ID to search for.</param>
		/// <returns>Returns the image, if it exists; null otherwise.</returns>
		public EncyclopediaImage FindImage(Guid id)
		{
			foreach (EncyclopediaImage img in fImages)
			{
				if (img.ID == id)
					return img;
			}

			return null;
		}

		/// <summary>
		/// Creates a copy of the entry.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncyclopediaEntry Copy()
		{
			EncyclopediaEntry entry = new EncyclopediaEntry();

			entry.Name = fName;
			entry.ID = fID;
			entry.Category = fCategory;
			entry.AttachmentID = fAttachmentID;
			entry.Details = fDetails;
			entry.DMInfo = fDM;

			foreach (EncyclopediaImage ei in fImages)
				entry.Images.Add(ei.Copy());

			return entry;
		}

		/// <summary>
		/// Compares this entry to another.
		/// </summary>
		/// <param name="rhs">The other entry.</param>
		/// <returns>Returns -1 if this entry should be sorted before the other; +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(EncyclopediaEntry rhs)
		{
			return fName.CompareTo(rhs.Name);
		}

		/// <summary>
		/// Returns the entry name.
		/// </summary>
		/// <returns>Returns the entry name.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a link between two encyclopedia entries.
	/// </summary>
	[Serializable]
	public class EncyclopediaLink
	{
		/// <summary>
		/// Gets or sets the list of entry IDs.
		/// </summary>
		public List<Guid> EntryIDs
		{
			get { return fIDs; }
			set { fIDs = value; }
		}
		List<Guid> fIDs = new List<Guid>();

		/// <summary>
		/// Creates a copy of the link.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncyclopediaLink Copy()
		{
			EncyclopediaLink link = new EncyclopediaLink();

			foreach (Guid id in fIDs)
				link.EntryIDs.Add(id);

			return link;
		}
	}

	/// <summary>
	/// Class representing an image assigned to an encyclopedia entry.
	/// </summary>
	[Serializable]
	public class EncyclopediaImage
	{
		/// <summary>
		/// Gets or sets the image name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the unique ID of the image.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		[XmlIgnore]
		public Image Image
		{
			get { return fImage; }
			set { fImage = value; }
		}
		Image fImage = null;

		/// <summary>
		/// Gets or sets the image data as a byte array.
		/// This is used only for XML serialisation.
		/// </summary>
		public byte[] ImageData
		{
			get
			{
				if (fImage != null)
				{
					TypeConverter BitmapConverter = TypeDescriptor.GetConverter(fImage.GetType());
					return (byte[])BitmapConverter.ConvertTo(fImage, typeof(byte[]));
				}
				else
				{
					return null;
				}
			}
			set
			{
				if (value != null)
					fImage = new Bitmap(new MemoryStream(value));
				else
					fImage = null;
			}
		}

		/// <summary>
		/// Creates a copy of the image.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncyclopediaImage Copy()
		{
			EncyclopediaImage ei = new EncyclopediaImage();

			ei.ID = fID;
			ei.Name = fName;
			ei.Image = fImage;

			return ei;
		}
	}

	/// <summary>
	/// Class representing a group of encyclopedia entries.
	/// </summary>
	[Serializable]
	public class EncyclopediaGroup : IEncyclopediaItem, IComparable<EncyclopediaGroup>
	{
		/// <summary>
		/// Gets or sets the entry name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the unique ID of the entry.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the list of entry IDs.
		/// </summary>
		public List<Guid> EntryIDs
		{
			get { return fIDs; }
			set { fIDs = value; }
		}
		List<Guid> fIDs = new List<Guid>();

		/// <summary>
		/// Creates a copy of the link.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EncyclopediaGroup Copy()
		{
			EncyclopediaGroup group = new EncyclopediaGroup();

			group.Name = fName;
			group.ID = fID;

			foreach (Guid id in fIDs)
				group.EntryIDs.Add(id);

			return group;
		}

		/// <summary>
		/// Compares this group to another.
		/// </summary>
		/// <param name="rhs">The other group.</param>
		/// <returns>Returns -1 if this group should be sorted before the other; +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(EncyclopediaGroup rhs)
		{
			return fName.CompareTo(rhs.Name);
		}
	}
}
