using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeroWaste.Models
{
    public class Appuser:IdentityUser
    {
        public string Morada { get; set; }
        public string tipo { get; set; }

        public int Numero { get; set; }


        public int rendimento { get; set; }
    }
}
