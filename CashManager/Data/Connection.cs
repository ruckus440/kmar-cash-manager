using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Data
{
    public static class Connection
    {
        public static string ConnectionString { get; } = @"server=DESKTOP-NQP9L02\localhost4444; database=CashManager;User ID=CashManagerAPI;Password=password;";
    }
}
