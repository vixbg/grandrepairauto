using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.Models
{
    public class InitialPasswordVM
    {
        public bool IsValid { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }

    public class InitialPasswordInputVM : InitialPasswordVM
    {
        public string Password { get;set; }
        public string RePassword { get; set; }
    }
}
