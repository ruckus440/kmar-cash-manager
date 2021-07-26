/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Models
{
    /// <summary>
    /// Login model to represent a user-submitted username and password for logging in. Both are stored as strings.
    /// </summary>
    public class Login
    {
        public Login(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
