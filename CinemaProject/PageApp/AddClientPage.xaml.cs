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
using System.Xml.Linq;

namespace CinemaProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
        }

        private void AddClientbtn_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                FIO = txtFio.Text,
                phone = txtPhone.Text
            };
            App.Connection.Client.Add(client);
            App.Connection.SaveChanges();
            MessageBox.Show("добавление прошло успешно", "", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void Returnbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
