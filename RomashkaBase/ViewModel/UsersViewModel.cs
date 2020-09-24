using DevExpress.Mvvm.Native;
using RomashkaBase.Model;
using RomashkaBase.Service;
using RomashkaBase.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RomashkaBase.View
{
    public class UsersViewModel : BasePropertyChanged
    {
        #region Коллекции данных БД
        private ApplicationContext db;
        private ObservableCollection<Company> _companies;
        private ObservableCollection<User> _users;

        public ObservableCollection<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Редактирование элементов таблицы Пользователи
        private string _userName;
        private string _userLogin;
        private string _userPassword;
        private User _selectedUser;
        private Company _selectedCompany;

        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
                OnPropertyChanged();
            }
        }
        public string UserLogin
        {
            get => _userLogin;
            set
            {
                _userLogin = value;
                OnPropertyChanged();
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }
        public Company SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                _selectedCompany = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addUser;
        private RelayCommand _removeUser;
        private RelayCommand _editUser;
        private RelayCommand _saveEditUser;
        private RelayCommand _closeUser;

        public RelayCommand CloseUser
        {
            get => _closeUser ?? (_closeUser = new RelayCommand(obj =>
            {
                UserName = null;
                SelectedCompany = null;
                UserLogin = null;
                UserPassword = null;
            }));
        }

        public RelayCommand SaveEditUser
        {
            get => _saveEditUser ?? (_saveEditUser = new RelayCommand(obj =>
            {
                SelectedUser.Name = UserName;
                SelectedUser.Login = UserLogin;
                SelectedUser.Password = UserPassword;
                SelectedUser.Company = SelectedCompany;
                db.SaveChanges();
            }, obj => ((from i in Users
                        where i.Login == UserLogin && i != SelectedUser
                        select i).Count() == 0) && SelectedCompany != null));
        }

        public RelayCommand EditUser
        {
            get => _editUser ?? (_editUser = new RelayCommand(obj =>
            {
                UserName = SelectedUser.Name;
                UserLogin = SelectedUser.Login;
                UserPassword = SelectedUser.Password;
                SelectedCompany = SelectedUser.Company;
            }, obj => SelectedUser != null));
        }

        public RelayCommand RemoveUser
        {
            get => _removeUser ?? (_removeUser = new RelayCommand(obj =>
            {
                db.Users.Remove(SelectedUser);
                db.SaveChanges();
                Users = db.Users.ToObservableCollection();
            }, obj => SelectedUser != null));
        }

        public RelayCommand AddUser
        {
            get => _addUser ?? (_addUser = new RelayCommand(obj =>
            {
                db.Users.Add(new User()
                {
                    Name = UserName,
                    Login = UserLogin,
                    Password = UserPassword,
                    Company = SelectedCompany
                }) ;
                db.SaveChanges();
                Users = db.Users.ToObservableCollection();
            }, obj => 
            ((from i in Users
              where i.Login == UserLogin 
              select i).Count() == 0) 
            && SelectedCompany != null 
            && !String.IsNullOrEmpty(UserName) 
            && !String.IsNullOrEmpty(UserLogin)));
        }
        #endregion

        public UsersViewModel(ApplicationContext db)
        {
            this.db = db;
            Users = db.Users.ToObservableCollection();
            foreach (var item in Users)
                db.Entry(item).Reference("Company").Load();
            Companies = db.Companies.ToObservableCollection();
        }
    }
}
