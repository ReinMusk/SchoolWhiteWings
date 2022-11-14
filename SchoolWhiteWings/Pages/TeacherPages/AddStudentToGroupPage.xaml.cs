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
    /// Interaction logic for AddStudentToGroupPage.xaml
    /// </summary>
    public partial class AddStudentToGroupPage : Page
    {
        public static List<Student> students { get; set; }
        public Teacher teacher { get; set; }
        public Group group { get; set; }
        public AddStudentToGroupPage(Group oldGroup,Teacher oldTeacher)
        {
            InitializeComponent();
            teacher = oldTeacher;
            group = oldGroup;

            students = MainWindow.db.Student.ToList();

            this.DataContext = this;
        }

        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SectionPage(group, teacher));
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchingText = tbSearch.Text.ToLower();

            if (searchingText == "")
                students = MainWindow.db.Student.ToList();
            else
                students = students.FindAll(x => x.FirstName.ToLower().Contains(searchingText));

            StudentsLV.ItemsSource = students;
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            Student tempStudent = StudentsLV.SelectedItem as Student;

            if (tempStudent != null)
            {
                foreach (var item in group.GroupStudent)
                {
                    if (item.Student == tempStudent)
                    {
                        MessageBox.Show("Этот студент уже есть в кружке", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
               
                var result = MessageBox.Show("Вы хотите добавить студента "
                    + tempStudent.FirstName + " " + tempStudent.LastName + " в группу номер " + group.Id,
                    "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    GroupStudent groupStudent = new GroupStudent()
                    {
                        StudentId = tempStudent.Id,
                        GroupId = group.Id,
                    };

                    MainWindow.db.GroupStudent.Add(groupStudent);
                    MainWindow.db.SaveChanges();

                    NavigationService.Navigate(new SectionPage(group, teacher));
                }
            }
            else
            {
                MessageBox.Show("Выберите студента","Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }   
    }
}
