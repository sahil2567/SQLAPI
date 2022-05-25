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
    public class TimeLogController : ControllerBase
    {
        private readonly ITimeLogData timeLogData;
        public TimeLogController(ITimeLogData _timeLogData)
        {
            timeLogData = _timeLogData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TimeLog>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<TimeLog>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getTimeLogList(string GSI1PK)
        {
            return Ok(await timeLogData.GetTimeLog( GSI1PK));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTimeLog(TimeLog timeLog)
        {
            string str = await timeLogData.AddTimeLog(timeLog);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTimeLog(TimeLog timeLog)
        {
            string str = await timeLogData.UpdateTimeLog(timeLog);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteTimeLog(int Id)
        {
            string str = await timeLogData.DeleteTimeLog(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
