using RomashkaBase.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomashkaBase.Model
{
    public class User : BasePropertyChanged
    {
        private int _id;
        private string _name;
        private string _login;
        private string _password;
        private Company _company;
        public int Id {
            get => _id;
            set {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Name { 
            get => _name; 
            set {
                _name = value;
                OnPropertyChanged();
            } 
        }
        public string Login { 
            get => _login;
            set {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Password { get => _password; 
            set {
                _password = value;
                OnPropertyChanged();
            } 
        }
        public Company Company { 
            get => _company; 
            set {
                _company = value;
                OnPropertyChanged();
            } 
        }
    }
}
