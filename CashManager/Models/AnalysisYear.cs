/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 */
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Models
{
    /// <summary>
    /// AnalysisYear model to respresent analysis years as stored in the database.
    /// </summary>
    public class AnalysisYear
    {
        public int AnalysisYearId { get; set; }
        public int UserId { get; set; }
        public int Year { get; set; }
        public DateTime BubbleUpDate { get; set; }
    }
}
