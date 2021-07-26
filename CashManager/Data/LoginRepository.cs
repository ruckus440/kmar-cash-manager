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
    public class LoginRepository
    {
        SqlConnection connection = new SqlConnection(Connection.ConnectionString);

        static string salt = "mysalt";

        public byte[] GenerateHashedPassword(string rawPassword)
        {
            byte[] tempSource;
            byte[] tempHash;

            tempSource = ASCIIEncoding.ASCII.GetBytes(rawPassword);
            tempHash = new MD5CryptoServiceProvider().ComputeHash(tempSource);

            return tempHash;


            //string rawSalted = rawPassword + salt;

            //using (SHA256 sha256 = SHA256.Create())
            //{
            //    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawSalted));

            //    return bytes;
            //}
        }

        public bool CompareHashedPasswords(Login login)
        {
            string query = $"SELECT Password, Status FROM Users WHERE UserName = '{login.UserName}'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            byte[] storedHash = (byte[])command.ExecuteScalar();
            connection.Close();

            bool valid = false;

            byte[] enteredHash = GenerateHashedPassword(login.Password);

            if (enteredHash.Length == storedHash.Length)
            {
                int i = 0;

                while ((i < enteredHash.Length) && enteredHash[i] == storedHash[i])
                {
                    i += 1;
                }
                if (i == enteredHash.Length)
                {
                    valid =  true;
                }
            }

            return valid;
        }


    }
}
