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
using Section = SchoolWhiteWings.DataBase.Section;

namespace SchoolWhiteWings
{
    /// <summary>
    /// Interaction logic for SectionGroupsPage.xaml
    /// </summary>
    public partial class SectionGroupsPage : Page
    {
        public Section section { get; set; }
        public Teacher teacher { get; set; }
        public static List<Group> groups { get; set; }
        public SectionGroupsPage(Section oldSection, Teacher oldTeacher)
        {
            InitializeComponent();
            section = oldSection;
            teacher = oldTeacher;
            groups = MainWindow.db.Group.Where(x => x.SectionId == section.Id).ToList();

            this.DataContext = this;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SectionTablePage(teacher));
        }

        private void GroupsLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new SectionPage(GroupsLV.SelectedItem as Group, teacher));
        }
    }
}
