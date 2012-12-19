using System;
using System.Collections.Generic;
using System.Linq;
using Cdw.Objects;
using System.Text;

namespace Cdw.App
{
    public class ComputerInfoResult
    {
        public Computer Computer { get; set; }
        public OperationResult Result { get; set; }

        public ComputerInfoResult(Computer computer, OperationResult result)
        {
            Computer = computer;
            Result = result;
        }
    }
}
