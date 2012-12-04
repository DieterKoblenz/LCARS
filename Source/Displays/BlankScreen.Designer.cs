namespace CodeImp.Gluon
{
	partial class BlankScreen
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
			this.calibratinglabel = new CodeImp.Gluon.DisplayLabel();
			this.SuspendLayout();
			// 
			// calibratinglabel
			// 
			this.calibratinglabel.AutoSizeHeight = false;
			this.calibratinglabel.ClickSound = null;
			this.calibratinglabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.calibratinglabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.calibratinglabel.FocusControl = null;
			this.calibratinglabel.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.calibratinglabel.ForeColor = System.Drawing.Color.DarkGray;
			this.calibratinglabel.Location = new System.Drawing.Point(12, 9);
			this.calibratinglabel.MaximumHeight = 0;
			this.calibratinglabel.Name = "calibratinglabel";
			this.calibratinglabel.Size = new System.Drawing.Size(1280, 1024);
			this.calibratinglabel.TabIndex = 22;
			this.calibratinglabel.Text = "SWITCHING SCREEN...";
			this.calibratinglabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BlankScreen
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(3000, 1185);
			this.Controls.Add(this.calibratinglabel);
			this.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BlankScreen";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "BlankScreen";
			this.TopMost = true;
			this.ResumeLayout(false);

		}

		#endregion

		private DisplayLabel calibratinglabel;
	}
}