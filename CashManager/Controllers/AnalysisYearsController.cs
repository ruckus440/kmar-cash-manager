/*
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
    /// This is a controller for the "api/years" endpoint.
    /// I've assumed the datetime is needed in the format shown below.
    /// The HTTP request body is expected in the following JSON:
    /// {
    ///    "UserId": <integer>,
    ///    "Year": <integer>,
    ///    "BubbleUpDate": "<YYYY-MM-DDT00:00:00>" 
    /// }
    /// </summary>
    [Route("api/years")]
    [ApiController]
    public class AnalysisYearsController : ControllerBase
    {
        private readonly AnalysisYearRepository _repository = new AnalysisYearRepository();

        [HttpGet]
        public ActionResult<IEnumerable<AnalysisYear>> GetAllAnalysisYears()
        {
            string yearItems = _repository.GetAllAnalysisYears();

            return Ok(yearItems);
        }

        [HttpGet("{id}")]
        public ActionResult<AnalysisYear> GetAnalysisYearById(int id)
        {
            string year = _repository.GetAnalysisYearByAnalysisYearId(id);

            return Ok(year);
        }

        [HttpPost]
        public ActionResult<AnalysisYear> CreateAnalysisYear([FromBody]AnalysisYear year)
        {
            int i = _repository.CreateAnalysisYear(year);

            return GenerateResponse(i, "created");
        }

        [HttpPut("{id}")]
        public ActionResult<AnalysisYear> UpdateAnalysisYear(int id, [FromBody]AnalysisYear year)
        {
            int i = _repository.UpdateAnalysisYear(id, year);

            return GenerateResponse(i, "updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAnalysisYear(int id)
        {
            int i = _repository.DeleteAnalysisYear(id);

            return GenerateResponse(i, "deleted");
        }

        public ActionResult GenerateResponse(int i, string action)
        {
            if (i > 0)
            {
                return Ok($"AnalysisYear {action}");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
