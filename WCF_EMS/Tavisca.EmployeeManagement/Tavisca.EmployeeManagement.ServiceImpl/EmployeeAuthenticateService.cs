using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;
using Tavisca.EmployeeManagement.DataContract;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeAuthenticateService : IEmployeeAuthenticateService
    {
        IEmployeeAuthenticateManager _manager;

        public EmployeeAuthenticateService(IEmployeeAuthenticateManager manager)
        {
            _manager = manager;
        }

        public DataContract.EmployeeResponse AuthenticateUser(DataContract.Credentials credentials)
        {
            DataContract.EmployeeResponse response = new DataContract.EmployeeResponse();
            try
            {
                var result = _manager.AuthenticateUser(credentials.ToDomainModel());
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

        public DataContract.ChangePasswordResponse UpdatePassword(DataContract.ChangePassword change)
        {
            DataContract.ChangePasswordResponse response = new DataContract.ChangePasswordResponse();
            try
            {
                var result = _manager.UpdatePassword(change.ToDomainModel());
                DataContract.Employee emp = new DataContract.Employee();
                if (result != 0)
                {
                    return response;
                }
                else
                {
                    throw new System.Exception("You entered wrong password.");
                }
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
