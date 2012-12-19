using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdw.Objects
{
    [Serializable]
    public class User
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}
