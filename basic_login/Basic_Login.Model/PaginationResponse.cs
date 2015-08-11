using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Login.Model
{
    public class PaginationResponse : Result
    {
        public Pagination RequestedPagination { get; set; }
    }
}
