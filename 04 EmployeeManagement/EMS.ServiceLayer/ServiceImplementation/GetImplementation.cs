using DataContract;
using EmployeeManagement.BusinessLogic;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Translator;

namespace ServiceImplementation
{
    class GetImplementation : IEmployeeService
    {
        public Employee Get(string id)
        {
            EmployeeModel employeeModel = EmployeeModel.GetEmployeeById(id);
            return EmployeeTranslator.TranslateToEmployee(employeeModel);
        }

        public List<Employee> GetAll()
        {

            List<EmployeeModel> employeeModelList = EmployeeModel.GetAllEmployees();

            return EmployeeTranslator.TranslateToEmployee(employeeModelList);

        }
    }
}
