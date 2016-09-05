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
            Register register_form = new Register();
            register_form.Show();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
