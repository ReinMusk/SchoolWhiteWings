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

namespace SchoolWhiteWings.Pages
{
    /// <summary>
    /// Interaction logic for AddEditSectionPage.xaml
    /// </summary>
    public partial class AddEditSectionPage : Page
    {
        private DataBase.Section currentSection { get; set; }
        private DataBase.Teacher _teacher { get; set; }
        private List<Cabinet> cabinets { get; set; } 
        private List<Teacher> _teachers { get; set; }
        private List<TeacherForSection> _tfs { get; set; }

        public AddEditSectionPage(DataBase.Section section, DataBase.Teacher teacher)
        {
            InitializeComponent();

            _teacher = teacher;
            currentSection = section;

            cabinets = MainWindow.db.Cabinet.ToList();
            _tfs = MainWindow.db.TeacherForSection.Where(t => t.SectionId == currentSection.Id && 
                                                              t.IsDeleted == false).ToList();

            _teachers = new List<Teacher>();
            foreach (var a in _tfs)
            {
                _teachers.Add(a.Teacher);
            }

            CabinetCB.ItemsSource = cabinets;
            Teachers.ItemsSource = _teachers;
            this.DataContext = currentSection;
        }

        private void SaveSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            currentSection.Name = SectionNameTB.Text;
            currentSection.CabinetId = (CabinetCB.SelectedItem as Cabinet).Id;
            currentSection.isDeleted = false;

            if (MainWindow.db.Section.FirstOrDefault(a => a.Id == currentSection.Id) == null)
                MainWindow.db.Section.Add(currentSection);
            MainWindow.db.SaveChanges();

            NavigationService.Navigate(new AllSectionPage(_teacher));
        }

        private void DelSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentSection.Id != 0)
            {
                var result = MessageBox.Show(
                    "Вы точно хотите удалить данную секцию?",
                    "Внимание",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                    return;
                currentSection.isDeleted = true;
                MainWindow.db.Section.SingleOrDefault(a => a.Id == currentSection.Id);
                MainWindow.db.SaveChanges();

                NavigationService.Navigate(new AllSectionPage(_teacher));
            }
        }
        private void PreviousPage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllSectionPage(_teacher));
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void NewTeacherToList_Add(object sender, RoutedEventArgs e)
        {
            TeacherChooseListWindow window = new TeacherChooseListWindow();
            window.ShowDialog();
            this._teacher = window._tempTeacher;

            TeacherForSection temp = new TeacherForSection();
            temp.TeacherId = _teacher.Id;
            temp.SectionId = currentSection.Id;
            temp.IsDeleted = false;

            MainWindow.db.TeacherForSection.Add(temp);
            MainWindow.db.SaveChanges();

            NavigationService.Navigate(new AddEditSectionPage(currentSection, _teacher));
        }

        private void TeacherFromSection_Delete(object sender, RoutedEventArgs e)
        {
            DataBase.TeacherForSection tempRecord = _tfs.Where(t => t.TeacherId == (Teachers.SelectedItem as Teacher).Id).FirstOrDefault();
            tempRecord.IsDeleted = true;
            MainWindow.db.TeacherForSection.FirstOrDefault();
            MainWindow.db.SaveChanges();

            NavigationService.Navigate(new AddEditSectionPage(currentSection, _teacher));
        }

    }
}
