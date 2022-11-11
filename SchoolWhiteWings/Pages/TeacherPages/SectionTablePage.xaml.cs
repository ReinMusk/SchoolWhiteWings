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
using static System.Collections.Specialized.BitVector32;
using Section = SchoolWhiteWings.DataBase.Section;

namespace SchoolWhiteWings
{
    /// <summary>
    /// Interaction logic for SectionTablePage.xaml
    /// </summary>
    public partial class SectionTablePage : Page
    {
        public static List<TeacherForSection> teacherForSection { get; set; }
        public Teacher teacher { get; set;}
        public SectionTablePage(Teacher oldTeacher)
        {
            InitializeComponent();

            teacher = oldTeacher;
            teacherForSection = MainWindow.db.TeacherForSection.Where(x => x.TeacherId == teacher.Id).ToList();

            this.DataContext = this;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeacherStartPage(teacher));
        }

        private void SectionsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var section = (SectionsLV.SelectedItem as TeacherForSection).Section;

            NavigationService.Navigate(new SectionGroupsPage(section, teacher));
        }
    }
}
