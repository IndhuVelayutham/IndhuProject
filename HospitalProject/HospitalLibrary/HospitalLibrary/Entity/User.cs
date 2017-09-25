using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalLibrary.Entity
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UserID { get; set; }

        public Department Department { get; set; }

        public int RoleID { get; set; }

        public Gender Gender { get; set; }
    }
}
