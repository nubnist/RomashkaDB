using System;
using System.Collections.Generic;
using System.Text;

namespace RomashkaBase.Model
{
    /// <summary>
    /// Для связи многие ко многим
    /// </summary>
    public class CompanyUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
