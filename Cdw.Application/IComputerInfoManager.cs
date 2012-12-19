using System;
using System.Collections.Generic;
using System.Linq;
using Cdw.Objects;
using System.Text;

namespace Cdw.App
{
    public interface IComputerInfoManager
    {
        ComputerInfoResult GetComputerInfo(Computer computer);
    }
}
