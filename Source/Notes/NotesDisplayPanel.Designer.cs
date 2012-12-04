namespace CodeImp.Gluon
{
	partial class NotesDisplayPanel
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
			this.keyboard = new CodeImp.Gluon.DisplayKeyboard();
			this.notetext = new CodeImp.Gluon.DisplayTextBox();
			this.notetextpanel = new CodeImp.Gluon.DisplayBar();
			this.textdown = new CodeImp.Gluon.DisplayButton();
			this.textup = new CodeImp.Gluon.DisplayButton();
			this.displayBar16 = new CodeImp.Gluon.DisplayBar();
			this.displayBar7 = new CodeImp.Gluon.DisplayBar();
			this.displayBar9 = new CodeImp.Gluon.DisplayBar();
			this.displayBar6 = new CodeImp.Gluon.DisplayBar();
			this.displayBar1 = new CodeImp.Gluon.DisplayBar();
			this.displayBar2 = new CodeImp.Gluon.DisplayBar();
			this.displayBar3 = new CodeImp.Gluon.DisplayBar();
			this.mainscroll = new CodeImp.Gluon.DisplayButton();
			this.maindown = new CodeImp.Gluon.DisplayButton();
			this.mainup = new CodeImp.Gluon.DisplayButton();
			this.mainitem10 = new CodeImp.Gluon.DisplayButton();
			this.mainitem9 = new CodeImp.Gluon.DisplayButton();
			this.mainitem8 = new CodeImp.Gluon.DisplayButton();
			this.mainitem7 = new CodeImp.Gluon.DisplayButton();
			this.mainitem6 = new CodeImp.Gluon.DisplayButton();
			this.mainitem5 = new CodeImp.Gluon.DisplayButton();
			this.mainitem4 = new CodeImp.Gluon.DisplayButton();
			this.mainitem3 = new CodeImp.Gluon.DisplayButton();
			this.mainitem2 = new CodeImp.Gluon.DisplayButton();
			this.mainitem1 = new CodeImp.Gluon.DisplayButton();
			this.addbutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar4 = new CodeImp.Gluon.DisplayBar();
			this.removebutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar5 = new CodeImp.Gluon.DisplayBar();
			this.displayBar8 = new CodeImp.Gluon.DisplayBar();
			this.overviewbutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar10 = new CodeImp.Gluon.DisplayBar();
			this.displayBar11 = new CodeImp.Gluon.DisplayBar();
			this.upbutton = new CodeImp.Gluon.DisplayButton();
			this.downbutton = new CodeImp.Gluon.DisplayButton();
			this.deselectedlabel = new CodeImp.Gluon.DisplayLabel();
			this.scrolltimer = new System.Windows.Forms.Timer(this.components);
			this.updatebutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar12 = new CodeImp.Gluon.DisplayBar();
			this.textscrolltimer = new System.Windows.Forms.Timer(this.components);
			this.textscroll = new CodeImp.Gluon.DisplayButton();
			this.displayBar13 = new CodeImp.Gluon.DisplayBar();
			this.displayBar14 = new CodeImp.Gluon.DisplayBar();
			this.notetextpanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// keyboard
			// 
			this.keyboard.BackColor = System.Drawing.Color.DarkGray;
			this.keyboard.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.keyboard.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.keyboard.Location = new System.Drawing.Point(37, 779);
			this.keyboard.Margin = new System.Windows.Forms.Padding(2);
			this.keyboard.Name = "keyboard";
			this.keyboard.Size = new System.Drawing.Size(886, 212);
			this.keyboard.TabIndex = 21;
			// 
			// notetext
			// 
			this.notetext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.notetext.BackColor = System.Drawing.Color.Silver;
			this.notetext.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.notetext.ClickSound = null;
			this.notetext.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.notetext.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.notetext.FocusControl = null;
			this.notetext.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.notetext.HideSelection = false;
			this.notetext.Location = new System.Drawing.Point(15, 15);
			this.notetext.Multiline = true;
			this.notetext.Name = "notetext";
			this.notetext.Size = new System.Drawing.Size(799, 88);
			this.notetext.TabIndex = 1;
			this.notetext.Text = "drie\r\nregels\r\ntekst";
			// 
			// notetextpanel
			// 
			this.notetextpanel.BackColor = System.Drawing.Color.Silver;
			this.notetextpanel.BlockMouseInput = true;
			this.notetextpanel.ClickSound = null;
			this.notetextpanel.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.notetextpanel.Controls.Add(this.notetext);
			this.notetextpanel.FocusControl = this.notetext;
			this.notetextpanel.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.notetextpanel.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.notetextpanel.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.notetextpanel.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.notetextpanel.Location = new System.Drawing.Point(37, 637);
			this.notetextpanel.Name = "notetextpanel";
			this.notetextpanel.Padding = new System.Windows.Forms.Padding(12);
			this.notetextpanel.ScaleFixedWidth = true;
			this.notetextpanel.ScaleLeftBottom = 0.12F;
			this.notetextpanel.ScaleLeftTop = 0.12F;
			this.notetextpanel.ScaleRightBottom = 0.12F;
			this.notetextpanel.ScaleRightTop = 0.12F;
			this.notetextpanel.Size = new System.Drawing.Size(829, 118);
			this.notetextpanel.TabIndex = 21;
			// 
			// textdown
			// 
			this.textdown.BackColor = System.Drawing.Color.Gray;
			this.textdown.Clickable = true;
			this.textdown.ClickSound = "207";
			this.textdown.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.textdown.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.textdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.textdown.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.textdown.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.textdown.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.textdown.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.textdown.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.textdown.InverseFlash = false;
			this.textdown.Location = new System.Drawing.Point(872, 705);
			this.textdown.Name = "textdown";
			this.textdown.ScaleFixedWidth = false;
			this.textdown.ScaleLeftBottom = 0.5F;
			this.textdown.ScaleLeftTop = 0.5F;
			this.textdown.ScaleRightBottom = 0.5F;
			this.textdown.ScaleRightTop = 0.5F;
			this.textdown.Size = new System.Drawing.Size(51, 50);
			this.textdown.TabIndex = 21;
			this.textdown.Text = "u";
			this.textdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.textdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textdown_MouseDown);
			this.textdown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbutton_MouseUp);
			// 
			// textup
			// 
			this.textup.BackColor = System.Drawing.Color.Gray;
			this.textup.Clickable = true;
			this.textup.ClickSound = "207";
			this.textup.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.textup.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.textup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.textup.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.textup.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.textup.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.textup.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.textup.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.textup.InverseFlash = false;
			this.textup.Location = new System.Drawing.Point(872, 637);
			this.textup.Name = "textup";
			this.textup.ScaleFixedWidth = false;
			this.textup.ScaleLeftBottom = 0.5F;
			this.textup.ScaleLeftTop = 0.5F;
			this.textup.ScaleRightBottom = 0.5F;
			this.textup.ScaleRightTop = 0.5F;
			this.textup.Size = new System.Drawing.Size(51, 50);
			this.textup.TabIndex = 21;
			this.textup.Text = "t";
			this.textup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.textup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textup_MouseDown);
			this.textup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbutton_MouseUp);
			// 
			// displayBar16
			// 
			this.displayBar16.BackColor = System.Drawing.Color.LightGray;
			this.displayBar16.BlockMouseInput = true;
			this.displayBar16.ClickSound = null;
			this.displayBar16.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar16.FocusControl = null;
			this.displayBar16.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar16.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar16.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar16.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar16.Location = new System.Drawing.Point(1022, 971);
			this.displayBar16.Name = "displayBar16";
			this.displayBar16.ScaleFixedWidth = false;
			this.displayBar16.ScaleLeftBottom = 0.25F;
			this.displayBar16.ScaleLeftTop = 0.25F;
			this.displayBar16.ScaleRightBottom = 0.25F;
			this.displayBar16.ScaleRightTop = 0.25F;
			this.displayBar16.Size = new System.Drawing.Size(245, 53);
			this.displayBar16.TabIndex = 1;
			// 
			// displayBar7
			// 
			this.displayBar7.BackColor = System.Drawing.Color.LightGray;
			this.displayBar7.BlockMouseInput = true;
			this.displayBar7.ClickSound = null;
			this.displayBar7.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar7.FocusControl = null;
			this.displayBar7.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveInverseFlipX;
			this.displayBar7.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.displayBar7.Location = new System.Drawing.Point(974, 528);
			this.displayBar7.Name = "displayBar7";
			this.displayBar7.ScaleFixedWidth = true;
			this.displayBar7.ScaleLeftBottom = 0.5F;
			this.displayBar7.ScaleLeftTop = 1F;
			this.displayBar7.ScaleRightBottom = 0.47F;
			this.displayBar7.ScaleRightTop = 1F;
			this.displayBar7.Size = new System.Drawing.Size(293, 96);
			this.displayBar7.TabIndex = 6;
			// 
			// displayBar9
			// 
			this.displayBar9.BackColor = System.Drawing.Color.LightGray;
			this.displayBar9.BlockMouseInput = true;
			this.displayBar9.ClickSound = null;
			this.displayBar9.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar9.FocusControl = null;
			this.displayBar9.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayBar9.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayBar9.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar9.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar9.Location = new System.Drawing.Point(13, 528);
			this.displayBar9.Name = "displayBar9";
			this.displayBar9.ScaleFixedWidth = true;
			this.displayBar9.ScaleLeftBottom = 0.5F;
			this.displayBar9.ScaleLeftTop = 0.5F;
			this.displayBar9.ScaleRightBottom = 0.25F;
			this.displayBar9.ScaleRightTop = 0.25F;
			this.displayBar9.Size = new System.Drawing.Size(99, 48);
			this.displayBar9.TabIndex = 14;
			// 
			// displayBar6
			// 
			this.displayBar6.BackColor = System.Drawing.Color.LightGray;
			this.displayBar6.BlockMouseInput = true;
			this.displayBar6.ClickSound = null;
			this.displayBar6.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar6.FocusControl = null;
			this.displayBar6.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar6.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveInverseFlipXY;
			this.displayBar6.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayBar6.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar6.Location = new System.Drawing.Point(974, 426);
			this.displayBar6.Name = "displayBar6";
			this.displayBar6.ScaleFixedWidth = true;
			this.displayBar6.ScaleLeftBottom = 1F;
			this.displayBar6.ScaleLeftTop = 0.5F;
			this.displayBar6.ScaleRightBottom = 1F;
			this.displayBar6.ScaleRightTop = 0.47F;
			this.displayBar6.Size = new System.Drawing.Size(293, 96);
			this.displayBar6.TabIndex = 6;
			// 
			// displayBar1
			// 
			this.displayBar1.BackColor = System.Drawing.Color.LightGray;
			this.displayBar1.BlockMouseInput = true;
			this.displayBar1.ClickSound = null;
			this.displayBar1.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar1.FocusControl = null;
			this.displayBar1.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar1.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar1.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar1.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar1.Location = new System.Drawing.Point(1022, 346);
			this.displayBar1.Name = "displayBar1";
			this.displayBar1.ScaleFixedWidth = false;
			this.displayBar1.ScaleLeftBottom = 0.25F;
			this.displayBar1.ScaleLeftTop = 0.25F;
			this.displayBar1.ScaleRightBottom = 0.25F;
			this.displayBar1.ScaleRightTop = 0.25F;
			this.displayBar1.Size = new System.Drawing.Size(245, 84);
			this.displayBar1.TabIndex = 5;
			// 
			// displayBar2
			// 
			this.displayBar2.BackColor = System.Drawing.Color.LightGray;
			this.displayBar2.BlockMouseInput = true;
			this.displayBar2.ClickSound = null;
			this.displayBar2.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar2.FocusControl = null;
			this.displayBar2.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayBar2.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayBar2.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.Location = new System.Drawing.Point(13, 474);
			this.displayBar2.Name = "displayBar2";
			this.displayBar2.ScaleFixedWidth = true;
			this.displayBar2.ScaleLeftBottom = 0.5F;
			this.displayBar2.ScaleLeftTop = 0.5F;
			this.displayBar2.ScaleRightBottom = 0.25F;
			this.displayBar2.ScaleRightTop = 0.25F;
			this.displayBar2.Size = new System.Drawing.Size(160, 48);
			this.displayBar2.TabIndex = 13;
			// 
			// displayBar3
			// 
			this.displayBar3.BackColor = System.Drawing.Color.LightGray;
			this.displayBar3.BlockMouseInput = true;
			this.displayBar3.ClickSound = null;
			this.displayBar3.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar3.FocusControl = null;
			this.displayBar3.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar3.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar3.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar3.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar3.Location = new System.Drawing.Point(653, 474);
			this.displayBar3.Name = "displayBar3";
			this.displayBar3.ScaleFixedWidth = true;
			this.displayBar3.ScaleLeftBottom = 0.5F;
			this.displayBar3.ScaleLeftTop = 0.5F;
			this.displayBar3.ScaleRightBottom = 0.25F;
			this.displayBar3.ScaleRightTop = 0.25F;
			this.displayBar3.Size = new System.Drawing.Size(328, 48);
			this.displayBar3.TabIndex = 7;
			// 
			// mainscroll
			// 
			this.mainscroll.BackColor = System.Drawing.Color.Gray;
			this.mainscroll.Clickable = true;
			this.mainscroll.ClickSound = "";
			this.mainscroll.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.mainscroll.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.mainscroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainscroll.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.mainscroll.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.mainscroll.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.mainscroll.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.mainscroll.InverseFlash = false;
			this.mainscroll.Location = new System.Drawing.Point(872, 77);
			this.mainscroll.Margin = new System.Windows.Forms.Padding(5);
			this.mainscroll.Name = "mainscroll";
			this.mainscroll.ScaleFixedWidth = true;
			this.mainscroll.ScaleLeftBottom = 0.25F;
			this.mainscroll.ScaleLeftTop = 0.25F;
			this.mainscroll.ScaleRightBottom = 0.25F;
			this.mainscroll.ScaleRightTop = 0.25F;
			this.mainscroll.Size = new System.Drawing.Size(51, 318);
			this.mainscroll.TabIndex = 20;
			this.mainscroll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainscroll_MouseMove);
			this.mainscroll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainscroll_MouseDown);
			this.mainscroll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainscroll_MouseUp);
			// 
			// maindown
			// 
			this.maindown.BackColor = System.Drawing.Color.Gray;
			this.maindown.Clickable = true;
			this.maindown.ClickSound = "207";
			this.maindown.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.maindown.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.maindown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.maindown.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.maindown.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.maindown.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.maindown.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.maindown.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.maindown.InverseFlash = false;
			this.maindown.Location = new System.Drawing.Point(872, 400);
			this.maindown.Name = "maindown";
			this.maindown.ScaleFixedWidth = false;
			this.maindown.ScaleLeftBottom = 0.5F;
			this.maindown.ScaleLeftTop = 0.5F;
			this.maindown.ScaleRightBottom = 0.5F;
			this.maindown.ScaleRightTop = 0.5F;
			this.maindown.Size = new System.Drawing.Size(51, 51);
			this.maindown.TabIndex = 20;
			this.maindown.Text = "u";
			this.maindown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.maindown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maindown_MouseDown);
			this.maindown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbutton_MouseUp);
			// 
			// mainup
			// 
			this.mainup.BackColor = System.Drawing.Color.Gray;
			this.mainup.Clickable = true;
			this.mainup.ClickSound = "207";
			this.mainup.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.mainup.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.mainup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainup.Font = new System.Drawing.Font("Marlett", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.mainup.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.mainup.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainup.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.mainup.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainup.InverseFlash = false;
			this.mainup.Location = new System.Drawing.Point(872, 21);
			this.mainup.Name = "mainup";
			this.mainup.ScaleFixedWidth = false;
			this.mainup.ScaleLeftBottom = 0.5F;
			this.mainup.ScaleLeftTop = 0.5F;
			this.mainup.ScaleRightBottom = 0.5F;
			this.mainup.ScaleRightTop = 0.5F;
			this.mainup.Size = new System.Drawing.Size(51, 51);
			this.mainup.TabIndex = 20;
			this.mainup.Text = "t";
			this.mainup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mainup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainup_MouseDown);
			this.mainup.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbutton_MouseUp);
			// 
			// mainitem10
			// 
			this.mainitem10.AutoEllipsis = true;
			this.mainitem10.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem10.Clickable = true;
			this.mainitem10.ClickSound = "211";
			this.mainitem10.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem10.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem10.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem10.ForeColor = System.Drawing.Color.Tan;
			this.mainitem10.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem10.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem10.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem10.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem10.InverseFlash = false;
			this.mainitem10.Location = new System.Drawing.Point(32, 408);
			this.mainitem10.Name = "mainitem10";
			this.mainitem10.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem10.ScaleFixedWidth = true;
			this.mainitem10.ScaleLeftBottom = 0.5F;
			this.mainitem10.ScaleLeftTop = 0.5F;
			this.mainitem10.ScaleRightBottom = 0.5F;
			this.mainitem10.ScaleRightTop = 0.5F;
			this.mainitem10.Size = new System.Drawing.Size(801, 43);
			this.mainitem10.TabIndex = 19;
			this.mainitem10.Text = "Bloemkool • 4";
			this.mainitem10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem10.UseMnemonic = false;
			this.mainitem10.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem9
			// 
			this.mainitem9.AutoEllipsis = true;
			this.mainitem9.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem9.Clickable = true;
			this.mainitem9.ClickSound = "211";
			this.mainitem9.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem9.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem9.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem9.ForeColor = System.Drawing.Color.Tan;
			this.mainitem9.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem9.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem9.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem9.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem9.InverseFlash = false;
			this.mainitem9.Location = new System.Drawing.Point(32, 365);
			this.mainitem9.Name = "mainitem9";
			this.mainitem9.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem9.ScaleFixedWidth = true;
			this.mainitem9.ScaleLeftBottom = 0.5F;
			this.mainitem9.ScaleLeftTop = 0.5F;
			this.mainitem9.ScaleRightBottom = 0.5F;
			this.mainitem9.ScaleRightTop = 0.5F;
			this.mainitem9.Size = new System.Drawing.Size(801, 43);
			this.mainitem9.TabIndex = 19;
			this.mainitem9.Text = "Bloemkool • 4";
			this.mainitem9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem9.UseMnemonic = false;
			this.mainitem9.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem8
			// 
			this.mainitem8.AutoEllipsis = true;
			this.mainitem8.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem8.Clickable = true;
			this.mainitem8.ClickSound = "211";
			this.mainitem8.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem8.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem8.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem8.ForeColor = System.Drawing.Color.Tan;
			this.mainitem8.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem8.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem8.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem8.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem8.InverseFlash = false;
			this.mainitem8.Location = new System.Drawing.Point(32, 322);
			this.mainitem8.Name = "mainitem8";
			this.mainitem8.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem8.ScaleFixedWidth = true;
			this.mainitem8.ScaleLeftBottom = 0.5F;
			this.mainitem8.ScaleLeftTop = 0.5F;
			this.mainitem8.ScaleRightBottom = 0.5F;
			this.mainitem8.ScaleRightTop = 0.5F;
			this.mainitem8.Size = new System.Drawing.Size(801, 43);
			this.mainitem8.TabIndex = 18;
			this.mainitem8.Text = "Bloemkool • 4";
			this.mainitem8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem8.UseMnemonic = false;
			this.mainitem8.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem7
			// 
			this.mainitem7.AutoEllipsis = true;
			this.mainitem7.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem7.Clickable = true;
			this.mainitem7.ClickSound = "211";
			this.mainitem7.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem7.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem7.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem7.ForeColor = System.Drawing.Color.Tan;
			this.mainitem7.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem7.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem7.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem7.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem7.InverseFlash = false;
			this.mainitem7.Location = new System.Drawing.Point(32, 279);
			this.mainitem7.Name = "mainitem7";
			this.mainitem7.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem7.ScaleFixedWidth = true;
			this.mainitem7.ScaleLeftBottom = 0.5F;
			this.mainitem7.ScaleLeftTop = 0.5F;
			this.mainitem7.ScaleRightBottom = 0.5F;
			this.mainitem7.ScaleRightTop = 0.5F;
			this.mainitem7.Size = new System.Drawing.Size(801, 43);
			this.mainitem7.TabIndex = 18;
			this.mainitem7.Text = "Bloemkool • 4";
			this.mainitem7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem7.UseMnemonic = false;
			this.mainitem7.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem6
			// 
			this.mainitem6.AutoEllipsis = true;
			this.mainitem6.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem6.Clickable = true;
			this.mainitem6.ClickSound = "211";
			this.mainitem6.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem6.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem6.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem6.ForeColor = System.Drawing.Color.Tan;
			this.mainitem6.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem6.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem6.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem6.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem6.InverseFlash = false;
			this.mainitem6.Location = new System.Drawing.Point(32, 236);
			this.mainitem6.Name = "mainitem6";
			this.mainitem6.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem6.ScaleFixedWidth = true;
			this.mainitem6.ScaleLeftBottom = 0.5F;
			this.mainitem6.ScaleLeftTop = 0.5F;
			this.mainitem6.ScaleRightBottom = 0.5F;
			this.mainitem6.ScaleRightTop = 0.5F;
			this.mainitem6.Size = new System.Drawing.Size(801, 43);
			this.mainitem6.TabIndex = 17;
			this.mainitem6.Text = "Bloemkool • 4";
			this.mainitem6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem6.UseMnemonic = false;
			this.mainitem6.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem5
			// 
			this.mainitem5.AutoEllipsis = true;
			this.mainitem5.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem5.Clickable = true;
			this.mainitem5.ClickSound = "211";
			this.mainitem5.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem5.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem5.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem5.ForeColor = System.Drawing.Color.Tan;
			this.mainitem5.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem5.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem5.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem5.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem5.InverseFlash = false;
			this.mainitem5.Location = new System.Drawing.Point(32, 193);
			this.mainitem5.Name = "mainitem5";
			this.mainitem5.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem5.ScaleFixedWidth = true;
			this.mainitem5.ScaleLeftBottom = 0.5F;
			this.mainitem5.ScaleLeftTop = 0.5F;
			this.mainitem5.ScaleRightBottom = 0.5F;
			this.mainitem5.ScaleRightTop = 0.5F;
			this.mainitem5.Size = new System.Drawing.Size(801, 43);
			this.mainitem5.TabIndex = 17;
			this.mainitem5.Text = "Bloemkool • 4";
			this.mainitem5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem5.UseMnemonic = false;
			this.mainitem5.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem4
			// 
			this.mainitem4.AutoEllipsis = true;
			this.mainitem4.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem4.Clickable = true;
			this.mainitem4.ClickSound = "211";
			this.mainitem4.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem4.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem4.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem4.ForeColor = System.Drawing.Color.Tan;
			this.mainitem4.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem4.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem4.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem4.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem4.InverseFlash = false;
			this.mainitem4.Location = new System.Drawing.Point(32, 150);
			this.mainitem4.Name = "mainitem4";
			this.mainitem4.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem4.ScaleFixedWidth = true;
			this.mainitem4.ScaleLeftBottom = 0.5F;
			this.mainitem4.ScaleLeftTop = 0.5F;
			this.mainitem4.ScaleRightBottom = 0.5F;
			this.mainitem4.ScaleRightTop = 0.5F;
			this.mainitem4.Size = new System.Drawing.Size(801, 43);
			this.mainitem4.TabIndex = 16;
			this.mainitem4.Text = "Bloemkool • 4";
			this.mainitem4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem4.UseMnemonic = false;
			this.mainitem4.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem3
			// 
			this.mainitem3.AutoEllipsis = true;
			this.mainitem3.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem3.Clickable = true;
			this.mainitem3.ClickSound = "211";
			this.mainitem3.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem3.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem3.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem3.ForeColor = System.Drawing.Color.Tan;
			this.mainitem3.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem3.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem3.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem3.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem3.InverseFlash = false;
			this.mainitem3.Location = new System.Drawing.Point(32, 107);
			this.mainitem3.Name = "mainitem3";
			this.mainitem3.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem3.ScaleFixedWidth = true;
			this.mainitem3.ScaleLeftBottom = 0.5F;
			this.mainitem3.ScaleLeftTop = 0.5F;
			this.mainitem3.ScaleRightBottom = 0.5F;
			this.mainitem3.ScaleRightTop = 0.5F;
			this.mainitem3.Size = new System.Drawing.Size(801, 43);
			this.mainitem3.TabIndex = 16;
			this.mainitem3.Text = "Bloemkool • 4";
			this.mainitem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem3.UseMnemonic = false;
			this.mainitem3.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem2
			// 
			this.mainitem2.AutoEllipsis = true;
			this.mainitem2.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem2.Clickable = true;
			this.mainitem2.ClickSound = "211";
			this.mainitem2.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem2.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem2.ForeColor = System.Drawing.Color.Tan;
			this.mainitem2.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem2.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem2.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem2.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem2.InverseFlash = false;
			this.mainitem2.Location = new System.Drawing.Point(32, 64);
			this.mainitem2.Name = "mainitem2";
			this.mainitem2.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem2.ScaleFixedWidth = true;
			this.mainitem2.ScaleLeftBottom = 0.5F;
			this.mainitem2.ScaleLeftTop = 0.5F;
			this.mainitem2.ScaleRightBottom = 0.5F;
			this.mainitem2.ScaleRightTop = 0.5F;
			this.mainitem2.Size = new System.Drawing.Size(801, 43);
			this.mainitem2.TabIndex = 15;
			this.mainitem2.Text = "Bloemkool • 4";
			this.mainitem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem2.UseMnemonic = false;
			this.mainitem2.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// mainitem1
			// 
			this.mainitem1.AutoEllipsis = true;
			this.mainitem1.BackColor = System.Drawing.Color.DarkGray;
			this.mainitem1.Clickable = true;
			this.mainitem1.ClickSound = "211";
			this.mainitem1.ColorNormal = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.mainitem1.ColorText = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.mainitem1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mainitem1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainitem1.ForeColor = System.Drawing.Color.Tan;
			this.mainitem1.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.mainitem1.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.mainitem1.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.mainitem1.ImageRightTop = CodeImp.Gluon.InterfaceImage.WindowCurveFlipX;
			this.mainitem1.InverseFlash = false;
			this.mainitem1.Location = new System.Drawing.Point(32, 21);
			this.mainitem1.Name = "mainitem1";
			this.mainitem1.Padding = new System.Windows.Forms.Padding(20, 5, 5, 5);
			this.mainitem1.ScaleFixedWidth = true;
			this.mainitem1.ScaleLeftBottom = 0.5F;
			this.mainitem1.ScaleLeftTop = 0.5F;
			this.mainitem1.ScaleRightBottom = 0.5F;
			this.mainitem1.ScaleRightTop = 0.5F;
			this.mainitem1.Size = new System.Drawing.Size(801, 43);
			this.mainitem1.TabIndex = 15;
			this.mainitem1.Text = "W • 4";
			this.mainitem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mainitem1.UseMnemonic = false;
			this.mainitem1.Click += new System.EventHandler(this.mainitem_Click);
			// 
			// addbutton
			// 
			this.addbutton.BackColor = System.Drawing.Color.LightGray;
			this.addbutton.Clickable = true;
			this.addbutton.ClickSound = "207";
			this.addbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.addbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.addbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.addbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.addbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.addbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.addbutton.InverseFlash = false;
			this.addbutton.Location = new System.Drawing.Point(1022, 83);
			this.addbutton.Name = "addbutton";
			this.addbutton.Padding = new System.Windows.Forms.Padding(5);
			this.addbutton.ScaleFixedWidth = true;
			this.addbutton.ScaleLeftBottom = 0.25F;
			this.addbutton.ScaleLeftTop = 0.25F;
			this.addbutton.ScaleRightBottom = 0.5F;
			this.addbutton.ScaleRightTop = 0.5F;
			this.addbutton.Size = new System.Drawing.Size(245, 110);
			this.addbutton.TabIndex = 2;
			this.addbutton.Text = "Add";
			this.addbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
			// 
			// displayBar4
			// 
			this.displayBar4.BackColor = System.Drawing.Color.LightGray;
			this.displayBar4.BlockMouseInput = true;
			this.displayBar4.ClickSound = null;
			this.displayBar4.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar4.FocusControl = null;
			this.displayBar4.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.Location = new System.Drawing.Point(1022, 621);
			this.displayBar4.Name = "displayBar4";
			this.displayBar4.ScaleFixedWidth = false;
			this.displayBar4.ScaleLeftBottom = 0.25F;
			this.displayBar4.ScaleLeftTop = 0.25F;
			this.displayBar4.ScaleRightBottom = 0.25F;
			this.displayBar4.ScaleRightTop = 0.25F;
			this.displayBar4.Size = new System.Drawing.Size(245, 25);
			this.displayBar4.TabIndex = 5;
			// 
			// removebutton
			// 
			this.removebutton.BackColor = System.Drawing.Color.IndianRed;
			this.removebutton.Clickable = true;
			this.removebutton.ClickSound = "214";
			this.removebutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColorNegative;
			this.removebutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.removebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.removebutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.removebutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.removebutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.removebutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.removebutton.InverseFlash = false;
			this.removebutton.Location = new System.Drawing.Point(1022, 230);
			this.removebutton.Name = "removebutton";
			this.removebutton.Padding = new System.Windows.Forms.Padding(5);
			this.removebutton.ScaleFixedWidth = true;
			this.removebutton.ScaleLeftBottom = 0.25F;
			this.removebutton.ScaleLeftTop = 0.25F;
			this.removebutton.ScaleRightBottom = 0.5F;
			this.removebutton.ScaleRightTop = 0.5F;
			this.removebutton.Size = new System.Drawing.Size(245, 110);
			this.removebutton.TabIndex = 4;
			this.removebutton.Text = "Remove";
			this.removebutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.removebutton.Click += new System.EventHandler(this.removebutton_Click);
			// 
			// displayBar5
			// 
			this.displayBar5.BackColor = System.Drawing.Color.Silver;
			this.displayBar5.BlockMouseInput = true;
			this.displayBar5.ClickSound = null;
			this.displayBar5.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayBar5.FocusControl = null;
			this.displayBar5.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.Location = new System.Drawing.Point(1022, 199);
			this.displayBar5.Name = "displayBar5";
			this.displayBar5.ScaleFixedWidth = false;
			this.displayBar5.ScaleLeftBottom = 0.25F;
			this.displayBar5.ScaleLeftTop = 0.25F;
			this.displayBar5.ScaleRightBottom = 0.25F;
			this.displayBar5.ScaleRightTop = 0.25F;
			this.displayBar5.Size = new System.Drawing.Size(245, 25);
			this.displayBar5.TabIndex = 3;
			// 
			// displayBar8
			// 
			this.displayBar8.BackColor = System.Drawing.Color.LightGray;
			this.displayBar8.BlockMouseInput = true;
			this.displayBar8.ClickSound = null;
			this.displayBar8.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar8.FocusControl = null;
			this.displayBar8.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar8.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar8.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar8.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar8.Location = new System.Drawing.Point(1022, -3);
			this.displayBar8.Name = "displayBar8";
			this.displayBar8.ScaleFixedWidth = false;
			this.displayBar8.ScaleLeftBottom = 0.25F;
			this.displayBar8.ScaleLeftTop = 0.25F;
			this.displayBar8.ScaleRightBottom = 0.25F;
			this.displayBar8.ScaleRightTop = 0.25F;
			this.displayBar8.Size = new System.Drawing.Size(245, 80);
			this.displayBar8.TabIndex = 1;
			// 
			// overviewbutton
			// 
			this.overviewbutton.BackColor = System.Drawing.Color.Tan;
			this.overviewbutton.Clickable = true;
			this.overviewbutton.ClickSound = "214";
			this.overviewbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor1;
			this.overviewbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.overviewbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.overviewbutton.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.overviewbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.overviewbutton.InverseFlash = false;
			this.overviewbutton.Location = new System.Drawing.Point(1022, 855);
			this.overviewbutton.Name = "overviewbutton";
			this.overviewbutton.Padding = new System.Windows.Forms.Padding(5);
			this.overviewbutton.ScaleFixedWidth = true;
			this.overviewbutton.ScaleLeftBottom = 0.25F;
			this.overviewbutton.ScaleLeftTop = 0.25F;
			this.overviewbutton.ScaleRightBottom = 0.25F;
			this.overviewbutton.ScaleRightTop = 0.25F;
			this.overviewbutton.Size = new System.Drawing.Size(245, 110);
			this.overviewbutton.TabIndex = 2;
			this.overviewbutton.Text = "Overview";
			this.overviewbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.overviewbutton.Click += new System.EventHandler(this.overviewbutton_Click);
			// 
			// displayBar10
			// 
			this.displayBar10.BackColor = System.Drawing.Color.Silver;
			this.displayBar10.BlockMouseInput = true;
			this.displayBar10.ClickSound = null;
			this.displayBar10.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.displayBar10.FocusControl = null;
			this.displayBar10.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar10.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar10.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar10.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar10.Location = new System.Drawing.Point(600, 528);
			this.displayBar10.Name = "displayBar10";
			this.displayBar10.ScaleFixedWidth = true;
			this.displayBar10.ScaleLeftBottom = 0.5F;
			this.displayBar10.ScaleLeftTop = 0.5F;
			this.displayBar10.ScaleRightBottom = 0.25F;
			this.displayBar10.ScaleRightTop = 0.25F;
			this.displayBar10.Size = new System.Drawing.Size(261, 48);
			this.displayBar10.TabIndex = 8;
			// 
			// displayBar11
			// 
			this.displayBar11.BackColor = System.Drawing.Color.LightGray;
			this.displayBar11.BlockMouseInput = true;
			this.displayBar11.ClickSound = null;
			this.displayBar11.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar11.FocusControl = null;
			this.displayBar11.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar11.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar11.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar11.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar11.Location = new System.Drawing.Point(867, 528);
			this.displayBar11.Name = "displayBar11";
			this.displayBar11.ScaleFixedWidth = true;
			this.displayBar11.ScaleLeftBottom = 0.5F;
			this.displayBar11.ScaleLeftTop = 0.5F;
			this.displayBar11.ScaleRightBottom = 0.25F;
			this.displayBar11.ScaleRightTop = 0.25F;
			this.displayBar11.Size = new System.Drawing.Size(114, 48);
			this.displayBar11.TabIndex = 7;
			// 
			// upbutton
			// 
			this.upbutton.BackColor = System.Drawing.Color.Tan;
			this.upbutton.Clickable = true;
			this.upbutton.ClickSound = "214";
			this.upbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor2;
			this.upbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.upbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.upbutton.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.upbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.upbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.upbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.upbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.upbutton.InverseFlash = false;
			this.upbutton.Location = new System.Drawing.Point(179, 474);
			this.upbutton.Name = "upbutton";
			this.upbutton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.upbutton.ScaleFixedWidth = false;
			this.upbutton.ScaleLeftBottom = 0.5F;
			this.upbutton.ScaleLeftTop = 0.5F;
			this.upbutton.ScaleRightBottom = 0.5F;
			this.upbutton.ScaleRightTop = 0.5F;
			this.upbutton.Size = new System.Drawing.Size(113, 48);
			this.upbutton.TabIndex = 12;
			this.upbutton.Text = "Up";
			this.upbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.upbutton.Click += new System.EventHandler(this.upbutton_Click);
			// 
			// downbutton
			// 
			this.downbutton.BackColor = System.Drawing.Color.Tan;
			this.downbutton.Clickable = true;
			this.downbutton.ClickSound = "214";
			this.downbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor2;
			this.downbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.downbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.downbutton.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.downbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.downbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.downbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.downbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.downbutton.InverseFlash = false;
			this.downbutton.Location = new System.Drawing.Point(298, 474);
			this.downbutton.Name = "downbutton";
			this.downbutton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.downbutton.ScaleFixedWidth = false;
			this.downbutton.ScaleLeftBottom = 0.5F;
			this.downbutton.ScaleLeftTop = 0.5F;
			this.downbutton.ScaleRightBottom = 0.5F;
			this.downbutton.ScaleRightTop = 0.5F;
			this.downbutton.Size = new System.Drawing.Size(113, 48);
			this.downbutton.TabIndex = 10;
			this.downbutton.Text = "Down";
			this.downbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.downbutton.Click += new System.EventHandler(this.downbutton_Click);
			// 
			// deselectedlabel
			// 
			this.deselectedlabel.AutoSizeHeight = false;
			this.deselectedlabel.ClickSound = null;
			this.deselectedlabel.ColorBackground = CodeImp.Gluon.ColorIndex.WindowBackground;
			this.deselectedlabel.ColorText = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.deselectedlabel.FocusControl = null;
			this.deselectedlabel.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deselectedlabel.Location = new System.Drawing.Point(37, 704);
			this.deselectedlabel.MaximumHeight = 0;
			this.deselectedlabel.Name = "deselectedlabel";
			this.deselectedlabel.Size = new System.Drawing.Size(940, 209);
			this.deselectedlabel.TabIndex = 21;
			this.deselectedlabel.Text = "SELECT AN ITEM TO EDIT\r\nOR ADD A NEW ITEM";
			this.deselectedlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// scrolltimer
			// 
			this.scrolltimer.Interval = 50;
			this.scrolltimer.Tick += new System.EventHandler(this.scrolltimer_Tick);
			// 
			// updatebutton
			// 
			this.updatebutton.BackColor = System.Drawing.Color.Khaki;
			this.updatebutton.Clickable = true;
			this.updatebutton.ClickSound = "207";
			this.updatebutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColorAffirmative;
			this.updatebutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.updatebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.updatebutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.updatebutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.updatebutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.updatebutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.updatebutton.InverseFlash = false;
			this.updatebutton.Location = new System.Drawing.Point(1022, 652);
			this.updatebutton.Name = "updatebutton";
			this.updatebutton.Padding = new System.Windows.Forms.Padding(5);
			this.updatebutton.ScaleFixedWidth = true;
			this.updatebutton.ScaleLeftBottom = 0.25F;
			this.updatebutton.ScaleLeftTop = 0.25F;
			this.updatebutton.ScaleRightBottom = 0.5F;
			this.updatebutton.ScaleRightTop = 0.5F;
			this.updatebutton.Size = new System.Drawing.Size(245, 110);
			this.updatebutton.TabIndex = 4;
			this.updatebutton.Text = "Update";
			this.updatebutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
			// 
			// displayBar12
			// 
			this.displayBar12.BackColor = System.Drawing.Color.LightGray;
			this.displayBar12.BlockMouseInput = true;
			this.displayBar12.ClickSound = null;
			this.displayBar12.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar12.FocusControl = null;
			this.displayBar12.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar12.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar12.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar12.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar12.Location = new System.Drawing.Point(1022, 768);
			this.displayBar12.Name = "displayBar12";
			this.displayBar12.ScaleFixedWidth = false;
			this.displayBar12.ScaleLeftBottom = 0.25F;
			this.displayBar12.ScaleLeftTop = 0.25F;
			this.displayBar12.ScaleRightBottom = 0.25F;
			this.displayBar12.ScaleRightTop = 0.25F;
			this.displayBar12.Size = new System.Drawing.Size(245, 81);
			this.displayBar12.TabIndex = 3;
			// 
			// textscrolltimer
			// 
			this.textscrolltimer.Interval = 50;
			this.textscrolltimer.Tick += new System.EventHandler(this.textscrolltimer_Tick);
			// 
			// textscroll
			// 
			this.textscroll.BackColor = System.Drawing.Color.Gray;
			this.textscroll.Clickable = false;
			this.textscroll.ClickSound = "";
			this.textscroll.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.textscroll.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.textscroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.textscroll.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.textscroll.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.textscroll.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.textscroll.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.textscroll.InverseFlash = false;
			this.textscroll.Location = new System.Drawing.Point(872, 692);
			this.textscroll.Margin = new System.Windows.Forms.Padding(5);
			this.textscroll.Name = "textscroll";
			this.textscroll.ScaleFixedWidth = true;
			this.textscroll.ScaleLeftBottom = 0.25F;
			this.textscroll.ScaleLeftTop = 0.25F;
			this.textscroll.ScaleRightBottom = 0.25F;
			this.textscroll.ScaleRightTop = 0.25F;
			this.textscroll.Size = new System.Drawing.Size(51, 8);
			this.textscroll.TabIndex = 21;
			// 
			// displayBar13
			// 
			this.displayBar13.BackColor = System.Drawing.Color.LightGray;
			this.displayBar13.BlockMouseInput = true;
			this.displayBar13.ClickSound = null;
			this.displayBar13.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar13.FocusControl = null;
			this.displayBar13.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar13.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar13.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar13.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar13.Location = new System.Drawing.Point(417, 474);
			this.displayBar13.Name = "displayBar13";
			this.displayBar13.ScaleFixedWidth = true;
			this.displayBar13.ScaleLeftBottom = 0.5F;
			this.displayBar13.ScaleLeftTop = 0.5F;
			this.displayBar13.ScaleRightBottom = 0.25F;
			this.displayBar13.ScaleRightTop = 0.25F;
			this.displayBar13.Size = new System.Drawing.Size(230, 48);
			this.displayBar13.TabIndex = 9;
			// 
			// displayBar14
			// 
			this.displayBar14.BackColor = System.Drawing.Color.LightGray;
			this.displayBar14.BlockMouseInput = true;
			this.displayBar14.ClickSound = null;
			this.displayBar14.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar14.FocusControl = null;
			this.displayBar14.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar14.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar14.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar14.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar14.Location = new System.Drawing.Point(118, 528);
			this.displayBar14.Name = "displayBar14";
			this.displayBar14.ScaleFixedWidth = true;
			this.displayBar14.ScaleLeftBottom = 0.5F;
			this.displayBar14.ScaleLeftTop = 0.5F;
			this.displayBar14.ScaleRightBottom = 0.25F;
			this.displayBar14.ScaleRightTop = 0.25F;
			this.displayBar14.Size = new System.Drawing.Size(476, 48);
			this.displayBar14.TabIndex = 11;
			// 
			// NotesDisplayPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.displayBar14);
			this.Controls.Add(this.displayBar13);
			this.Controls.Add(this.textscroll);
			this.Controls.Add(this.displayBar12);
			this.Controls.Add(this.updatebutton);
			this.Controls.Add(this.overviewbutton);
			this.Controls.Add(this.downbutton);
			this.Controls.Add(this.upbutton);
			this.Controls.Add(this.displayBar11);
			this.Controls.Add(this.displayBar10);
			this.Controls.Add(this.displayBar8);
			this.Controls.Add(this.displayBar5);
			this.Controls.Add(this.removebutton);
			this.Controls.Add(this.displayBar4);
			this.Controls.Add(this.addbutton);
			this.Controls.Add(this.mainitem10);
			this.Controls.Add(this.mainitem9);
			this.Controls.Add(this.mainitem8);
			this.Controls.Add(this.mainitem7);
			this.Controls.Add(this.mainitem6);
			this.Controls.Add(this.mainitem5);
			this.Controls.Add(this.mainitem4);
			this.Controls.Add(this.mainitem3);
			this.Controls.Add(this.mainitem2);
			this.Controls.Add(this.mainitem1);
			this.Controls.Add(this.mainscroll);
			this.Controls.Add(this.maindown);
			this.Controls.Add(this.mainup);
			this.Controls.Add(this.displayBar3);
			this.Controls.Add(this.displayBar2);
			this.Controls.Add(this.displayBar6);
			this.Controls.Add(this.displayBar9);
			this.Controls.Add(this.displayBar7);
			this.Controls.Add(this.textdown);
			this.Controls.Add(this.textup);
			this.Controls.Add(this.notetextpanel);
			this.Controls.Add(this.keyboard);
			this.Controls.Add(this.displayBar1);
			this.Controls.Add(this.displayBar16);
			this.Controls.Add(this.deselectedlabel);
			this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.Name = "NotesDisplayPanel";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(1280, 1024);
			this.notetextpanel.ResumeLayout(false);
			this.notetextpanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private DisplayKeyboard keyboard;
		private DisplayTextBox notetext;
		private DisplayBar notetextpanel;
		private DisplayButton textdown;
		private DisplayButton textup;
		private DisplayBar displayBar16;
		private DisplayBar displayBar7;
		private DisplayBar displayBar9;
		private DisplayBar displayBar6;
		private DisplayBar displayBar1;
		private DisplayBar displayBar2;
		private DisplayBar displayBar3;
		private DisplayButton mainscroll;
		private DisplayButton maindown;
		private DisplayButton mainup;
		private DisplayButton mainitem10;
		private DisplayButton mainitem9;
		private DisplayButton mainitem8;
		private DisplayButton mainitem7;
		private DisplayButton mainitem6;
		private DisplayButton mainitem5;
		private DisplayButton mainitem4;
		private DisplayButton mainitem3;
		private DisplayButton mainitem2;
		private DisplayButton mainitem1;
		private DisplayButton addbutton;
		private DisplayBar displayBar4;
		private DisplayButton removebutton;
		private DisplayBar displayBar5;
		private DisplayBar displayBar8;
		private DisplayButton overviewbutton;
		private DisplayBar displayBar10;
		private DisplayBar displayBar11;
		private DisplayButton upbutton;
		private DisplayButton downbutton;
		private DisplayLabel deselectedlabel;
		private System.Windows.Forms.Timer scrolltimer;
		private DisplayButton updatebutton;
		private DisplayBar displayBar12;
		private System.Windows.Forms.Timer textscrolltimer;
		private DisplayButton textscroll;
		private DisplayBar displayBar13;
		private DisplayBar displayBar14;
	}
}
