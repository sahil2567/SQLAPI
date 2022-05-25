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
    public class BPController : ControllerBase
    {
        private readonly IBPData bpData;
        public BPController(IBPData  _bpData)
        {
            bpData = _bpData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BP>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BP>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getBPList(string GSI1PK)
        {
            return Ok(await bpData.GetBP(GSI1PK));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBP(BP bp)
        {
            string str = await bpData.AddBP(bp);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBP(BP bp)
        {
            string str = await bpData.UpdateBP(bp);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBP(int Id)
        {
            string str = await bpData.DeleteBP(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
