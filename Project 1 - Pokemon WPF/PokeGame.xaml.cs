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

        public int left { get; set; }
        public int top { get; set; }
        public int count { get; set; }

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

            //string Query = "SELECT imageNR, Username FROM user_pokemon, pokemon, users WHERE pokemon.pokemons_ID = user_pokemon.pokemon_ID and user_pokemon.user_ID = '" + idLogged + "' and users.Username = '" + usernameLoggedSQL + "'";
            string Query = "SELECT imageNR FROM pokemon";

            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader dbr;
            con.Open();
            dbr = cmd.ExecuteReader();

            while (dbr.Read())
            {

                //MessageBox.Show("Dit is een test");
                //             int left = 0;
                List<Image> imageList = new List<Image>();
                int imgCount = 1;
                BitmapImage carBitmap = new BitmapImage(new Uri("pack://application:,,,/Images/Sprites3/" + dbr.GetInt32(0) + ".png", UriKind.Absolute));
                for (int i = 0; i < imgCount; i++)

                {
                    if (count % 10 == 0)
                    {
                        if (count != 0)
                        {

                            top += 175;
                            left = 0;

                        }
                        else
                        {
                            top = 0;
                            //                          left = 0;
                        }

                    }

                    // 1 min

                    Image img_ding = new Image();
                    img_ding.Source = carBitmap;
                    img_ding.Height = 150;
                    img_ding.Width = 150;
                    img_ding.Margin = new Thickness(left, top, 0, 0);
                    left += 175;
                    imageList.Add(img_ding);

                }



                foreach (Image img in imageList)
                {
                    imageCanvas.Children.Add(img);
                    left++;
                    count++;
                }
                }


            dbr.Close();

                string Query2 = "SELECT imageNR, Username FROM user_pokemon, pokemon, users WHERE pokemon.pokemons_ID = user_pokemon.pokemon_ID and user_pokemon.user_ID = '" + idLogged + "' and users.Username = '" + usernameLoggedSQL + "'";
                //string Query = "SELECT imageNR FROM pokemon";

                MySqlCommand cmd2 = new MySqlCommand(Query2, con);
                MySqlDataReader dbr2;
                //con.Open();
                dbr2 = cmd2.ExecuteReader();

                while (dbr2.Read())
                {

                    //MessageBox.Show("Dit is een test");
                    //             int left = 0;
                    List<Image> imageList2 = new List<Image>();
                    int imgCount2 = 1;
                    BitmapImage carBitmap2 = new BitmapImage(new Uri("pack://application:,,,/Images/Sprites2/" + dbr2.GetInt32(0) + ".png", UriKind.Absolute));
                    for (int i = 0; i < imgCount2; i++)

                    {
                        if (count % 10 == 0)
                        {
                            if (count != 0)
                            {

                                top += 175;
                                left = 0;

                            }
                            else
                            {
                                top = 0;
                                //                          left = 0;
                            }

                        }

                        // 1 min

                        Image img_ding2 = new Image();
                        img_ding2.Source = carBitmap2;
                        img_ding2.Height = 150;
                        img_ding2.Width = 150;
                        img_ding2.Margin = new Thickness(left, top, 0, 0);
                        left += 175;
                        imageList2.Add(img_ding2);

                    }


                    foreach (Image img in imageList2)
                    {
                        imageCanvas.Children.Add(img);
                        left++;
                        count++;
                    }
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

        private void ClickOwned_Click(object sender, RoutedEventArgs e)
        {

            string Query2 = "SELECT imageNR, Username FROM user_pokemon, pokemon, users WHERE pokemon.pokemons_ID = user_pokemon.pokemon_ID and user_pokemon.user_ID = '" + DataContainer.IDOfLoggedUser + "' and users.Username = '" + DataContainer.UsernameOfLoggedUser + "'";

            MySqlConnection con = new MySqlConnection(constring);
            MySqlCommand cmd2 = new MySqlCommand(Query2, con);
            MySqlDataReader dbr2;
            con.Open();
            dbr2 = cmd2.ExecuteReader();

            while (dbr2.Read())
            {

                //MessageBox.Show("Dit is een test");
                //             int left = 0;
                List<Image> imageList2 = new List<Image>();
                int imgCount2 = 1;
                BitmapImage carBitmap2 = new BitmapImage(new Uri("pack://application:,,,/Images/Sprites2/" + dbr2.GetInt32(0) + ".png", UriKind.Absolute));
                for (int i = 0; i < imgCount2; i++)

                {
                    if (count % 10 == 0)
                    {
                        if (count != 0)
                        {

                            top += 175;
                            left = 0;

                        }
                        else
                        {
                            top = 0;
                            //                          left = 0;
                        }

                    }

                    // 1 min

                    Image img_ding2 = new Image();
                    img_ding2.Source = carBitmap2;
                    img_ding2.Height = 150;
                    img_ding2.Width = 150;
                    img_ding2.Margin = new Thickness(left, top, 0, 0);
                    left += 175;
                    imageList2.Add(img_ding2);

                }


                foreach (Image img in imageList2)
                {
                    imageCanvas.Children.Add(img);
                    left++;
                    count++;
                }
            }
        }

        private void ClickAll_Click(object sender, RoutedEventArgs e)
        {

        }
           
    }
    }

//vragen:
//Hoe zorg ik ervoor dat scrollviewer volledig leeg is om er vervolgens opnieuw plaatjes in te zetten?
//ScrlVwr.Content = null;
//werkt helaas niet omdat dan niks meer getoont kan worden.

//Hoe kan ik ervoor zorgen dat de plaatjes die ik wel heb op de plek komen van het silhouette van de Pokémon? 

//afwezigheidchizzle
// 10/11-10-2016: Ziek thuis (2 maal tandarts met verdovingen)
// 28-10-2016: ziek thuis
