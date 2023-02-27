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
using FitnessClubKiselev.DB;
using FitnessClubKiselev.Windows;
using FitnessClubKiselev.ClassHelper;

namespace FitnessClubKiselev.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceList.xaml
    /// </summary>
    public partial class ServiceList : Window
    {
        public ServiceList()
        {
            InitializeComponent();
            GetServiceList();
        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = EFClass.context.Service.ToList();

            lvService.ItemsSource = serviceList;
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            // Изменение услуги

            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;

            // Открытие окна изменения услуги 
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            // Обновить список
            GetServiceList();
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {

            // Открытие окна добавление услуги
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            // Обновить список
            GetServiceList();
        }
    }
}