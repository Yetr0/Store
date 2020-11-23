using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for MovieDetailsWindow.xaml
    /// </summary>
    public partial class MovieDetailsWindow : Window
    {
        public MovieDetailsWindow()
        {
            InitializeComponent();
            Title.Text = State.Pick.Title;
            Uri uri = new Uri(State.Pick.ImageURL, UriKind.Absolute);
            ImageSource imageSource = new BitmapImage(uri);
            Image.Source = imageSource;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new MainWindow();
            next_window.Show();
            this.Close();
        }
    }
}
