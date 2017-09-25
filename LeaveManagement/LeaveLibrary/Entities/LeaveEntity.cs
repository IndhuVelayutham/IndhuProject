using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveLibrary.Entities
{
    public class LeaveEntity
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string Comments { get; set; }
    }
}
