using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Results
{
    public class Result : IResult
    {



        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public static Result Success(string message = "")
        {
            return new Result { Succeeded = true, Message = message };
        }

        public static Result Failure(string message)
        {
            return new Result { Succeeded = false, Message = message };
        }
    }
}
