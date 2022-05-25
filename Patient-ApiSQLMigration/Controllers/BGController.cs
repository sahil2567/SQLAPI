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
    public class BGController : ControllerBase
    {
        private readonly IBGData bgData;
        public BGController(IBGData _bgData)
        {
            bgData = _bgData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BG>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<BG>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getBGList()
        {
            return Ok(await bgData.GetBG());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBG(BG bg)
        {
            string str = await bgData.AddBG(bg);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBG(BG bg)
        {
            string str = await bgData.UpdateBG(bg);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBG(int Id)
        {
            string str = await bgData.DeleteBG(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
