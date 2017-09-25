using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalExceptionLayer
{
    public class HospitalException:ApplicationException
    {
        public HospitalException()
            : base()
        {
        }
        public HospitalException(string Message)
            : base(Message)
        {
        }
        public HospitalException(string Message,Exception innerException)
            : base(Message, innerException)
        {
        }
    }
}
