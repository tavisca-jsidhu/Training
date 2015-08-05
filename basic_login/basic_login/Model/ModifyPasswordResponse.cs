using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModifyPasswordResponse : Result
    {
        public ModifyPassword RequestedModifyPassword { get; set; }
    }
}
