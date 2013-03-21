using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class OrganizationalUnit
    {
        public string DistinguishedName { get; set; }
        public string DisplayName { get; set; }
        public List<String> ComputerNamePrefixes { get; set; }
        public List<String> Groups { get; set; }

        public OrganizationalUnit()
        {
            Groups = new List<string>();
            ComputerNamePrefixes = new List<string>();
        }
    }
}
