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
using ITU_Desktop.Models;
using ITU_Desktop.ViewModels;

namespace ITU_Desktop
{
    /// <summary>
    /// Interaction logic for CustomizeWorkerWindow.xaml
    /// </summary>
    public partial class CustomizeWorkerWindow : Window
    {

        public CustomizeWorkerWindow(ICommand closeCustomizeWorkerWindowCommand, User selectedWorker, List<UserType> userTypesObj)
        {
            InitializeComponent();
            DataContext = new CustomizeWorkerWindowViewModel(closeCustomizeWorkerWindowCommand, selectedWorker, userTypesObj);
        }
    }
}
