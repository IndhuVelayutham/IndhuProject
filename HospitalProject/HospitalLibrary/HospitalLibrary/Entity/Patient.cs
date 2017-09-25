using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.Entity
{
   public class Patient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Emergency { get; set; }
    }
}
