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
    /// Логика взаимодействия для AddDVDPage.xaml
    /// </summary>
    public partial class AddDVDPage : Page
    {
        public AddDVDPage()
        {
            InitializeComponent();
        }

        private void AddFilmbtn_Click(object sender, RoutedEventArgs e)
        {
            Film film = new Film()
            {
                title = txtTitle.Text,
                id_genre = Convert.ToInt32(txtGenre.Text),
                id_age = Convert.ToInt32(txtAge.Text),
                rental_cost = Convert.ToInt32(txtCost.Text),
            };
            App.Connection.Film.Add(film);
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
