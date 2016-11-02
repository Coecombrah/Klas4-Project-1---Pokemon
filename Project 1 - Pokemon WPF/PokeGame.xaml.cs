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
using System.Data.SqlClient;
using System.Data;

namespace Project_1___Pokemon_WPF
{
    /// <summary>
    /// Interaction logic for PokeGame.xaml
    /// </summary>
    public partial class PokeGame : Window
    {

        string constring = "datasource=127.0.0.1; port=3307;Initial Catalog='pokemon_DB'; username=root; password=usbw;";

        public PokeGame(string userLoggedName, double userLogged, string usernameLoggedSQL, int idLogged)
        //userLoggedName = the name that comes from login screen
        //userLogged should be "1". Stating that there's a user logged in. To log out we can change this back to "0".
        {

            InitializeComponent();

            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/PokeGame_background.png")));
            lbl_welkom.Content = "Welcome, " + usernameLoggedSQL + " je ID is: " + idLogged; //Left upper corner shows welcome, <name> to see who's logged in.
            if (userLogged == 1)
            {
                lbl_ingelogd.Content = "Successfully logged in";
            }
            else
            {
                lbl_ingelogd.Content = "Not logged in";
            }

            string Query = "SELECT imageNR, Username FROM user_pokemon, pokemon, users WHERE pokemon.pokemons_ID = user_pokemon.pokemon_ID and user_pokemon.user_ID = 15 and users.Username = '12345678'";
            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader dbr;
            con.Open();
            dbr = cmd.ExecuteReader();

            int count = 0;
            while (dbr.Read())
            {

                MessageBox.Show("Dit is een test");
                int left = 0;
                int top = 0;
                List<Image> imageList = new List<Image>();
                int imgCount = 100;
                for (int i = 0; i < imgCount; i++)
                {
                    if (i % 10 == 0)
                    {
                        if (i != 0)
                        {
                            
                            top += 175;
                            left = 0;
                        }
                        else
                        {
                            top = 0;
                            left = 0;
                        }
                    }
                    BitmapImage carBitmap = new BitmapImage(new Uri("pack://application:,,,/Images/Sprites2/" + dbr.GetInt16(0) + ".png", UriKind.Absolute));

                    Image img_ding = new Image();
                    img_ding.Source = carBitmap;
                    img_ding.Height = 150;
                    img_ding.Width = 150;
                    img_ding.Margin = new Thickness(left, top, 0, 0);
                    imageList.Add(img_ding);
                    left += 175;
                }

                int j = 0;

                foreach (Image img in imageList)
                {
                    imageCanvas.Children.Add(img);
                    j++;
                }

                count++;

                /*
                
                while (dbr.Read())
                {
                    MessageBox.Show("Dit is een test");
                    int left = 0;
                    int top = 0;
                    List<Image> imageList = new List<Image>();
                    int imgCount = 1;
                    for (int i = 0; i < imgCount; i++)
                    {
                        string img = i.ToString().PadLeft(3, '0');
                        BitmapImage carBitmap = new BitmapImage(new Uri("pack://application:,,,/Images/Sprites2/" + "5" + ".png", UriKind.Absolute));

                        if (i % 10 == 0)
                        {
                            if (i != 0)
                            {
                                top += 175;
                                left = 0;
                            }
                            else
                            {
                                top = 0;
                                left = 0;
                            }
                        }
                        Image img_ding = new Image();
                        img_ding.Source = carBitmap;
                        img_ding.Height = 150;
                        img_ding.Width = 150;
                        img_ding.Margin = new Thickness(left, top, 0, 0);
                        imageList.Add(img_ding);
                        left += 175;
                    } 

                    int j = 0;

                foreach (Image img in imageList)
                {
                    imageCanvas.Children.Add(img);
                    j++;
                }

                count++;
            } */
            }
        }

        public void MenuItem_Click_LogOff(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow MainWindowForm = new MainWindow();
            MainWindowForm.Show();  
        }

        private void MenuItem_Click_Retro(object sender, RoutedEventArgs e)
        {
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/PokeGame_Background_Retro.jpg")));
            lbl_ingelogd.Foreground = new SolidColorBrush(Colors.Yellow);
            lbl_welkom.Foreground = new SolidColorBrush(Colors.Yellow);
            menu.Background = new SolidColorBrush(Colors.Yellow);
            menu2.Background = new SolidColorBrush(Colors.Yellow);
            menu3.Background = new SolidColorBrush(Colors.Yellow);
            menu4.Background = new SolidColorBrush(Colors.Yellow);
            menu5.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void MenuItem_Click_Black(object sender, RoutedEventArgs e)
        {
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/PokeGame_Background_Black.jpg")));
            lbl_ingelogd.Foreground = new SolidColorBrush(Colors.Red);
            lbl_welkom.Foreground = new SolidColorBrush(Colors.Red);
            menu.Background = new SolidColorBrush(Colors.Red);
            menu2.Background = new SolidColorBrush(Colors.Red);
            menu3.Background = new SolidColorBrush(Colors.Red);
            menu4.Background = new SolidColorBrush(Colors.Red);
            menu5.Background = new SolidColorBrush(Colors.Red);
        }

        private void MenuItem_Click_Default(object sender, RoutedEventArgs e)
        {
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Backgrounds/PokeGame_background.png")));
            lbl_ingelogd.Foreground = new SolidColorBrush(Colors.White);
            lbl_welkom.Foreground = new SolidColorBrush(Colors.White);
            menu.Background = new SolidColorBrush(Colors.White);
            menu2.Background = new SolidColorBrush(Colors.White);
            menu3.Background = new SolidColorBrush(Colors.White);
            menu4.Background = new SolidColorBrush(Colors.White);
            menu5.Background = new SolidColorBrush(Colors.White);
        }
    }
}


//afwezigheidchizzle
// 10/11-10-2016: Ziek thuis (2 maal tandarts met verdovingen)
// 28-10-2016: ziek thuis
                         