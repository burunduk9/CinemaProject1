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
    /// Логика взаимодействия для ShowEmployeePage.xaml
    /// </summary>
    public partial class ShowEmployeePage : Page
    {
        public ShowEmployeePage()
        {
            InitializeComponent();
            ListEmployee.ItemsSource = App.Connection.Employee.ToList();
        }
        private void ReductEmployeebtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new PageApp.ReductEmployeePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
