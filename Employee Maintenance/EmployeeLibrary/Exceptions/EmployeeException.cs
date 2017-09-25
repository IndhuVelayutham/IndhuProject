using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLibrary.Exceptions
{
    public class EmployeeException : ApplicationException
    {
        public EmployeeException()
            : base()
        {

        }

        public EmployeeException(string message)
            : base(message)
        {

        }
    }
}
