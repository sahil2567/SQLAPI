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
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceData deviceData;
        public DeviceController(IDeviceData _deviceData)
        {
            deviceData = _deviceData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Device>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Device>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getDeviceList()
        {
            return Ok(await deviceData.GetDevice());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDevice(Device device)
        {
            string str = await deviceData.AddDevice(device);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDevice(Device device)
        {
            string str = await deviceData.UpdateDevice(device);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDevice(int Id)
        {
            string str = await deviceData.DeleteDevice(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
