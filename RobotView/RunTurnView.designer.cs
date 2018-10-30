namespace RobotView
{
    partial class RunTurnView
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
            this.btnStart = new System.Windows.Forms.Button();
            this.npAngle = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(325, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 28);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // npAngle
            // 
            this.npAngle.Location = new System.Drawing.Point(177, 16);
            this.npAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.npAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.npAngle.Name = "npAngle";
            this.npAngle.Size = new System.Drawing.Size(142, 24);
            this.npAngle.TabIndex = 8;
            this.npAngle.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.npAngle.ValueChanged += new System.EventHandler(this.npAngle_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(128, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "+/-";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.Text = "Angle (+/-)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.Text = "RunTurn";
            // 
            // RunTurnView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.npAngle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RunTurnView";
            this.Size = new System.Drawing.Size(403, 55);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown npAngle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
