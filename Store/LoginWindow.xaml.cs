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
using DatabaseConnection;

namespace Store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            Button b = new Button();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            State.User = API.GetCustomerByName(NameField.Text.Trim(), PasswordField.Password);
            if (State.User != null)
            {
                var next_window = new RentedMoviesWindow();
                next_window.Show();
                State.Rentals = API.GetRentedMovies(State.User);
                this.Close();
            }
            // Finns flera användare med samma username, password fast olika IDs, vem loggar in?(man är inte inloggad?)
            else
            {
                NameField.Text = "";
                PasswordField.Clear();
                MessageBox.Show("Wrong password or username");
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var new_window = new AddUserWindow();
            new_window.Show();
            this.Close();
        }
    }
}
