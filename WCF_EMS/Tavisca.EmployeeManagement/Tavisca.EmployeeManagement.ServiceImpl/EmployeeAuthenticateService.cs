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

        public DataContract.Credentials AuthenticateUser(DataContract.Credentials credentials)
        {
            try
            {
                var result = _manager.AuthenticateUser(credentials.ToDomainModel());
                if (result == null) return null;
                return result.ToDataContract();
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                throw newEx;
            }
        }
    }
}
