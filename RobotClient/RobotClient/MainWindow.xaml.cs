using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RobotClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunStreight(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("TrackLine ");

            if (!float.TryParse(this.LineWidthBox.Text, out float width))
            {
                MessageBox.Show("invalid data");
                return;
            }

            builder.Append(width);

            SendAndGiveFeedback(builder.ToString());
        }
        private void TurnAround(object sender, RoutedEventArgs e)
        {

            StringBuilder builder = new StringBuilder();
            if (this.TurnAroundLeft.IsEnabled && this.TurnAroundRight.IsEnabled)
            {
                MessageBox.Show("Please define a valid turn value");
                return;
            }

            string turnValue = string.Empty;

            if (this.TurnAroundLeft.IsEnabled)
            {
                builder.Append("TrackTurnLeft ");
                turnValue = this.TurnAroundLeft.Text;
            }
            else
            {
                builder.Append("TrackTurnRight ");
                turnValue = this.TurnAroundRight.Text;
            }

            if(!int.TryParse(turnValue, out int turnAngle))
            {
                MessageBox.Show("invalid data");
                return;
            }

            builder.Append(turnAngle);

            SendAndGiveFeedback(builder.ToString());
        }
        private void TurnLeftArc(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("TrackArcLeft ");

            if (!int.TryParse(this.TurnLeftAngle.Text, out int angle))
            {
                MessageBox.Show("invalid data");
                return;
            }

            if (!float.TryParse(this.TurnLeftRadius.Text, out float radius))
            {
                MessageBox.Show("invalid data");
                return;
            }

            builder.Append(angle);
            builder.Append(" ");
            builder.Append(radius);

            SendAndGiveFeedback(builder.ToString());
        }
        private void TurnRightArc(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("TrackArcRight ");
            if (!int.TryParse(this.TurnRightAngle.Text, out int angle))
            {
                MessageBox.Show("invalid data");
                return;
            }

            if (!float.TryParse(this.TurnRightRadius.Text, out float radius))
            {
                MessageBox.Show("invalid data");
                return;
            }

            builder.Append(angle);
            builder.Append(" ");
            builder.Append(radius);

            SendAndGiveFeedback(builder.ToString());
        }

        private void SendAndGiveFeedback(string message)
        {
            TcpClient client = new TcpClient();
            client.Connect(new IPEndPoint(IPAddress.Parse("192.168.1.21"), 1819));
            NetworkStream stream = client.GetStream();
            var bytemsg = new ASCIIEncoding().GetBytes(message);
            stream.Write(bytemsg, 0, bytemsg.Length);
            client.Client.Close();
            MessageBox.Show("Send successful", message);
        }

        private void TurnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.TurnAroundLeft.Text))
            {
                this.TurnAroundRight.IsEnabled = true;
            }
            else
            {
                this.TurnAroundRight.IsEnabled = false;
            }

            if (String.IsNullOrWhiteSpace(this.TurnAroundRight.Text))
            {
                this.TurnAroundLeft.IsEnabled = true;
            }
            else
            {
                this.TurnAroundLeft.IsEnabled = false;
            }
        }

        private void Go(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Start");
            SendAndGiveFeedback(builder.ToString());
        }
    }
}
