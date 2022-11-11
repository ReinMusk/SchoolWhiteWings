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
    /// Логика взаимодействия для AdminNewTeacherAddPage.xaml
    /// </summary>
    public partial class AdminNewTeacherAddPage : Page
    {
        private DataBase.Teacher _teacher;
        public AdminNewTeacherAddPage(DataBase.Teacher teacher)
        {
            InitializeComponent();
            _teacher = new DataBase.Teacher();
        }

        private void ToPreviousPage_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NewTeacher_Create(object sender, RoutedEventArgs e)
        {
            if (FirstnameEnter.Text != "" &&
                LastnameEnter.Text != "" &&
                PatronymicEnter.Text != "" &&
                SpecialityEnter.Text != "")
            {
                if (TeacherPasswordEnter.Text != "")
                {
                    _teacher.FirstName = FirstnameEnter.Text;
                    _teacher.LastName = LastnameEnter.Text;
                    _teacher.Patronymic = PatronymicEnter.Text;
                    _teacher.Speciality = SpecialityEnter.Text;
                    _teacher.Password = TeacherPasswordEnter.Text;
                    _teacher.IsAdmin = false;

                    MainWindow.db.Teacher.Add(_teacher);
                    MainWindow.db.SaveChanges();

                    MessageBox.Show($"{_teacher.LastName} {_teacher.Patronymic} успешно добавлен в базу как учитель");

                    NavigationService.Navigate(new AdminTeacherListPage(_teacher));
                }
                else
                {
                    MessageBox.Show("Укажите пароль для нового учителя");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля данными");
            }
            
        }

    }
}
