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
    /// Логика взаимодействия для UsersView.xaml
    /// </summary>
    public partial class UsersView : Page
    {
        UsersViewModel viewModel;
        public UsersView(ApplicationContext db)
        {
            InitializeComponent();
            viewModel = new UsersViewModel(db);
            DataContext = viewModel;
        }

        public void ChangeData(ObservableCollection<Company> companies, ObservableCollection<User> users)
        {
            viewModel.Companies = companies;
            viewModel.Users = users;
        }

        private void ButtonOpenAddUser_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenAddUser.Visibility = Visibility.Collapsed;
            ButtonCloseUser.Visibility = Visibility.Visible;
            ButtonRemoveUser.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseUser_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseUser.Visibility = Visibility.Collapsed;
            ButtonOpenAddUser.Visibility = Visibility.Visible;
            ButtonRemoveUser.Visibility = Visibility.Visible;
            if (ButtonChangeSaveUser.Visibility == Visibility.Visible)
            {
                ButtonChangeSaveUser.Visibility = Visibility.Collapsed;
                ButtonAddSaveUser.Visibility = Visibility.Visible;
            }
            ButtonOpenEditUser.Visibility = Visibility.Visible;
        }

        private void ButtonOpenEditUser_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenAddUser.Visibility = Visibility.Collapsed;
            ButtonCloseUser.Visibility = Visibility.Visible;
            ButtonRemoveUser.Visibility = Visibility.Collapsed;
            ButtonChangeSaveUser.Visibility = Visibility.Visible;
            ButtonOpenEditUser.Visibility = Visibility.Collapsed;
            ButtonAddSaveUser.Visibility = Visibility.Collapsed;
        }
    }
}
