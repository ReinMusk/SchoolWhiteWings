using SchoolWhiteWings.DataBase;
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

namespace SchoolWhiteWings.Pages.TeacherPages
{
    /// <summary>
    /// Логика взаимодействия для TeacherLessonsPage.xaml
    /// </summary>
    public partial class TeacherLessonsPage : Page
    {
        public static List<Lesson> lessons { get; set; }
        public Teacher teacher { get; set; }
        public TeacherLessonsPage(Teacher oldTeacher)
        {
            InitializeComponent();
            teacher = oldTeacher;
            lessons = MainWindow.db.Lesson.ToList();
            this.DataContext = this;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void lvLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lesson = lvLessons.SelectedItem as Lesson;

            NavigationService.Navigate(new JournalPage(lesson));
        }

        private void cbLessonIsBe_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
