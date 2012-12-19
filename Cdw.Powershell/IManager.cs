using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cdw.Objects;
using System.Threading.Tasks;

namespace Cdw.Powershell
{
    public interface IManager
    {
        OperationResult CreateComputer(Computer computer);
        OperationResult GetComputer(String computername);
        OperationResult GetUser(String username);
        OperationResult GetComputerBIOSInfo(ref Computer computer);
        OperationResult GetComputerNICInfo(ref Computer computer);
        OperationResult GetComputerSystemInfo(ref Computer computer);
    }
}
