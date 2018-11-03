namespace RobotView
{
    partial class RunLineView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.npDistance = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.Text = "RunLine";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.Text = "Length (+/-)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "+/-";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // npDistance
            // 
            this.npDistance.Location = new System.Drawing.Point(178, 20);
            this.npDistance.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.npDistance.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.npDistance.Name = "npDistance";
            this.npDistance.Size = new System.Drawing.Size(142, 24);
            this.npDistance.TabIndex = 3;
            this.npDistance.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.npDistance.ValueChanged += new System.EventHandler(this.npDistance_ValueChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(326, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 28);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // RunLineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.npDistance);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RunLineView";
            this.Size = new System.Drawing.Size(404, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown npDistance;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
    }
}
