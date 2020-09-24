using DevExpress.Mvvm.Native;
using RomashkaBase.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RomashkaBase.ViewModel
{
    public class CompaniesAndUsersViewModel : BasePropertyChanged
    {
        private ObservableCollection<Company> _companies;
        public ObservableCollection<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                OnPropertyChanged();
            }
        }

        public CompaniesAndUsersViewModel(ApplicationContext db)
        {
            Companies = db.Companies.ToObservableCollection();
        }
    }
}
