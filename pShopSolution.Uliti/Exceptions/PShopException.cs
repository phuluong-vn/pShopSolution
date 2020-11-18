using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Utilities.Exceptions
{
    public class PShopException : Exception
    {
        public PShopException()
        {
        }

        public PShopException(string message)
            : base(message)
        {
        }

        public PShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
