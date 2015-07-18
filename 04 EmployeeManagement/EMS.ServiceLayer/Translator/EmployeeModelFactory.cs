using EmployeeManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class EmployeeModelFactory
    {
        public static IEmployeeHandler CreateInstance(string title, string firstName, string lastName, string email)
        {
            var employeeHandler = new EmployeeModel(title, firstName, lastName, email);
            return employeeHandler;
        }
    }
}
