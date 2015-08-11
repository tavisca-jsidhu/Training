using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Login.Model
{
    public class Result
    {
        public Status ResponseStatus { get; set; }
        public Result()
        {
            this.ResponseStatus = Status.Success;
        }
    }
}
