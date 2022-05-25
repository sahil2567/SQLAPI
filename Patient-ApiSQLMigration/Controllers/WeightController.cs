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
    public class WeightController : ControllerBase
    {
        private readonly IWeightData weightData;
        public WeightController(IWeightData _weightData)
        {
            weightData = _weightData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Weight>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Weight>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getWeightList()
        {
            return Ok(await weightData.GetWeight());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddWeight(Weight weight)
        {
            string str = await weightData.AddWeight(weight);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateWeight(Weight weight)
        {
            string str = await weightData.UpdateWeight(weight);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteWeight(int Id)
        {
            string str = await weightData.DeleteWeight(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
