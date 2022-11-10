﻿using System;
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
using SchoolWhiteWings.DataBase;

namespace SchoolWhiteWings
{
    public partial class AdminTimeTablePage : Page
    {
        public static List<Lesson> lessonList { get; set; }
        public AdminTimeTablePage()
        {
            InitializeComponent();
            lessonList = MainWindow.db.Lesson.ToList();
            this.DataContext = this;
        }

        private void PreviousPage_Opening(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
