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
        
        public PokeGame(string userLoggedName, double userLogged)
            //userLoggedName = the name that comes from login screen
            //userLogged should be "1". Stating that there's a user logged in. To log out we can change this back to "0".
        {
            InitializeComponent();
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\joost\Documents\visual studio 2015\Projects\Project 1 - Pokemon WPF\Afbeeldingen\PokeGame_background.png")));
            lbl_welkom.Content = "Welkom, " + userLoggedName;
            
        }
    }
}
