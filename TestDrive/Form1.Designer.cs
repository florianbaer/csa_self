namespace TestDrive
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.driveView1 = new RobotView.DriveView();
            this.commonRunParameters1 = new RobotView.CommonRunParameters();
            this.runLineView1 = new RobotView.RunLineView();
            this.runTurnView1 = new RobotView.RunTurnView();
            this.runArcView1 = new RobotView.RunArcView();
            this.SuspendLayout();
            // 
            // driveView1
            // 
            this.driveView1.Location = new System.Drawing.Point(3, 3);
            this.driveView1.Name = "driveView1";
            this.driveView1.Size = new System.Drawing.Size(292, 289);
            this.driveView1.TabIndex = 0;
            // 
            // commonRunParameters1
            // 
            this.commonRunParameters1.Acceleration = 0.3F;
            this.commonRunParameters1.Location = new System.Drawing.Point(3, 289);
            this.commonRunParameters1.Name = "commonRunParameters1";
            this.commonRunParameters1.Size = new System.Drawing.Size(410, 84);
            this.commonRunParameters1.Speed = 0.5F;
            this.commonRunParameters1.TabIndex = 1;
            this.commonRunParameters1.SpeedChanged += new System.EventHandler<System.EventArgs>(this.commonRunParameters1_SpeedChanged);
            this.commonRunParameters1.AccelerationChanged += new System.EventHandler<System.EventArgs>(this.commonRunParameters1_AccelerationChanged);
            // 
            // runLineView1
            // 
            this.runLineView1.Acceleration = 0F;
            this.runLineView1.Location = new System.Drawing.Point(301, 23);
            this.runLineView1.Name = "runLineView1";
            this.runLineView1.Size = new System.Drawing.Size(404, 56);
            this.runLineView1.Speed = 0F;
            this.runLineView1.TabIndex = 2;
            // 
            // runTurnView1
            // 
            this.runTurnView1.Acceleration = 0F;
            this.runTurnView1.Location = new System.Drawing.Point(302, 85);
            this.runTurnView1.Name = "runTurnView1";
            this.runTurnView1.Size = new System.Drawing.Size(403, 55);
            this.runTurnView1.Speed = 0F;
            this.runTurnView1.TabIndex = 3;
            // 
            // runArcView1
            // 
            this.runArcView1.Acceleration = 0F;
            this.runArcView1.Location = new System.Drawing.Point(301, 146);
            this.runArcView1.Name = "runArcView1";
            this.runArcView1.Size = new System.Drawing.Size(433, 107);
            this.runArcView1.Speed = 0F;
            this.runArcView1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(750, 381);
            this.Controls.Add(this.runArcView1);
            this.Controls.Add(this.runTurnView1);
            this.Controls.Add(this.runLineView1);
            this.Controls.Add(this.commonRunParameters1);
            this.Controls.Add(this.driveView1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private RobotView.DriveView driveView1;
        private RobotView.CommonRunParameters commonRunParameters1;
        private RobotView.RunLineView runLineView1;
        private RobotView.RunTurnView runTurnView1;
        private RobotView.RunArcView runArcView1;
    }
}

