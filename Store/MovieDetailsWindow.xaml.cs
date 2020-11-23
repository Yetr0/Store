using DatabaseConnection;
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
            var movie = State.Pick;
            if (State.Rentals.Contains(movie))
            {
                MainButton.Content = "Watch";
                Price.Text = "Owned movie";
            }
            else if (!State.Rentals.Contains(State.Pick))
            {
                MainButton.Content = "Rent";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            API.RegisterSale(State.User, State.Pick);
            State.Rentals.Add(State.Pick);
            MessageBox.Show("Successfully rented movie");
            MainButton.Content = "Watch";
            Price.Text = "Owned movie";
        }
    }
}
