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

            UsernameBlock.Text = UsernameBlock.Text + State.User.Name;
            AddressBlock.Text  = AddressBlock.Text + State.User.Address;
            EmailBlock.Text    = EmailBlock.Text + State.User.Email;
            PhoneBlock.Text    = PhoneBlock.Text + State.User.PhoneNumber;


            //Genre favgenre = new Genre();
            //favgenre = State.User.favoriteGenre;
            //GenreBlock.Text = GenreBlock.Text + ": " + favgenre.GenreName;

            //var favgenre = API.getGenre(State.User.favoriteGenre.GenreName);
            //GenreBlock.Text = GenreBlock.Text + ": " + favgenre.GenreName;

            //API.GetFavoriteGenre(State.User.favoriteGenre.GenreName);

            //State.Favorite = API.getGenre("Comedy");

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
