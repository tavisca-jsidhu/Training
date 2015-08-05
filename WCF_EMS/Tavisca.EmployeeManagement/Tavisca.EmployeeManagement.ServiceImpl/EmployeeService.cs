using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Translator;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeManager manager)
        {
            _manager = manager;
        }

        IEmployeeManager _manager;

        public DataContract.EmployeeResponse Get(string employeeId)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.Get(employeeId);
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

        public EmployeeListResponse GetAll()
        {
            DataContract.EmployeeListResponse response = new DataContract.EmployeeListResponse();
            try
            {
                var result = _manager.GetAll();
                if (result == null) return null;
                response.RequestedEmployeeList = result.Select(employee => employee.ToDataContract()).ToList();
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

        public RemarkListResponse GetRemarks(string employeeId)
        {
            DataContract.RemarkListResponse response = new DataContract.RemarkListResponse();
            try
            {
                var result = _manager.GetRemarks(employeeId);
                if (result == null) return null;
                response.RequestedRemarkList = result.Select(employee => employee.ToDataContract()).ToList();
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

        public DataContract.PaginationResponse GetPageData(string employeeId, string pageNumber)
        {
            DataContract.PaginationResponse response = new DataContract.PaginationResponse();
            try
            {
                var result = _manager.GetPageData(employeeId, pageNumber);
                if (result == null) return null;
                response.RequestedPagination = result.ToDataContract();
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
