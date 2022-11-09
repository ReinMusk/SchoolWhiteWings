using SchoolWhiteWings.DB;
using SchoolWhiteWings.Pages.AuthRegPages;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static SchoolWhiteWingsEntities db = new SchoolWhiteWingsEntities();
        public MainWindow()
        {
            InitializeComponent();

            Log_frame.Content = new AuthPage();
        }
    }
}
