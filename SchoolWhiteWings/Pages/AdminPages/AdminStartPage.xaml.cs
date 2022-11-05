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
    /// Логика взаимодействия для AdminStartPage.xaml
    /// </summary>
    public partial class AdminStartPage : Page
    {
        public AdminStartPage()
        {
            InitializeComponent();
            
            UserNameBlock.Text = "Антон"; //забиндить юзернейм чела
        }

        private void LessonTablePage_Opening(object sender, RoutedEventArgs e)
        {

        }

        private void SectionPage_Opening(object sender, RoutedEventArgs e)
        {

        }

    }
}
