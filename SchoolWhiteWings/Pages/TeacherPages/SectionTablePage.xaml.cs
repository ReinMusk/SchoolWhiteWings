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
    /// Interaction logic for SectionTablePage.xaml
    /// </summary>
    public partial class SectionTablePage : Page
    {
        public List<TeacherForSection> teacherForSection { get; set; }
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
            NavigationService.GoBack();
        }
    }
}
