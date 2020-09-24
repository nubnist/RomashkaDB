using RomashkaBase.Model;
using RomashkaBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CompaniesAndUsersView.xaml
    /// </summary>
    public partial class CompaniesAndUsersView : Page
    {
        CompaniesAndUsersViewModel companiesAndUsersViewModel;
        public CompaniesAndUsersView(ApplicationContext db)
        {
            InitializeComponent();
            companiesAndUsersViewModel = new CompaniesAndUsersViewModel(db);
            DataContext = companiesAndUsersViewModel;
        }

        public void ChangeData(ObservableCollection<Company> companies)
        {
            companiesAndUsersViewModel.Companies = companies;
        }
    }
}
