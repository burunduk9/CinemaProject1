using System;
using CinemaProject.ADOApp;
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
    /// Логика взаимодействия для ShowClientPage.xaml
    /// </summary>
    public partial class ShowClientPage : Page
    {
        public ShowClientPage()
        {
            InitializeComponent();
            ListClient.ItemsSource = App.Connection.Client.ToList();
        }
        private void ReductClientbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new PageApp.ReductClientPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
