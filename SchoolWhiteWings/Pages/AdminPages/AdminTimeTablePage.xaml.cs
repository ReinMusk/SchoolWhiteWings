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

using System.Collections.ObjectModel;

namespace SchoolWhiteWings
{
    public partial class AdminTimeTablePage : Page
    {
        public AdminTimeTablePage()
        {
            InitializeComponent();
            lessons.ItemsSource = DBConnection.conn.Lesson.ToList(); //строку подключения сами замените на свою
        }

        private void PreviousPage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminStartPage());
        }
    }
}
