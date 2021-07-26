/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 */

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
using System.Text.Json;

namespace CashManager.Data
{
    /// <summary>
    /// This class is a repository of methods used in the mantenaince of User database records.
    /// Assumptions I've made with this class, as well as the other database repo classes, include...
    ///     All CRUD operations are necessary.
    ///     Reading a User by ID is also necessary.
    /// </summary>
public class UserRepository
    {        
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
            LoginRepository loginRepo = new LoginRepository();
            var password = loginRepo.GenerateHashedPassword(user.Password);

            using (SqlCommand command = new SqlCommand($@"INSERT Users (UserName, DisplayName, Password, Status)
                                                          VALUES ('{user.UserName}', '{user.DisplayName}', @pword, '{user.Status}')", connection))
            {
                SqlParameter param = command.Parameters.Add("@pword", SqlDbType.Binary);
                param.Value = password;

                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                return i;
            }
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
