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
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        public AccountWindow()
        {
            InitializeComponent();
            Genre favgenre = API.GetGenre(State.User);
            List<Genre> genres = new List<Genre>();
            genres = API.GetGenreList();

            //API hämta genres loopar och lägger dom i Genrebox listan
            // Sen i Addin_click lägg till för en användare
            for (int i = 0; i < genres.Count; i++)
            {
                GenreBox.Items.Add(genres[i].GenreName);
            }



            ComboChange.Items.Add(UsernameBlock.Text);
            ComboChange.Items.Add(AddressBlock.Text);
            ComboChange.Items.Add(EmailBlock.Text);
            ComboChange.Items.Add(PhoneBlock.Text);
            ComboChange.Items.Add(GenreBlock.Text);

            GenreBlock.Text = GenreBlock.Text + ": " + favgenre.GenreName;
            UsernameBlock.Text = UsernameBlock.Text + ": " + State.User.Name;
            AddressBlock.Text = AddressBlock.Text + ": " + State.User.Address;
            EmailBlock.Text = EmailBlock.Text + ": " + State.User.Email;
            PhoneBlock.Text = PhoneBlock.Text + ": " + State.User.PhoneNumber;





        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ComboChange.SelectedItem.Equals("Username"))
                {
                API.UpdateUsername(State.User, State.User.Name, ChangeBox.Text);
                State.User.Name = ChangeBox.Text;
            }
            else if(ComboChange.SelectedItem.Equals("Address"))
            {
                API.UpdateAddress(State.User, State.User.Address, ChangeBox.Text);
                State.User.Address = ChangeBox.Text;
            }
            else if (ComboChange.SelectedItem.Equals("Email"))
            {
                API.UpdateAddress(State.User, State.User.Email, ChangeBox.Text);
                State.User.Email = ChangeBox.Text;
            }
            else if (ComboChange.SelectedItem.Equals("Phone number"))
            {
                int intnumber = Convert.ToInt32(ChangeBox.Text);
                API.UpdatePnumber(State.User, State.User.PhoneNumber, intnumber);
                State.User.PhoneNumber = intnumber;
            }
            else if (ComboChange.SelectedItem.Equals("Favorite genre"))
            {
                String choosenGenre = GenreBox.SelectedItem.ToString();
                API.SetFavoriteGenre(State.User, choosenGenre);
                State.User.favoriteGenre.GenreName = choosenGenre;
                //Måste starta om för att se skillnaden
            }

            this.Close();
            
        }
    }
}
