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
using System.Windows.Shapes;

namespace SchoolWhiteWings
{
    /// <summary>
    /// Логика взаимодействия для TeacherChooseListWindow.xaml
    /// </summary>
    public partial class TeacherChooseListWindow : Window
    {
        public static List<DataBase.Teacher> teacherList { get; set; }
        public DataBase.Teacher _tempTeacher;
        public TeacherChooseListWindow()
        {
            InitializeComponent();
            
            _tempTeacher = new DataBase.Teacher();

            teacherList = MainWindow.db.Teacher.ToList();
            this.DataContext = this;
        }

        private void TeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tempTeacher = TeacherList.SelectedItem as DataBase.Teacher;
            this.DialogResult = true;
            this.Close();
        }
    }
}
