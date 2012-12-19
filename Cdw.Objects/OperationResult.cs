using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class OperationResult
    {
        public Statics.Result Status { get; set; }
        public List<String> Messages { get; set; }
        public List<String> Errors { get; set; }
        public User ResultAsUser { get; set; }
        public Computer ResultAsComputer { get; set; }
        public string ResultAsString { get; set; }

        public OperationResult()
        {
            Errors = new List<String>();
            Messages = new List<String>();
        }

        public bool HasErrors()
        {
            return Errors.Count > 0;
        }
    }
}
