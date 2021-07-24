using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Models
{
    public class AnalysisYear
    {
        public int AnalysisYearId { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public DateTime BubbleUpDate { get; set; }
    }
}
