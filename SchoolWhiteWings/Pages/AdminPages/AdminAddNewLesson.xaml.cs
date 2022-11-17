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
    public partial class AdminAddNewLesson : Page
    {
        private static List<DataBase.Section> sectionList { get; set; }
        private static DataBase.Teacher _teacher { get; set; }
        public AdminAddNewLesson(DataBase.Teacher teacher)
        {
            InitializeComponent();

            _teacher = teacher;

            sectionList = MainWindow.db.Section.Where(s => s.isDeleted != true).ToList();
            secList.ItemsSource = sectionList;
            timeOfBegining.Value = DateTime.Now;
            timeOfBegining.Minimum = DateTime.Today;
            //timeOfend.Minimum = DateTime.Today;
            
        }

        private void CreateNewButton_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Lesson les = new DataBase.Lesson();
            if (secList.SelectedItem != null)
            {
                les.Section = secList.SelectedItem as DataBase.Section;
                if (timeOfBegining.Value != timeOfend.Value)
                {
                    les.DateTimeOfBeginning = timeOfBegining.Value;
                    les.DateTimeOfEnding = timeOfend.Value;

                    MainWindow.db.Lesson.Add(les);
                    MainWindow.db.SaveChanges();
                    NavigationService.Navigate(new AdminTimeTablePage(_teacher));
                }
                else
                {
                    MessageBox.Show("Выберите дату");
                }
            }
            else
            {
                MessageBox.Show("Выберите кружок");
            }
        }

        private void timeOfBegining_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            timeOfend.Value = timeOfBegining.Value;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminTimeTablePage(_teacher));
        }
    }
}
