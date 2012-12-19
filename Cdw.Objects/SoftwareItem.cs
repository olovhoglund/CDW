using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cdw.Objects
{
    [Serializable]
    public class SoftwareItem
    {
        public string DisplayName { get; set; }
        public string Group { get; set; }
        public string SCCMPackageId { get; set; }
        public string SCCMProgram { get; set; }
        public bool Selected { get; set; }
    }
}
