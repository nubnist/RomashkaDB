using RomashkaBase.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomashkaBase.Model
{
    public class Company : BasePropertyChanged
    {
        private int _id;
        private string _name;
        private ContractStatus _contractStatus;
        public int Id { 
            get => _id;
            set {
                _id = value;
                OnPropertyChanged();
            } }
        public string Name { 
            get => _name;
            set {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ContractStatus ContractStatus { 
            get => _contractStatus;
            set {
                _contractStatus = value;
                OnPropertyChanged();
            }
        }
        public List<User> Users { get; set; }
    }
}
