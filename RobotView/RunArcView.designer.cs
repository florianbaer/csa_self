    namespace RobotView
{
    partial class RunArcView
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
            this.npRadius = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.npAngle = new System.Windows.Forms.NumericUpDown();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(347, 70);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 28);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // npRadius
            // 
            this.npRadius.Location = new System.Drawing.Point(199, 36);
            this.npRadius.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.npRadius.Minimum = new decimal(new int[] {
            9999999,
            0,
            0,
            -2147483648});
            this.npRadius.Name = "npRadius";
            this.npRadius.Size = new System.Drawing.Size(142, 24);
            this.npRadius.TabIndex = 13;
            this.npRadius.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.npRadius.ValueChanged += new System.EventHandler(this.npRadius_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 28);
            this.button1.TabIndex = 12;
            this.button1.Text = "+/-";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.Text = "Radius (+mm)";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.Text = "RunArc";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.Text = "Angle (+/- degree)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 28);
            this.button2.TabIndex = 19;
            this.button2.Text = "+/-";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // npAngle
            // 
            this.npAngle.Location = new System.Drawing.Point(199, 70);
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
            this.npAngle.TabIndex = 20;
            this.npAngle.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.npAngle.ValueChanged += new System.EventHandler(this.npAngle_ValueChanged);
            // 
            // rbLeft
            // 
            this.rbLeft.Checked = true;
            this.rbLeft.Location = new System.Drawing.Point(199, 3);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(63, 20);
            this.rbLeft.TabIndex = 21;
            this.rbLeft.Text = "Left";
            // 
            // rbRight
            // 
            this.rbRight.Location = new System.Drawing.Point(268, 3);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(73, 20);
            this.rbRight.TabIndex = 22;
            this.rbRight.TabStop = false;
            this.rbRight.Text = "Right";
            // 
            // RunArcView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.rbRight);
            this.Controls.Add(this.rbLeft);
            this.Controls.Add(this.npAngle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.npRadius);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RunArcView";
            this.Size = new System.Drawing.Size(433, 107);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown npRadius;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown npAngle;
        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.RadioButton rbRight;
    }
}
