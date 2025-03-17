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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        public AutoPage()
        {
            InitializeComponent();
        }

        private void Autobtn_Click(object sender, RoutedEventArgs e)
        {
            if (txtLog.Text != "" && txtPas != null)
            {
                var _employee = App.Connection.Employee.Where(u => u.login == txtLog.Text && u.password == txtPas.Password).FirstOrDefault();
                if (_employee != null)
                {
                    if (_employee.id_role != null)
                    {
                        if (_employee.id_role == 2)
                        {
                            MessageBox.Show("авторизация прошла успешно");
                            NavigationService.Navigate(new PageApp.CashierPage());
                        }
                        else if (_employee.id_role == 11)
                        {
                            MessageBox.Show("авторизация прошла успешно");
                            NavigationService.Navigate(new PageApp.AdminPage());
                        }
                        else if (_employee.id_role == 12)
                        {
                            MessageBox.Show("авторизация прошла успешно");
                            NavigationService.Navigate(new PageApp.RoomPage());
                        }
                        else
                        {
                            MessageBox.Show("ахтунг, отказано в доступе", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("у вас нет доступа", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("такого пользователя нет", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("не все поля заполнены", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
