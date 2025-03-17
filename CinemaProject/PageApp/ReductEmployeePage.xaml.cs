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
    /// Логика взаимодействия для ReductEmployeePage.xaml
    /// </summary>
    public partial class ReductEmployeePage : Page
    {
        public ReductEmployeePage()
        {
            InitializeComponent();
            this.DataContext = App.Connection.Employee.Where(u => u.ID == ClassApp.ClassEmployee.CorrEmployee.ID).FirstOrDefault();
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            App.Connection.SaveChanges();
        }

        private void Returnbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
