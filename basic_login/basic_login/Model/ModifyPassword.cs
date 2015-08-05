using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModifyPassword
    {
        public string EmailId { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
