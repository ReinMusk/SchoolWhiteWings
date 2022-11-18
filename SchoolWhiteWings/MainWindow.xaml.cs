using SchoolWhiteWings.DataBase;
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
        internal static SchoolWhiteWingsEntities db = new SchoolWhiteWingsEntities(); //бд коннектион блиа
        public string pageTitle { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Log_frame.Navigated += Frame_Navigated;
            Log_frame.Content = new AuthPage();
        }
        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var pageContent = Log_frame.Content;
            pageTitle = (pageContent as Page).Title;
            tbTitle.Text = pageTitle;

            if (pageContent is AuthPage)
                btnGoOut.Visibility = Visibility.Hidden;
            else
            {
                btnGoOut.Visibility = Visibility.Visible;
            }
        }

        private void btnGoOut_Click(object sender, RoutedEventArgs e)
        {
            if (Log_frame.CanGoBack)
                Log_frame.Content = new AuthPage();
        }
    }
}
