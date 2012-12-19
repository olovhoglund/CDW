using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class DeploymentContext
    {
        public string Domain { get; set; }
        public string DomainController { get; set; }
        [XmlArray(ElementName = "OrganizationalUnits")]
        public List<OrganizationalUnit> OrganizationalUnits { get; set; }
        public bool ForceGeneratedName { get; set; }

        public DeploymentContext()
        {
            OrganizationalUnits = new List<OrganizationalUnit>();
        }
    }
}
