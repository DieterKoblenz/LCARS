namespace CodeImp.Gluon
{
	partial class AgendaDayDisplay
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.addbutton = new CodeImp.Gluon.DisplayButton();
			this.viewbutton = new CodeImp.Gluon.DisplayButton();
			this.textlabel1 = new CodeImp.Gluon.DisplayLabel();
			this.timelabel1 = new CodeImp.Gluon.DisplayLabel();
			this.daybar = new CodeImp.Gluon.DisplayBar();
			this.daynamelabel = new CodeImp.Gluon.DisplayLabel();
			this.daylabel = new CodeImp.Gluon.DisplayLabel();
			this.daybar.SuspendLayout();
			this.SuspendLayout();
			// 
			// addbutton
			// 
			this.addbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addbutton.BackColor = System.Drawing.Color.LightGray;
			this.addbutton.Clickable = true;
			this.addbutton.ClickSound = "214";
			this.addbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.addbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addbutton.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.addbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.addbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.addbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.addbutton.InverseFlash = false;
			this.addbutton.Location = new System.Drawing.Point(403, 0);
			this.addbutton.Name = "addbutton";
			this.addbutton.ScaleFixedWidth = true;
			this.addbutton.ScaleLeftBottom = 0.5F;
			this.addbutton.ScaleLeftTop = 0.5F;
			this.addbutton.ScaleRightBottom = 0.5F;
			this.addbutton.ScaleRightTop = 0.5F;
			this.addbutton.Size = new System.Drawing.Size(70, 61);
			this.addbutton.TabIndex = 0;
			this.addbutton.Text = "+";
			this.addbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
			// 
			// viewbutton
			// 
			this.viewbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.viewbutton.BackColor = System.Drawing.Color.LightGray;
			this.viewbutton.Clickable = true;
			this.viewbutton.ClickSound = "214";
			this.viewbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.viewbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.viewbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.viewbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.viewbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.viewbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.viewbutton.InverseFlash = false;
			this.viewbutton.Location = new System.Drawing.Point(271, 0);
			this.viewbutton.Name = "viewbutton";
			this.viewbutton.Padding = new System.Windows.Forms.Padding(5);
			this.viewbutton.ScaleFixedWidth = true;
			this.viewbutton.ScaleLeftBottom = 0.5F;
			this.viewbutton.ScaleLeftTop = 0.5F;
			this.viewbutton.ScaleRightBottom = 0.5F;
			this.viewbutton.ScaleRightTop = 0.5F;
			this.viewbutton.Size = new System.Drawing.Size(126, 61);
			this.viewbutton.TabIndex = 0;
			this.viewbutton.Text = "View";
			this.viewbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.viewbutton.Click += new System.EventHandler(this.viewbutton_Click);
			// 
			// textlabel1
			// 
			this.textlabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textlabel1.AutoEllipsis = true;
			this.textlabel1.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.textlabel1.ColorText = CodeImp.Gluon.ColorIndex.WindowText;
			this.textlabel1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textlabel1.Location = new System.Drawing.Point(83, 65);
			this.textlabel1.Name = "textlabel1";
			this.textlabel1.Size = new System.Drawing.Size(387, 29);
			this.textlabel1.TabIndex = 0;
			this.textlabel1.Text = "•  This description is way too long to display on the agenda week view, but I\'m t" +
				"rying anyway.";
			this.textlabel1.UseMnemonic = false;
			this.textlabel1.Visible = false;
			// 
			// timelabel1
			// 
			this.timelabel1.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.timelabel1.ColorText = CodeImp.Gluon.ColorIndex.WindowText;
			this.timelabel1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timelabel1.Location = new System.Drawing.Point(13, 65);
			this.timelabel1.Name = "timelabel1";
			this.timelabel1.Size = new System.Drawing.Size(69, 29);
			this.timelabel1.TabIndex = 0;
			this.timelabel1.Text = "23:35";
			this.timelabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.timelabel1.Visible = false;
			// 
			// daybar
			// 
			this.daybar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.daybar.BackColor = System.Drawing.Color.LightGray;
			this.daybar.BlockMouseInput = true;
			this.daybar.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.daybar.Controls.Add(this.daynamelabel);
			this.daybar.Controls.Add(this.daylabel);
			this.daybar.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.daybar.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.daybar.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.daybar.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.daybar.Location = new System.Drawing.Point(0, 0);
			this.daybar.Name = "daybar";
			this.daybar.ScaleFixedWidth = true;
			this.daybar.ScaleLeftBottom = 0.5F;
			this.daybar.ScaleLeftTop = 0.5F;
			this.daybar.ScaleRightBottom = 0.5F;
			this.daybar.ScaleRightTop = 0.5F;
			this.daybar.Size = new System.Drawing.Size(265, 61);
			this.daybar.TabIndex = 0;
			// 
			// daynamelabel
			// 
			this.daynamelabel.AutoSize = true;
			this.daynamelabel.BackColor = System.Drawing.Color.LightGray;
			this.daynamelabel.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.daynamelabel.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.daynamelabel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.daynamelabel.Location = new System.Drawing.Point(66, 11);
			this.daynamelabel.Name = "daynamelabel";
			this.daynamelabel.Size = new System.Drawing.Size(120, 39);
			this.daynamelabel.TabIndex = 0;
			this.daynamelabel.Text = "Monday";
			// 
			// daylabel
			// 
			this.daylabel.BackColor = System.Drawing.Color.LightGray;
			this.daylabel.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.daylabel.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.daylabel.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.daylabel.Location = new System.Drawing.Point(9, 11);
			this.daylabel.Name = "daylabel";
			this.daylabel.Size = new System.Drawing.Size(51, 39);
			this.daylabel.TabIndex = 0;
			this.daylabel.Text = "35";
			this.daylabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// AgendaDayDisplay
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.addbutton);
			this.Controls.Add(this.viewbutton);
			this.Controls.Add(this.textlabel1);
			this.Controls.Add(this.timelabel1);
			this.Controls.Add(this.daybar);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "AgendaDayDisplay";
			this.Size = new System.Drawing.Size(473, 362);
			this.daybar.ResumeLayout(false);
			this.daybar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DisplayLabel daynamelabel;
		private DisplayLabel daylabel;
		private DisplayLabel timelabel1;
		private DisplayLabel textlabel1;
		private DisplayButton viewbutton;
		private DisplayButton addbutton;
		private DisplayBar daybar;
	}
}
