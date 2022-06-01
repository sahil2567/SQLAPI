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
    public class UserTableController : ControllerBase
    {
        private readonly IUserTableData userTableData;
        public UserTableController(IUserTableData _userTableData)
        {
            userTableData = _userTableData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserTable>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<UserTable>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getUserTableList()
        {
            return Ok(await userTableData.GetUserTable());
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUserTable(UserTable userTable)
        {
            string str = await userTableData.AddUserTable(userTable);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserTable(UserTable userTable)
        {
            string str = await userTableData.UpdateUserTable(userTable);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUserTable(int Id)
        {
            string str = await userTableData.DeleteUserTable(Id);
            if (str == "Y")
                return Ok();
            else
                return BadRequest();
        }
    }
}
