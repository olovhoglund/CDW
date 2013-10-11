using System;
using System.Collections.Generic;
using System.Linq;
using Cdw.Objects;
using System.Text;

namespace Cdw.App
{
    public class ComputerInfoManager : IComputerInfoManager
    {

        public delegate ComputerInfoResult GetComputerInfoAsync(Computer computer);


        public ComputerInfoResult GetComputerInfo(Computer computer)
        {
            var powershell = new Powershell.Manager("");
            var result = new OperationResult();
            result = powershell.GetComputerBIOSInfo(ref computer);
            var response = new ComputerInfoResult(computer, result);
            return response;
        }
    
    }
}
