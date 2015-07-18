using DataContract;
using EmployeeManagement.BusinessLogic;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator;

namespace ServiceImplementation
{
    public class PostImplementation : IEmployeeManagementService
    {
        public Employee Create(Employee employee)
        {
            EmployeeModel employeeModel = EmployeeTranslator.EmployeeModelGenerator(employee);
            string id = employeeModel.GenerateId();
            employeeModel.Id = id;
            EmployeeModel.InsertEmployeeIntoFile(employeeModel);
            return employee;
        }

        public Remark AddRemark(string employeeId, Remark remark)
        {
            RemarkModel remarkModel = EmployeeTranslator.RemarkModelGenerator(remark);
            string timeStamp = remarkModel.GenerateUtcTime();
            remarkModel.UtcTime = timeStamp;
            RemarkModel.InsertRemarkIntoFile(remarkModel, employeeId);
            return remark;
        }
    }
}
