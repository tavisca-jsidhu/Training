using DataContract;
using EmployeeManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Translator
{
    public static class EmployeeTranslator
    {
        public static EmployeeModel EmployeeModelGenerator(Employee employee)
        {

            var employeeModel = EmployeeModelFactory.CreateInstance(employee.Title, employee.FirstName, employee.LastName, employee.Email);

            /*   employeeModel.FirstName = employee.FirstName;
               employeeModel.LastName = employee.LastName;
               employeeModel.Email = employee.Email;
             */
            return employeeModel as EmployeeModel;  //........checkpoint for error..........
        }

        public static RemarkModel RemarkModelGenerator(Remark remark)
        {
            var remarkModel = RemarkModelFactory.CreateInstance(remark.Text);
            //To Do: Wrapping
            //  return remarkModel;
            return remarkModel as RemarkModel;
        }

        public static Employee TranslateToEmployee(EmployeeModel employeeModel)
        {
            Employee employeeDataContractObject = new Employee();
            employeeDataContractObject.Id = employeeModel.Id;
            employeeDataContractObject.Title = employeeModel.Title;
            employeeDataContractObject.FirstName = employeeModel.FirstName;
            employeeDataContractObject.LastName = employeeModel.LastName;
            employeeDataContractObject.Email = employeeModel.Email;
            employeeDataContractObject.EmployeeRemark = employeeModel.Remark;

            return employeeDataContractObject;
        }

        public static List<Employee> TranslateToEmployee(List<EmployeeModel> employeeModelList)
        {
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < employeeModelList.Count - 1; i++)
            {
                Employee employeeDataContractObject = new Employee();
                employeeDataContractObject.Id = employeeModelList[i].Id;
                employeeDataContractObject.Title = employeeModelList[i].Title;
                employeeDataContractObject.FirstName = employeeModelList[i].FirstName;
                employeeDataContractObject.LastName = employeeModelList[i].LastName;
                employeeDataContractObject.Email = employeeModelList[i].Email;
                employeeDataContractObject.EmployeeRemark = employeeModelList[i].Remark;
                employees.Add(employeeDataContractObject);
            }
            return employees;
        }
    }
}
