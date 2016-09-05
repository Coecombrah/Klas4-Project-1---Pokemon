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
        }

        private void button_Click(object sender, RoutedEventArgs e)
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
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
