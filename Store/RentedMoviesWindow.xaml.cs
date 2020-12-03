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
using Store.SubViews;

namespace Store
{
    /// <summary>
    /// Interaction logic for RentedMoviesWindow.xaml
    /// </summary>
    public partial class RentedMoviesWindow : Window
    {
        public RentedMoviesWindow()
        {

            /*RentedMoviesWindow rented = new RentedMoviesWindow();
            StackPanel.MouseWheel += rented.Scroller_MouseWheel ;*/

            //this.MouseWheel += Scroller_MouseWheel;

            InitializeComponent();
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

        /*public void Scroller_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var a = -1 * e.Delta;
            var offset = Scroller.VerticalOffset;
            Scroller.ScrollToHorizontalOffset(offset + a);
            MessageBox.Show("Working");
        }*/

    }
}
