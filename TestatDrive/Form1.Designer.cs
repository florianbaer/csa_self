namespace TestatDrive
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbAnzahlObjekte = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.radarView1 = new RobotView.RadarView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Anzahl Objekte";
            // 
            // tbAnzahlObjekte
            // 
            this.tbAnzahlObjekte.Font = new System.Drawing.Font("Tahoma", 55F, System.Drawing.FontStyle.Regular);
            this.tbAnzahlObjekte.Location = new System.Drawing.Point(135, 74);
            this.tbAnzahlObjekte.Name = "tbAnzahlObjekte";
            this.tbAnzahlObjekte.Size = new System.Drawing.Size(259, 95);
            this.tbAnzahlObjekte.TabIndex = 1;
            // 
            // radarView1
            // 
            this.radarView1.Location = new System.Drawing.Point(3, 26);
            this.radarView1.Name = "radarView1";
            this.radarView1.Radar = null;
            this.radarView1.Size = new System.Drawing.Size(565, 42);
            this.radarView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(589, 238);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbAnzahlObjekte);
            this.Controls.Add(this.radarView1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAnzahlObjekte;
        private RobotView.RadarView radarView1;
        private System.Windows.Forms.MainMenu mainMenu1;
    }
}

