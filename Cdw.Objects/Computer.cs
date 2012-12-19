using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class Computer
    {
        public string Owner { get; set; }
        public string InstalledBy { get; set; }
        public DateTime InstalledDate { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public string MACAddress { get; set; }
        public string Prefix { get; set; }
        public bool Exists { get; set; }
        public string IPAddress { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public LanguageItem Language { get; set; }
        public string OrganizationalUnit { get; set; }
        public List<String> Groups { get; set; }
        public string BiosGuid { get; set; }
        public string BiosVersion { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string DriverPath { get; set; }
        public bool DHCPReservation { get; set; }

        public Computer()
        {
            Groups = new List<string>();
        }
    }
}
