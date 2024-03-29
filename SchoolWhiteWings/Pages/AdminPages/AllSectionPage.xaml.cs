﻿using SchoolWhiteWings.DataBase;
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
    public partial class AllSectionPage : Page
    {
        private List<DataBase.Section> sections { get; set; }
        private DataBase.Teacher _teacher;
        public AllSectionPage(DataBase.Teacher teacher)
        {
            InitializeComponent();
            sections = MainWindow.db.Section.Where(a => a.isDeleted != true).ToList();

            _teacher = teacher;
            SectionLV.ItemsSource = sections;
            this.DataContext = this;
        }

        private void SectionLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var section = SectionLV.SelectedItem as DataBase.Section;
            
            NavigationService.Navigate(new Pages.AddEditSectionPage(section, _teacher));
        }

        private void AddSectionBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddEditSectionPage(new DataBase.Section(), _teacher));
        }

        private void PreviousPage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminStartPage(_teacher));
        }
    }
}
