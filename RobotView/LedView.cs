using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class LedView : UserControl
    {
        public bool State { get; set; } = false;

        public LedView()
        {
            InitializeComponent();
        }
    }
}