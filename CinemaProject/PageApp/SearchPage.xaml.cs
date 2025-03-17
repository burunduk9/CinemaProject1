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

namespace CinemaProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            ListClient.ItemsSource = App.Connection.Client.ToList();
        }
        private void Searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListClient.ItemsSource = App.Connection.Client.Where(u => u.FIO.ToLower().Contains(Searchtxt.Text.ToLower())).ToList();
            if(Searchtxt.Text == "")
            {
                ListClient.ItemsSource = App.Connection.Client.ToList();
            }
        }
    }
}
