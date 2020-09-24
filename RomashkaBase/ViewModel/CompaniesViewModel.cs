using RomashkaBase.Model;
using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Mvvm;
using System.Linq;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using RomashkaBase.Service;
using System.Windows;

namespace RomashkaBase.ViewModel
{
    public class CompaniesViewModel : BasePropertyChanged
    {
        #region Коллекции данных БД
        private ApplicationContext db;
        private List<Company> _companies;
        private List<ContractStatus> _contractStatuses;

        public List<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value;
                OnPropertyChanged();
            }
        }
        public List<ContractStatus> ContractStatuses
        {
            get => _contractStatuses;
            set
            {
                _contractStatuses = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Редактирование элементов таблицы Компания
        private string _companyName;
        private ContractStatus _selectedContractStatus;
        private Company _selectedCompany;

        public Company SelectedCompany
        {
            get => _selectedCompany;
            set
            {
                _selectedCompany = value;
                OnPropertyChanged();
            }
        }

        public string CompanyName
        {
            get => _companyName;
            set
            {
                _companyName = value;
                OnPropertyChanged();
            }
        }
        public ContractStatus SelectedContractStatus
        {
            get => _selectedContractStatus;
            set
            {
                _selectedContractStatus = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _addCompany;
        private RelayCommand _removeCompany;
        private RelayCommand _editCompany;
        private RelayCommand _saveEditCompany;
        private RelayCommand _closeCompany;

        public RelayCommand CloseCompany
        {
            get => _closeCompany ?? (_closeCompany = new RelayCommand(obj =>
            {
                CompanyName = null;
                SelectedContractStatus = null;
            }));
        }

        public RelayCommand SaveEditCompany
        {
            get => _saveEditCompany ?? (_saveEditCompany = new RelayCommand(obj =>
            {
                SelectedCompany.Name = CompanyName;
                SelectedCompany.ContractStatus = SelectedContractStatus;
                db.SaveChanges();
            }, obj => ((from i in Companies             // Проверка на существование такого же имени компании
                       where i.Name == CompanyName && i != SelectedCompany
                       select i).Count() == 0) && SelectedContractStatus != null));
        }

        public RelayCommand EditCompany
        {
            get => _editCompany ?? (_editCompany = new RelayCommand(obj =>
            {
                CompanyName = SelectedCompany.Name;
                SelectedContractStatus = SelectedCompany.ContractStatus;
            }, obj => SelectedCompany != null));
        }

        public RelayCommand RemoveCompany
        {
            get => _removeCompany ?? (_removeCompany = new RelayCommand(obj => 
                {
                    try
                    {
                        db.Companies.Remove(SelectedCompany);
                        db.SaveChanges();
                        Companies = db.Companies.ToList();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка удаления!");
                    }
                }, obj => SelectedCompany != null));
        }

        public RelayCommand AddCompany
        {
            get => _addCompany ?? (_addCompany = new RelayCommand(obj =>
           {
               db.Companies.Add(new Company()
               {
                   Name = CompanyName,
                   ContractStatus = SelectedContractStatus
               }) ;
               db.SaveChanges();
               Companies = db.Companies.ToList();
           }, obj => ((from i in Companies             // Проверка на существование такого же имени компании
                       where i.Name == CompanyName
                       select i).Count() == 0) && SelectedContractStatus != null && !String.IsNullOrEmpty(CompanyName)));
        }
        #endregion

        public CompaniesViewModel(ApplicationContext db)
        {
            this.db = db;
            Companies = db.Companies.ToList();
            foreach (var item in Companies)
                db.Entry(item).Reference("ContractStatus").Load();
            ContractStatuses = db.ContractStatuses.ToList();
        }
    }
}
