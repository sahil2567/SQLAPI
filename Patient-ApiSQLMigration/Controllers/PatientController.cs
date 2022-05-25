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
    public class PatientController : ControllerBase
    {
        private readonly IPatientData pData;
        public PatientController(IPatientData _pData)
        {
            pData = _pData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Patient>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Patient>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getPatientList(string DoctorId,string ActiveStatus)
        {
            return Ok(await pData.GetPatient(DoctorId,ActiveStatus));
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            string str = await pData.AddPatient(patient);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
            string str = await pData.UpdatePatient(patient);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePatient(int Id)
        {
            string str = await pData.DeletePatient(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
