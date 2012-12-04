namespace CodeImp.Gluon
{
	partial class OverviewTechPanel1
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.displayLabel1 = new CodeImp.Gluon.DisplayLabel();
			this.librarysizelabel = new CodeImp.Gluon.DisplayLabel();
			this.updatetimer = new System.Windows.Forms.Timer(this.components);
			this.displayLabel2 = new CodeImp.Gluon.DisplayLabel();
			this.displayLabel4 = new CodeImp.Gluon.DisplayLabel();
			this.displayLabel3 = new CodeImp.Gluon.DisplayLabel();
			this.libraryusedlabel = new CodeImp.Gluon.DisplayLabel();
			this.libraryfreelabel = new CodeImp.Gluon.DisplayLabel();
			this.displayLabel7 = new CodeImp.Gluon.DisplayLabel();
			this.memoryfreelabel = new CodeImp.Gluon.DisplayLabel();
			this.displayLabel6 = new CodeImp.Gluon.DisplayLabel();
			this.memoryusedlabel = new CodeImp.Gluon.DisplayLabel();
			this.displayLabel9 = new CodeImp.Gluon.DisplayLabel();
			this.memorysizelabel = new CodeImp.Gluon.DisplayLabel();
			this.libraryusedplabel = new CodeImp.Gluon.DisplayLabel();
			this.libraryfreeplabel = new CodeImp.Gluon.DisplayLabel();
			this.memoryusedplabel = new CodeImp.Gluon.DisplayLabel();
			this.memoryfreeplabel = new CodeImp.Gluon.DisplayLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel1 = new CodeImp.Gluon.DisplayFrame();
			this.displayFrame1 = new CodeImp.Gluon.DisplayFrame();
			this.displayLabel5 = new CodeImp.Gluon.DisplayLabel();
			this.interfacenumberlabel = new CodeImp.Gluon.DisplayLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// displayLabel1
			// 
			this.displayLabel1.AutoSize = true;
			this.displayLabel1.AutoSizeHeight = false;
			this.displayLabel1.ClickSound = null;
			this.displayLabel1.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel1.ColorText = CodeImp.Gluon.ColorIndex.ControlColor2;
			this.displayLabel1.FocusControl = null;
			this.displayLabel1.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel1.Location = new System.Drawing.Point(0, 20);
			this.displayLabel1.MaximumHeight = 0;
			this.displayLabel1.Name = "displayLabel1";
			this.displayLabel1.Size = new System.Drawing.Size(438, 60);
			this.displayLabel1.TabIndex = 20;
			this.displayLabel1.Text = "SYSTEM DIAGNOSTICS";
			// 
			// librarysizelabel
			// 
			this.librarysizelabel.AutoEllipsis = true;
			this.librarysizelabel.AutoSize = true;
			this.librarysizelabel.AutoSizeHeight = false;
			this.librarysizelabel.ClickSound = null;
			this.librarysizelabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.librarysizelabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.librarysizelabel.FocusControl = null;
			this.librarysizelabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.librarysizelabel.Location = new System.Drawing.Point(212, 107);
			this.librarysizelabel.MaximumHeight = 0;
			this.librarysizelabel.Name = "librarysizelabel";
			this.librarysizelabel.Size = new System.Drawing.Size(82, 29);
			this.librarysizelabel.TabIndex = 21;
			this.librarysizelabel.Text = "999 GB";
			// 
			// updatetimer
			// 
			this.updatetimer.Enabled = true;
			this.updatetimer.Interval = 3000;
			this.updatetimer.Tick += new System.EventHandler(this.updatetimer_Tick);
			// 
			// displayLabel2
			// 
			this.displayLabel2.AutoEllipsis = true;
			this.displayLabel2.AutoSize = true;
			this.displayLabel2.AutoSizeHeight = false;
			this.displayLabel2.ClickSound = null;
			this.displayLabel2.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel2.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel2.FocusControl = null;
			this.displayLabel2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel2.Location = new System.Drawing.Point(40, 107);
			this.displayLabel2.MaximumHeight = 0;
			this.displayLabel2.Name = "displayLabel2";
			this.displayLabel2.Size = new System.Drawing.Size(166, 29);
			this.displayLabel2.TabIndex = 21;
			this.displayLabel2.Text = "Library Storage:";
			// 
			// displayLabel4
			// 
			this.displayLabel4.AutoEllipsis = true;
			this.displayLabel4.AutoSize = true;
			this.displayLabel4.AutoSizeHeight = false;
			this.displayLabel4.ClickSound = null;
			this.displayLabel4.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel4.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel4.FocusControl = null;
			this.displayLabel4.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel4.Location = new System.Drawing.Point(32, 243);
			this.displayLabel4.MaximumHeight = 0;
			this.displayLabel4.Name = "displayLabel4";
			this.displayLabel4.Size = new System.Drawing.Size(174, 29);
			this.displayLabel4.TabIndex = 24;
			this.displayLabel4.Text = "System Memory:";
			// 
			// displayLabel3
			// 
			this.displayLabel3.AutoEllipsis = true;
			this.displayLabel3.AutoSize = true;
			this.displayLabel3.AutoSizeHeight = false;
			this.displayLabel3.BackColor = System.Drawing.Color.Transparent;
			this.displayLabel3.ClickSound = null;
			this.displayLabel3.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel3.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel3.FocusControl = null;
			this.displayLabel3.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel3.Location = new System.Drawing.Point(140, 144);
			this.displayLabel3.MaximumHeight = 0;
			this.displayLabel3.Name = "displayLabel3";
			this.displayLabel3.Size = new System.Drawing.Size(66, 29);
			this.displayLabel3.TabIndex = 22;
			this.displayLabel3.Text = "Used:";
			// 
			// libraryusedlabel
			// 
			this.libraryusedlabel.AutoEllipsis = true;
			this.libraryusedlabel.AutoSize = true;
			this.libraryusedlabel.AutoSizeHeight = false;
			this.libraryusedlabel.BackColor = System.Drawing.Color.Transparent;
			this.libraryusedlabel.ClickSound = null;
			this.libraryusedlabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.libraryusedlabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.libraryusedlabel.FocusControl = null;
			this.libraryusedlabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.libraryusedlabel.Location = new System.Drawing.Point(212, 144);
			this.libraryusedlabel.MaximumHeight = 0;
			this.libraryusedlabel.Name = "libraryusedlabel";
			this.libraryusedlabel.Size = new System.Drawing.Size(82, 29);
			this.libraryusedlabel.TabIndex = 22;
			this.libraryusedlabel.Text = "999 GB";
			// 
			// libraryfreelabel
			// 
			this.libraryfreelabel.AutoEllipsis = true;
			this.libraryfreelabel.AutoSize = true;
			this.libraryfreelabel.AutoSizeHeight = false;
			this.libraryfreelabel.BackColor = System.Drawing.Color.Transparent;
			this.libraryfreelabel.ClickSound = null;
			this.libraryfreelabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.libraryfreelabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.libraryfreelabel.FocusControl = null;
			this.libraryfreelabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.libraryfreelabel.Location = new System.Drawing.Point(212, 181);
			this.libraryfreelabel.MaximumHeight = 0;
			this.libraryfreelabel.Name = "libraryfreelabel";
			this.libraryfreelabel.Size = new System.Drawing.Size(82, 29);
			this.libraryfreelabel.TabIndex = 23;
			this.libraryfreelabel.Text = "999 GB";
			// 
			// displayLabel7
			// 
			this.displayLabel7.AutoEllipsis = true;
			this.displayLabel7.AutoSize = true;
			this.displayLabel7.AutoSizeHeight = false;
			this.displayLabel7.BackColor = System.Drawing.Color.Transparent;
			this.displayLabel7.ClickSound = null;
			this.displayLabel7.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel7.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel7.FocusControl = null;
			this.displayLabel7.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel7.Location = new System.Drawing.Point(145, 181);
			this.displayLabel7.MaximumHeight = 0;
			this.displayLabel7.Name = "displayLabel7";
			this.displayLabel7.Size = new System.Drawing.Size(61, 29);
			this.displayLabel7.TabIndex = 23;
			this.displayLabel7.Text = "Free:";
			// 
			// memoryfreelabel
			// 
			this.memoryfreelabel.AutoEllipsis = true;
			this.memoryfreelabel.AutoSize = true;
			this.memoryfreelabel.AutoSizeHeight = false;
			this.memoryfreelabel.BackColor = System.Drawing.Color.Transparent;
			this.memoryfreelabel.ClickSound = null;
			this.memoryfreelabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.memoryfreelabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.memoryfreelabel.FocusControl = null;
			this.memoryfreelabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoryfreelabel.Location = new System.Drawing.Point(212, 317);
			this.memoryfreelabel.MaximumHeight = 0;
			this.memoryfreelabel.Name = "memoryfreelabel";
			this.memoryfreelabel.Size = new System.Drawing.Size(82, 29);
			this.memoryfreelabel.TabIndex = 26;
			this.memoryfreelabel.Text = "999 GB";
			// 
			// displayLabel6
			// 
			this.displayLabel6.AutoEllipsis = true;
			this.displayLabel6.AutoSize = true;
			this.displayLabel6.AutoSizeHeight = false;
			this.displayLabel6.BackColor = System.Drawing.Color.Transparent;
			this.displayLabel6.ClickSound = null;
			this.displayLabel6.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel6.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel6.FocusControl = null;
			this.displayLabel6.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel6.Location = new System.Drawing.Point(145, 317);
			this.displayLabel6.MaximumHeight = 0;
			this.displayLabel6.Name = "displayLabel6";
			this.displayLabel6.Size = new System.Drawing.Size(61, 29);
			this.displayLabel6.TabIndex = 26;
			this.displayLabel6.Text = "Free:";
			// 
			// memoryusedlabel
			// 
			this.memoryusedlabel.AutoEllipsis = true;
			this.memoryusedlabel.AutoSize = true;
			this.memoryusedlabel.AutoSizeHeight = false;
			this.memoryusedlabel.BackColor = System.Drawing.Color.Transparent;
			this.memoryusedlabel.ClickSound = null;
			this.memoryusedlabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.memoryusedlabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.memoryusedlabel.FocusControl = null;
			this.memoryusedlabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoryusedlabel.Location = new System.Drawing.Point(212, 280);
			this.memoryusedlabel.MaximumHeight = 0;
			this.memoryusedlabel.Name = "memoryusedlabel";
			this.memoryusedlabel.Size = new System.Drawing.Size(82, 29);
			this.memoryusedlabel.TabIndex = 25;
			this.memoryusedlabel.Text = "999 GB";
			// 
			// displayLabel9
			// 
			this.displayLabel9.AutoEllipsis = true;
			this.displayLabel9.AutoSize = true;
			this.displayLabel9.AutoSizeHeight = false;
			this.displayLabel9.BackColor = System.Drawing.Color.Transparent;
			this.displayLabel9.ClickSound = null;
			this.displayLabel9.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel9.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel9.FocusControl = null;
			this.displayLabel9.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel9.Location = new System.Drawing.Point(140, 280);
			this.displayLabel9.MaximumHeight = 0;
			this.displayLabel9.Name = "displayLabel9";
			this.displayLabel9.Size = new System.Drawing.Size(66, 29);
			this.displayLabel9.TabIndex = 25;
			this.displayLabel9.Text = "Used:";
			// 
			// memorysizelabel
			// 
			this.memorysizelabel.AutoEllipsis = true;
			this.memorysizelabel.AutoSize = true;
			this.memorysizelabel.AutoSizeHeight = false;
			this.memorysizelabel.ClickSound = null;
			this.memorysizelabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.memorysizelabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.memorysizelabel.FocusControl = null;
			this.memorysizelabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memorysizelabel.Location = new System.Drawing.Point(212, 243);
			this.memorysizelabel.MaximumHeight = 0;
			this.memorysizelabel.Name = "memorysizelabel";
			this.memorysizelabel.Size = new System.Drawing.Size(82, 29);
			this.memorysizelabel.TabIndex = 24;
			this.memorysizelabel.Text = "999 GB";
			// 
			// libraryusedplabel
			// 
			this.libraryusedplabel.AutoEllipsis = true;
			this.libraryusedplabel.AutoSize = true;
			this.libraryusedplabel.AutoSizeHeight = false;
			this.libraryusedplabel.BackColor = System.Drawing.Color.Transparent;
			this.libraryusedplabel.ClickSound = null;
			this.libraryusedplabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.libraryusedplabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.libraryusedplabel.FocusControl = null;
			this.libraryusedplabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.libraryusedplabel.Location = new System.Drawing.Point(316, 144);
			this.libraryusedplabel.MaximumHeight = 0;
			this.libraryusedplabel.Name = "libraryusedplabel";
			this.libraryusedplabel.Size = new System.Drawing.Size(52, 29);
			this.libraryusedplabel.TabIndex = 22;
			this.libraryusedplabel.Text = "76%";
			// 
			// libraryfreeplabel
			// 
			this.libraryfreeplabel.AutoEllipsis = true;
			this.libraryfreeplabel.AutoSize = true;
			this.libraryfreeplabel.AutoSizeHeight = false;
			this.libraryfreeplabel.BackColor = System.Drawing.Color.Transparent;
			this.libraryfreeplabel.ClickSound = null;
			this.libraryfreeplabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.libraryfreeplabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.libraryfreeplabel.FocusControl = null;
			this.libraryfreeplabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.libraryfreeplabel.Location = new System.Drawing.Point(316, 181);
			this.libraryfreeplabel.MaximumHeight = 0;
			this.libraryfreeplabel.Name = "libraryfreeplabel";
			this.libraryfreeplabel.Size = new System.Drawing.Size(52, 29);
			this.libraryfreeplabel.TabIndex = 23;
			this.libraryfreeplabel.Text = "76%";
			// 
			// memoryusedplabel
			// 
			this.memoryusedplabel.AutoEllipsis = true;
			this.memoryusedplabel.AutoSize = true;
			this.memoryusedplabel.AutoSizeHeight = false;
			this.memoryusedplabel.BackColor = System.Drawing.Color.Transparent;
			this.memoryusedplabel.ClickSound = null;
			this.memoryusedplabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.memoryusedplabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.memoryusedplabel.FocusControl = null;
			this.memoryusedplabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoryusedplabel.Location = new System.Drawing.Point(316, 280);
			this.memoryusedplabel.MaximumHeight = 0;
			this.memoryusedplabel.Name = "memoryusedplabel";
			this.memoryusedplabel.Size = new System.Drawing.Size(52, 29);
			this.memoryusedplabel.TabIndex = 25;
			this.memoryusedplabel.Text = "76%";
			// 
			// memoryfreeplabel
			// 
			this.memoryfreeplabel.AutoEllipsis = true;
			this.memoryfreeplabel.AutoSize = true;
			this.memoryfreeplabel.AutoSizeHeight = false;
			this.memoryfreeplabel.BackColor = System.Drawing.Color.Transparent;
			this.memoryfreeplabel.ClickSound = null;
			this.memoryfreeplabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.memoryfreeplabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.memoryfreeplabel.FocusControl = null;
			this.memoryfreeplabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.memoryfreeplabel.Location = new System.Drawing.Point(316, 317);
			this.memoryfreeplabel.MaximumHeight = 0;
			this.memoryfreeplabel.Name = "memoryfreeplabel";
			this.memoryfreeplabel.Size = new System.Drawing.Size(52, 29);
			this.memoryfreeplabel.TabIndex = 26;
			this.memoryfreeplabel.Text = "76%";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::CodeImp.Gluon.Properties.Resources.diskstructure;
			this.pictureBox1.Location = new System.Drawing.Point(506, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(444, 440);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 47;
			this.pictureBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.ColorBackground = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.panel1.Location = new System.Drawing.Point(361, 122);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(437, 1);
			this.panel1.TabIndex = 21;
			// 
			// displayFrame1
			// 
			this.displayFrame1.BackColor = System.Drawing.Color.Silver;
			this.displayFrame1.ColorBackground = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayFrame1.Location = new System.Drawing.Point(361, 258);
			this.displayFrame1.Name = "displayFrame1";
			this.displayFrame1.Size = new System.Drawing.Size(290, 1);
			this.displayFrame1.TabIndex = 24;
			// 
			// displayLabel5
			// 
			this.displayLabel5.AutoEllipsis = true;
			this.displayLabel5.AutoSize = true;
			this.displayLabel5.AutoSizeHeight = false;
			this.displayLabel5.ClickSound = null;
			this.displayLabel5.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayLabel5.ColorText = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayLabel5.FocusControl = null;
			this.displayLabel5.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.displayLabel5.Location = new System.Drawing.Point(32, 379);
			this.displayLabel5.MaximumHeight = 0;
			this.displayLabel5.Name = "displayLabel5";
			this.displayLabel5.Size = new System.Drawing.Size(252, 29);
			this.displayLabel5.TabIndex = 48;
			this.displayLabel5.Text = "Interface Serial Number:";
			// 
			// interfacenumberlabel
			// 
			this.interfacenumberlabel.AutoEllipsis = true;
			this.interfacenumberlabel.AutoSize = true;
			this.interfacenumberlabel.AutoSizeHeight = false;
			this.interfacenumberlabel.ClickSound = null;
			this.interfacenumberlabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.interfacenumberlabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.interfacenumberlabel.FocusControl = null;
			this.interfacenumberlabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.interfacenumberlabel.Location = new System.Drawing.Point(316, 379);
			this.interfacenumberlabel.MaximumHeight = 0;
			this.interfacenumberlabel.Name = "interfacenumberlabel";
			this.interfacenumberlabel.Size = new System.Drawing.Size(82, 29);
			this.interfacenumberlabel.TabIndex = 49;
			this.interfacenumberlabel.Text = "999 GB";
			// 
			// OverviewTechPanel1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.interfacenumberlabel);
			this.Controls.Add(this.displayLabel5);
			this.Controls.Add(this.displayFrame1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.memoryfreeplabel);
			this.Controls.Add(this.memoryusedplabel);
			this.Controls.Add(this.libraryfreeplabel);
			this.Controls.Add(this.libraryusedplabel);
			this.Controls.Add(this.memoryfreelabel);
			this.Controls.Add(this.displayLabel6);
			this.Controls.Add(this.memoryusedlabel);
			this.Controls.Add(this.displayLabel9);
			this.Controls.Add(this.memorysizelabel);
			this.Controls.Add(this.libraryfreelabel);
			this.Controls.Add(this.displayLabel7);
			this.Controls.Add(this.libraryusedlabel);
			this.Controls.Add(this.displayLabel3);
			this.Controls.Add(this.displayLabel4);
			this.Controls.Add(this.displayLabel2);
			this.Controls.Add(this.librarysizelabel);
			this.Controls.Add(this.displayLabel1);
			this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.Name = "OverviewTechPanel1";
			this.Padding = new System.Windows.Forms.Padding(20);
			this.Size = new System.Drawing.Size(950, 440);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DisplayLabel displayLabel1;
		private DisplayLabel librarysizelabel;
		private System.Windows.Forms.Timer updatetimer;
		private DisplayLabel displayLabel2;
		private DisplayLabel displayLabel4;
		private DisplayLabel displayLabel3;
		private DisplayLabel libraryusedlabel;
		private DisplayLabel libraryfreelabel;
		private DisplayLabel displayLabel7;
		private DisplayLabel memoryfreelabel;
		private DisplayLabel displayLabel6;
		private DisplayLabel memoryusedlabel;
		private DisplayLabel displayLabel9;
		private DisplayLabel memorysizelabel;
		private DisplayLabel libraryusedplabel;
		private DisplayLabel libraryfreeplabel;
		private DisplayLabel memoryusedplabel;
		private DisplayLabel memoryfreeplabel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private DisplayFrame panel1;
		private DisplayFrame displayFrame1;
		private DisplayLabel displayLabel5;
		private DisplayLabel interfacenumberlabel;

	}
}
