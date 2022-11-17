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
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public Teacher teacher { get; set; }
        public Section section { get; set; }
        public AddGroupWindow(Section oldSection, Teacher oldTeacher)
        {
            InitializeComponent();

            teacher = oldTeacher;
            section = oldSection;

            this.DataContext = this;
        }
        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            if (nameTxt.Text != "")
            {
                var result = MessageBox.Show("Вы уверены что хотите добавить в секцию " + section.Name + " группу " + nameTxt.Text, "", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Group group = new Group()
                    {
                        Name = nameTxt.Text,
                        SectionId = section.Id,
                    };

                    MainWindow.db.Group.Add(group);
                    MainWindow.db.SaveChanges();
                    this.Close();

                }
            }
        }
    }
}
