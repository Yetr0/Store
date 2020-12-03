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

            List<Genre> genres = new List<Genre>();
            genres = API.GetGenreList();

            //API hämta genres loopar och lägger dom i Genrebox listan
            // Sen i Addin_click lägg till för en användare
            for (int i = 0; i < genres.Count; i++)
            {
                GenreBox.Items.Add(genres[i].GenreName);
            }

        }
        private void AddIn_Click(object sender, RoutedEventArgs e)
          {
           

            State.User = API.GetCustomerByName(UserField.Text.Trim(), PWField.Password);

            if (State.User != null)
            {
                MessageBox.Show("Användaren finns redan");
            } else
            {
                int phonenummer = Convert.ToInt32(PField.Text.Trim());
                API.AddCustomer(UserField.Text.Trim(), PWField.Password,
                                AddressField.Text.Trim(), EmailField.Text.Trim(), phonenummer);

                State.User = API.GetCustomerByName(UserField.Text.Trim(), PWField.Password);

                String choosenGenre = GenreBox.SelectedItem.ToString();
                API.SetFavoriteGenre(State.User, choosenGenre);
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
