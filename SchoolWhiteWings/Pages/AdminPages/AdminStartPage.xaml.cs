using SchoolWhiteWings.DataBase;
using SchoolWhiteWings.Pages.AdminPages;
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

namespace SchoolWhiteWings
{
    public partial class AdminStartPage : Page
    {
        private DataBase.Teacher _tempTeacher;
        public AdminStartPage(Teacher teacher)
        {
            InitializeComponent();
            
            _tempTeacher = teacher;
            UserNameBlock.Text = $"{teacher.LastName} {teacher.Patronymic}"; 
        }

        private void LessonTablePage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminTimeTablePage(_tempTeacher));
        }

        private void SectionPage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllSectionPage(_tempTeacher));
        }

        private void TeacherList_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminTeacherListPage(_tempTeacher));
        }

        private void ToStaticksPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticksPage());
        }
    }
}
