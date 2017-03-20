using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockEmulator.Models
{
    public class SignUpModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string FirstSecurityQuestion { get; set; }
        public string FirstSecurityAnswer { get; set; }
        public string SecondSecurityQuestion { get; set; }
        public string SecondSecurityAnswer { get; set; }
    }
}
