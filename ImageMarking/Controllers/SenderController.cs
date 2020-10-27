using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarkingContracts.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenderController : ControllerBase
    {
        IMessanger _messanger;
        public SenderController(IMessanger messanger)
        {
            _messanger = messanger;
        }


        // POST api/<SenderController>
        [HttpPost]
        public async Task Send(MessageRequest messageRequest)
        {
            await _messanger.Send(messageRequest.ID, messageRequest.Message);
        }

    }
}
