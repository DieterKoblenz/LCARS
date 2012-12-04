namespace CodeImp.Gluon
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.screensaver = new System.Windows.Forms.Timer(this.components);
			this.warningflasher = new System.Windows.Forms.Timer(this.components);
			this.infoflasher = new System.Windows.Forms.Timer(this.components);
			this.activitychecker = new System.Windows.Forms.Timer(this.components);
			this.librarySearchDisplayPanel1 = new CodeImp.Gluon.LibrarySearchDisplayPanel();
			this.playlistspanel = new CodeImp.Gluon.PlaylistsDisplayPanel();
			this.mediaplayerpanel = new CodeImp.Gluon.MediaPlayerDisplayPanel();
			this.librarybrowserpanel = new CodeImp.Gluon.LibraryBrowserDisplayPanel();
			this.notespanel = new CodeImp.Gluon.NotesDisplayPanel();
			this.transferobexpanel = new CodeImp.Gluon.ObexTransferDisplayPanel();
			this.loadingpanel = new CodeImp.Gluon.LoadingDisplayPanel();
			this.errorpanel = new CodeImp.Gluon.ErrorDisplayPanel();
			this.addgroceriespanel = new CodeImp.Gluon.AddGroceriesDisplayPanel();
			this.groceriespanel = new CodeImp.Gluon.GroceriesDisplayPanel();
			this.accesspanel = new CodeImp.Gluon.AccessDisplayPanel();
			this.buienradarpanel = new CodeImp.Gluon.BuienradarDisplayPanel();
			this.treintijdenpanel = new CodeImp.Gluon.TreintijdenDisplayPanel();
			this.agendaitempanel = new CodeImp.Gluon.AgendaItemDisplayPanel();
			this.agendadaypanel = new CodeImp.Gluon.AgendaEditDisplayPanel();
			this.agendapanel = new CodeImp.Gluon.AgendaDisplayPanel();
			this.internetpanel = new CodeImp.Gluon.InternetDisplayPanel();
			this.overviewpanel = new CodeImp.Gluon.OverviewDisplayPanel();
			this.SuspendLayout();
			// 
			// screensaver
			// 
			this.screensaver.Enabled = true;
			this.screensaver.Interval = 100000;
			this.screensaver.Tick += new System.EventHandler(this.screensaver_Tick);
			// 
			// warningflasher
			// 
			this.warningflasher.Enabled = true;
			this.warningflasher.Interval = 400;
			this.warningflasher.Tick += new System.EventHandler(this.warningflasher_Tick);
			// 
			// infoflasher
			// 
			this.infoflasher.Enabled = true;
			this.infoflasher.Interval = 800;
			this.infoflasher.Tick += new System.EventHandler(this.infoflasher_Tick);
			// 
			// activitychecker
			// 
			this.activitychecker.Enabled = true;
			this.activitychecker.Interval = 1000;
			this.activitychecker.Tick += new System.EventHandler(this.activitychecker_Tick);
			// 
			// librarySearchDisplayPanel1
			// 
			this.librarySearchDisplayPanel1.AnimationEndSound = null;
			this.librarySearchDisplayPanel1.BackColor = System.Drawing.Color.DarkGray;
			this.librarySearchDisplayPanel1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.librarySearchDisplayPanel1.Location = new System.Drawing.Point(450, 394);
			this.librarySearchDisplayPanel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.librarySearchDisplayPanel1.Name = "librarySearchDisplayPanel1";
			this.librarySearchDisplayPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.librarySearchDisplayPanel1.Size = new System.Drawing.Size(208, 85);
			this.librarySearchDisplayPanel1.TabIndex = 18;
			this.librarySearchDisplayPanel1.Tag = "searchlibrary";
			// 
			// playlistspanel
			// 
			this.playlistspanel.AnimationEndSound = "210";
			this.playlistspanel.BackColor = System.Drawing.Color.DarkGray;
			this.playlistspanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.playlistspanel.Location = new System.Drawing.Point(231, 394);
			this.playlistspanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.playlistspanel.Name = "playlistspanel";
			this.playlistspanel.Padding = new System.Windows.Forms.Padding(10);
			this.playlistspanel.Size = new System.Drawing.Size(208, 85);
			this.playlistspanel.TabIndex = 17;
			this.playlistspanel.Tag = "playlists";
			// 
			// mediaplayerpanel
			// 
			this.mediaplayerpanel.AnimationEndSound = "210";
			this.mediaplayerpanel.BackColor = System.Drawing.Color.DarkGray;
			this.mediaplayerpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mediaplayerpanel.Location = new System.Drawing.Point(669, 297);
			this.mediaplayerpanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.mediaplayerpanel.Name = "mediaplayerpanel";
			this.mediaplayerpanel.Padding = new System.Windows.Forms.Padding(10);
			this.mediaplayerpanel.Size = new System.Drawing.Size(208, 85);
			this.mediaplayerpanel.TabIndex = 15;
			this.mediaplayerpanel.Tag = "mediaplayer";
			// 
			// librarybrowserpanel
			// 
			this.librarybrowserpanel.AnimationEndSound = "";
			this.librarybrowserpanel.BackColor = System.Drawing.Color.DarkGray;
			this.librarybrowserpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.librarybrowserpanel.Location = new System.Drawing.Point(450, 297);
			this.librarybrowserpanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.librarybrowserpanel.Name = "librarybrowserpanel";
			this.librarybrowserpanel.Padding = new System.Windows.Forms.Padding(10);
			this.librarybrowserpanel.Size = new System.Drawing.Size(208, 85);
			this.librarybrowserpanel.TabIndex = 14;
			this.librarybrowserpanel.Tag = "librarybrowser";
			// 
			// notespanel
			// 
			this.notespanel.AddNew = false;
			this.notespanel.AnimationEndSound = "210";
			this.notespanel.BackColor = System.Drawing.Color.DarkGray;
			this.notespanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.notespanel.Location = new System.Drawing.Point(231, 297);
			this.notespanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.notespanel.Name = "notespanel";
			this.notespanel.Padding = new System.Windows.Forms.Padding(10);
			this.notespanel.Size = new System.Drawing.Size(208, 85);
			this.notespanel.TabIndex = 13;
			this.notespanel.Tag = "notes";
			// 
			// transferobexpanel
			// 
			this.transferobexpanel.AnimationEndSound = "210";
			this.transferobexpanel.BackColor = System.Drawing.Color.DarkGray;
			this.transferobexpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.transferobexpanel.Location = new System.Drawing.Point(12, 297);
			this.transferobexpanel.Name = "transferobexpanel";
			this.transferobexpanel.Padding = new System.Windows.Forms.Padding(10);
			this.transferobexpanel.ReturnPanel = null;
			this.transferobexpanel.Size = new System.Drawing.Size(208, 85);
			this.transferobexpanel.TabIndex = 12;
			this.transferobexpanel.Tag = "transferobex";
			// 
			// loadingpanel
			// 
			this.loadingpanel.AnimationEndSound = null;
			this.loadingpanel.BackColor = System.Drawing.Color.DarkGray;
			this.loadingpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loadingpanel.Location = new System.Drawing.Point(669, 200);
			this.loadingpanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.loadingpanel.Name = "loadingpanel";
			this.loadingpanel.Padding = new System.Windows.Forms.Padding(10);
			this.loadingpanel.Size = new System.Drawing.Size(208, 85);
			this.loadingpanel.TabIndex = 11;
			this.loadingpanel.Tag = "loading";
			// 
			// errorpanel
			// 
			this.errorpanel.AnimationEndSound = null;
			this.errorpanel.BackColor = System.Drawing.Color.DarkGray;
			this.errorpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorpanel.Location = new System.Drawing.Point(450, 200);
			this.errorpanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.errorpanel.Name = "errorpanel";
			this.errorpanel.Padding = new System.Windows.Forms.Padding(10);
			this.errorpanel.Size = new System.Drawing.Size(208, 85);
			this.errorpanel.TabIndex = 10;
			this.errorpanel.Tag = "error";
			// 
			// addgroceriespanel
			// 
			this.addgroceriespanel.AnimationEndSound = "210";
			this.addgroceriespanel.BackColor = System.Drawing.Color.DarkGray;
			this.addgroceriespanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addgroceriespanel.Location = new System.Drawing.Point(231, 200);
			this.addgroceriespanel.Name = "addgroceriespanel";
			this.addgroceriespanel.Padding = new System.Windows.Forms.Padding(10);
			this.addgroceriespanel.SelectedList = 0;
			this.addgroceriespanel.Size = new System.Drawing.Size(208, 85);
			this.addgroceriespanel.TabIndex = 9;
			this.addgroceriespanel.Tag = "addgroceries";
			// 
			// groceriespanel
			// 
			this.groceriespanel.AnimationEndSound = "210";
			this.groceriespanel.BackColor = System.Drawing.Color.DarkGray;
			this.groceriespanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groceriespanel.Location = new System.Drawing.Point(12, 200);
			this.groceriespanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.groceriespanel.Name = "groceriespanel";
			this.groceriespanel.Padding = new System.Windows.Forms.Padding(10);
			this.groceriespanel.SelectedList = 0;
			this.groceriespanel.Size = new System.Drawing.Size(208, 85);
			this.groceriespanel.TabIndex = 8;
			this.groceriespanel.Tag = "groceries";
			// 
			// accesspanel
			// 
			this.accesspanel.AnimationEndSound = null;
			this.accesspanel.BackColor = System.Drawing.Color.DarkGray;
			this.accesspanel.BackPanel = null;
			this.accesspanel.ContinuePanel = null;
			this.accesspanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.accesspanel.Location = new System.Drawing.Point(669, 106);
			this.accesspanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.accesspanel.Name = "accesspanel";
			this.accesspanel.Padding = new System.Windows.Forms.Padding(10);
			this.accesspanel.Size = new System.Drawing.Size(208, 85);
			this.accesspanel.TabIndex = 7;
			this.accesspanel.Tag = "accessport";
			// 
			// buienradarpanel
			// 
			this.buienradarpanel.AnimationEndSound = "210";
			this.buienradarpanel.BackColor = System.Drawing.Color.DarkGray;
			this.buienradarpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buienradarpanel.Location = new System.Drawing.Point(450, 106);
			this.buienradarpanel.Name = "buienradarpanel";
			this.buienradarpanel.Padding = new System.Windows.Forms.Padding(10);
			this.buienradarpanel.Size = new System.Drawing.Size(208, 85);
			this.buienradarpanel.TabIndex = 6;
			this.buienradarpanel.Tag = "buienradar";
			// 
			// treintijdenpanel
			// 
			this.treintijdenpanel.AnimationEndSound = "210";
			this.treintijdenpanel.BackColor = System.Drawing.Color.DarkGray;
			this.treintijdenpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treintijdenpanel.Location = new System.Drawing.Point(231, 106);
			this.treintijdenpanel.Name = "treintijdenpanel";
			this.treintijdenpanel.Padding = new System.Windows.Forms.Padding(10);
			this.treintijdenpanel.Size = new System.Drawing.Size(208, 85);
			this.treintijdenpanel.TabIndex = 5;
			this.treintijdenpanel.Tag = "treintijden";
			// 
			// agendaitempanel
			// 
			this.agendaitempanel.AnimationEndSound = "210";
			this.agendaitempanel.BackColor = System.Drawing.Color.DarkGray;
			this.agendaitempanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.agendaitempanel.Location = new System.Drawing.Point(12, 106);
			this.agendaitempanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.agendaitempanel.Name = "agendaitempanel";
			this.agendaitempanel.Padding = new System.Windows.Forms.Padding(10);
			this.agendaitempanel.ReturnPanel = null;
			this.agendaitempanel.Size = new System.Drawing.Size(208, 85);
			this.agendaitempanel.TabIndex = 4;
			this.agendaitempanel.Tag = "agendaitem";
			// 
			// agendadaypanel
			// 
			this.agendadaypanel.AnimationEndSound = "210";
			this.agendadaypanel.BackColor = System.Drawing.Color.DarkGray;
			this.agendadaypanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.agendadaypanel.ItemEditor = null;
			this.agendadaypanel.Location = new System.Drawing.Point(669, 12);
			this.agendadaypanel.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.agendadaypanel.Name = "agendadaypanel";
			this.agendadaypanel.Padding = new System.Windows.Forms.Padding(10);
			this.agendadaypanel.ReturnPanel = null;
			this.agendadaypanel.Size = new System.Drawing.Size(208, 85);
			this.agendadaypanel.TabIndex = 3;
			this.agendadaypanel.Tag = "agendaday";
			// 
			// agendapanel
			// 
			this.agendapanel.AnimationEndSound = null;
			this.agendapanel.BackColor = System.Drawing.Color.DarkGray;
			this.agendapanel.DayEditor = null;
			this.agendapanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.agendapanel.ItemEditor = null;
			this.agendapanel.Location = new System.Drawing.Point(450, 12);
			this.agendapanel.Name = "agendapanel";
			this.agendapanel.Padding = new System.Windows.Forms.Padding(10);
			this.agendapanel.Size = new System.Drawing.Size(208, 85);
			this.agendapanel.TabIndex = 2;
			this.agendapanel.Tag = "agenda";
			// 
			// internetpanel
			// 
			this.internetpanel.AnimationEndSound = "210";
			this.internetpanel.BackColor = System.Drawing.Color.DarkGray;
			this.internetpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.internetpanel.Location = new System.Drawing.Point(231, 12);
			this.internetpanel.Name = "internetpanel";
			this.internetpanel.Padding = new System.Windows.Forms.Padding(10);
			this.internetpanel.Size = new System.Drawing.Size(208, 85);
			this.internetpanel.TabIndex = 1;
			this.internetpanel.Tag = "internet";
			// 
			// overviewpanel
			// 
			this.overviewpanel.AnimationEndSound = null;
			this.overviewpanel.BackColor = System.Drawing.Color.DarkGray;
			this.overviewpanel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.overviewpanel.Location = new System.Drawing.Point(12, 12);
			this.overviewpanel.Margin = new System.Windows.Forms.Padding(0);
			this.overviewpanel.Name = "overviewpanel";
			this.overviewpanel.Padding = new System.Windows.Forms.Padding(10);
			this.overviewpanel.Size = new System.Drawing.Size(208, 85);
			this.overviewpanel.TabIndex = 0;
			this.overviewpanel.Tag = "overview";
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Gray;
			this.ClientSize = new System.Drawing.Size(1280, 1024);
			this.ControlBox = false;
			this.Controls.Add(this.librarySearchDisplayPanel1);
			this.Controls.Add(this.playlistspanel);
			this.Controls.Add(this.mediaplayerpanel);
			this.Controls.Add(this.librarybrowserpanel);
			this.Controls.Add(this.notespanel);
			this.Controls.Add(this.transferobexpanel);
			this.Controls.Add(this.loadingpanel);
			this.Controls.Add(this.errorpanel);
			this.Controls.Add(this.addgroceriespanel);
			this.Controls.Add(this.groceriespanel);
			this.Controls.Add(this.accesspanel);
			this.Controls.Add(this.buienradarpanel);
			this.Controls.Add(this.treintijdenpanel);
			this.Controls.Add(this.agendaitempanel);
			this.Controls.Add(this.agendadaypanel);
			this.Controls.Add(this.agendapanel);
			this.Controls.Add(this.internetpanel);
			this.Controls.Add(this.overviewpanel);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Gluon";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer screensaver;
		private System.Windows.Forms.Timer warningflasher;
		private OverviewDisplayPanel overviewpanel;
		private System.Windows.Forms.Timer infoflasher;
		private System.Windows.Forms.Timer activitychecker;
		private InternetDisplayPanel internetpanel;
		private AgendaDisplayPanel agendapanel;
		private AgendaEditDisplayPanel agendadaypanel;
		private AgendaItemDisplayPanel agendaitempanel;
		private TreintijdenDisplayPanel treintijdenpanel;
		private BuienradarDisplayPanel buienradarpanel;
		private AccessDisplayPanel accesspanel;
		private GroceriesDisplayPanel groceriespanel;
		private AddGroceriesDisplayPanel addgroceriespanel;
		private ErrorDisplayPanel errorpanel;
		private LoadingDisplayPanel loadingpanel;
		private ObexTransferDisplayPanel transferobexpanel;
		private NotesDisplayPanel notespanel;
		private LibraryBrowserDisplayPanel librarybrowserpanel;
		private MediaPlayerDisplayPanel mediaplayerpanel;
		private PlaylistsDisplayPanel playlistspanel;
		private LibrarySearchDisplayPanel librarySearchDisplayPanel1;
	}
}

