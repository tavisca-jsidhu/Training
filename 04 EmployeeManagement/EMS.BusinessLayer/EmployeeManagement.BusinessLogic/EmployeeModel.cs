using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using EmployeeManagement.FileSystem;

namespace EmployeeManagement.BusinessLogic
{
    public class EmployeeModel : IEmployeeHandler
    {
        public EmployeeModel(string title, string firstName, string lastName, string email)
        {
            this.Id = "";
            this.Title = title;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Remark = "";
        }
        public string Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }


        public string Email
        {
            get;
            set;
        }

        public String Remark
        {
            get;
            set;
        }

        public string GenerateId()
        {
            string UniqueId = string.Format(@"{0}", Guid.NewGuid());
            return UniqueId;
        }

        public static void InsertEmployeeIntoFile(EmployeeModel employee)
        {

            var jsonString = JsonConvert.SerializeObject(employee);

            FileHandler file = new FileHandler();
            file.SaveEmployee(jsonString, employee.Id);
        }

        public static EmployeeModel GetEmployeeById(string id)
        {
            FileHandler file = new FileHandler();

            EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(file.RetrieveById(id));

            return employeeModel;
        }

        public static List<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> employeeModelList = new List<EmployeeModel>();
            FileHandler file = new FileHandler();
            List<string> empId = file.RetrieveAllIds();
            for (int i = 0; i < empId.Count - 1; i++)
            {
                employeeModelList.Add(GetEmployeeById(empId[i]));

            }
            return employeeModelList;
        }

    }
}
