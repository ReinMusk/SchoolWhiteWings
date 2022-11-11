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
        private List<Cabinet> cabinets { get; set; }    
        public AddEditSectionPage(DataBase.Section section)
        {
            InitializeComponent();

            currentSection = section;
            cabinets = MainWindow.db.Cabinet.ToList();

            CabinetCB.ItemsSource = cabinets;
            this.DataContext = currentSection;
        }

        private void SaveSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            currentSection.Name = SectionNameTB.Text;
            currentSection.CabinetId = (CabinetCB.SelectedItem as Cabinet).Id;

            if (MainWindow.db.Section.FirstOrDefault(a => a.Id == currentSection.Id) == null)
                MainWindow.db.Section.Add(currentSection);
            MainWindow.db.SaveChanges();

            NavigationService.Navigate(new AllSectionPage());
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
                MainWindow.db.Section.Remove(currentSection);
                MainWindow.db.SaveChanges();

                NavigationService.Navigate(new AllSectionPage());
            }
        }
    }
}
