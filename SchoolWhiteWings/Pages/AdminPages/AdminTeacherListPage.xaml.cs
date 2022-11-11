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
    public partial class AdminTeacherListPage : Page
    {
        public static List<DataBase.Teacher> teacherList { get; set; }
        private DataBase.Teacher _tempTeacher;
        public AdminTeacherListPage(DataBase.Teacher teacher)
        {
            InitializeComponent();

            _tempTeacher = teacher;
            teacherList = MainWindow.db.Teacher.ToList();
            this.DataContext = this;
        }

        private void PreviousPage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminStartPage(_tempTeacher));
        }

        private void TeacherCreatePageOpening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminNewTeacherAddPage(_tempTeacher));
        }

    }
}
