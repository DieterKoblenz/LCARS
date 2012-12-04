namespace CodeImp.Gluon
{
	partial class InternetDisplayPanel
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
			this.displayBar1 = new CodeImp.Gluon.DisplayBar();
			this.addressbox = new System.Windows.Forms.TextBox();
			this.displayCorner1 = new CodeImp.Gluon.DisplayCorner();
			this.gobutton = new CodeImp.Gluon.DisplayButton();
			this.optionsbutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar2 = new CodeImp.Gluon.DisplayBar();
			this.displayBar3 = new CodeImp.Gluon.DisplayBar();
			this.scrollupbutton = new CodeImp.Gluon.DisplayButton();
			this.scrolldownbutton = new CodeImp.Gluon.DisplayButton();
			this.displayCorner2 = new CodeImp.Gluon.DisplayCorner();
			this.linksbutton = new CodeImp.Gluon.DisplayButton();
			this.displayButton4 = new CodeImp.Gluon.DisplayButton();
			this.displayBar5 = new CodeImp.Gluon.DisplayBar();
			this.displayBar6 = new CodeImp.Gluon.DisplayBar();
			this.inputbutton = new CodeImp.Gluon.DisplayButton();
			this.displayCorner4 = new CodeImp.Gluon.DisplayCorner();
			this.displayBar7 = new CodeImp.Gluon.DisplayBar();
			this.sizelabel = new CodeImp.Gluon.DisplayLabel();
			this.displayCorner3 = new CodeImp.Gluon.DisplayCorner();
			this.overviewbutton = new CodeImp.Gluon.DisplayButton();
			this.backbutton = new CodeImp.Gluon.DisplayButton();
			this.browserframe = new CodeImp.Gluon.DisplayFrame();
			this.inputframe = new CodeImp.Gluon.DisplayFrame();
			this.keyboard = new CodeImp.Gluon.DisplayKeyboard();
			this.linksframe = new CodeImp.Gluon.DisplayFrame();
			this.displayButton11 = new CodeImp.Gluon.DisplayButton();
			this.displayButton10 = new CodeImp.Gluon.DisplayButton();
			this.displayButton9 = new CodeImp.Gluon.DisplayButton();
			this.displayButton8 = new CodeImp.Gluon.DisplayButton();
			this.displayButton7 = new CodeImp.Gluon.DisplayButton();
			this.displayButton6 = new CodeImp.Gluon.DisplayButton();
			this.displayButton2 = new CodeImp.Gluon.DisplayButton();
			this.displayButton1 = new CodeImp.Gluon.DisplayButton();
			this.displayButton5 = new CodeImp.Gluon.DisplayButton();
			this.displayButton3 = new CodeImp.Gluon.DisplayButton();
			this.scrollbar = new CodeImp.Gluon.DisplayButton();
			this.scrolltimer = new System.Windows.Forms.Timer(this.components);
			this.optionsframe = new CodeImp.Gluon.DisplayFrame();
			this.showvideobutton = new CodeImp.Gluon.DisplayButton();
			this.onscreenbutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar1.SuspendLayout();
			this.displayBar7.SuspendLayout();
			this.browserframe.SuspendLayout();
			this.inputframe.SuspendLayout();
			this.linksframe.SuspendLayout();
			this.optionsframe.SuspendLayout();
			this.SuspendLayout();
			// 
			// displayBar1
			// 
			this.displayBar1.BackColor = System.Drawing.Color.LightGray;
			this.displayBar1.BlockMouseInput = true;
			this.displayBar1.ClickSound = null;
			this.displayBar1.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar1.Controls.Add(this.addressbox);
			this.displayBar1.FocusControl = null;
			this.displayBar1.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayBar1.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayBar1.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar1.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar1.Location = new System.Drawing.Point(13, 12);
			this.displayBar1.Name = "displayBar1";
			this.displayBar1.Padding = new System.Windows.Forms.Padding(5);
			this.displayBar1.ScaleFixedWidth = true;
			this.displayBar1.ScaleLeftBottom = 0.5F;
			this.displayBar1.ScaleLeftTop = 0.5F;
			this.displayBar1.ScaleRightBottom = 0.5F;
			this.displayBar1.ScaleRightTop = 0.5F;
			this.displayBar1.Size = new System.Drawing.Size(695, 87);
			this.displayBar1.TabIndex = 1;
			// 
			// addressbox
			// 
			this.addressbox.BackColor = System.Drawing.Color.LightGray;
			this.addressbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.addressbox.Cursor = System.Windows.Forms.Cursors.Default;
			this.addressbox.Location = new System.Drawing.Point(33, 39);
			this.addressbox.Name = "addressbox";
			this.addressbox.Size = new System.Drawing.Size(654, 40);
			this.addressbox.TabIndex = 1;
			this.addressbox.Text = "http://www.google.com/";
			this.addressbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addressbox_KeyDown);
			// 
			// displayCorner1
			// 
			this.displayCorner1.BackColor = System.Drawing.Color.DimGray;
			this.displayCorner1.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayCorner1.CurveDetail = 10;
			this.displayCorner1.FlipX = false;
			this.displayCorner1.FlipY = false;
			this.displayCorner1.Location = new System.Drawing.Point(0, 0);
			this.displayCorner1.Name = "displayCorner1";
			this.displayCorner1.Size = new System.Drawing.Size(26, 26);
			this.displayCorner1.TabIndex = 0;
			// 
			// gobutton
			// 
			this.gobutton.BackColor = System.Drawing.Color.LightGreen;
			this.gobutton.Clickable = true;
			this.gobutton.ClickSound = "208";
			this.gobutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColorAffirmative;
			this.gobutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.gobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gobutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.gobutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.gobutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.gobutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.gobutton.InverseFlash = false;
			this.gobutton.Location = new System.Drawing.Point(714, 12);
			this.gobutton.Name = "gobutton";
			this.gobutton.Padding = new System.Windows.Forms.Padding(5);
			this.gobutton.ScaleFixedWidth = true;
			this.gobutton.ScaleLeftBottom = 0.25F;
			this.gobutton.ScaleLeftTop = 0.25F;
			this.gobutton.ScaleRightBottom = 0.25F;
			this.gobutton.ScaleRightTop = 0.25F;
			this.gobutton.Size = new System.Drawing.Size(200, 87);
			this.gobutton.TabIndex = 2;
			this.gobutton.Text = "Load";
			this.gobutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.gobutton.Click += new System.EventHandler(this.gobutton_Click);
			// 
			// optionsbutton
			// 
			this.optionsbutton.BackColor = System.Drawing.Color.SteelBlue;
			this.optionsbutton.Clickable = true;
			this.optionsbutton.ClickSound = "207";
			this.optionsbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.optionsbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.optionsbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.optionsbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.optionsbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.optionsbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.optionsbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.optionsbutton.InverseFlash = false;
			this.optionsbutton.Location = new System.Drawing.Point(508, 924);
			this.optionsbutton.Name = "optionsbutton";
			this.optionsbutton.Padding = new System.Windows.Forms.Padding(5);
			this.optionsbutton.ScaleFixedWidth = true;
			this.optionsbutton.ScaleLeftBottom = 0.25F;
			this.optionsbutton.ScaleLeftTop = 0.25F;
			this.optionsbutton.ScaleRightBottom = 0.25F;
			this.optionsbutton.ScaleRightTop = 0.25F;
			this.optionsbutton.Size = new System.Drawing.Size(200, 87);
			this.optionsbutton.TabIndex = 3;
			this.optionsbutton.Text = "Options";
			this.optionsbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.optionsbutton.Click += new System.EventHandler(this.optionsbutton_Click);
			// 
			// displayBar2
			// 
			this.displayBar2.BackColor = System.Drawing.Color.LightGray;
			this.displayBar2.BlockMouseInput = true;
			this.displayBar2.ClickSound = null;
			this.displayBar2.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar2.FocusControl = null;
			this.displayBar2.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.Location = new System.Drawing.Point(1126, 12);
			this.displayBar2.Name = "displayBar2";
			this.displayBar2.ScaleFixedWidth = false;
			this.displayBar2.ScaleLeftBottom = 0.25F;
			this.displayBar2.ScaleLeftTop = 0.25F;
			this.displayBar2.ScaleRightBottom = 0.25F;
			this.displayBar2.ScaleRightTop = 0.25F;
			this.displayBar2.Size = new System.Drawing.Size(48, 87);
			this.displayBar2.TabIndex = 4;
			// 
			// displayBar3
			// 
			this.displayBar3.BackColor = System.Drawing.Color.LightGray;
			this.displayBar3.BlockMouseInput = true;
			this.displayBar3.ClickSound = null;
			this.displayBar3.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar3.FocusControl = null;
			this.displayBar3.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveInverseFlipX;
			this.displayBar3.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar3.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar3.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayBar3.Location = new System.Drawing.Point(1171, 12);
			this.displayBar3.Name = "displayBar3";
			this.displayBar3.ScaleFixedWidth = true;
			this.displayBar3.ScaleLeftBottom = 0.31F;
			this.displayBar3.ScaleLeftTop = 0.5F;
			this.displayBar3.ScaleRightBottom = 0.5F;
			this.displayBar3.ScaleRightTop = 0.7F;
			this.displayBar3.Size = new System.Drawing.Size(96, 126);
			this.displayBar3.TabIndex = 5;
			// 
			// scrollupbutton
			// 
			this.scrollupbutton.BackColor = System.Drawing.Color.Tan;
			this.scrollupbutton.Clickable = true;
			this.scrollupbutton.ClickSound = "";
			this.scrollupbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.scrollupbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.scrollupbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.scrollupbutton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.scrollupbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.scrollupbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.scrollupbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.scrollupbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.scrollupbutton.InverseFlash = false;
			this.scrollupbutton.Location = new System.Drawing.Point(1210, 142);
			this.scrollupbutton.Name = "scrollupbutton";
			this.scrollupbutton.ScaleFixedWidth = true;
			this.scrollupbutton.ScaleLeftBottom = 0.25F;
			this.scrollupbutton.ScaleLeftTop = 0.25F;
			this.scrollupbutton.ScaleRightBottom = 0.25F;
			this.scrollupbutton.ScaleRightTop = 0.25F;
			this.scrollupbutton.Size = new System.Drawing.Size(57, 54);
			this.scrollupbutton.TabIndex = 6;
			this.scrollupbutton.Text = "t";
			this.scrollupbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.scrollupbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollupbutton_MouseDown);
			this.scrollupbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbutton_MouseUp);
			// 
			// scrolldownbutton
			// 
			this.scrolldownbutton.BackColor = System.Drawing.Color.Tan;
			this.scrolldownbutton.Clickable = true;
			this.scrolldownbutton.ClickSound = "";
			this.scrolldownbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.scrolldownbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.scrolldownbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.scrolldownbutton.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.scrolldownbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.scrolldownbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.scrolldownbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.scrolldownbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.scrolldownbutton.InverseFlash = false;
			this.scrolldownbutton.Location = new System.Drawing.Point(1210, 827);
			this.scrolldownbutton.Name = "scrolldownbutton";
			this.scrolldownbutton.ScaleFixedWidth = true;
			this.scrolldownbutton.ScaleLeftBottom = 0.25F;
			this.scrolldownbutton.ScaleLeftTop = 0.25F;
			this.scrolldownbutton.ScaleRightBottom = 0.25F;
			this.scrolldownbutton.ScaleRightTop = 0.25F;
			this.scrolldownbutton.Size = new System.Drawing.Size(57, 54);
			this.scrolldownbutton.TabIndex = 8;
			this.scrolldownbutton.Text = "u";
			this.scrolldownbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.scrolldownbutton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrolldownbutton_MouseDown);
			this.scrolldownbutton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbutton_MouseUp);
			// 
			// displayCorner2
			// 
			this.displayCorner2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.displayCorner2.BackColor = System.Drawing.Color.DimGray;
			this.displayCorner2.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayCorner2.CurveDetail = 10;
			this.displayCorner2.FlipX = true;
			this.displayCorner2.FlipY = false;
			this.displayCorner2.Location = new System.Drawing.Point(1161, 0);
			this.displayCorner2.Name = "displayCorner2";
			this.displayCorner2.Size = new System.Drawing.Size(26, 26);
			this.displayCorner2.TabIndex = 0;
			// 
			// linksbutton
			// 
			this.linksbutton.BackColor = System.Drawing.Color.LightGray;
			this.linksbutton.Clickable = true;
			this.linksbutton.ClickSound = "207";
			this.linksbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.linksbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.linksbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.linksbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.linksbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.linksbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.linksbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.linksbutton.InverseFlash = false;
			this.linksbutton.Location = new System.Drawing.Point(714, 924);
			this.linksbutton.Name = "linksbutton";
			this.linksbutton.Padding = new System.Windows.Forms.Padding(5);
			this.linksbutton.ScaleFixedWidth = true;
			this.linksbutton.ScaleLeftBottom = 0.25F;
			this.linksbutton.ScaleLeftTop = 0.25F;
			this.linksbutton.ScaleRightBottom = 0.25F;
			this.linksbutton.ScaleRightTop = 0.25F;
			this.linksbutton.Size = new System.Drawing.Size(200, 87);
			this.linksbutton.TabIndex = 12;
			this.linksbutton.Text = "Links";
			this.linksbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.linksbutton.Click += new System.EventHandler(this.linksbutton_Click);
			// 
			// displayButton4
			// 
			this.displayButton4.BackColor = System.Drawing.Color.LightGray;
			this.displayButton4.Clickable = true;
			this.displayButton4.ClickSound = "214";
			this.displayButton4.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton4.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton4.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayButton4.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayButton4.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayButton4.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayButton4.InverseFlash = false;
			this.displayButton4.Location = new System.Drawing.Point(1210, 901);
			this.displayButton4.Name = "displayButton4";
			this.displayButton4.ScaleFixedWidth = true;
			this.displayButton4.ScaleLeftBottom = 0.25F;
			this.displayButton4.ScaleLeftTop = 0.25F;
			this.displayButton4.ScaleRightBottom = 0.25F;
			this.displayButton4.ScaleRightTop = 0.25F;
			this.displayButton4.Size = new System.Drawing.Size(57, 17);
			this.displayButton4.TabIndex = 17;
			// 
			// displayBar5
			// 
			this.displayBar5.BackColor = System.Drawing.Color.LightGray;
			this.displayBar5.BlockMouseInput = true;
			this.displayBar5.ClickSound = null;
			this.displayBar5.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar5.FocusControl = null;
			this.displayBar5.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveInverseFlipXY;
			this.displayBar5.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayBar5.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.Location = new System.Drawing.Point(1171, 885);
			this.displayBar5.Name = "displayBar5";
			this.displayBar5.ScaleFixedWidth = true;
			this.displayBar5.ScaleLeftBottom = 0.3F;
			this.displayBar5.ScaleLeftTop = 0.31F;
			this.displayBar5.ScaleRightBottom = 0.7F;
			this.displayBar5.ScaleRightTop = 0.7F;
			this.displayBar5.Size = new System.Drawing.Size(96, 126);
			this.displayBar5.TabIndex = 9;
			// 
			// displayBar6
			// 
			this.displayBar6.BackColor = System.Drawing.Color.LightGray;
			this.displayBar6.BlockMouseInput = true;
			this.displayBar6.ClickSound = null;
			this.displayBar6.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar6.FocusControl = null;
			this.displayBar6.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar6.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar6.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar6.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar6.Location = new System.Drawing.Point(1126, 924);
			this.displayBar6.Name = "displayBar6";
			this.displayBar6.ScaleFixedWidth = false;
			this.displayBar6.ScaleLeftBottom = 0.25F;
			this.displayBar6.ScaleLeftTop = 0.25F;
			this.displayBar6.ScaleRightBottom = 0.25F;
			this.displayBar6.ScaleRightTop = 0.25F;
			this.displayBar6.Size = new System.Drawing.Size(48, 87);
			this.displayBar6.TabIndex = 10;
			// 
			// inputbutton
			// 
			this.inputbutton.BackColor = System.Drawing.Color.SteelBlue;
			this.inputbutton.Clickable = true;
			this.inputbutton.ClickSound = "207";
			this.inputbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.inputbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.inputbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.inputbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.inputbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.inputbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.inputbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.inputbutton.InverseFlash = false;
			this.inputbutton.Location = new System.Drawing.Point(13, 924);
			this.inputbutton.Name = "inputbutton";
			this.inputbutton.Padding = new System.Windows.Forms.Padding(5);
			this.inputbutton.ScaleFixedWidth = true;
			this.inputbutton.ScaleLeftBottom = 0.5F;
			this.inputbutton.ScaleLeftTop = 0.5F;
			this.inputbutton.ScaleRightBottom = 0.5F;
			this.inputbutton.ScaleRightTop = 0.5F;
			this.inputbutton.Size = new System.Drawing.Size(200, 87);
			this.inputbutton.TabIndex = 15;
			this.inputbutton.Text = "Input";
			this.inputbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.inputbutton.Click += new System.EventHandler(this.inputbutton_Click);
			// 
			// displayCorner4
			// 
			this.displayCorner4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.displayCorner4.BackColor = System.Drawing.Color.DimGray;
			this.displayCorner4.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayCorner4.CurveDetail = 10;
			this.displayCorner4.FlipX = false;
			this.displayCorner4.FlipY = true;
			this.displayCorner4.Location = new System.Drawing.Point(0, 778);
			this.displayCorner4.Name = "displayCorner4";
			this.displayCorner4.Size = new System.Drawing.Size(26, 25);
			this.displayCorner4.TabIndex = 0;
			// 
			// displayBar7
			// 
			this.displayBar7.BackColor = System.Drawing.Color.LightGray;
			this.displayBar7.BlockMouseInput = true;
			this.displayBar7.ClickSound = null;
			this.displayBar7.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar7.Controls.Add(this.sizelabel);
			this.displayBar7.FocusControl = null;
			this.displayBar7.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.Location = new System.Drawing.Point(219, 924);
			this.displayBar7.Name = "displayBar7";
			this.displayBar7.ScaleFixedWidth = false;
			this.displayBar7.ScaleLeftBottom = 0.25F;
			this.displayBar7.ScaleLeftTop = 0.25F;
			this.displayBar7.ScaleRightBottom = 0.25F;
			this.displayBar7.ScaleRightTop = 0.25F;
			this.displayBar7.Size = new System.Drawing.Size(283, 87);
			this.displayBar7.TabIndex = 21;
			// 
			// sizelabel
			// 
			this.sizelabel.AutoSizeHeight = false;
			this.sizelabel.ClickSound = null;
			this.sizelabel.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.sizelabel.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.sizelabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sizelabel.FocusControl = null;
			this.sizelabel.Location = new System.Drawing.Point(0, 0);
			this.sizelabel.MaximumHeight = 0;
			this.sizelabel.Name = "sizelabel";
			this.sizelabel.Padding = new System.Windows.Forms.Padding(5);
			this.sizelabel.Size = new System.Drawing.Size(283, 87);
			this.sizelabel.TabIndex = 14;
			this.sizelabel.Text = "1421";
			this.sizelabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// displayCorner3
			// 
			this.displayCorner3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.displayCorner3.BackColor = System.Drawing.Color.DimGray;
			this.displayCorner3.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.displayCorner3.CurveDetail = 10;
			this.displayCorner3.FlipX = true;
			this.displayCorner3.FlipY = true;
			this.displayCorner3.Location = new System.Drawing.Point(1161, 778);
			this.displayCorner3.Name = "displayCorner3";
			this.displayCorner3.Size = new System.Drawing.Size(26, 25);
			this.displayCorner3.TabIndex = 0;
			// 
			// overviewbutton
			// 
			this.overviewbutton.BackColor = System.Drawing.Color.Tan;
			this.overviewbutton.Clickable = true;
			this.overviewbutton.ClickSound = "214";
			this.overviewbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.overviewbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.overviewbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.overviewbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.InverseFlash = false;
			this.overviewbutton.Location = new System.Drawing.Point(920, 924);
			this.overviewbutton.Name = "overviewbutton";
			this.overviewbutton.Padding = new System.Windows.Forms.Padding(5);
			this.overviewbutton.ScaleFixedWidth = true;
			this.overviewbutton.ScaleLeftBottom = 0.25F;
			this.overviewbutton.ScaleLeftTop = 0.25F;
			this.overviewbutton.ScaleRightBottom = 0.25F;
			this.overviewbutton.ScaleRightTop = 0.25F;
			this.overviewbutton.Size = new System.Drawing.Size(200, 87);
			this.overviewbutton.TabIndex = 11;
			this.overviewbutton.Text = "Overview";
			this.overviewbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.overviewbutton.Click += new System.EventHandler(this.overviewbutton_Click);
			// 
			// backbutton
			// 
			this.backbutton.BackColor = System.Drawing.Color.LightGray;
			this.backbutton.Clickable = true;
			this.backbutton.ClickSound = "214";
			this.backbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.backbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.backbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.backbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.backbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.backbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.backbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.backbutton.InverseFlash = false;
			this.backbutton.Location = new System.Drawing.Point(920, 12);
			this.backbutton.Name = "backbutton";
			this.backbutton.Padding = new System.Windows.Forms.Padding(5);
			this.backbutton.ScaleFixedWidth = true;
			this.backbutton.ScaleLeftBottom = 0.25F;
			this.backbutton.ScaleLeftTop = 0.25F;
			this.backbutton.ScaleRightBottom = 0.25F;
			this.backbutton.ScaleRightTop = 0.25F;
			this.backbutton.Size = new System.Drawing.Size(200, 87);
			this.backbutton.TabIndex = 13;
			this.backbutton.Text = "Back";
			this.backbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
			// 
			// browserframe
			// 
			this.browserframe.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.browserframe.Controls.Add(this.displayCorner1);
			this.browserframe.Controls.Add(this.displayCorner3);
			this.browserframe.Controls.Add(this.displayCorner2);
			this.browserframe.Controls.Add(this.displayCorner4);
			this.browserframe.Location = new System.Drawing.Point(13, 110);
			this.browserframe.Name = "browserframe";
			this.browserframe.Size = new System.Drawing.Size(1186, 802);
			this.browserframe.TabIndex = 25;
			// 
			// inputframe
			// 
			this.inputframe.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.inputframe.Controls.Add(this.keyboard);
			this.inputframe.Location = new System.Drawing.Point(13, 700);
			this.inputframe.Name = "inputframe";
			this.inputframe.Size = new System.Drawing.Size(1155, 213);
			this.inputframe.TabIndex = 26;
			this.inputframe.Visible = false;
			// 
			// keyboard
			// 
			this.keyboard.BackColor = System.Drawing.Color.DarkGray;
			this.keyboard.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.keyboard.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.keyboard.Location = new System.Drawing.Point(0, 0);
			this.keyboard.Margin = new System.Windows.Forms.Padding(2);
			this.keyboard.Name = "keyboard";
			this.keyboard.Size = new System.Drawing.Size(886, 212);
			this.keyboard.TabIndex = 0;
			// 
			// linksframe
			// 
			this.linksframe.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.linksframe.Controls.Add(this.displayButton11);
			this.linksframe.Controls.Add(this.displayButton10);
			this.linksframe.Controls.Add(this.displayButton9);
			this.linksframe.Controls.Add(this.displayButton8);
			this.linksframe.Controls.Add(this.displayButton7);
			this.linksframe.Controls.Add(this.displayButton6);
			this.linksframe.Controls.Add(this.displayButton2);
			this.linksframe.Controls.Add(this.displayButton1);
			this.linksframe.Controls.Add(this.displayButton5);
			this.linksframe.Controls.Add(this.displayButton3);
			this.linksframe.Location = new System.Drawing.Point(6, 371);
			this.linksframe.Name = "linksframe";
			this.linksframe.Size = new System.Drawing.Size(1179, 229);
			this.linksframe.TabIndex = 0;
			this.linksframe.Visible = false;
			// 
			// displayButton11
			// 
			this.displayButton11.BackColor = System.Drawing.Color.LightGray;
			this.displayButton11.Clickable = true;
			this.displayButton11.ClickSound = "208";
			this.displayButton11.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton11.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton11.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton11.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton11.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton11.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton11.InverseFlash = false;
			this.displayButton11.Location = new System.Drawing.Point(304, 150);
			this.displayButton11.Name = "displayButton11";
			this.displayButton11.ScaleFixedWidth = true;
			this.displayButton11.ScaleLeftBottom = 0.5F;
			this.displayButton11.ScaleLeftTop = 0.5F;
			this.displayButton11.ScaleRightBottom = 0.5F;
			this.displayButton11.ScaleRightTop = 0.5F;
			this.displayButton11.Size = new System.Drawing.Size(264, 59);
			this.displayButton11.TabIndex = 5;
			this.displayButton11.Tag = "http://www.kickasstorrents.com/";
			this.displayButton11.Text = "KickAssTorrents";
			this.displayButton11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton11.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton10
			// 
			this.displayButton10.BackColor = System.Drawing.Color.LightGray;
			this.displayButton10.Clickable = true;
			this.displayButton10.ClickSound = "208";
			this.displayButton10.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton10.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton10.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton10.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton10.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton10.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton10.InverseFlash = false;
			this.displayButton10.Location = new System.Drawing.Point(0, 150);
			this.displayButton10.Name = "displayButton10";
			this.displayButton10.ScaleFixedWidth = true;
			this.displayButton10.ScaleLeftBottom = 0.5F;
			this.displayButton10.ScaleLeftTop = 0.5F;
			this.displayButton10.ScaleRightBottom = 0.5F;
			this.displayButton10.ScaleRightTop = 0.5F;
			this.displayButton10.Size = new System.Drawing.Size(264, 59);
			this.displayButton10.TabIndex = 4;
			this.displayButton10.Tag = "http://www.btjunkie.com/";
			this.displayButton10.Text = "BTJunkie";
			this.displayButton10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton10.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton9
			// 
			this.displayButton9.BackColor = System.Drawing.Color.LightGray;
			this.displayButton9.Clickable = true;
			this.displayButton9.ClickSound = "208";
			this.displayButton9.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton9.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton9.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton9.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton9.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton9.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton9.InverseFlash = false;
			this.displayButton9.Location = new System.Drawing.Point(0, 76);
			this.displayButton9.Name = "displayButton9";
			this.displayButton9.ScaleFixedWidth = true;
			this.displayButton9.ScaleLeftBottom = 0.5F;
			this.displayButton9.ScaleLeftTop = 0.5F;
			this.displayButton9.ScaleRightBottom = 0.5F;
			this.displayButton9.ScaleRightTop = 0.5F;
			this.displayButton9.Size = new System.Drawing.Size(264, 59);
			this.displayButton9.TabIndex = 3;
			this.displayButton9.Tag = "http://www.weer.nl/nl/home/weer/nederland/zuid-holland.html";
			this.displayButton9.Text = "Weer";
			this.displayButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton9.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton8
			// 
			this.displayButton8.BackColor = System.Drawing.Color.LightGray;
			this.displayButton8.Clickable = true;
			this.displayButton8.ClickSound = "208";
			this.displayButton8.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton8.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton8.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton8.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton8.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton8.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton8.InverseFlash = false;
			this.displayButton8.Location = new System.Drawing.Point(304, 76);
			this.displayButton8.Name = "displayButton8";
			this.displayButton8.ScaleFixedWidth = true;
			this.displayButton8.ScaleLeftBottom = 0.5F;
			this.displayButton8.ScaleLeftTop = 0.5F;
			this.displayButton8.ScaleRightBottom = 0.5F;
			this.displayButton8.ScaleRightTop = 0.5F;
			this.displayButton8.Size = new System.Drawing.Size(264, 59);
			this.displayButton8.TabIndex = 2;
			this.displayButton8.Tag = "http://www.ah.nl/";
			this.displayButton8.Text = "AH";
			this.displayButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton8.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton7
			// 
			this.displayButton7.BackColor = System.Drawing.Color.LightGray;
			this.displayButton7.Clickable = true;
			this.displayButton7.ClickSound = "208";
			this.displayButton7.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton7.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton7.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton7.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton7.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton7.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton7.InverseFlash = false;
			this.displayButton7.Location = new System.Drawing.Point(608, 76);
			this.displayButton7.Name = "displayButton7";
			this.displayButton7.ScaleFixedWidth = true;
			this.displayButton7.ScaleLeftBottom = 0.5F;
			this.displayButton7.ScaleLeftTop = 0.5F;
			this.displayButton7.ScaleRightBottom = 0.5F;
			this.displayButton7.ScaleRightTop = 0.5F;
			this.displayButton7.Size = new System.Drawing.Size(264, 59);
			this.displayButton7.TabIndex = 1;
			this.displayButton7.Tag = "http://frg.sin-online.nl/channel/";
			this.displayButton7.Text = "Sin-Online";
			this.displayButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton7.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton6
			// 
			this.displayButton6.BackColor = System.Drawing.Color.LightGray;
			this.displayButton6.Clickable = true;
			this.displayButton6.ClickSound = "208";
			this.displayButton6.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton6.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton6.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton6.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton6.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton6.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton6.InverseFlash = false;
			this.displayButton6.Location = new System.Drawing.Point(912, 76);
			this.displayButton6.Name = "displayButton6";
			this.displayButton6.ScaleFixedWidth = true;
			this.displayButton6.ScaleLeftBottom = 0.5F;
			this.displayButton6.ScaleLeftTop = 0.5F;
			this.displayButton6.ScaleRightBottom = 0.5F;
			this.displayButton6.ScaleRightTop = 0.5F;
			this.displayButton6.Size = new System.Drawing.Size(264, 59);
			this.displayButton6.TabIndex = 0;
			this.displayButton6.Tag = "www.arriva.nl";
			this.displayButton6.Text = "Arriva";
			this.displayButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton6.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton2
			// 
			this.displayButton2.BackColor = System.Drawing.Color.LightGray;
			this.displayButton2.Clickable = true;
			this.displayButton2.ClickSound = "208";
			this.displayButton2.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton2.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton2.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton2.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton2.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton2.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton2.InverseFlash = false;
			this.displayButton2.Location = new System.Drawing.Point(912, 0);
			this.displayButton2.Name = "displayButton2";
			this.displayButton2.ScaleFixedWidth = true;
			this.displayButton2.ScaleLeftBottom = 0.5F;
			this.displayButton2.ScaleLeftTop = 0.5F;
			this.displayButton2.ScaleRightBottom = 0.5F;
			this.displayButton2.ScaleRightTop = 0.5F;
			this.displayButton2.Size = new System.Drawing.Size(264, 59);
			this.displayButton2.TabIndex = 0;
			this.displayButton2.Tag = "www.ns.nl";
			this.displayButton2.Text = "NS";
			this.displayButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton2.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton1
			// 
			this.displayButton1.BackColor = System.Drawing.Color.LightGray;
			this.displayButton1.Clickable = true;
			this.displayButton1.ClickSound = "208";
			this.displayButton1.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton1.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton1.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton1.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton1.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton1.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton1.InverseFlash = false;
			this.displayButton1.Location = new System.Drawing.Point(608, 0);
			this.displayButton1.Name = "displayButton1";
			this.displayButton1.ScaleFixedWidth = true;
			this.displayButton1.ScaleLeftBottom = 0.5F;
			this.displayButton1.ScaleLeftTop = 0.5F;
			this.displayButton1.ScaleRightBottom = 0.5F;
			this.displayButton1.ScaleRightTop = 0.5F;
			this.displayButton1.Size = new System.Drawing.Size(264, 59);
			this.displayButton1.TabIndex = 0;
			this.displayButton1.Tag = "www.youtube.com";
			this.displayButton1.Text = "YouTube";
			this.displayButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton1.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton5
			// 
			this.displayButton5.BackColor = System.Drawing.Color.LightGray;
			this.displayButton5.Clickable = true;
			this.displayButton5.ClickSound = "208";
			this.displayButton5.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton5.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton5.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton5.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton5.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton5.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton5.InverseFlash = false;
			this.displayButton5.Location = new System.Drawing.Point(304, 0);
			this.displayButton5.Name = "displayButton5";
			this.displayButton5.ScaleFixedWidth = true;
			this.displayButton5.ScaleLeftBottom = 0.5F;
			this.displayButton5.ScaleLeftTop = 0.5F;
			this.displayButton5.ScaleRightBottom = 0.5F;
			this.displayButton5.ScaleRightTop = 0.5F;
			this.displayButton5.Size = new System.Drawing.Size(264, 59);
			this.displayButton5.TabIndex = 0;
			this.displayButton5.Tag = "www.hotmail.com";
			this.displayButton5.Text = "Hotmail";
			this.displayButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton5.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// displayButton3
			// 
			this.displayButton3.BackColor = System.Drawing.Color.LightGray;
			this.displayButton3.Clickable = true;
			this.displayButton3.ClickSound = "208";
			this.displayButton3.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayButton3.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.displayButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.displayButton3.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayButton3.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayButton3.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayButton3.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayButton3.InverseFlash = false;
			this.displayButton3.Location = new System.Drawing.Point(0, 0);
			this.displayButton3.Name = "displayButton3";
			this.displayButton3.ScaleFixedWidth = true;
			this.displayButton3.ScaleLeftBottom = 0.5F;
			this.displayButton3.ScaleLeftTop = 0.5F;
			this.displayButton3.ScaleRightBottom = 0.5F;
			this.displayButton3.ScaleRightTop = 0.5F;
			this.displayButton3.Size = new System.Drawing.Size(264, 59);
			this.displayButton3.TabIndex = 0;
			this.displayButton3.Tag = "www.google.com";
			this.displayButton3.Text = "Google";
			this.displayButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.displayButton3.Click += new System.EventHandler(this.TaggedLinkClick);
			// 
			// scrollbar
			// 
			this.scrollbar.BackColor = System.Drawing.Color.Tan;
			this.scrollbar.Clickable = true;
			this.scrollbar.ClickSound = "";
			this.scrollbar.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor2;
			this.scrollbar.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.scrollbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.scrollbar.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.scrollbar.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.scrollbar.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.scrollbar.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.scrollbar.InverseFlash = false;
			this.scrollbar.Location = new System.Drawing.Point(1210, 200);
			this.scrollbar.Margin = new System.Windows.Forms.Padding(5);
			this.scrollbar.Name = "scrollbar";
			this.scrollbar.ScaleFixedWidth = true;
			this.scrollbar.ScaleLeftBottom = 0.25F;
			this.scrollbar.ScaleLeftTop = 0.25F;
			this.scrollbar.ScaleRightBottom = 0.25F;
			this.scrollbar.ScaleRightTop = 0.25F;
			this.scrollbar.Size = new System.Drawing.Size(57, 623);
			this.scrollbar.TabIndex = 7;
			this.scrollbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollbar_MouseMove);
			this.scrollbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollbar_MouseDown);
			this.scrollbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbar_MouseUp);
			// 
			// scrolltimer
			// 
			this.scrolltimer.Interval = 50;
			this.scrolltimer.Tick += new System.EventHandler(this.scrolltimer_Tick);
			// 
			// optionsframe
			// 
			this.optionsframe.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.optionsframe.Controls.Add(this.showvideobutton);
			this.optionsframe.Controls.Add(this.onscreenbutton);
			this.optionsframe.Location = new System.Drawing.Point(6, 179);
			this.optionsframe.Name = "optionsframe";
			this.optionsframe.Size = new System.Drawing.Size(1179, 78);
			this.optionsframe.TabIndex = 0;
			this.optionsframe.Visible = false;
			// 
			// showvideobutton
			// 
			this.showvideobutton.BackColor = System.Drawing.Color.LightGray;
			this.showvideobutton.Clickable = true;
			this.showvideobutton.ClickSound = "208";
			this.showvideobutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.showvideobutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.showvideobutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.showvideobutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.showvideobutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.showvideobutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.showvideobutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.showvideobutton.InverseFlash = false;
			this.showvideobutton.Location = new System.Drawing.Point(304, 0);
			this.showvideobutton.Name = "showvideobutton";
			this.showvideobutton.ScaleFixedWidth = true;
			this.showvideobutton.ScaleLeftBottom = 0.5F;
			this.showvideobutton.ScaleLeftTop = 0.5F;
			this.showvideobutton.ScaleRightBottom = 0.5F;
			this.showvideobutton.ScaleRightTop = 0.5F;
			this.showvideobutton.Size = new System.Drawing.Size(264, 59);
			this.showvideobutton.TabIndex = 2;
			this.showvideobutton.Tag = "";
			this.showvideobutton.Text = "Show Video";
			this.showvideobutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.showvideobutton.Click += new System.EventHandler(this.showvideobutton_Click);
			// 
			// onscreenbutton
			// 
			this.onscreenbutton.BackColor = System.Drawing.Color.LightGray;
			this.onscreenbutton.Clickable = true;
			this.onscreenbutton.ClickSound = "208";
			this.onscreenbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.onscreenbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.onscreenbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.onscreenbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.onscreenbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.onscreenbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.onscreenbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.onscreenbutton.InverseFlash = false;
			this.onscreenbutton.Location = new System.Drawing.Point(0, 0);
			this.onscreenbutton.Name = "onscreenbutton";
			this.onscreenbutton.ScaleFixedWidth = true;
			this.onscreenbutton.ScaleLeftBottom = 0.5F;
			this.onscreenbutton.ScaleLeftTop = 0.5F;
			this.onscreenbutton.ScaleRightBottom = 0.5F;
			this.onscreenbutton.ScaleRightTop = 0.5F;
			this.onscreenbutton.Size = new System.Drawing.Size(264, 59);
			this.onscreenbutton.TabIndex = 1;
			this.onscreenbutton.Tag = "";
			this.onscreenbutton.Text = "On Screen";
			this.onscreenbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.onscreenbutton.Click += new System.EventHandler(this.onscreenbutton_Click);
			// 
			// InternetDisplayPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.optionsframe);
			this.Controls.Add(this.scrollbar);
			this.Controls.Add(this.linksframe);
			this.Controls.Add(this.inputframe);
			this.Controls.Add(this.backbutton);
			this.Controls.Add(this.overviewbutton);
			this.Controls.Add(this.displayBar7);
			this.Controls.Add(this.inputbutton);
			this.Controls.Add(this.displayButton4);
			this.Controls.Add(this.displayBar6);
			this.Controls.Add(this.linksbutton);
			this.Controls.Add(this.scrolldownbutton);
			this.Controls.Add(this.scrollupbutton);
			this.Controls.Add(this.optionsbutton);
			this.Controls.Add(this.gobutton);
			this.Controls.Add(this.displayBar1);
			this.Controls.Add(this.displayBar2);
			this.Controls.Add(this.browserframe);
			this.Controls.Add(this.displayBar3);
			this.Controls.Add(this.displayBar5);
			this.Name = "InternetDisplayPanel";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(1280, 1024);
			this.displayBar1.ResumeLayout(false);
			this.displayBar1.PerformLayout();
			this.displayBar7.ResumeLayout(false);
			this.browserframe.ResumeLayout(false);
			this.inputframe.ResumeLayout(false);
			this.linksframe.ResumeLayout(false);
			this.optionsframe.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DisplayWebBrowser browser;
		private DisplayBar displayBar1;
		private DisplayCorner displayCorner1;
		private DisplayButton gobutton;
		private DisplayButton optionsbutton;
		private DisplayBar displayBar2;
		private DisplayBar displayBar3;
		private DisplayButton scrollupbutton;
		private DisplayButton scrolldownbutton;
		private DisplayCorner displayCorner2;
		private DisplayButton linksbutton;
		private DisplayButton displayButton4;
		private DisplayBar displayBar5;
		private DisplayBar displayBar6;
		private DisplayButton inputbutton;
		private DisplayCorner displayCorner4;
		private DisplayBar displayBar7;
		private DisplayCorner displayCorner3;
		private DisplayButton overviewbutton;
		private System.Windows.Forms.TextBox addressbox;
		private DisplayButton backbutton;
		private DisplayFrame browserframe;
		private DisplayFrame inputframe;
		private DisplayKeyboard keyboard;
		private DisplayLabel sizelabel;
		private DisplayFrame linksframe;
		private DisplayButton displayButton3;
		private DisplayButton displayButton5;
		private DisplayButton scrollbar;
		private System.Windows.Forms.Timer scrolltimer;
		private DisplayButton displayButton2;
		private DisplayButton displayButton1;
		private DisplayButton displayButton6;
		private DisplayButton displayButton8;
		private DisplayButton displayButton7;
		private DisplayButton displayButton9;
		private DisplayFrame optionsframe;
		private DisplayButton onscreenbutton;
		private DisplayButton showvideobutton;
		private DisplayButton displayButton10;
		private DisplayButton displayButton11;

	}
}
