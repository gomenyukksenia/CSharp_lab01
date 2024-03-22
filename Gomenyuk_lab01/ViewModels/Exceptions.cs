using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.CSharp2024.Gomenyuk_lab01.ViewModels
{
    internal class WrongEmailException: Exception
    {
        public WrongEmailException(string reason)
            : base(reason)
        {
        }
    }


    internal class WrongNameException : Exception
    {
        public WrongNameException(string reason)
            : base(reason)
        {
        }
    }
}
