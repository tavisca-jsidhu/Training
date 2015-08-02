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
using System.Data;
using Tavisca.EmployeeManagement.Model;

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
                SqlCommand command = new SqlCommand("insert_emp_data", connect);
                command.CommandType = CommandType.StoredProcedure;
                if (employee.Remarks == null)
                {
                    command.Parameters.AddWithValue("@title", employee.Title);
                    command.Parameters.AddWithValue("@first_name", employee.FirstName);
                    command.Parameters.AddWithValue("@last_name", employee.LastName);
                    command.Parameters.AddWithValue("@email_id", employee.Email);
                    command.Parameters.AddWithValue("@phone", employee.Phone);
                    command.Parameters.AddWithValue("@password", employee.Password);
                    command.Parameters.AddWithValue("@joining_date", employee.JoiningDate);
                    command.ExecuteNonQuery();
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

        public Model.Remark AddRemark(string employeeId, Remark remark)
        {
            try
            {
                SqlConnection connect = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                connect.Open();
                SqlCommand commandRemark = new SqlCommand("insert_emp_remark", connect);
                commandRemark.CommandType = CommandType.StoredProcedure;
                if (remark != null)
                {
                    commandRemark.Parameters.AddWithValue("@emp_id", employeeId);
                    commandRemark.Parameters.AddWithValue("@text", remark.Text);
                    commandRemark.Parameters.AddWithValue("@timestamp", remark.CreateTimeStamp);
                    commandRemark.ExecuteNonQuery();
                }
                connect.Close();
                return remark;
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

                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("get_emp", conEmployee);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@emp_id", SqlDbType.Int));
                    command.Parameters["@emp_id"].Value = employeeId;

                    conEmployee.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        emp.Id = reader[0].ToString();
                        emp.Title = reader[1].ToString();
                        emp.FirstName = reader[2].ToString();
                        emp.LastName = reader[3].ToString();
                        emp.Email = reader[4].ToString();
                        emp.Phone = reader[5].ToString();
                        emp.JoiningDate = Convert.ToDateTime(reader[7]);
                    }
                    reader.Close();
                }
                conEmployee.Close();

                List<Model.Remark> remarkList = new List<Model.Remark>(); //displaying remarks of employee
                SqlConnection conRemark = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                conRemark.Open();
                using (conRemark)
                {
                    SqlCommand command = new SqlCommand("get_emp_remark", conRemark);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@emp_id", SqlDbType.Int));
                    command.Parameters["@emp_id"].Value = employeeId;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Remark remark = new Model.Remark();
                        remark.Text = reader[1].ToString();
                        remark.CreateTimeStamp = Convert.ToDateTime(reader[2]);
                        remarkList.Add(remark);
                    }
                    emp.Remarks = remarkList;
                    reader.Close();
                }
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

        public List<Model.Remark> GetRemarks(string employeeId)
        {
            try
            {
                List<Model.Remark> remarkList = new List<Model.Remark>();
                SqlConnection conAllEmployee = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (conAllEmployee)
                {
                    SqlCommand command = new SqlCommand("get_emp_remark", conAllEmployee);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@emp_id", SqlDbType.Int));
                    command.Parameters["@emp_id"].Value = employeeId;

                    conAllEmployee.Open();
                    SqlDataReader remarkReader = command.ExecuteReader();
                    while (remarkReader.Read())
                    {
                        Model.Remark remark = new Model.Remark();
                        remark.Text = remarkReader[1].ToString();
                        remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[2]);
                        remarkList.Add(remark);
                    }
                    remarkReader.Close();
                }
                conAllEmployee.Close();
                return remarkList;
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
                SqlConnection conAllEmployee = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                using (conAllEmployee)
                {
                    SqlCommand command = new SqlCommand("get_all", conAllEmployee);
                    command.CommandType = CommandType.StoredProcedure;
                    conAllEmployee.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Model.Employee allEmployee = new Model.Employee();
                        allEmployee.Id = reader[0].ToString();
                        allEmployee.Title = reader[1].ToString();
                        allEmployee.FirstName = reader[2].ToString();
                        allEmployee.LastName = reader[3].ToString();
                        allEmployee.Email = reader[4].ToString();
                        allEmployee.Phone = reader[5].ToString();
                        allEmployee.JoiningDate = Convert.ToDateTime(reader[7]);
                        employeeList.Add(allEmployee);
                    }
                    reader.Close();
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

        public Employee AuthenticateUser(Credentials credentials)
        {
            try
            {
                SqlConnection conEmployee = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                Model.Employee allEmployee = new Model.Employee();
                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("login_credentials", conEmployee);
                    conEmployee.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar));
                    command.Parameters["@EmailId"].Value = credentials.EmailId;
                    command.Parameters["@Password"].Value = credentials.Password;

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        allEmployee.Id = reader[0].ToString();
                        allEmployee.Title = reader[1].ToString();
                        allEmployee.FirstName = reader[2].ToString();
                        allEmployee.LastName = reader[3].ToString();
                        allEmployee.Email = reader[4].ToString();
                        allEmployee.Phone = reader[5].ToString();
                        allEmployee.JoiningDate = Convert.ToDateTime(reader[7]);
                    }
                    else
                    {
                        return null;
                    }
                    conEmployee.Close();
                }
                return allEmployee;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public int UpdatePassword(ChangePassword change)
        {
            try
            {
                SqlConnection conEmployee = new SqlConnection("Data Source=TRAINING13;Initial Catalog=WCF-EMS;Persist Security Info=True;User ID=sa;Password=test123!@#");
                Model.Employee allEmployee = new Model.Employee();
                using (conEmployee)
                {
                    SqlCommand command = new SqlCommand("update_password", conEmployee);
                    SqlCommand command2 = new SqlCommand("get_emp_password", conEmployee);
                    conEmployee.Open();

                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                    command2.Parameters["@EmailId"].Value = change.EmailId;
                    SqlDataReader reader = command2.ExecuteReader();
                    reader.Read();
                    if (reader[0].ToString() == change.OldPassword)
                    {
                        reader.Close();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@EmailId", SqlDbType.NVarChar));
                        command.Parameters.Add(new SqlParameter("@OldPassword", SqlDbType.NVarChar));
                        command.Parameters.Add(new SqlParameter("@NewPassword", SqlDbType.NVarChar));
                        command.Parameters["@EmailId"].Value = change.EmailId;
                        command.Parameters["@OldPassword"].Value = change.OldPassword;
                        command.Parameters["@NewPassword"].Value = change.NewPassword;
                        command.ExecuteNonQuery();
                        conEmployee.Close();
                        return 1;
                    }
                    else
                    {
                        conEmployee.Close();
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return 0;
            }
        }

        private string GetFileName(string employeeId)
        {
            return string.Format(@"{0}\{1}.emp", Configurations.StoragePath, employeeId);
        }
    }
}