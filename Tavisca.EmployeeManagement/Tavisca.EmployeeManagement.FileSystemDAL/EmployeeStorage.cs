using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Data.SqlClient;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {
        readonly string EXTENSION = ".emp";

        public Model.Employee Save(Model.Employee employee)
        {
            try
            {
                SqlConnection connect = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                connect.Open();

                SqlCommand command = new SqlCommand("insert into emp_data values(@emp_id,@title,@first_name,@last_name,@email_id,@phone,@joining_date)", connect);
                SqlParameter p1 = new SqlParameter("emp_id", employee.Id);
                SqlParameter p2 = new SqlParameter("title", employee.Title);
                SqlParameter p3 = new SqlParameter("first_name", employee.FirstName);
                SqlParameter p4 = new SqlParameter("last_name", employee.LastName);
                SqlParameter p5 = new SqlParameter("email_id", employee.Email);
                SqlParameter p6 = new SqlParameter("phone", employee.Phone);
                SqlParameter p7 = new SqlParameter("joining_date", employee.JoiningDate);

                command.Parameters.Add(p1);
                command.Parameters.Add(p2);
                command.Parameters.Add(p3);
                command.Parameters.Add(p4);
                command.Parameters.Add(p5);
                command.Parameters.Add(p6);
                command.Parameters.Add(p7);

                command.ExecuteNonQuery();
                SqlCommand commandRemark = new SqlCommand("insert into empRemark values(@emp_id,@text)", connect);
                while (employee.Remarks != null)
                {
                    foreach (var empRemark in employee.Remarks)
                    {
                        SqlParameter p8 = new SqlParameter("emp_id", employee.Id);
                        SqlParameter p9 = new SqlParameter("text", empRemark.Text);
                        SqlParameter p10 = new SqlParameter("timestamp", empRemark.CreateTimeStamp);
                        commandRemark.Parameters.Add(p8);
                        commandRemark.Parameters.Add(p9);
                        commandRemark.Parameters.Add(p10);
                        commandRemark.ExecuteNonQuery();
                        return employee;
                    }
                }
                connect.Close();
                return employee;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Model.Employee Get(string employeeId)
        {
            try
            {
                Model.Employee emp = new Model.Employee();
                SqlConnection conEmployee = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                conEmployee.Open();
                SqlCommand cmdEmployee = new SqlCommand("select * from emp_data where emp_id='" + emp.Id + "'", conEmployee);
                SqlDataReader reader = cmdEmployee.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = reader[0].ToString();
                    emp.Title = reader[1].ToString();
                    emp.FirstName = reader[2].ToString();
                    emp.LastName = reader[3].ToString();
                    emp.Email = reader[4].ToString();
                    emp.Phone = reader[5].ToString();
                    emp.JoiningDate = Convert.ToDateTime(reader[6]);
                }
                conEmployee.Close();

                SqlConnection conRemark = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                conRemark.Open();
                SqlCommand cmdGetRemark = new SqlCommand("select * from emp_remark where emp_id='" + emp.Id + "'", conRemark);
                SqlDataReader remarkReader = cmdGetRemark.ExecuteReader();
                List<Model.Remark> remarkList = new List<Model.Remark>();
                while (remarkReader.Read())
                {
                    Model.Remark remark = new Model.Remark();
                    remark.Text = remarkReader[2].ToString();
                    remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[3]);
                    remarkList.Add(remark);
                }
                emp.Remarks = remarkList;
                conEmployee.Close();
                return emp;

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }

        }

        public List<Model.Employee> GetAll()
        {
            try
            {
                List<Model.Employee> employeeList = new List<Model.Employee>();
                Model.Employee allEmployee = new Model.Employee();
                SqlConnection conAllEmployee = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                conAllEmployee.Open();
                SqlCommand cmdAllEmployee = new SqlCommand("select * from emp_data where emp_id", conAllEmployee);
                SqlDataReader readAllEmployee = cmdAllEmployee.ExecuteReader();
                while (readAllEmployee.Read())
                {
                    allEmployee.Id = readAllEmployee[0].ToString();
                    allEmployee.Title = readAllEmployee[1].ToString();
                    allEmployee.FirstName = readAllEmployee[2].ToString();
                    allEmployee.LastName = readAllEmployee[3].ToString();
                    allEmployee.Email = readAllEmployee[4].ToString();
                    allEmployee.Phone = readAllEmployee[5].ToString();
                    allEmployee.JoiningDate = Convert.ToDateTime(readAllEmployee[6]);
                    employeeList.Add(allEmployee);
                }
                conAllEmployee.Close();
                return employeeList;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        private string GetFileName(string employeeId)
        {
            return string.Format(@"{0}\{1}.emp", Configurations.StoragePath, employeeId);
        }
    }
}