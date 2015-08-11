﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Basic_Login.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public List<Remark> Remarks { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.FirstName))
                throw new Exception("FirstName cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(this.Email))
                throw new Exception("Email cannot be null or empty.");
        }

        public static EmployeeResponse AddEmployee(Employee employee)
        {
            HttpClient client = new HttpClient();
            var url = System.Configuration.ConfigurationManager.AppSettings["EmployeeManagementServiceURL"];
            var empResponse = client.UploadData<Employee, EmployeeResponse>(url + "/employee", employee);
            return empResponse;
        }
    }
}