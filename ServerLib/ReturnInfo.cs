using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerLib
{
    public class ReturnInfo
    {
        public bool IsSuccess { get; set; }
        public string Des { get; set; }
        public Exception Ex { get; set; }
        public ReturnInfo()
        {
            IsSuccess = true;
        }
    }
}
