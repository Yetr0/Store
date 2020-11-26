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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            StackPanel.MouseWheel += Scroller_MouseWheel;
            Scroller.MouseWheel += Scroller_MouseWheel;
            this.MouseWheel += Scroller_MouseWheel;


            for (int i = 0; i < State.Rentals.Count; i++)
            {
                TheGrid.ColumnDefinitions.Add(new ColumnDefinition());
                var movie = State.Rentals[i];
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
        private void Scroller_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var a = -1 * e.Delta;
                var offset = Scroller.HorizontalOffset;
                Scroller.ScrollToHorizontalOffset(offset + a);
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);

            int i = x;

            State.Pick = State.Rentals[i];
            var next_window = new MovieDetailsWindow();
            next_window.Show();
        }
    }
}
