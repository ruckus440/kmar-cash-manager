using CashManager.Data;
using CashManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashManager.Controllers
{
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
