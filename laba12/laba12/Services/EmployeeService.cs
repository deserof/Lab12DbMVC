using laba12.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace laba12.Services
{
    public class EmployeeService
    {
        public string connectionString = "Data Source=localhost;Initial Catalog=userdb;Integrated Security=True";

        public IEnumerable<Employee> GetEmployeesList()
        {
            List<Employee> getEmployeesList = new List<Employee>();
            string sqlExpression = "SELECT * FROM EmployeesCopy ORDER BY Employee_Id";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connect);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();


                        employee.Id = (int)reader.GetValue(0);

                        if(reader.GetValue(1) is DBNull)
                        {
                            employee.DepartmentId = null;
                        }
                        else
                        {
                            employee.DepartmentId = (int)reader.GetValue(1);
                        }

                        if (reader.GetValue(2) is DBNull)
                        {
                            employee.PositionId = null;
                        }
                        else
                        {
                            employee.PositionId = (int)reader.GetValue(2);
                        }

                        if(reader.GetValue(3) is DBNull)
                        {
                            employee.DateOfHiring = null;
                        }
                        else
                        {
                            employee.DateOfHiring = (DateTime)reader.GetValue(3);
                        }

                        if (reader.GetValue(4) is DBNull)
                        {
                            employee.DateOfFiring = null;
                        }
                        else
                        {
                            employee.DateOfFiring = (DateTime)reader.GetValue(4);
                        }

                        employee.FirstName = (string)reader.GetValue(5);
                        employee.LastName = (string)reader.GetValue(6);
                        employee.MiddleName = (string)reader.GetValue(7);
                        employee.Gender = (string)reader.GetValue(8);
                        employee.PassportNumber = (string)reader.GetValue(9);
                        employee.Address = (string)reader.GetValue(10);
                        employee.Phone = (string)reader.GetValue(11);

                        getEmployeesList.Add(employee);
                    }
                }

                reader.Close();

                return getEmployeesList;
            }
        }

        public void InsertEmployee(Employee model)
        {
            string sqlExpression = $"INSERT INTO EmployeesCopy (Department_Id, Position_Id, Date_Of_Hiring, Date_Of_Firing, FirstName," +
                $" LastName, MiddleName, Gender, Passport_Number, Adress, Phone) VALUES ({model.DepartmentId}, {model.PositionId}, " +
                $"'{model.DateOfHiring}', '{model.DateOfHiring}', '{model.FirstName}', '{model.LastName}', '{model.MiddleName}'," +
                $" '{model.Gender}', '{model.PassportNumber}', '{model.Address}', '{model.Phone}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee model)
        {
            string sqlExpression = $"UPDATE EmployeesCopy SET FirstName = '{model.FirstName}', LastName = '{model.LastName}', MiddleName = " +
                $"'{model.MiddleName}', Adress = '{model.Address}', Phone = '{model.Phone}'" +
                $"WHERE Employee_Id = {model.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            string sqlExpression = $"DELETE EmployeesCopy WHERE Employee_Id = {id}";
            // string sqlReseed = "DBCC CHECKIDENT('EmployeesCopy', RESEED)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                //  command = new SqlCommand(sqlReseed, connection);
                //  command.ExecuteNonQuery();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            var model = new Employee();
            string sqlExpression = $"SELECT * FROM EmployeesCopy WHERE Employee_Id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.Id = (int)reader.GetValue(0);

                        if (reader.GetValue(1) is DBNull)
                        {
                            model.DepartmentId = null;
                        }
                        else
                        {
                            model.DepartmentId = (int)reader.GetValue(1);
                        }

                        if (reader.GetValue(2) is DBNull)
                        {
                            model.PositionId = null;
                        }
                        else
                        {
                            model.PositionId = (int)reader.GetValue(2);
                        }

                        if (reader.GetValue(3) is DBNull)
                        {
                            model.DateOfHiring = null;
                        }
                        else
                        {
                            model.DateOfHiring = (DateTime)reader.GetValue(3);
                        }

                        if (reader.GetValue(4) is DBNull)
                        {
                            model.DateOfFiring = null;
                        }
                        else
                        {
                            model.DateOfFiring = (DateTime)reader.GetValue(4);
                        }

                        model.FirstName = (string)reader.GetValue(5);
                        model.LastName = (string)reader.GetValue(6);
                        model.MiddleName = (string)reader.GetValue(7);
                        model.Gender = (string)reader.GetValue(8);
                        model.PassportNumber = (string)reader.GetValue(9);
                        model.Address = (string)reader.GetValue(10);
                        model.Phone = (string)reader.GetValue(11);
                    }
                }

                reader.Close();
            }

            return model;
        }
    }
}
