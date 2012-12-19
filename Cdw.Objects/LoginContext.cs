using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class LoginContext
    {
        public string Domain { get; set; }
        public string DomainController { get; set; }
    }
}
