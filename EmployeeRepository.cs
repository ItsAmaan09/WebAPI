using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace Tutorial_5
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=ADb; User ID=sa; Password=admin@123";
        public IList<Employee> GetEmployees()
        {
            IList<Employee> empList = new List<Employee>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "SELECT * FROM Employee";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.firstName = reader.GetValue(0).ToString();
                        emp.lastName = reader.GetValue(1).ToString();
                        emp.dob = reader.GetValue(2) == null ? null : Convert.ToDateTime(reader.GetValue(2));
                        emp.address = reader.GetValue(3).ToString();
                        emp.gender = reader.GetValue(4).ToString();
                        emp.empId = Convert.ToInt32(reader.GetValue(5));
                        empList.Add(emp);
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return empList;
        }
        public IList<Employee> GetEmployeeById(int Id)
        {
            IList<Employee> empWithId = new List<Employee>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "SELECT * FROM Employee WHERE emp_id = @empId";
                    sqlCommand.Parameters.Add("@empId", SqlDbType.Int).Value = Id;
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        emp.firstName = reader.GetValue(0).ToString();
                        emp.lastName = reader.GetValue(1).ToString();
                        emp.dob = reader.GetValue(2) == null ? null : Convert.ToDateTime(reader.GetValue(2));
                        emp.address = reader.GetValue(3).ToString();
                        emp.gender = reader.GetValue(4).ToString();
                        emp.empId = Convert.ToInt32(reader.GetValue(5));
                        empWithId.Add(emp);
                    }
                    reader.Close();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return empWithId;
        }
        public bool AddEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "INSERT INTO Employee(first_name,last_name,dob,address,gender)VALUES(@firstName,@lastName,@dob,@address,@gender)";
                    sqlCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = emp.firstName;
                    sqlCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = emp.lastName;
                    sqlCommand.Parameters.Add("@dob", SqlDbType.DateTime).Value = emp.dob;
                    sqlCommand.Parameters.Add("@address", SqlDbType.VarChar).Value = emp.address;
                    sqlCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = emp.gender;
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }
        public bool UpdateEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "UPDATE Employee SET first_name = @firstName, last_name = @lastName, dob = @dob, address = @address, gender = @gender WHERE emp_id = @empId";
                    sqlCommand.Parameters.Add("@empId", SqlDbType.Int).Value = emp.empId;
                    sqlCommand.Parameters.Add("@firstName", SqlDbType.VarChar).Value = emp.firstName;
                    sqlCommand.Parameters.Add("@lastName", SqlDbType.VarChar).Value = emp.lastName;
                    sqlCommand.Parameters.Add("@dob", SqlDbType.DateTime).Value = emp.dob;
                    sqlCommand.Parameters.Add("@address", SqlDbType.VarChar).Value = emp.address;
                    sqlCommand.Parameters.Add("@gender", SqlDbType.VarChar).Value = emp.gender;
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        public bool DeleteEmployee(Employee emp)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandText = "DELETE Employee WHERE emp_id = @empId";
                    sqlCommand.Parameters.Add("@empId", SqlDbType.Int).Value = emp.empId;
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int affectedRows = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
    }

}

