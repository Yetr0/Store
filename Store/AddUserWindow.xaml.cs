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

            //API hämta genres loopar och lägger dom i Genrebox listan
            // Sen i Addin_click lägg till för en användare
            String a = "anton";
            String b = "Banton";

            GenreBox.Items.Add(a);
            GenreBox.Items.Add(b);
        }
        private void AddIn_Click(object sender, RoutedEventArgs e)
          {
           

            State.User = API.GetCustomerByName(UserField.Text.Trim(), PWField.Password);

            if (State.User != null)
            {
                MessageBox.Show("Användaren finns redan");
            } else
            {

                API.AddCustomerByName(UserField.Text.Trim(), PWField.Password);
                //API.addemail/adress/phonenumber
                // API.AddGenre()
                var new_window = new LoginWindow();
                new_window.Show();
                this.Close();
            }

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var login_window = new LoginWindow();
            login_window.Show();
            this.Close();
        }

    }
}
