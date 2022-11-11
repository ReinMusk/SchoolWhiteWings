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

namespace SchoolWhiteWings.Pages.AuthRegPages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }


        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            if(LoginTb.Text == "" || PasswordCb.Password == "")
            {
                MessageBox.Show("Enter the data");
                return;
            }

            int _id = 0;
            if (int.TryParse(LoginTb.Text, out var number))
                _id = number;
            else
            {
                MessageBox.Show("Login consists only of numbers ");
                return;
            }

            var teacher = MainWindow.db.Teacher.Where(p => p.Id == _id && p.Password == PasswordCb.Password).FirstOrDefault();
            if (teacher != null)
            {
                if (teacher.IsAdmin == true)
                    NavigationService.Navigate(new AdminStartPage(teacher));
                else
                    NavigationService.Navigate(new TeacherStartPage(teacher));
            }
            else
                MessageBox.Show("User not found");
        }
    }
}
