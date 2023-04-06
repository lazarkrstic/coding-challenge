using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Application.Common.Exceptions
{
    public class CouldNotOrderArticleException : Exception
    {
        public CouldNotOrderArticleException() { }  
        
        public CouldNotOrderArticleException(string message) : base(message) { }

    }
}
