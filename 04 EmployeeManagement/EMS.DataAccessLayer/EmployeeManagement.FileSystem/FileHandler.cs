using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace EmployeeManagement.FileSystem
{
    public class FileHandler
    {
        public void SaveEmployee(string jsonString, string id)
        {
            if (File.Exists(@"C:\EmployeeID\ID.Txt"))
            {
                File.AppendAllText(@"C:\EmployeeID\ID.Txt", id + Environment.NewLine);
            }
            else
            {

                File.WriteAllText(@"C:\EmployeeID\ID.Txt", id + Environment.NewLine);
            }

            File.WriteAllText(@"C:\EmployeeDetails\" + id + ".Txt", jsonString);


        }
        public string RetrieveById(String id)
        {
            var jsonString = File.ReadAllText(@"C:\EmployeeDetails\" + id);
            return jsonString;
        }

        public List<string> RetrieveAllIds()
        {

            // var allId = File.ReadAllText(@"C:\EmployeeIDs\AllEmpID.Txt");
            DirectoryInfo dir = new DirectoryInfo(@"C:\EmployeeDetails");
            var files = dir.GetFiles("*.txt");
            List<string> empId = new List<string>();


            foreach (var file in files)
            {
                empId.Add(file.Name);
            }
            return empId;

        }
    }
}
