using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BL.Exception
{
    public class ValidationException : SystemException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
