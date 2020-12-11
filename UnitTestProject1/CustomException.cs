using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class CustomException : Exception
    {
        public CustomException()
        {

        }
        public CustomException(String message) : base(message)
        {

        }
        public CustomException(String message, Exception inner) : base(message, inner)
        {

        }

        public CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}