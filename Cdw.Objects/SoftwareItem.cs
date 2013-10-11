using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdw.Objects
{
    public enum InstallationType
    {
        Package,
        Application
    }


    [Serializable]
    public class SoftwareItem
    {
        public InstallationType SCCMInstallationType {get;set;}

        public string DisplayName { get; set; }
        public string Group { get; set; }

        //Packages only
        public string SCCMPackageId { get; set; }
        public string SCCMProgram { get; set; }

        //Applications only
        public string SCCMName { get; set; }

        public bool Selected { get; set; }
    }
}
