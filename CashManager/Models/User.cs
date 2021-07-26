/*
 * User.cs
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
    /// User model to represent users as stored in the database.
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
