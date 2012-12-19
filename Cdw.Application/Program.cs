using System;
using System.Collections.Generic;
using System.Linq;
using Cdw.Objects;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cdw.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static LoginContext LoginContext { get; set; }
        public static DeploymentContext DeploymentContext { get; set; }
        public static Computer Computer { get; set; }
        public static UserContext User { get; set; }
        public static List<SoftwareItem> Software { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash());
        }
    }
}
