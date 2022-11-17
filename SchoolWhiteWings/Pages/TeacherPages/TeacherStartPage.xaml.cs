using SchoolWhiteWings.DataBase;
using SchoolWhiteWings.Pages.TeacherPages;
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
    /// <summary>
    /// Interaction logic for TeacherStartPage.xaml
    /// </summary>
    public partial class TeacherStartPage : Page
    {
        public static List<Lesson> lessons { get; set; }
        private static List<TeacherForSection> _tfs { get; set; }
        private HashSet<int> sects { get; set; }
        public Teacher teacher { get; set; }
        public TeacherStartPage(Teacher oldTeacher)
        {
            InitializeComponent();
            teacher = oldTeacher;
            _tfs = MainWindow.db.TeacherForSection.Where(t => t.TeacherId == oldTeacher.Id).ToList();
            sects = new HashSet<int>();
            foreach (var temp in _tfs)
            {
                sects.Add(temp.SectionId);
            }

            lessons = MainWindow.db.Lesson.Where(t => sects.Contains((int)t.SectionId)).ToList();
            UserNameBlock.Text = $" Преподаватель: {teacher.FirstName} { teacher.LastName}";
            this.DataContext = this;
        }
        private void lvLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lesson = lvLessons.SelectedItem as Lesson;

            NavigationService.Navigate(new JournalPage(lesson));
        }

        private void cbLessonIsBe_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.db.SaveChanges();
        }

        private void ToSectionTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SectionTablePage(teacher));
        }

        private void ToLessonTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherLessonsPage(teacher));
        }
    }
}
