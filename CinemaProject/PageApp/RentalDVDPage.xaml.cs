using CinemaProject.ADOApp;
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
    /// Логика взаимодействия для RentalDVDPage.xaml
    /// </summary>
    public partial class RentalDVDPage : Page
    {
        public RentalDVDPage()
        {
            InitializeComponent();
        }
        private void AddRentalbtn_Click(object sender, RoutedEventArgs e)
        {
            Rental rental = new Rental()
            {
                date_of_issue = Convert.ToDateTime(txtDate_of_issue.Text),
                id_client = Convert.ToInt32(txtClient.Text),
                id_employee = Convert.ToInt32(txtEmployee.Text),
                date_of_delivery = Convert.ToDateTime(txtDate_of_return.Text),
            };
            App.Connection.Rental.Add(rental);
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
