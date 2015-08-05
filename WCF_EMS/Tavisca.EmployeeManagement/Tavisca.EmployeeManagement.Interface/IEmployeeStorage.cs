using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeStorage
    {
        Employee Save(Employee employee);

        List<Remark> GetRemarks(string employeeId);

        Employee Get(string employeeId);

        List<Employee> GetAll();

        Remark AddRemark(string employeeId, Remark remark);

        Employee AuthenticateUser(Credentials credentials);

        int UpdatePassword(ChangePassword change);

        Pagination GetPageData(string employeeId, string pageNumber);
    }
}
