#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	internal class DirectoryList
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private string path;
		private DirectoryEntry[] directories;
		private DirectoryEntry[] files;
		private DirectoryEntry[] allentries;
		
		#endregion

		#region ================== Properties

		public string Path { get { return path; } }

		public int DirectoryCount { get { return directories.Length; } }
		public int FileCount { get { return files.Length; } }
		public int TotalCount { get { return allentries.Length; } }

		public ReadOnlyCollection<DirectoryEntry> Directories { get { return Array.AsReadOnly(directories); } }
		public ReadOnlyCollection<DirectoryEntry> Files { get { return Array.AsReadOnly(files); } }
		public DirectoryEntry this[int index] { get { return allentries[index]; } }
		
		#endregion

		#region ================== Constructor / Destructor

		// Constructor for normal list
		public DirectoryList(string path, string filterext, bool subdirectories)
		{
			SetupNewList(path, filterext, subdirectories, "*");
		}

		// Constructor for searching files
		public DirectoryList(string path, string filterext, bool subdirectories, string searchpattern)
		{
			SetupNewList(path, filterext, subdirectories, searchpattern);
		}

		// Constructor for two combined lists
		public DirectoryList(DirectoryList a, DirectoryList b)
		{
			this.path = "";
			
			this.directories = new DirectoryEntry[a.directories.Length + b.directories.Length];
			Array.Copy(a.directories, 0, this.directories, 0, a.directories.Length);
			Array.Copy(b.directories, 0, this.directories, a.directories.Length, b.directories.Length);

			this.files = new DirectoryEntry[a.files.Length + b.files.Length];
			Array.Copy(a.files, 0, this.files, 0, a.files.Length);
			Array.Copy(b.files, 0, this.files, a.files.Length, b.files.Length);

			UpdateAllItemsList();
		}

		#endregion

		#region ================== Private Methods

		// This is called by some constructors to create a new list
		private void SetupNewList(string path, string filterext, bool subdirectories, string searchpattern)
		{
			// Initialize
			this.path = System.IO.Path.GetFullPath(path);

			SearchOption searchoptions = subdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
			
			// Fetch content names
			string[] dirnames = Directory.GetDirectories(path, searchpattern, searchoptions);
			string[] filenames = Directory.GetFiles(path, searchpattern, searchoptions);
			
			// Make directory entries
			directories = new DirectoryEntry[dirnames.Length];
			for(int i = 0; i < dirnames.Length; i++)
				directories[i] = new DirectoryEntry(dirnames[i]);
			
			// Make file entries
			List<DirectoryEntry> fileslist = new List<DirectoryEntry>(filenames.Length);
			for(int i = 0; i < filenames.Length; i++)
			{
				DirectoryEntry e = new DirectoryEntry(filenames[i]);
				if((filterext == null) || filterext.Contains(e.extension.ToLowerInvariant()))
					fileslist.Add(e);
			}
			files = fileslist.ToArray();
			
			UpdateAllItemsList();
		}
		
		// This creates the All Items combined list from directories and files
		private void UpdateAllItemsList()
		{
			this.allentries = new DirectoryEntry[this.files.Length + this.directories.Length];
			Array.Copy(this.directories, 0, this.allentries, 0, this.directories.Length);
			Array.Copy(this.files, 0, this.allentries, this.directories.Length, this.files.Length);
		}

		#endregion

		#region ================== Public Methods

		// This combines directory lists
		public static DirectoryList operator+(DirectoryList a, DirectoryList b)
		{
			return new DirectoryList(a, b);
		}

		#endregion
	}
}
