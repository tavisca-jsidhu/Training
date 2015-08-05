using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeAuthenticateManager : IEmployeeAuthenticateManager
    {
        public EmployeeAuthenticateManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee AuthenticateUser(Credentials credentials)
        {
            return _storage.AuthenticateUser(credentials);
        }


        public int UpdatePassword(ChangePassword change)
        {
            return _storage.UpdatePassword(change);
        }
    }
}
