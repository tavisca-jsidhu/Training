using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.DataContract
{
    [DataContract]
    public class Pagination
    {
        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public List<Remark> Remarks { get; set; }
    }
}
