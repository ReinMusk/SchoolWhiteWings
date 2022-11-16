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
        public AdminAddNewLesson()
        {
            InitializeComponent();

            sectionList = MainWindow.db.Section.Where(s => s.isDeleted != true).ToList();
            secList.ItemsSource = sectionList;
        }

        private void CreateNewButton_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Lesson les = new DataBase.Lesson();
            if (secList.SelectedItem != null)
            {
                les.Section = secList.SelectedItem as DataBase.Section;
                //Двигать дальше по вложенным ифам
                MainWindow.db.Lesson.Add(les);
                MainWindow.db.SaveChanges();
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Выберите кружок");
            }
        }
    }
}
