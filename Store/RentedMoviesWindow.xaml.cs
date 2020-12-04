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
            List<int> ints = new List<int>();
            while (ints.Count <= 3)
            {
                Random rnd = new Random();
                var num = rnd.Next(1, 12);
                if (!ints.Contains(num))
                {
                    ints.Add(num);
                }
            }
            State.Genres = ints;
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

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            var next_window = new AccountWindow();
            next_window.Show();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home.Visibility = Visibility.Hidden;
            Movies.Visibility = Visibility.Visible;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Home.Visibility = Visibility.Visible;
            Movies.Visibility = Visibility.Hidden;
        }

    }
}
