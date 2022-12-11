using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Results.Concrete.ErrorResult
{
    public class ErrorResults : Result
    {
        // torediyi class in konstraktoruna melumat gondermek ucun
        public ErrorResults() : base(false)
        {

        }
        public ErrorResults(string message) : base(false, message)
        {

        }
    }
}
