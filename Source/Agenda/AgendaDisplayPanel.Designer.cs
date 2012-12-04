namespace CodeImp.Gluon
{
	partial class AgendaDisplayPanel
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
			this.day1 = new CodeImp.Gluon.AgendaDayDisplay();
			this.day2 = new CodeImp.Gluon.AgendaDayDisplay();
			this.day3 = new CodeImp.Gluon.AgendaDayDisplay();
			this.day7 = new CodeImp.Gluon.AgendaDayDisplay();
			this.day6 = new CodeImp.Gluon.AgendaDayDisplay();
			this.day5 = new CodeImp.Gluon.AgendaDayDisplay();
			this.day4 = new CodeImp.Gluon.AgendaDayDisplay();
			this.displayBar1 = new CodeImp.Gluon.DisplayBar();
			this.displayBar2 = new CodeImp.Gluon.DisplayBar();
			this.displayBar4 = new CodeImp.Gluon.DisplayBar();
			this.displayBar5 = new CodeImp.Gluon.DisplayBar();
			this.nextmonthbutton = new CodeImp.Gluon.DisplayButton();
			this.nextweekbutton = new CodeImp.Gluon.DisplayButton();
			this.prevweekbutton = new CodeImp.Gluon.DisplayButton();
			this.prevmonthbutton = new CodeImp.Gluon.DisplayButton();
			this.displayBar7 = new CodeImp.Gluon.DisplayBar();
			this.yearlabel = new CodeImp.Gluon.DisplayLabel();
			this.monthlabel = new CodeImp.Gluon.DisplayLabel();
			this.weeklabel = new CodeImp.Gluon.DisplayLabel();
			this.displayBar3 = new CodeImp.Gluon.DisplayBar();
			this.overviewbutton = new CodeImp.Gluon.DisplayButton();
			this.showtimer = new System.Windows.Forms.Timer(this.components);
			this.displayBar7.SuspendLayout();
			this.SuspendLayout();
			// 
			// day1
			// 
			this.day1.BackColor = System.Drawing.Color.DarkGray;
			this.day1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day1.Location = new System.Drawing.Point(13, 13);
			this.day1.Name = "day1";
			this.day1.Size = new System.Drawing.Size(480, 245);
			this.day1.TabIndex = 0;
			this.day1.AddClicked += new System.EventHandler(this.Add_Click);
			this.day1.ViewClicked += new System.EventHandler(this.View_Click);
			// 
			// day2
			// 
			this.day2.BackColor = System.Drawing.Color.DarkGray;
			this.day2.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day2.Location = new System.Drawing.Point(13, 264);
			this.day2.Name = "day2";
			this.day2.Size = new System.Drawing.Size(480, 245);
			this.day2.TabIndex = 0;
			this.day2.AddClicked += new System.EventHandler(this.Add_Click);
			this.day2.ViewClicked += new System.EventHandler(this.View_Click);
			// 
			// day3
			// 
			this.day3.BackColor = System.Drawing.Color.DarkGray;
			this.day3.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day3.Location = new System.Drawing.Point(13, 515);
			this.day3.Name = "day3";
			this.day3.Size = new System.Drawing.Size(480, 245);
			this.day3.TabIndex = 0;
			this.day3.AddClicked += new System.EventHandler(this.Add_Click);
			this.day3.ViewClicked += new System.EventHandler(this.View_Click);
			// 
			// day7
			// 
			this.day7.BackColor = System.Drawing.Color.DarkGray;
			this.day7.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day7.Location = new System.Drawing.Point(538, 515);
			this.day7.Name = "day7";
			this.day7.Size = new System.Drawing.Size(480, 245);
			this.day7.TabIndex = 0;
			this.day7.AddClicked += new System.EventHandler(this.Add_Click);
			this.day7.ViewClicked += new System.EventHandler(this.View_Click);
			// 
			// day6
			// 
			this.day6.BackColor = System.Drawing.Color.DarkGray;
			this.day6.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day6.Location = new System.Drawing.Point(538, 264);
			this.day6.Name = "day6";
			this.day6.Size = new System.Drawing.Size(480, 245);
			this.day6.TabIndex = 0;
			this.day6.AddClicked += new System.EventHandler(this.Add_Click);
			this.day6.ViewClicked += new System.EventHandler(this.View_Click);
			// 
			// day5
			// 
			this.day5.BackColor = System.Drawing.Color.DarkGray;
			this.day5.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day5.Location = new System.Drawing.Point(538, 13);
			this.day5.Name = "day5";
			this.day5.Size = new System.Drawing.Size(480, 245);
			this.day5.TabIndex = 0;
			this.day5.AddClicked += new System.EventHandler(this.Add_Click);
			this.day5.ViewClicked += new System.EventHandler(this.View_Click);
			// 
			// day4
			// 
			this.day4.BackColor = System.Drawing.Color.DarkGray;
			this.day4.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.day4.Location = new System.Drawing.Point(13, 766);
			this.day4.Name = "day4";
			this.day4.Size = new System.Drawing.Size(480, 245);
			this.day4.TabIndex = 0;
			this.day4.AddClicked += new System.EventHandler(this.Add_Click);
			this.day4.ViewClicked += new System.EventHandler(this.View_Click);
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
			this.displayBar1.Location = new System.Drawing.Point(1118, 812);
			this.displayBar1.Name = "displayBar1";
			this.displayBar1.ScaleFixedWidth = true;
			this.displayBar1.ScaleLeftBottom = 0.5F;
			this.displayBar1.ScaleLeftTop = 0.5F;
			this.displayBar1.ScaleRightBottom = 0.5F;
			this.displayBar1.ScaleRightTop = 1F;
			this.displayBar1.Size = new System.Drawing.Size(149, 103);
			this.displayBar1.TabIndex = 7;
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
			this.displayBar2.ImageRightBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipXY;
			this.displayBar2.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar2.Location = new System.Drawing.Point(1118, 914);
			this.displayBar2.Name = "displayBar2";
			this.displayBar2.ScaleFixedWidth = true;
			this.displayBar2.ScaleLeftBottom = 0.5F;
			this.displayBar2.ScaleLeftTop = 0.5F;
			this.displayBar2.ScaleRightBottom = 1F;
			this.displayBar2.ScaleRightTop = 0.5F;
			this.displayBar2.Size = new System.Drawing.Size(149, 97);
			this.displayBar2.TabIndex = 8;
			// 
			// displayBar4
			// 
			this.displayBar4.BackColor = System.Drawing.Color.LightGray;
			this.displayBar4.BlockMouseInput = true;
			this.displayBar4.ClickSound = null;
			this.displayBar4.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar4.FocusControl = null;
			this.displayBar4.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveInverseFlipXY;
			this.displayBar4.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar4.Location = new System.Drawing.Point(1066, 887);
			this.displayBar4.Name = "displayBar4";
			this.displayBar4.ScaleFixedWidth = true;
			this.displayBar4.ScaleLeftBottom = 0.5F;
			this.displayBar4.ScaleLeftTop = 0.999F;
			this.displayBar4.ScaleRightBottom = 0.5F;
			this.displayBar4.ScaleRightTop = 0.5F;
			this.displayBar4.Size = new System.Drawing.Size(52, 52);
			this.displayBar4.TabIndex = 8;
			// 
			// displayBar5
			// 
			this.displayBar5.BackColor = System.Drawing.Color.LightGray;
			this.displayBar5.BlockMouseInput = true;
			this.displayBar5.ClickSound = null;
			this.displayBar5.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar5.FocusControl = null;
			this.displayBar5.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar5.Location = new System.Drawing.Point(1118, -17);
			this.displayBar5.Name = "displayBar5";
			this.displayBar5.ScaleFixedWidth = true;
			this.displayBar5.ScaleLeftBottom = 0.5F;
			this.displayBar5.ScaleLeftTop = 0.5F;
			this.displayBar5.ScaleRightBottom = 0.5F;
			this.displayBar5.ScaleRightTop = 1F;
			this.displayBar5.Size = new System.Drawing.Size(149, 91);
			this.displayBar5.TabIndex = 1;
			// 
			// nextmonthbutton
			// 
			this.nextmonthbutton.BackColor = System.Drawing.Color.LightGray;
			this.nextmonthbutton.Clickable = true;
			this.nextmonthbutton.ClickSound = "207";
			this.nextmonthbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.nextmonthbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.nextmonthbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nextmonthbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.nextmonthbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.nextmonthbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.nextmonthbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.nextmonthbutton.InverseFlash = false;
			this.nextmonthbutton.Location = new System.Drawing.Point(1118, 691);
			this.nextmonthbutton.Margin = new System.Windows.Forms.Padding(3);
			this.nextmonthbutton.Name = "nextmonthbutton";
			this.nextmonthbutton.Padding = new System.Windows.Forms.Padding(5);
			this.nextmonthbutton.ScaleFixedWidth = true;
			this.nextmonthbutton.ScaleLeftBottom = 0.25F;
			this.nextmonthbutton.ScaleLeftTop = 0.25F;
			this.nextmonthbutton.ScaleRightBottom = 0.25F;
			this.nextmonthbutton.ScaleRightTop = 0.25F;
			this.nextmonthbutton.Size = new System.Drawing.Size(149, 115);
			this.nextmonthbutton.TabIndex = 6;
			this.nextmonthbutton.Text = "Next\r\nMonth";
			this.nextmonthbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.nextmonthbutton.Click += new System.EventHandler(this.nextmonthbutton_Click);
			// 
			// nextweekbutton
			// 
			this.nextweekbutton.BackColor = System.Drawing.Color.LightGray;
			this.nextweekbutton.Clickable = true;
			this.nextweekbutton.ClickSound = "207";
			this.nextweekbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.nextweekbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.nextweekbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nextweekbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.nextweekbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.nextweekbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.nextweekbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.nextweekbutton.InverseFlash = false;
			this.nextweekbutton.Location = new System.Drawing.Point(1118, 570);
			this.nextweekbutton.Margin = new System.Windows.Forms.Padding(3);
			this.nextweekbutton.Name = "nextweekbutton";
			this.nextweekbutton.Padding = new System.Windows.Forms.Padding(5);
			this.nextweekbutton.ScaleFixedWidth = true;
			this.nextweekbutton.ScaleLeftBottom = 0.25F;
			this.nextweekbutton.ScaleLeftTop = 0.25F;
			this.nextweekbutton.ScaleRightBottom = 0.25F;
			this.nextweekbutton.ScaleRightTop = 0.25F;
			this.nextweekbutton.Size = new System.Drawing.Size(149, 115);
			this.nextweekbutton.TabIndex = 5;
			this.nextweekbutton.Text = "Next\r\nWeek";
			this.nextweekbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.nextweekbutton.Click += new System.EventHandler(this.nextweekbutton_Click);
			// 
			// prevweekbutton
			// 
			this.prevweekbutton.BackColor = System.Drawing.Color.LightGray;
			this.prevweekbutton.Clickable = true;
			this.prevweekbutton.ClickSound = "207";
			this.prevweekbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor3;
			this.prevweekbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.prevweekbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.prevweekbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.prevweekbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.prevweekbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.prevweekbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.prevweekbutton.InverseFlash = false;
			this.prevweekbutton.Location = new System.Drawing.Point(1118, 201);
			this.prevweekbutton.Margin = new System.Windows.Forms.Padding(3);
			this.prevweekbutton.Name = "prevweekbutton";
			this.prevweekbutton.Padding = new System.Windows.Forms.Padding(5);
			this.prevweekbutton.ScaleFixedWidth = true;
			this.prevweekbutton.ScaleLeftBottom = 0.25F;
			this.prevweekbutton.ScaleLeftTop = 0.25F;
			this.prevweekbutton.ScaleRightBottom = 0.25F;
			this.prevweekbutton.ScaleRightTop = 0.25F;
			this.prevweekbutton.Size = new System.Drawing.Size(149, 115);
			this.prevweekbutton.TabIndex = 3;
			this.prevweekbutton.Text = "Prev\r\nWeek";
			this.prevweekbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.prevweekbutton.Click += new System.EventHandler(this.prevweekbutton_Click);
			// 
			// prevmonthbutton
			// 
			this.prevmonthbutton.BackColor = System.Drawing.Color.LightGray;
			this.prevmonthbutton.Clickable = true;
			this.prevmonthbutton.ClickSound = "207";
			this.prevmonthbutton.ColorNormal = CodeImp.Gluon.ColorIndex.ControlColor4;
			this.prevmonthbutton.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.prevmonthbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.prevmonthbutton.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.None;
			this.prevmonthbutton.ImageLeftTop = CodeImp.Gluon.InterfaceImage.None;
			this.prevmonthbutton.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.prevmonthbutton.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.prevmonthbutton.InverseFlash = false;
			this.prevmonthbutton.Location = new System.Drawing.Point(1118, 80);
			this.prevmonthbutton.Margin = new System.Windows.Forms.Padding(3);
			this.prevmonthbutton.Name = "prevmonthbutton";
			this.prevmonthbutton.Padding = new System.Windows.Forms.Padding(5);
			this.prevmonthbutton.ScaleFixedWidth = true;
			this.prevmonthbutton.ScaleLeftBottom = 0.25F;
			this.prevmonthbutton.ScaleLeftTop = 0.25F;
			this.prevmonthbutton.ScaleRightBottom = 0.25F;
			this.prevmonthbutton.ScaleRightTop = 0.25F;
			this.prevmonthbutton.Size = new System.Drawing.Size(149, 115);
			this.prevmonthbutton.TabIndex = 2;
			this.prevmonthbutton.Text = "Prev\r\nMonth";
			this.prevmonthbutton.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.prevmonthbutton.Click += new System.EventHandler(this.prevmonthbutton_Click);
			// 
			// displayBar7
			// 
			this.displayBar7.BackColor = System.Drawing.Color.LightGray;
			this.displayBar7.BlockMouseInput = true;
			this.displayBar7.ClickSound = null;
			this.displayBar7.ColorNormal = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.displayBar7.Controls.Add(this.yearlabel);
			this.displayBar7.FocusControl = null;
			this.displayBar7.ImageLeftBottom = CodeImp.Gluon.InterfaceImage.WindowCurveFlipY;
			this.displayBar7.ImageLeftTop = CodeImp.Gluon.InterfaceImage.WindowCurveNormal;
			this.displayBar7.ImageRightBottom = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.ImageRightTop = CodeImp.Gluon.InterfaceImage.None;
			this.displayBar7.Location = new System.Drawing.Point(538, 937);
			this.displayBar7.Name = "displayBar7";
			this.displayBar7.ScaleFixedWidth = true;
			this.displayBar7.ScaleLeftBottom = 0.5F;
			this.displayBar7.ScaleLeftTop = 0.5F;
			this.displayBar7.ScaleRightBottom = 0.5F;
			this.displayBar7.ScaleRightTop = 0.5F;
			this.displayBar7.Size = new System.Drawing.Size(133, 74);
			this.displayBar7.TabIndex = 12;
			// 
			// yearlabel
			// 
			this.yearlabel.AutoSize = true;
			this.yearlabel.AutoSizeHeight = false;
			this.yearlabel.ClickSound = null;
			this.yearlabel.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.yearlabel.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.yearlabel.FocusControl = null;
			this.yearlabel.Location = new System.Drawing.Point(35, 13);
			this.yearlabel.Margin = new System.Windows.Forms.Padding(3);
			this.yearlabel.MaximumHeight = 0;
			this.yearlabel.Name = "yearlabel";
			this.yearlabel.Padding = new System.Windows.Forms.Padding(5);
			this.yearlabel.Size = new System.Drawing.Size(94, 49);
			this.yearlabel.TabIndex = 12;
			this.yearlabel.Text = "2009";
			// 
			// monthlabel
			// 
			this.monthlabel.AutoSizeHeight = false;
			this.monthlabel.BackColor = System.Drawing.Color.LightGray;
			this.monthlabel.ClickSound = null;
			this.monthlabel.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.monthlabel.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.monthlabel.FocusControl = null;
			this.monthlabel.Location = new System.Drawing.Point(677, 937);
			this.monthlabel.Margin = new System.Windows.Forms.Padding(3);
			this.monthlabel.MaximumHeight = 0;
			this.monthlabel.Name = "monthlabel";
			this.monthlabel.Padding = new System.Windows.Forms.Padding(5);
			this.monthlabel.Size = new System.Drawing.Size(195, 74);
			this.monthlabel.TabIndex = 11;
			this.monthlabel.Text = "September";
			this.monthlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// weeklabel
			// 
			this.weeklabel.AutoSizeHeight = false;
			this.weeklabel.BackColor = System.Drawing.Color.LightGray;
			this.weeklabel.ClickSound = null;
			this.weeklabel.ColorBackground = CodeImp.Gluon.ColorIndex.ControlNormal;
			this.weeklabel.ColorText = CodeImp.Gluon.ColorIndex.ControlNormalText;
			this.weeklabel.FocusControl = null;
			this.weeklabel.Location = new System.Drawing.Point(1118, 322);
			this.weeklabel.Margin = new System.Windows.Forms.Padding(3);
			this.weeklabel.MaximumHeight = 0;
			this.weeklabel.Name = "weeklabel";
			this.weeklabel.Padding = new System.Windows.Forms.Padding(5);
			this.weeklabel.Size = new System.Drawing.Size(149, 242);
			this.weeklabel.TabIndex = 4;
			this.weeklabel.Text = "26";
			this.weeklabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
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
			this.displayBar3.Location = new System.Drawing.Point(1051, 937);
			this.displayBar3.Name = "displayBar3";
			this.displayBar3.ScaleFixedWidth = true;
			this.displayBar3.ScaleLeftBottom = 0.5F;
			this.displayBar3.ScaleLeftTop = 0.5F;
			this.displayBar3.ScaleRightBottom = 0.5F;
			this.displayBar3.ScaleRightTop = 1F;
			this.displayBar3.Size = new System.Drawing.Size(67, 74);
			this.displayBar3.TabIndex = 9;
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
			this.overviewbutton.Location = new System.Drawing.Point(878, 937);
			this.overviewbutton.Name = "overviewbutton";
			this.overviewbutton.Padding = new System.Windows.Forms.Padding(5);
			this.overviewbutton.ScaleFixedWidth = true;
			this.overviewbutton.ScaleLeftBottom = 0.25F;
			this.overviewbutton.ScaleLeftTop = 0.25F;
			this.overviewbutton.ScaleRightBottom = 0.25F;
			this.overviewbutton.ScaleRightTop = 0.25F;
			this.overviewbutton.Size = new System.Drawing.Size(167, 74);
			this.overviewbutton.TabIndex = 10;
			this.overviewbutton.Text = "Overview";
			this.overviewbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.overviewbutton.Click += new System.EventHandler(this.overviewbutton_Click);
			// 
			// showtimer
			// 
			this.showtimer.Interval = 60;
			this.showtimer.Tick += new System.EventHandler(this.showtimer_Tick);
			// 
			// AgendaDisplayPanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.DarkGray;
			this.Controls.Add(this.overviewbutton);
			this.Controls.Add(this.displayBar3);
			this.Controls.Add(this.weeklabel);
			this.Controls.Add(this.monthlabel);
			this.Controls.Add(this.displayBar7);
			this.Controls.Add(this.prevweekbutton);
			this.Controls.Add(this.prevmonthbutton);
			this.Controls.Add(this.nextweekbutton);
			this.Controls.Add(this.nextmonthbutton);
			this.Controls.Add(this.displayBar5);
			this.Controls.Add(this.displayBar4);
			this.Controls.Add(this.displayBar2);
			this.Controls.Add(this.displayBar1);
			this.Controls.Add(this.day4);
			this.Controls.Add(this.day7);
			this.Controls.Add(this.day6);
			this.Controls.Add(this.day5);
			this.Controls.Add(this.day3);
			this.Controls.Add(this.day2);
			this.Controls.Add(this.day1);
			this.Name = "AgendaDisplayPanel";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(1280, 1024);
			this.displayBar7.ResumeLayout(false);
			this.displayBar7.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private AgendaDayDisplay day1;
		private AgendaDayDisplay day2;
		private AgendaDayDisplay day3;
		private AgendaDayDisplay day7;
		private AgendaDayDisplay day6;
		private AgendaDayDisplay day5;
		private AgendaDayDisplay day4;
		private DisplayBar displayBar1;
		private DisplayBar displayBar2;
		private DisplayBar displayBar4;
		private DisplayBar displayBar5;
		private DisplayButton nextmonthbutton;
		private DisplayButton nextweekbutton;
		private DisplayButton prevweekbutton;
		private DisplayButton prevmonthbutton;
		private DisplayBar displayBar7;
		private DisplayLabel monthlabel;
		private DisplayLabel yearlabel;
		private DisplayLabel weeklabel;
		private DisplayBar displayBar3;
		private DisplayButton overviewbutton;
		private System.Windows.Forms.Timer showtimer;
	}
}
