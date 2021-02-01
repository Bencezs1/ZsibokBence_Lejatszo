using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Lejatszo
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
        MediaPlayer mediaPlayer = new MediaPlayer();
        string filename;

        private void pl_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void p_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void s_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void be_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog
            {
                Multiselect = true,
                DefaultExt = ".mp3"

            };
            bool? dialogOk = filedialog.ShowDialog();
            if (dialogOk==true)
            {
                filename = filedialog.FileName;
                lista.Items.Add(filename);
                mediaPlayer.Open(new Uri(filename));
            }
        }

        private void t_Click(object sender, RoutedEventArgs e)
        {
            lista.Items.Clear();
        }

        void timer_Tick(object Sender, EventArgs e)
        {
            csuszka.Value = mediaPlayer.Position.TotalSeconds;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan ts = new TimeSpan();
            mediaPlayer.Position = ts;
        }

        private void hang_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = (double)hang.Value;
        }
    }
}
