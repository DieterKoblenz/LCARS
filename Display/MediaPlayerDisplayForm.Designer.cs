namespace CodeImp.Gluon
{
	partial class MediaPlayerDisplayForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaPlayerDisplayForm));
			this.updatetimer = new System.Windows.Forms.Timer(this.components);
			this.muxplayer = new AxWMPLib.AxWindowsMediaPlayer();
			this.player = new AxWMPLib.AxWindowsMediaPlayer();
			((System.ComponentModel.ISupportInitialize)(this.muxplayer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
			this.SuspendLayout();
			// 
			// updatetimer
			// 
			this.updatetimer.Interval = 200;
			this.updatetimer.Tick += new System.EventHandler(this.updatetimer_Tick);
			// 
			// muxplayer
			// 
			this.muxplayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.muxplayer.Enabled = true;
			this.muxplayer.Location = new System.Drawing.Point(0, 0);
			this.muxplayer.Name = "muxplayer";
			this.muxplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("muxplayer.OcxState")));
			this.muxplayer.Size = new System.Drawing.Size(795, 638);
			this.muxplayer.TabIndex = 1;
			// 
			// player
			// 
			this.player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.player.Enabled = true;
			this.player.Location = new System.Drawing.Point(0, 0);
			this.player.Name = "player";
			this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
			this.player.Size = new System.Drawing.Size(795, 638);
			this.player.TabIndex = 0;
			this.player.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.player_PlayStateChange);
			// 
			// MediaPlayerDisplayForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(795, 638);
			this.ControlBox = false;
			this.Controls.Add(this.player);
			this.Controls.Add(this.muxplayer);
			this.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MediaPlayerDisplayForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MediaPlayerDisplayForm";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.muxplayer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer updatetimer;
		private AxWMPLib.AxWindowsMediaPlayer player;
		private AxWMPLib.AxWindowsMediaPlayer muxplayer;
	}
}