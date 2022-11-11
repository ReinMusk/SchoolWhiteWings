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
            teacherList = MainWindow.db.Teacher.Where(a => a.isDeleted != true).ToList();
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
        private void TeacherDelete(object sender, RoutedEventArgs e)
        {
            if (TeacherList.SelectedItem != null)
            {
                MessageBoxResult mes = MessageBox.Show("Вы точно хотите удалить этого учителя?", 
                    "Удаление", MessageBoxButton.OK);
                if (mes == MessageBoxResult.OK)
                {
                    var temp = TeacherList.SelectedItem as DataBase.Teacher;
                    temp.isDeleted = true;
                    MainWindow.db.Teacher.FirstOrDefault();
                    MainWindow.db.SaveChanges();
                }
            }    
            else
            {
                MessageBox.Show("Выберите учителя, которого хотите удалить");
            }
        }

    }
}
