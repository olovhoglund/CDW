using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class UserContext
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
    }
}
