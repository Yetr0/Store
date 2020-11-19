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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }
        private void AddIn_Click(object sender, RoutedEventArgs e)
        {
            API.AddCustomerByName(UserField.Text.Trim(), PWField.Text);
            var new_window = new LoginWindow();
            new_window.Show();
            this.Close();
            //State.User = API.GetCustomerByName(UserField.Text.Trim(), PWField.Text);
            //if (State.User == null)
            //{

            //}
            //else
            //{
            //   MessageBox.Show("Användaren finns redan");
            //}

            //API.AddCustomerByName(UserField.Text.Trim(), PWField.Text); // ändra tillbaka sen  API.AddCustomerByName("Anton", "Berglund");
            // kolla ifall username redan finns, adda inte då.

            /* var new_window = new LoginWindow();
             new_window.Show();
             this.Close();
            */
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var login_window = new LoginWindow();
            login_window.Show();
            this.Close();
        }
    }
}
