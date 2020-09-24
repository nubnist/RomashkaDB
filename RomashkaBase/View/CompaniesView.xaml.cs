using RomashkaBase.Model;
using RomashkaBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RomashkaBase.View
{
    /// <summary>
    /// Логика взаимодействия для CompaniesView.xaml
    /// </summary>
    public partial class CompaniesView : Page
    {
        public CompaniesView(ApplicationContext db)
        {
            InitializeComponent();
            DataContext = new CompaniesViewModel(db);
        }

        private void ButtonOpenAddCompany_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenAddCompany.Visibility = Visibility.Collapsed;
            ButtonCloseCompany.Visibility = Visibility.Visible;
            ButtonRemoveCompany.Visibility = Visibility.Collapsed;
        }


        private void ButtonCloseCompany_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseCompany.Visibility = Visibility.Collapsed;
            ButtonOpenAddCompany.Visibility = Visibility.Visible;
            ButtonRemoveCompany.Visibility = Visibility.Visible;
            if (ButtonChangeSaveCompany.Visibility == Visibility.Visible)
            {
                ButtonChangeSaveCompany.Visibility = Visibility.Collapsed;
                ButtonAddSaveCompany.Visibility = Visibility.Visible;
            }
            ButtonOpenEditCompany.Visibility = Visibility.Visible;
        }

        private void ButtonOpenEditCompany_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenAddCompany.Visibility = Visibility.Collapsed;
            ButtonCloseCompany.Visibility = Visibility.Visible;
            ButtonRemoveCompany.Visibility = Visibility.Collapsed;
            ButtonChangeSaveCompany.Visibility = Visibility.Visible;
            ButtonOpenEditCompany.Visibility = Visibility.Collapsed;
            ButtonAddSaveCompany.Visibility = Visibility.Collapsed;
        }
    }
}
