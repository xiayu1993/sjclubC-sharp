using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Model
{
    public class T_FunctionAuthority
    {
        public Guid Id { get; set; }
        public Guid BackMenuId { get; set; }
        public string FunctionName { get; set; }
        public int Num { get; set; }
    }
}
