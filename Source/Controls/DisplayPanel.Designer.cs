namespace CodeImp.Gluon
{
	partial class DisplayPanel
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
			this.showtimer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// showtimer
			// 
			this.showtimer.Interval = 10;
			this.showtimer.Tick += new System.EventHandler(this.showtimer_Tick);
			// 
			// DisplayPanel
			// 
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "DisplayPanel";
			this.Size = new System.Drawing.Size(399, 312);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer showtimer;
	}
}
