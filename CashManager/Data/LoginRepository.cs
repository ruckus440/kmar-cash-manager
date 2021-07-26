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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CashManager.Data
{
    /// <summary>
    /// This class is a repository of methods used to assist in the maintenance of user logins.
    /// I've assumed that MD5 encryption will suffice.
    /// </summary>
    public class LoginRepository
    {        
        SqlConnection connection = new SqlConnection(Connection.ConnectionString);        

        public byte[] GenerateHashedPassword(string rawPassword)
        {
            byte[] tempSource;
            byte[] tempHash;

            tempSource = ASCIIEncoding.ASCII.GetBytes(rawPassword);
            tempHash = new MD5CryptoServiceProvider().ComputeHash(tempSource);

            return tempHash;
        }

        public bool CompareHashedPasswords(Login login)
        {            
            string query = $"SELECT Password, Status FROM Users WHERE UserName = '{login.UserName}'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            byte[] storedHash = (byte[])command.ExecuteScalar();
            connection.Close();

            byte[] enteredHash = GenerateHashedPassword(login.Password);

            bool valid = storedHash.SequenceEqual(enteredHash);

            return valid;
        }


    }
}
