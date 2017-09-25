using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerDetails.Entities
{
    public class Customer
    {

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime DOB { get; set; }
        public string CustomerItems { get; set; }
        public GenderType Gender { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerPinCode { get; set; }
        public string CustomerEmailId { get; set; }
        public string CustomerListOfItems { get; set; }
        public string CustomerTown { get; set; }
        public string CustomerVillage { get; set; }
        public string Products { get; set; }
        public int CustomerMPTMarks { get; set; }
        public int CustomerMTTMarks { get; set; }
        public int CustomerAssignment { get; set; }
        public int CustomerTotalMarks { get; set; }
        public string CustomerGrade { get; set; }
        public int CustomerAge { get; set; }
        public CustomerBloodGroupType CustomerBloodGroup { get; set; }

    }
}



