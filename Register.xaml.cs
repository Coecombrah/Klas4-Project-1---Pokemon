using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Project_1___Pokemon_WPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\joost\Documents\visual studio 2015\Projects\Project 1 - Pokemon WPF\Afbeeldingen\register.jpg")));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_username.Text.Length > 7 || txt_password.Text.Length > 8) {
                if (txt_username.Text != "Username" || txt_password.Text != "Password")
                {
                    string constring = "datasource=127.0.0.1; port=3307; username=root; password=usbw;";
                    string Query = "INSERT INTO pokemon_db.users(Username, Password, Mail)VALUES('" + txt_username.Text + "','" + txt_password.Text + "','" + txt_mail.Text + "') ; ";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {

                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();
                        MessageBox.Show("Gebruiker aangemaakt!");
                        txt_password.Clear();
                        txt_username.Clear();
                        txt_mail.Clear();
                        while (myReader.Read())
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } else
                {
                    MessageBox.Show("Vergeet natuurlijk niet je eigen gegevens te verzinnen.");
                }
            } else
            {
                MessageBox.Show("Vul bij zowel gebruikersnaam als wachtwoord minimaal 8 tekens in.");
            }

        }

        private void txt_username_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_username.Clear();
        }

        private void txt_password_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_password.Clear();
        }

        private void txt_mail_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_mail.Clear();
        }

        private void btn_registerscreen_register_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
