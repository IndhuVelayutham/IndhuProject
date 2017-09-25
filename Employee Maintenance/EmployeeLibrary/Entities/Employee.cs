using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DOJ { get; set; }
        public DesignationType Designation { get; set; }
    }
}
