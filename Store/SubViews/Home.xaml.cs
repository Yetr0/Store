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
using Store.SubViews;

namespace Store.SubViews
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
            this.MouseWheel += Scroller_MouseWheel;
            if (State.Rentals.Count > 0)
            {
                RowDefinition rd = new RowDefinition();
                rd.MaxHeight = 150;
                grid.RowDefinitions.Add(rd);
                var rented = new RentedMovies();
                grid.Children.Add(rented);
                Grid.SetRow(rented, 0);
            }

            int i = 1;

            while (State.Genres.Count > 0)
            {
                    RowDefinition rd = new RowDefinition();
                    rd.MaxHeight = 140;
                    grid.RowDefinitions.Add(rd);
                    var action = new ActionMovies();
                    grid.Children.Add(action);
                    Grid.SetRow(action, i);
                    i++;
            }

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);

            int i = x;

            State.Pick = State.Rentals[i];
            var next_window = new MovieDetailsWindow();
            next_window.Show();
        }
        public void Scroller_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var a = -1 * e.Delta;
            var offset = Scroller.VerticalOffset;
            Scroller.ScrollToHorizontalOffset(offset + a);
            MessageBox.Show("Working");
        }
    }
}
