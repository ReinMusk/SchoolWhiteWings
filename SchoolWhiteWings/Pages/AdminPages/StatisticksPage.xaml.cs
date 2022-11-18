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
            SectionPopLV.ItemsSource = MainWindow.db.Section
                .Where(a => a.isDeleted != true)
                .OrderByDescending(a => a.Group.Count).ToList();
            
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
    }
}
