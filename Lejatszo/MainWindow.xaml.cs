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
using System.IO;

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
        int jatsz = -1;
        int jatsze = 0;

        private void pl_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Items.Count != 0)
            {
                if (jatsze == 0)
                {
                    if (lista.SelectedIndex != -1)
                    {
                        string file = lista.Items[lista.SelectedIndex].ToString();
                        mediaPlayer.Open(new Uri(file));
                        mediaPlayer.Play();
                        jatsze = 2;
                        jatsz = Convert.ToInt32(lista.SelectedIndex);

    
                    }
                    else
                    {

                        lista.SelectedIndex = 0;
                        string file = lista.Items[0].ToString();
                        mediaPlayer.Open(new Uri(file));
                        mediaPlayer.Play();
                        jatsze = 2;
                        jatsz = 0;
                    }
                }
                else if (jatsze == 1)
                {
                    mediaPlayer.Play();
                    jatsze = 2;
                }
                else
                {
                    mediaPlayer.Pause();
                    jatsze = 1;
                }
            }
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "MP3 files (*.mp3)|*.mp3",
                Multiselect = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    if (!lista.Items.Contains(file))
                    {
                        lista.Items.Add(file);
                    }
                }
            }
        }

        private void t_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Items.Count == 0)
            {
                MessageBox.Show("Nincs mit törölni.", "Üres Lista", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (lista.SelectedIndex == -1)
                {
                    MessageBox.Show("Válaszd ki a törölni kívánt zenét.", "Zene Törlés", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (lista.SelectedIndex == jatsz)
                    {
                        lista.Items.Remove(lista.SelectedItem);
                        lista.SelectedIndex = -1;
                        mediaPlayer.Close();
                        jatsz = -1;
                        jatsze = 0;
                    }
                    else
                    {
                        if (lista.SelectedIndex > jatsz)
                        {
                            lista.Items.Remove(lista.SelectedItem);
                            lista.SelectedIndex = jatsz;
                        }
                        else
                        {
                            jatsz--;
                            lista.Items.Remove(lista.SelectedItem);
                            lista.SelectedIndex = jatsz;
                        }
                    }
                }
            }
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

        private void pr_Click(object sender, RoutedEventArgs e)
        {
            jatsz = jatsz - 1;
            lista.SelectedIndex = jatsz;
            string file = lista.Items[lista.SelectedIndex].ToString();
            mediaPlayer.Open(new Uri(file));
            mediaPlayer.Play();
            jatsze = 2;
        }

        private void lista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string file = lista.Items[lista.SelectedIndex].ToString();
            mediaPlayer.Open(new Uri(file));
            mediaPlayer.Play();
            jatsze = 2;
            jatsz = Convert.ToInt32(lista.SelectedIndex);
        }

        private void n_Click(object sender, RoutedEventArgs e)
        {
            jatsz++;
            lista.SelectedIndex = jatsz;
            string file = lista.Items[lista.SelectedIndex].ToString();
            mediaPlayer.Open(new Uri(file));
            mediaPlayer.Play();
            jatsze = 2;
        }
    }
}
