using laba12.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace laba12.Services
{
    public class DepartmentService
    {
        public string connectionString = "Data Source=localhost;Initial Catalog=userdb;Integrated Security=True";

        public IEnumerable<Department> GetDepartmentsList()
        {
            List<Department> getDepartmentsList = new List<Department>();
            string sqlExpression = "SELECT * FROM DepartmentsCopy";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connect);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Department Department = new Department();
                        Department.Id = (int)reader.GetValue(0);
                        Department.Address = (string)reader.GetValue(1);
                        Department.CreatedDate = (DateTime)reader.GetValue(2);
                        getDepartmentsList.Add(Department);
                    }
                }

                reader.Close();

                return getDepartmentsList;
            }
        }

        public void InsertDepartment(Department model)
        {
            string sqlExpression = $"INSERT INTO DepartmentsCopy (Adress, CreatedTime) VALUES ('{model.Address}', '{model.CreatedDate}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(Department model)
        {
            string sqlExpression = $"UPDATE DepartmentsCopy SET Adress = '{model.Address}', CreatedTime = {model.CreatedDate} " +
                $"WHERE Department_Id = {model.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDepartment(int id)
        {
            string sqlExpression = $"DELETE DepartmentsCopy WHERE Department_Id = {id}";
            // string sqlReseed = "DBCC CHECKIDENT('DepartmentsCopy', RESEED)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                //  command = new SqlCommand(sqlReseed, connection);
                //  command.ExecuteNonQuery();
            }
        }

        public Department GetDepartmentById(int id)
        {
            var model = new Department();
            string sqlExpression = $"SELECT * FROM DepartmentsCopy WHERE Department_Id = {id}";

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
                        model.Address = (string)reader.GetValue(1);
                        model.CreatedDate = (DateTime)reader.GetValue(2);
                    }
                }

                reader.Close();
            }

            return model;
        }
    }
}
