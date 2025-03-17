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
    /// Логика взаимодействия для ReductClientPage.xaml
    /// </summary>
    public partial class ReductClientPage : Page
    {
        public ReductClientPage()
        {
            InitializeComponent();
            this.DataContext = App.Connection.Client.Where(u => u.ID == ClassApp.ClassClient.CorrClient.ID).FirstOrDefault();
        }

        private void Returnbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Connection.SaveChanges();
        }
    }
}
