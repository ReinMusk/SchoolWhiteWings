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
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private List<DataBase.Section> sections { get; set; }
        public StatisticsPage()
        {
            InitializeComponent();
            sections = MainWindow.db.Section.ToList();
            List<DataBase.Group> groups = MainWindow.db.Group.ToList();
        }
    }
}
