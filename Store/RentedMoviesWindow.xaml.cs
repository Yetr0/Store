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
    /// Interaction logic for RentedMoviesWindow.xaml
    /// </summary>
    public partial class RentedMoviesWindow : Window
    {
        public RentedMoviesWindow()
        {
            InitializeComponent();
            State.Rentals = API.GetRentedMovies(State.User);

            for (int y = 1; y < MovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = (y - 1) * MovieGrid.ColumnDefinitions.Count + x;
                    if (i < State.Rentals.Count)
                    {
                        var movie = State.Rentals[i];

                        try
                        {
                            var image = new Image() { };
                            image.Cursor = Cursors.Hand;
                            image.MouseUp += Image_MouseUp;
                            image.HorizontalAlignment = HorizontalAlignment.Center;
                            image.VerticalAlignment = VerticalAlignment.Center;
                            image.Source = new BitmapImage(new Uri(movie.ImageURL));
                            //image.Height = 120;
                            image.Margin = new Thickness(4, 4, 4, 4);

                            MovieGrid.Children.Add(image);
                            Grid.SetRow(image, y);
                            Grid.SetColumn(image, x);
                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            continue;
                        }
                    }
                }
            }
    }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement) - 1;

            int i = y * MovieGrid.ColumnDefinitions.Count + x;

            State.Pick = State.Rentals[i];
            var next_window = new MovieDetailsWindow();
            next_window.Show();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new AccountWindow();
            next_window.Show();
        }
    }
}
