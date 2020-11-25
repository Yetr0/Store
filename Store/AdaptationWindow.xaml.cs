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
    /// Interaction logic for AdaptationWindow.xaml
    /// </summary>
    public partial class AdaptationWindow : Window
    {
        public AdaptationWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            API.setNewUserTrue(State.User);
            var next_window = new MainWindow();
            next_window.Show();
            this.Close();

        }
    }
}
