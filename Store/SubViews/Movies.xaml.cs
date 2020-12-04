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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store.SubViews
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : UserControl
    {
        public Movies()
        {
            InitializeComponent();

            // USER.ID ska ha en egen rent lista.
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

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
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;

            State.Pick = State.Movies[i];
            var next_window = new MovieDetailsWindow();
            next_window.Show();
        }
    }
}
