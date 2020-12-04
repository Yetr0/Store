using DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ActionMovies.xaml
    /// </summary>
    public partial class ActionMovies : UserControl
    {
        public ActionMovies()
        {
            InitializeComponent();

            State.Actions = API.GetMoviesByGenre(State.Genres[0]);
            State.Genres.RemoveAt(0);
            title.Text = State.Actions[0].Genres[0].GenreName;
            for (int i = 0; i < State.Actions.Count; i++)
            {
                ColumnDefinition cd = new ColumnDefinition();
                cd.MaxWidth = 100;
                TheGrid1.ColumnDefinitions.Add(cd);
                var movie = State.Actions[i];
                var image = new Image() { };
                image.Cursor = Cursors.Hand;
                image.MouseUp += Image_MouseUp;
                image.HorizontalAlignment = HorizontalAlignment.Center;
                image.VerticalAlignment = VerticalAlignment.Center;
                image.Source = new BitmapImage(new Uri(movie.ImageURL));
                StackPanel.Children.Add(image);
                Grid.SetColumn(image, i);
            }
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);

            int i = x;

            State.Pick = State.Actions[i];
            var next_window = new MovieDetailsWindow();
            next_window.Show();
        }
    }
}
