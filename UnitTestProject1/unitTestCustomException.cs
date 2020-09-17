using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class unitTestCustomException : Exception
    {
        public unitTestCustomException()
        {

        }
        public unitTestCustomException(String message) : base(message)
        {

        }
        public unitTestCustomException(String message, Exception inner) : base(message, inner)
        {

        }

        public unitTestCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}