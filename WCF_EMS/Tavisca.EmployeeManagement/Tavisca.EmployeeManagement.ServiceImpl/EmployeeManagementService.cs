using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public EmployeeManagementService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.EmployeeResponse Create(DataContract.Employee employee)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Create(employee.ToDomainModel());
                if (result == null) return null;
                response.RequestedEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }
        }

        public DataContract.RemarkResponse AddRemark(string employeeId, DataContract.Remark remark)
        {
            DataContract.RemarkResponse response = new DataContract.RemarkResponse();
            try
            {
                var result = _manager.AddRemark(employeeId, remark.ToDomainModel());
                if (result == null) return null;
                response.RequestedRemark = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }
        }
    }
}