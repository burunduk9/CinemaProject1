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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void Regbtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee()
            {
                FIO = txtFio.Text,
                phone = txtPhone.Text,
                id_role = Convert.ToInt32(txtPhone.Text),
                salary = 1000,
                login = txtLog.Text,
                password = txtPas.Text
            };
            App.Connection.Employee.Add(employee);
            App.Connection.SaveChanges();
            MessageBox.Show("авторизация прошла успешно", "", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void Returnbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
