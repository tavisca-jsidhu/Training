using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Login.Model
{
    public class Status
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public static Status Success { get { return new Status() { Code = "200", Message = "Success" }; } }
    }
}
