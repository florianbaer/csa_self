using RobotCtrl;
using RobotView;

namespace TestMotor
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
            this.driveCtrlView1 = new RobotView.DriveCtrlView();
            this.motorCtrlView1 = new RobotView.MotorCtrlView();
            this.motorCtrlView2 = new RobotView.MotorCtrlView();
            this.SuspendLayout();
            // 
            // driveCtrlView1
            // 
            this.driveCtrlView1.DriveCtrl = null;
            this.driveCtrlView1.Location = new System.Drawing.Point(3, 3);
            this.driveCtrlView1.Name = "driveCtrlView1";
            this.driveCtrlView1.Size = new System.Drawing.Size(480, 93);
            this.driveCtrlView1.TabIndex = 0;
            // 
            // motorCtrlView1
            // 
            this.motorCtrlView1.Location = new System.Drawing.Point(3, 67);
            this.motorCtrlView1.MotorCtrl = null;
            this.motorCtrlView1.Name = "motorCtrlView1";
            this.motorCtrlView1.Size = new System.Drawing.Size(480, 330);
            this.motorCtrlView1.TabIndex = 1;
            // 
            // motorCtrlView2
            // 
            this.motorCtrlView2.Location = new System.Drawing.Point(487, 67);
            this.motorCtrlView2.MotorCtrl = null;
            this.motorCtrlView2.Name = "motorCtrlView2";
            this.motorCtrlView2.Size = new System.Drawing.Size(480, 330);
            this.motorCtrlView2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(970, 455);
            this.Controls.Add(this.motorCtrlView2);
            this.Controls.Add(this.motorCtrlView1);
            this.Controls.Add(this.driveCtrlView1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DriveCtrlView driveCtrlView1;
        private MotorCtrlView motorCtrlView1;
        private MotorCtrlView motorCtrlView2;
    }
}

