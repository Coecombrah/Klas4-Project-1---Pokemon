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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Project_1___Pokemon_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\joost\Documents\visual studio 2015\Projects\Project 1 - Pokemon WPF\Afbeeldingen\inlog.jpg")));

            //All components that needs to be hidden at start up.
            screen_register.Height = 0;
            btn_registerscreen_back.Height = 0;
            btn_registerscreen_register.Height = 0;
            txt_mail.Height = 0;
            txt_username.Height = 0;
            txt_password.Height = 0;
        }

        private void txt_username_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_username.Clear();
        }

        private void txt_password_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_password.Clear();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            //Register register_form = new Register(); (show form 2: Register.xaml. Isn't needed anymore as we do that in this code by showing/hiding components)
            //register_form.Show();

            txt_username_login.Height = 44;
            txt_password_login.Height = 44;
            txt_username.Height = 0;
            txt_password.Height = 0;
            screen_login.Height = 0;
            btn_registerscreen_register.Height = 50;
            btn_registerscreen_back.Height = 50;
            btn_register.Height = 0;
            btn_login.Height = 0;
            btn_register.Height = 0;
            btn_login.Height = 0;
            btn_forgotPassword.Height = 0;
            txt_mail.Height = 44;
            txt_username.Text = "Username";
            txt_password.Text = "Password";
            txt_mail.Text = "Mail";
            screen_register.Height = 320;

        }

        private void btn_registerscreen_back_Click(object sender, RoutedEventArgs e)
        {
            screen_register.Height = 0;
            screen_login.Height = 250;
            btn_registerscreen_register.Height = 0;
            btn_registerscreen_back.Height = 0;
            btn_register.Height = 50;
            btn_login.Height = 50;
            btn_forgotPassword.Height = 50;
            txt_username_login.Text = "Username";
            txt_password_login.Text = "Password";
            txt_password_login.Height = 44;
            txt_username_login.Height = 44;
            txt_username.Height = 0;
            txt_password.Height = 0;
            txt_mail.Height = 0;
        }
        private void btn_registerscreen_register_Click(object sender, RoutedEventArgs e)
        {
            if (txt_username.Text.Length > 7 || txt_password.Text.Length > 7)
            {
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

                        screen_register.Height = 0;
                        screen_register.Width = 0;
                        screen_login.Height = 250;
                        btn_registerscreen_register.Height = 0;
                        btn_registerscreen_back.Height = 0;
                        btn_register.Height = 50;
                        btn_login.Height = 50;
                        btn_forgotPassword.Height = 50;
                        txt_mail.Height = 0;
                        txt_username.Text = "Username";
                        txt_password.Text = "Password";

                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vergeet natuurlijk niet je eigen gegevens te verzinnen.");
                }
            }
            else
            {
                MessageBox.Show("Vul bij zowel gebruikersnaam als wachtwoord minimaal 8 tekens in.");
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (txt_username_login.Text.Length > 7 || txt_password_login.Text.Length > 7)
            {
                if (txt_username_login.Text != "Username" || txt_password_login.Text != "Password")
                {
                    string constring = "datasource=127.0.0.1; port=3307; username=root; password=usbw;";
                    string Query = "SELECT * FROM pokemon_db.users WHERE Username='" + txt_username_login.Text + "' AND Password='" + txt_password_login.Text + "') ; ";
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
                }
                else
                {
                    MessageBox.Show("Misschien is het handig daadwerkelijk je eigen gegevens in te vullen.");
                }
            }
            else
            {
                MessageBox.Show("Vul bij zowel gebruikersnaam als wachtwoord minimaal 8 tekens in.");
            }
        
            }

        private void txt_mail_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_mail.Clear();
        }

        private void txt_username_login_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_username_login.Clear();
        }

        private void txt_password_login_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_password_login.Clear();
        }
    }
}
