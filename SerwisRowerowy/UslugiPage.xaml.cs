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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SerwisRowerowy
{
    /// <summary>
    /// Interaction logic for UslugiPage.xaml
    /// </summary>
    public partial class UslugiPage : Page
    {
        //UslugiViewModel UslugiVM;
        //Frame Frame;

        public UslugiPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UslugiRepository uslugiRepository = new UslugiRepository();
            
            ListaUslug.ItemsSource = uslugiRepository.uslugiRepository.ToList();
        }
    }
}
