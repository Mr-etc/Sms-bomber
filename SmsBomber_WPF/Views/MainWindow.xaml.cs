using SmsBomber_WPF.Views;
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
using SmsBomber_WPF.Services;

namespace SmsBomber_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /*private Home home_Page = new Home();
        private Settings Settings_Page = new Settings();*/
        public MainWindow()
        {
            InitializeComponent();
            Pages.Content = SMS_Services.home_Page;
        }

        private void Choose_Page(object sender, MouseEventArgs e)
        {
            switch ((sender as Label).Content.ToString())
            {
                case "Main":
                    Pages.Content = SMS_Services.home_Page;
                    break;
                case "Settings":
                    Pages.Content = SMS_Services.Settings_Page;
                    break;
                case "About":
                    MessageBox.Show("We don't have this page!");
                    break;
            }
        }

        private void Close_Hide_btn(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Label).Content.ToString())
            {
                case "Close":
                    this.Close();
                    break;
                case "Hide":
                    this.WindowState = WindowState.Minimized;
                    break;
            }
        }

        private void Movement_form(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

    }
}
