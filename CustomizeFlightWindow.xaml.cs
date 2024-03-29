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
    /// Interaction logic for CustomizeFlightWindow.xaml
    /// </summary>
    public partial class CustomizeFlightWindow : Window
    {
        public CustomizeFlightWindow(ICommand closeCustomizeFlightWindowCommand, Event flight, List<EventType> eventTypesObj)
        {
            InitializeComponent();
            DataContext=new CustomizeFlightWindowViewModel(closeCustomizeFlightWindowCommand, flight, eventTypesObj);
        }
    }
}
