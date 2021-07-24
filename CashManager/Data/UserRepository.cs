using CashManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;


namespace CashManager.Data
{
    public class UserRepository
    {
        //private readonly string connectionString = "server=DESKTOP-NQP9L02\\localhost4444; database=CashManager;User ID=CashManagerAPI;Password=password;";
        SqlConnection connection = new SqlConnection(Connection.ConnectionString);
        

        public string GetAllUsers()
        {            
            string query = "SELECT * FROM Users";


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dataTable);
            }
            else
            {
                return "No data found.";
            }
        }

        public string GetUserById(int id)
        {
            string query = $@"SELECT UserId, UserName, DisplayName, Password, Status
                              FROM Users
                              WHERE UserId = {id}";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dataTable);
            }
            else
            {
                return "No data found.";
            }
        }

        public int CreateUser(User user)
        {       
            SqlCommand command = new SqlCommand($@"INSERT Users (UserName, DisplayName, Password, Status)
                                                   VALUES ('{user.UserName}', '{user.DisplayName}', '{user.Password}', '{user.Status}')", connection);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;           
        }

        public int UpdateUser(int id, User user)
        {
            SqlCommand command = new SqlCommand($@"UPDATE Users
                                                   SET UserName = '{user.UserName}', DisplayName = '{user.DisplayName}', Password = '{user.Password}', Status = '{user.Status}'
                                                   WHERE UserId = {id}", connection);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;
        }

        public int DeleteUser(int id)
        {
            SqlCommand command = new SqlCommand($@"DELETE FROM Users                                                   
                                                   WHERE UserId = {id}", connection);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;
        }


    }
}
