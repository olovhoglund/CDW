using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdw.Objects
{
    [Serializable]
    public class AuthenticationResponse
    {
        public DeploymentContext DeploymentContext { get; set; }
        public UserContext User { get; set; }
        public List<String> Errors { get; set; }
        public List<String> Messages { get; set; }
        public Statics.Result Result { get; set; }

        public AuthenticationResponse()
        {
            Errors = new List<string>();
            Messages = new List<string>();
            DeploymentContext = new DeploymentContext();
        }
    }
}
