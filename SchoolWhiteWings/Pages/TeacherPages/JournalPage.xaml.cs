using SchoolWhiteWings.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        public static List<Journal> journals { get; set; }
        public Lesson selectedLesson { get; set; }
        public JournalPage(Lesson lesson)
        {
            InitializeComponent();
            selectedLesson = lesson;
            journals = MainWindow.db.Journal.Where(x => x.LessonId == selectedLesson.Id).ToList();
            this.DataContext = this;
        }


        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void cbStudentIsBe_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.db.SaveChanges();
        }
    }
}
