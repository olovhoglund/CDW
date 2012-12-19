using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class AuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public Computer Computer { get; set; }

        public AuthenticationRequest()
        {
            Computer = new Computer();
        }
    }
}
