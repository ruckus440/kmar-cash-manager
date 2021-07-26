/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Data
{
    /// <summary>
    /// This class is simply used to centrally store the connection string, so changes can be easily made if needed.
    /// </summary>
    public static class Connection
    {
        public static string ConnectionString { get; } = @"server=DESKTOP-NQP9L02\localhost4444; database=CashManager;User ID=CashManagerAPI;Password=password;";
    }
}
