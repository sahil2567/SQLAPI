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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorData doctorData;
        public DoctorController(IDoctorData _doctorData)
        {
            doctorData = _doctorData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Doctor>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Doctor>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getDoctorList()
        {
            return Ok(await doctorData.GetDoctor());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            string str = await doctorData.AddDoctor(doctor);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            string str = await doctorData.UpdateDoctor(doctor);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDoctor(int Id)
        {
            string str = await doctorData.DeleteDoctor(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
