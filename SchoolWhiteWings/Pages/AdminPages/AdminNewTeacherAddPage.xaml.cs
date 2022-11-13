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
        private DataBase.Teacher _loggedTeacher;
        public AdminNewTeacherAddPage(DataBase.Teacher teacher)
        {
            InitializeComponent();
            _teacher = new DataBase.Teacher();
            _loggedTeacher = teacher;
        }

        public AdminNewTeacherAddPage(DataBase.Teacher loggedTeacher, DataBase.Teacher teacherForRedact)
        {
            InitializeComponent();
            _loggedTeacher = loggedTeacher;
            _teacher = teacherForRedact;

            FirstnameEnter.Text = teacherForRedact.FirstName;
            LastnameEnter.Text = teacherForRedact.LastName;
            PatronymicEnter.Text = teacherForRedact.Patronymic;
            SpecialityEnter.Text = teacherForRedact.Speciality;
            TeacherPasswordEnter.Text = teacherForRedact.Password;
        }

        private void ToPreviousPage_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NewTeacher_Create(object sender, RoutedEventArgs e)
        {
            if (FirstnameEnter.Text != "" &&
                LastnameEnter.Text != "" &&
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

                    if(_teacher.Id == 0)
                    {
                        MainWindow.db.Teacher.Add(_teacher);
                        MainWindow.db.SaveChanges();

                        MessageBox.Show($"{_teacher.LastName} {_teacher.Patronymic} успешно добавлен в базу как учитель");
                    }
                    else
                    {
                        MainWindow.db.Teacher.FirstOrDefault();
                        MainWindow.db.SaveChanges();
                        MessageBox.Show($"Данные об учителе были успешно изменены");

                    }


                    NavigationService.Navigate(new AdminTeacherListPage(_loggedTeacher));
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

        private void TBRusLetters_Check(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsLetter(e.Text, 0));
        }

    }
}
