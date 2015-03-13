using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Model
{
    public class T_BackMenu
    {
        public Guid Id { get; set; }
        public Guid ParentID { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
        public int Num { get; set; }
    }
}
