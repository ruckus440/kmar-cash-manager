﻿/*
 * Author: Mike Ruckert
 * Date: 7/26/2021
 * Submitted for consideration of the position of Programmer and Systems Developer at K-MAR-105 Association.
 */
using CashManager.Data;
using CashManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Controllers
{
    /// <summary>
    /// This class is a controller for the "api/records" endpoint.
    /// I've assumed the datetime is needed in the format shown below.
    /// The HTTP request body is expected in the following JSON:
    /// {
    ///    "AnalysisYearId": <integer>,
    ///    "TransactionCodeId": <integer>,
    ///    "TransactionDate": "<YYYY-MM-DDT00:00:00>", 
    ///    "Description": "<description>",
    ///    "Amount": <decimal>,
    ///    "LastUpdated": "<YYYY-MM-DDT00:00:00>",
    ///    "LastUpdatedBy": "<string>"   
    /// }
    /// </summary>
    [Route("api/records")]
    [ApiController]
    public class CashRecordsController : ControllerBase
    {
        private readonly CashRecordRepository _repository = new CashRecordRepository();

        [HttpGet]
        public ActionResult<IEnumerable<CashRecord>> GetAllCashRecords()
        {
            var recordItems = _repository.GetAllCashRecords();

            return Ok(recordItems);
        }

        [HttpGet("{id}")]
        public ActionResult<CashRecord> GetCashRecordById(int id)
        {
            string record = _repository.GetCashRecordById(id);

            return Ok(record);
        }

        [HttpPost]
        public ActionResult<CashRecord> CreateCashRecord([FromBody]CashRecord record)
        {
            int i = _repository.CreateCashRecord(record);

            return GenerateResponse(i, "created");
        }

        [HttpPut("{id}")]
        public ActionResult<CashRecord> UpdateCashRecord(int id, [FromBody]CashRecord record)
        {
            int i = _repository.UpdateCashRecord(id, record);

            return GenerateResponse(i, "updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCashRecord(int id)
        {
            int i = _repository.DeleteCashRecord(id);

            return GenerateResponse(i, "deleted");
        }


        public ActionResult GenerateResponse(int i, string action)
        {
            if (i > 0)
            {
                return Ok($"CashRecord {action}");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
