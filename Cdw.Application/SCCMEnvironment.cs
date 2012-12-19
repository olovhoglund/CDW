using System;
using System.Collections.Generic;
using System.Linq;
using TSEnvironmentLib;
using System.Text;

namespace Cdw.App
{
    public class SCCMEnvironment
    {

        public static void SetVariable(string name, string value)
        {
            var env = new TSEnvClassClass();
            env[name] = value;
            env = null;
        }

        public static string GetVariable(string name)
        {
            var env = new TSEnvClassClass();
            return env[name].ToString();
        }
    }
}
