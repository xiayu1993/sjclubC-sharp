using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SJmedia.Model
{
    public class T_Users
    {
        public Guid Id { get; set; }
        public string TrueName { get; set; }        //真实姓名
        public string Name { get; set; }            //昵称
        public string Account { get; set; }
        public string Password { get; set; }
        public bool? Sex { get; set; }
        public string Birthday { get; set; }
        public string Introducation { get; set; }
        public bool IsInSchool { get; set; }
        public Int64? Number { get; set; }
        public string Academy { get; set; }
        public Guid Status { get; set; }
    }
}
