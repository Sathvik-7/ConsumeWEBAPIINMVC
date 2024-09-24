using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWEBAPIINMVC.Models
{
    public class Employee
    {
        public int Eno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public Nullable<int> Salary { get; set; }
        public string Dname { get; set; }
    }
}