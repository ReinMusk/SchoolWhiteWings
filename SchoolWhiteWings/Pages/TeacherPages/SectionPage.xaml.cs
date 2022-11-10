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
    /// Interaction logic for SectionPage.xaml
    /// </summary>
    public partial class SectionPage : Page
    {
        public Section section { get; set; }

        public Group group { get; set; }
        public List<GroupStudent> students { get; set; }
        public SectionPage(Section oldSection)
        {
            InitializeComponent();
            section = oldSection;

            group = MainWindow.db.Group.Where(x => x.SectionId == section.Id).First();
            students = MainWindow.db.GroupStudent.Where(x => x.GroupId == group.Id).ToList();

            this.DataContext = this;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonDel(object sender, RoutedEventArgs e)
        {
            var selectedStudent = StudentsLV.SelectedItem as GroupStudent;

            if (selectedStudent != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить студента?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)
                {
                    MainWindow.db.GroupStudent.Remove(selectedStudent);
                }
            }
            else
            {
                MessageBox.Show("Выберите студента","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudentToGroupPage());
        }
    }
}
