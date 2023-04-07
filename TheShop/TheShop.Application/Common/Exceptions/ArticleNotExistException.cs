using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Application.Common.Exceptions
{
    public class ArticleNotExistException : Exception
    {
        public ArticleNotExistException() { }

        public ArticleNotExistException(string? message) : base(message)
        {
        }

        public ArticleNotExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
