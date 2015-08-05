using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class PaginationTranslator
    {
        public static Model.Pagination ToDomainModel(this DataContract.Pagination pagination)
        {
            if (pagination == null) return null;
            return new Model.Pagination()
            {
                Count = pagination.Count,
                Remarks = pagination.Remarks == null ? null : pagination.Remarks.Select(remark => remark.ToDomainModel()).ToList()
            };
        }

        public static DataContract.Pagination ToDataContract(this Model.Pagination pagination)
        {
            if (pagination == null) return null;
            return new DataContract.Pagination()
            {
                Count = pagination.Count,
                Remarks = pagination.Remarks == null ? null : pagination.Remarks.Select(remark => remark.ToDataContract()).ToList()
            };
        }
    }
}
