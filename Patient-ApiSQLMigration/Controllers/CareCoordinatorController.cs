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
    public class CareCoordinatorController : ControllerBase
    {
        private readonly ICareCoordinatorData careCoordinatorData;
        public CareCoordinatorController(ICareCoordinatorData _careCoordinatorData)
        {
            careCoordinatorData = _careCoordinatorData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CareCoordinator>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<CareCoordinator>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getCareCoordinatorList(string ActiveStatus)
        {
            return Ok(await careCoordinatorData.GetCareCoordinator(ActiveStatus));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCareCoordinator(CareCoordinator careCoordinator)
        {
            string str = await careCoordinatorData.AddCareCoordinator(careCoordinator);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCareCoordinator(CareCoordinator careCoordinator)
        {
            string str = await careCoordinatorData.UpdateCareCoordinator(careCoordinator);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCareCoordinator(int Id)
        {
            string str = await careCoordinatorData.DeleteCareCoordinator(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
