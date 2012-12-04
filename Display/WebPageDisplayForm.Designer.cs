namespace CodeImp.Gluon
{
	partial class WebPageDisplayForm
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
			this.browser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// browser
			// 
			this.browser.AllowWebBrowserDrop = false;
			this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browser.IsWebBrowserContextMenuEnabled = false;
			this.browser.Location = new System.Drawing.Point(0, 0);
			this.browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.browser.Name = "browser";
			this.browser.ScriptErrorsSuppressed = true;
			this.browser.ScrollBarsEnabled = false;
			this.browser.Size = new System.Drawing.Size(834, 683);
			this.browser.TabIndex = 0;
			this.browser.TabStop = false;
			this.browser.WebBrowserShortcutsEnabled = false;
			// 
			// WebPageDisplayForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.ClientSize = new System.Drawing.Size(834, 683);
			this.ControlBox = false;
			this.Controls.Add(this.browser);
			this.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WebPageDisplayForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "WebPageDisplayForm";
			this.TopMost = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser browser;

	}
}