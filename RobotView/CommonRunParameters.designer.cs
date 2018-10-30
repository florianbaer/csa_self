namespace RobotView
{
    partial class CommonRunParameters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label16 = new System.Windows.Forms.Label();
            this.upDownAcceleration = new System.Windows.Forms.NumericUpDown();
            this.upDownSpeed = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.buttonEditSpeed = new System.Windows.Forms.Button();
            this.buttonEditAcceleration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(182, 20);
            this.label16.Text = "Common Run Parameter";
            // 
            // upDownAcceleration
            // 
            this.upDownAcceleration.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.upDownAcceleration.Location = new System.Drawing.Point(215, 50);
            this.upDownAcceleration.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.upDownAcceleration.Name = "upDownAcceleration";
            this.upDownAcceleration.Size = new System.Drawing.Size(75, 24);
            this.upDownAcceleration.TabIndex = 20;
            this.upDownAcceleration.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // upDownSpeed
            // 
            this.upDownSpeed.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.upDownSpeed.Location = new System.Drawing.Point(215, 20);
            this.upDownSpeed.Maximum = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            this.upDownSpeed.Name = "upDownSpeed";
            this.upDownSpeed.Size = new System.Drawing.Size(75, 24);
            this.upDownSpeed.TabIndex = 21;
            this.upDownSpeed.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.label19.Location = new System.Drawing.Point(3, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(172, 20);
            this.label19.Text = "Acceleration (+ mm/s^2)";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.label18.Location = new System.Drawing.Point(3, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(172, 20);
            this.label18.Text = "Speed (+ mm/s)";
            // 
            // buttonEditSpeed
            // 
            this.buttonEditSpeed.Location = new System.Drawing.Point(296, 20);
            this.buttonEditSpeed.Name = "buttonEditSpeed";
            this.buttonEditSpeed.Size = new System.Drawing.Size(51, 24);
            this.buttonEditSpeed.TabIndex = 34;
            this.buttonEditSpeed.Text = "...";
            this.buttonEditSpeed.Click += new System.EventHandler(this.buttonEditSpeed_Click);
            // 
            // buttonEditAcceleration
            // 
            this.buttonEditAcceleration.Location = new System.Drawing.Point(296, 50);
            this.buttonEditAcceleration.Name = "buttonEditAcceleration";
            this.buttonEditAcceleration.Size = new System.Drawing.Size(51, 24);
            this.buttonEditAcceleration.TabIndex = 35;
            this.buttonEditAcceleration.Text = "...";
            this.buttonEditAcceleration.Click += new System.EventHandler(this.buttonEditAcceleration_Click);
            // 
            // CommonRunParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.buttonEditAcceleration);
            this.Controls.Add(this.buttonEditSpeed);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.upDownAcceleration);
            this.Controls.Add(this.upDownSpeed);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Name = "CommonRunParameters";
            this.Size = new System.Drawing.Size(410, 84);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown upDownAcceleration;
        private System.Windows.Forms.NumericUpDown upDownSpeed;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonEditSpeed;
        private System.Windows.Forms.Button buttonEditAcceleration;
    }
}
