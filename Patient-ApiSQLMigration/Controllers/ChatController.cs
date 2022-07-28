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
    public class ChatController : ControllerBase
    {
        private readonly IChatData chatData;
        public ChatController(IChatData _chatData)
        {
            chatData = _chatData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Chat>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Chat>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getChatList(int ReceiverId)
        {
            return Ok(await chatData.GetChat( ReceiverId));
        }

       
    }
}
