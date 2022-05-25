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
    public class ThresholdController : ControllerBase
    {
        private readonly IThresholdData thresholdData;
        public ThresholdController(IThresholdData _thresholdData)
        {
            thresholdData = _thresholdData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Threshold>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Threshold>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getThresholdList()
        {
            return Ok(await thresholdData.GetThreshold());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddThreshold(Threshold threshold)
        {
            string str = await thresholdData.AddThreshold(threshold);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateThreshold(Threshold threshold)
        {
            string str = await thresholdData.UpdateThreshold(threshold);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteThreshold(int Id)
        {
            string str = await thresholdData.DeleteThreshold(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
