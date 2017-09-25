using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaveLibrary.Exceptions
{
    public class LeaveException:ApplicationException
    {
        public LeaveException()
            :base()
        {

        }
        public LeaveException(string message)
            :base(message)
        {

        }
    }
}
