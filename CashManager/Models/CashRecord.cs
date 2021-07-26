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
    /// CashRecord model to respresent cash records as stored in the database.
    /// </summary>
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
