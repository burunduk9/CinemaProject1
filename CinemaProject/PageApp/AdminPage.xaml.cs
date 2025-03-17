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
using Excel = Microsoft.Office.Interop.Excel;

namespace CinemaProject.PageApp
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void AddDVDbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.AddDVDPage());
        }
        private void AddClientbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.AddClientPage());
        }
        private void AddEmployeebtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.RegPage());
        }




        private void RentalDVDbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.RentalDVDPage());
        }
        private void ReturnDVDbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageApp.ReturnDVDPage());
        }
        private void RentalViewbtn_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.RentaLViewPage());
        }




        private void ViewListDVDbtn_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.ShowDVDPage());
        }
        private void ViewListClientbtn_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.ShowClientPage());
        }
        private void ViewListEmployeebtn_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.ShowEmployeePage());
        }





        private void SortUp_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.SortUpPage());
        }
        private void SortDown_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.SortDownPage());
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            ListFrame.NavigationService.Navigate(new PageApp.SearchPage());
        }



        private void exportBtn_Click(object sender, RoutedEventArgs e)
        {
            var allUsers = App.Connection.Employee.ToList().OrderBy(u => u.FIO).ToList();

            var application = new Excel.Application();
            application.SheetsInNewWorkbook = allUsers.Count();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;
            for(int i = 0; i < allUsers.Count; i++)
            {
                Excel.Worksheet worksheet = application.Worksheets.Item[i + 1];
                worksheet.Name = allUsers[i].FIO;
                worksheet.Cells[1][startRowIndex] = "Дата платежа";
                worksheet.Cells[2][startRowIndex] = "Название";
                worksheet.Cells[3][startRowIndex] = "Стоимость";
                worksheet.Cells[4][startRowIndex] = "Количество";
                worksheet.Cells[5][startRowIndex] = "Сумма";
                startRowIndex++;

                var usersCategories = allUsers[i].Rental.OrderBy(u => u.date_of_delivery).GroupBy(u => u.id_client).OrderBy(u => u.Key.Value);
                foreach (var groupCategories in usersCategories)
                {
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[5][startRowIndex]];
                    headerRange.Merge();
                    headerRange.Value = groupCategories.Key.Value;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.Font.Italic = true;

                    startRowIndex++;
                    foreach (var payment in groupCategories)
                    {
                        worksheet.Cells[1][startRowIndex] = payment.date_of_delivery.ToString();
                        worksheet.Cells[2][startRowIndex] = payment.Employee.FIO.ToString();
                        worksheet.Cells[3][startRowIndex] = payment.Employee.salary.ToString();
                        worksheet.Cells[4][startRowIndex] = payment.Employee.phone.ToString();

                        worksheet.Cells[5][startRowIndex].Format = $"=C{startRowIndex}*D{startRowIndex}";
                        worksheet.Cells[3][startRowIndex].NumberFormat = worksheet.Cells[3][startRowIndex].NumberFormat = "#,###.00";
                        startRowIndex++;
                    }
                    Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[4][startRowIndex]];
                    sumRange.Merge();
                    sumRange.Value = "itogo";
                    sumRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    worksheet.Cells[5][startRowIndex].Format = $"=SUM(E{startRowIndex - groupCategories.Count()}:" + $"E{startRowIndex - 1})";
                    sumRange.Font.Bold = worksheet.Cells[5][startRowIndex].Font.Bold = true;
                    worksheet.Cells[5][startRowIndex].NumberFormat = "#,###.00";

                    startRowIndex++;

                    Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[5][startRowIndex - 1]];
                    rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
                    rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
                    rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
                    rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
                    rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
                    rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

                    worksheet.Columns.AutoFit();
                }
                application.Visible = true;
            }
        }
        //private void Searchtxt_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    var filteredProducts = products.Where(p => p.Name.ToLower().Contains(searchQuery)).ToList();
        //    Lista2.ItemsSource = filteredProducts;
        //    //s



        //    //List<Lekar> _lek = new List<Lekar>();
        //    //List<Pobochki> _ner = new List<Pobochki>();
        //    //var _listNeiro = App.Connection.Neyro.Where(z => z.title_neyro.Contains(txtSearchik.Text)).ToList();
        //    //foreach (var Indexer in _listNeiro)
        //    //{
        //    //    _lek.Add(Indexer.Lekar);
        //    //}
        //    //foreach (var Indexer in _lek)
        //    //{
        //    //    _ner.Add(Indexer.Pobochki);
        //    //}
        //    //vivod.ItemsSource = _lek;
        //}
    }
}
