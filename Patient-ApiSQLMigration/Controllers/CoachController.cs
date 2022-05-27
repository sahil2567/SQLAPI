using API.DataLayer.IData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient_ApiSQLMigration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoachController : ControllerBase
    {
        private readonly ICoachData coachData;
        public CoachController(ICoachData _coachData)
        {
            coachData = _coachData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Coach>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Coach>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getCoachList(string ActiveStatus)
        {
            return Ok(await coachData.GetCoach(ActiveStatus));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCoach(Coach coach)
        {
            string str = await coachData.AddCoach(coach);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCoach(Coach coach)
        {
            string str = await coachData.UpdateCoach(coach);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCoach(int Id)
        {
            string str = await coachData.DeleteCoach(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
