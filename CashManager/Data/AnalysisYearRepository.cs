/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 */
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
    /// <summary>
    /// This class is a repository of methods used for the maintenance of AnalysisYears in the database.
    /// </summary>
    public class AnalysisYearRepository
    {
        SqlConnection connection = new SqlConnection(Connection.ConnectionString);

        public string GetAllAnalysisYears()
        {
            string query = "SELECT * FROM AnalysisYears";

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

        public string GetAnalysisYearByAnalysisYearId(int id)
        {
            string query = $@"SELECT AnalysisYearId, UserId, Year, BubbleUpDate
                              FROM AnalysisYears
                              WHERE AnalysisYearId = {id}";

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

        public int CreateAnalysisYear(AnalysisYear year)
        {
            try
            {
                SqlCommand command = new SqlCommand($@"INSERT AnalysisYears (UserId, Year, BubbleUpDate)
                                                   VALUES ('{year.UserId}', '{year.Year}', '{year.BubbleUpDate}')", connection);

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

        public int UpdateAnalysisYear(int id, AnalysisYear year)
        {
            SqlCommand command = new SqlCommand($@"UPDATE AnalysisYears
                                                   SET UserId = '{year.UserId}', Year = '{year.Year}', BubbleUpDate = '{year.BubbleUpDate}'
                                                   WHERE AnalysisYearId = {id}", connection);


            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;
        }

        public int DeleteAnalysisYear(int id)
        {
            SqlCommand command = new SqlCommand($@"DELETE FROM AnalysisYears
                                                   WHERE AnalysisYearId = {id}", connection);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();

            return i;
        }
    }
}
