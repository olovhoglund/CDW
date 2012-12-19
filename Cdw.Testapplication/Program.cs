using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Cdw.Objects;
using System.Threading.Tasks;

namespace Cdw.Testapplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WCFService.ServiceClient();
            var result = client.GetSoftware();
            var test = "";
        }
    }
}
