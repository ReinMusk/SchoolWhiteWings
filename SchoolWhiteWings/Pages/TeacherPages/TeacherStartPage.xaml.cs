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

namespace SchoolWhiteWings
{
    /// <summary>
    /// Interaction logic for TeacherStartPage.xaml
    /// </summary>
    public partial class TeacherStartPage : Page
    {
        public Teacher teacher { get; set; }
        public TeacherStartPage(Teacher oldTeacher)
        {
            InitializeComponent();
            teacher = oldTeacher;

            UserNameBlock.Text = teacher.FirstName + " " + teacher.LastName;
        }

        private void ToSectionTable_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SectionTablePage(teacher));
        }

        private void ToLessonTable_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
