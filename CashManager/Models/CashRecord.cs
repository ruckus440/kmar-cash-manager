using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Models
{
    public class CashRecord
    {
        public int CashRecordId { get; set; }
        public int AnalysisYearId { get; set; }
        public int TransactionCodeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
