using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using laba12.Models;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace laba12.Services
{
    public class PositionService
    {
        public string connectionString = "Data Source=localhost;Initial Catalog=userdb;Integrated Security=True";

        public IEnumerable<Position> GetPositionsList()
        {
            List<Position> getPositionsList = new List<Position>();
            string sqlExpression = "SELECT * FROM PositionsCopy";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connect);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Position position = new Position();
                        position.Id = (int)reader.GetValue(0);
                        position.PositionName = (string)reader.GetValue(1);
                        getPositionsList.Add(position);
                    }
                }

                reader.Close();

                //getPositionsList.Sort(Compare);

                return getPositionsList;
            }
        }

        private int Compare(Position x, Position y)
        {
            if (x.Id > y.Id)
            {
                return 1;
            }

            if (x.Id < y.Id)
            {
                return -1;
            }

            return 0;
        }

        public void InsertPosition(Position model)
        {
            string sqlExpression = $"INSERT INTO PositionsCopy (Position_Name) VALUES ('{model.PositionName}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdatePosition(Position model)
        {
            string sqlExpression = $"UPDATE PositionsCopy SET Position_Name = '{model.PositionName}' WHERE Position_Id = {model.Id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeletePosition(int id)
        {
            string sqlExpression = $"DELETE PositionsCopy WHERE Position_Id = {id}";
            // string sqlReseed = "DBCC CHECKIDENT('PositionsCopy', RESEED)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            //  command = new SqlCommand(sqlReseed, connection);
            //  command.ExecuteNonQuery();
            }
        }

        public Position GetPositionById(int id)
        {
            var model = new Position();
            string sqlExpression = $"SELECT * FROM PositionsCopy WHERE Position_Id = {id}";

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
                        model.PositionName = (string)reader.GetValue(1);
                    }
                }

                reader.Close();
            }
            
            return model;
        }
    }
}
