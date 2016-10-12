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

namespace Project_1___Pokemon_WPF
{
    /// <summary>
    /// Interaction logic for PokeGame.xaml
    /// </summary>
    public partial class PokeGame : Window
    {
        BitmapImage carBitmap = new BitmapImage(new Uri("pack://application:,,,/Images/download.png", UriKind.Absolute));
        Image[] carImg = new Image[5];
        Random rnd = new Random();

        public PokeGame(string userLoggedName, double userLogged)
            //userLoggedName = the name that comes from login screen
            //userLogged should be "1". Stating that there's a user logged in. To log out we can change this back to "0".

            
        {

            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\joost\Documents\visual studio 2015\Projects\Project 1 - Pokemon WPF\Afbeeldingen\PokeGame_background.png")));
            lbl_welkom.Content = "Welcome, " + userLoggedName; //Left upper corner shows welcome, <name> to see who's logged in.
            if (userLogged == 1) {
                lbl_ingelogd.Content = "Successfully logged in";
            } else {
                lbl_ingelogd.Content = "Not logged in";
            }


            double maxX = canvas1.Width - carBitmap.Width;
            double maxY = canvas1.Height - carBitmap.Height;
            for (int i = 0; i < carImg.Length; i++)
            {
                carImg[i] = new Image();
                carImg[i].Source = carBitmap;
                carImg[i].Width = carBitmap.Width;
                carImg[i].Height = carBitmap.Height;
                Canvas.SetLeft(carImg[i], rnd.NextDouble() * maxX);
                Canvas.SetTop(carImg[i], rnd.NextDouble() * maxY);
                canvas1.Children.Add(carImg[i]);
            }


        }
        
        public void MenuItem_Click_LogOff(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow MainWindowForm = new MainWindow();
            MainWindowForm.Show();  
        }

    }
}


// 5-10-2016: Ziek thuis
// 10/11-10-2016: Ziek thuis (2 maal tandarts met verdovingen)