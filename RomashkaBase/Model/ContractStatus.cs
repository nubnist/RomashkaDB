using RomashkaBase.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RomashkaBase.Model
{
    public class ContractStatus : BasePropertyChanged
    {
        [Key]
        public string Status { get; set; }
        public List<Company> Companies { get; set; }
    }
}
