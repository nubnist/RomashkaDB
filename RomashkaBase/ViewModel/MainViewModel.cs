using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RomashkaBase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using RomashkaBase.Service;
using RomashkaBase.View;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Threading;
using DevExpress.Mvvm.Native;

namespace RomashkaBase.ViewModel
{
    public class MainViewModel : BasePropertyChanged
    {
        private ApplicationContext db;
        private List<Company> _companies;
        private List<User> _users;
        
        public List<Company> Companies {
            get => _companies;
            set {
                _companies = value;
                OnPropertyChanged();
            }
        }
        public List<User> Users {
            get => _users;
            set {
                _users = value;
                OnPropertyChanged();
            }
        }

        #region Страницы формы
        CompaniesView companiesView;
        UsersView usersView;
        CompaniesAndUsersView companiesAndUsersView;

        Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        double _frameOpacity;
        public double FrameOpacity
        {
            get => _frameOpacity;
            set
            {
                _frameOpacity = value;
                OnPropertyChanged();
            }
        }

        RelayCommand _selectedPageCommand;
        public RelayCommand SelectedPageCommand
        {
            get => _selectedPageCommand ??
                (_selectedPageCommand = new RelayCommand((obj) =>
                {
                    if (obj != null)
                    {
                        switch (((ListViewItem)((ListView)obj).SelectedItem).Name)
                        {
                            case "ItemCompanies":
                                SlowOpacity(companiesView);
                                break;
                            case "ItemUsers":
                                SlowOpacity(usersView);
                                break;
                            case "ItemCompanyAndUsers":
                                SlowOpacity(companiesAndUsersView);
                                break;
                            default:
                                break;
                        }
                    }
                }));
        }

        private async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0; i -= 0.01)
                {
                    FrameOpacity = i;
                    Thread.Sleep(1);
                }
                CurrentPage = page;
                (page as UsersView)?.ChangeData(db.Companies.ToObservableCollection(), db.Users.ToObservableCollection());
                (page as CompaniesAndUsersView)?.ChangeData(db.Companies.ToObservableCollection());
                Thread.Sleep(100);
                for (double i = 0; i < 1.1; i += 0.01)
                {
                    FrameOpacity = i;
                    Thread.Sleep(1);
                }
            });
        }
        #endregion

        public MainViewModel()
        {
            db = new ApplicationContext();
            companiesView = new CompaniesView(db);
            usersView = new UsersView(db);
            companiesAndUsersView = new CompaniesAndUsersView(db);

            SlowOpacity(companiesView);
        }
    }
}
