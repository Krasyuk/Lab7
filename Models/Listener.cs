using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCoursesWebApp.Models
{
    public class Listener
    {
        public int ListenerId { get; set; }
        public string NameOfListener { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PassportData { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
