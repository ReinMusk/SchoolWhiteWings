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

namespace SchoolWhiteWings.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for StatisticksPage.xaml
    /// </summary>
    public partial class StatisticksPage : Page
    {
        public StatisticksPage()
        {
            InitializeComponent();
            var sectionPop = MainWindow.db.Section
                .Where(a => a.isDeleted != true)
                .OrderByDescending(a => a.Group.Count).ToList();
            SectionPopLV.ItemsSource = sectionPop;
            
            var students = MainWindow.db.Student.ToList();
            var orderedStud = 
                from s in students
                orderby s.JournalCount descending
                select s;
            StudentMostActiveLV.ItemsSource = orderedStud;
            
            SortsCB.SelectedIndex = 0;
        }

        private void SortsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortsCB.SelectedIndex == 0)
            {
                SectionPopLV.Visibility = Visibility.Visible;
                StudentMostActiveLV.Visibility = Visibility.Collapsed;  
            } else if (SortsCB.SelectedIndex == 1)
            {
                SectionPopLV.Visibility = Visibility.Collapsed;
                StudentMostActiveLV.Visibility = Visibility.Visible;
            }
        }

        private void ToPreviousPage_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (SortsCB.SelectedIndex == 0)
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                int startRowIndex = 1;

                worksheet.Cells[1][startRowIndex] = "Кружок";
                worksheet.Cells[2][startRowIndex] = "Количество групп";
                worksheet.Cells[3][startRowIndex] = "Количество учащихся";
                startRowIndex++;

                var sectionPop = MainWindow.db.Section
                    .Where(a => a.isDeleted != true)
                    .OrderByDescending(a => a.Group.Count).ToList();
                foreach (var result in sectionPop)
                {
                    worksheet.Cells[1][startRowIndex] = result.Name;
                    worksheet.Cells[2][startRowIndex] = result.Group.Count;
                    worksheet.Cells[3][startRowIndex] = result.StudentCount;
                    startRowIndex++;
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
                application.Visible = true;
            }
            else if (SortsCB.SelectedIndex == 1)
            {
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = application.Worksheets.Item[1];
                int startRowIndex = 1;
                worksheet.Rows.HorizontalAlignment = HorizontalAlignment.Center;
                worksheet.Rows.VerticalAlignment = HorizontalAlignment.Center;
                worksheet.Cells[1][startRowIndex] = "ФИО";
                worksheet.Cells[2][startRowIndex] = "Класс";
                worksheet.Cells[3][startRowIndex] = "Общее количество посещений";
                startRowIndex++;

                var students = MainWindow.db.Student.ToList();
                var orderedStud =
                    from s in students
                    orderby s.JournalCount descending
                    select s;
                foreach (var result in orderedStud)
                {
                    worksheet.Cells[1][startRowIndex] = result.FirstName + " " + result.LastName + " " + result.Patronymic;
                    worksheet.Cells[2][startRowIndex] = result.Class.Number;
                    worksheet.Cells[3][startRowIndex] = result.JournalCount;
                    startRowIndex++;
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
                application.Visible = true;
            }
        }
    }
}
