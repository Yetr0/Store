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

            this.Close();
            
        }
    }
}
