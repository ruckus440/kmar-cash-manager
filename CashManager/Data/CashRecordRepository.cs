using CashManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Data
{
    public class CashRecordRepository
    {
        SqlConnection connection = new SqlConnection(Connection.ConnectionString);

        public string GetAllCashRecords()
        {
            string query = "SELECT * FROM CashRecords";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dataTable);
            }
            else
            {
                return "No data found";
            }
        }

        public string GetCashRecordById(int id)
        {
            string query = $@"SELECT CashRecordId, AnalysisYearId, TransactionCodeId, TransactionDate, Description, Amount, LastUpdated, LastUpdatedBy 
                              FROM CashRecords
                              WHERE CashRecordId = {id}";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dataTable);
            }
            else
            {
                return "No data found.";
            }
        }

        public int CreateCashRecord(CashRecord record)
        {
            try
            {
                SqlCommand command = new SqlCommand($@"INSERT CashRecords (AnalysisYearId, TransactionCodeId, TransactionDate, Description, Amount, LastUpdated, LastUpdatedBy)
                                                       VALUES ('{record.AnalysisYearId}', 
                                                               '{record.TransactionCodeId}', 
                                                               '{record.TransactionDate}', 
                                                               '{record.Description}',
                                                               '{record.Amount}',
                                                                CURRENT_TIMESTAMP,
                                                               '{record.LastUpdatedBy}'
                                                               )", connection);

                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();

                return i;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UpdateCashRecord(int id, CashRecord record)
        {
            SqlCommand command = new SqlCommand($@"UPDATE CashRecords
                                                   SET                                                    
                                                       AnalysisYearId = '{record.AnalysisYearId}', 
                                                       TransactionCodeId = '{record.TransactionCodeId}', 
                                                       TransactionDate = '{record.TransactionDate}', 
                                                       Description = '{record.Description}',
                                                       Amount = '{record.Amount}',
                                                       LastUpdated =  CURRENT_TIMESTAMP,
                                                       LastUpdatedBy = '{record.LastUpdatedBy}'                                                   
                                                   WHERE CashRecordId = {id}", connection);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;
        }

        public int DeleteCashRecord(int id)
        {
            SqlCommand command = new SqlCommand($@"DELETE FROM CashRecords
                                                   WHERE CashRecordId = {id}", connection);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;
        }

    }
}
