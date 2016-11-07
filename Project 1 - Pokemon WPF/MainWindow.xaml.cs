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
using System.Data.SqlClient;
using System.Data;

namespace Project_1___Pokemon_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    

    public partial class MainWindow : Window
    {
        public static string userLoggedName { get; set; }
        public double userLogged { get; set; }
        public string usernameLogged { get; set; }
        public static int idLogged { get; set; }

        string constring = "datasource=127.0.0.1; port=3307; username=root; password=usbw;";
        public MainWindow()
        {
            //When logged in we can check if the userLogged = 1 (0 by default) and we can check the name to see who's logged in.
            userLoggedName = "";
            userLogged = 0;
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/Inlog.jpg")));

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
            screen_register.Height = 320;
            txt_username_login.Height = 0;
            txt_password_login.Height = 0;
            txt_username.Height = 44;
            txt_password.Height = 44;
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

        public void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if(txt_password_login.Text == "123456789" || txt_password_login.Text == "123456789")
            {
                MessageBox.Show("Offline ingelogd. Gebruik deze gegevens natuurlijk niet als je verbinding wilt maken met de database.");
                userLoggedName = txt_username_login.Text;
                userLogged = 1;
                this.Hide();
                PokeGame PokeGameForm = new PokeGame(userLoggedName, userLogged, usernameLogged, idLogged);
                PokeGameForm.Show();
            }
            else {

            
            try
            {
                if (txt_password_login.Text.Length > 7 || txt_password_login.Text.Length > 7)
                {
                        string Query = "SELECT * FROM pokemon_db.users where Username = '" + txt_username_login.Text + "'and Password = '" + txt_password_login.Text + "'";
                        MySqlConnection con = new MySqlConnection(constring);
                        MySqlCommand cmd = new MySqlCommand(Query, con);
                        MySqlDataReader dbr;
                        con.Open();
                        dbr = cmd.ExecuteReader();
                        int count = 0;
                        while (dbr.Read())
                        {
                            count = count + 1;
                        }



                        if (count == 1)
                        {
                            dbr.Close();
                            dbr.Dispose();
                            string UserQuery = "SELECT Username, users_ID FROM users WHERE users.username = '" + txt_password_login.Text + "'";
                            MySqlDataReader Userdbr;
                            Userdbr = cmd.ExecuteReader();
                            while (Userdbr.Read())
                            {
                                int Usercount = 1;
                                while ((Usercount == 1)) { 
                                    usernameLogged = Userdbr.GetString("Username");
                                    idLogged = Userdbr.GetInt16("users_ID");
                                    DataContainer.IDOfLoggedUser = Userdbr.GetInt16("users_ID");
                                    Usercount++;
                                }
                            }


                            
                            userLoggedName = txt_username_login.Text;
                            userLogged = 1;
                            this.Hide();
                            PokeGame PokeGameForm = new PokeGame(userLoggedName, userLogged, usernameLogged, idLogged);
                            PokeGameForm.Show();
                            DataContainer.UsernameOfLoggedUser = txt_username_login.Text;

                        }
                    else
                    {
                        MessageBox.Show("Deze gegevens zijn ghelaas onjuist mienier");
                    } 
                }

                else
                {
                    MessageBox.Show("Vul bij gebruikersnaam en wachtwoord wel 8 tekens in.");
                }


            
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }
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

        private void txt_username_login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
