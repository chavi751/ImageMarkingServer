using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageMarking.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IsignInService _signService;
        IRemoveUserService _removeService;

        public UserController(IsignInService signService,
            IRemoveUserService removeService)
        {
            _signService = signService;
            _removeService = removeService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public Response SignIn([FromBody] SignInRequest request)
        {
            return _signService.SignIn(request);
        }
        // POST api/<UserController>
        [HttpPost]
        public Response RemoveUser([FromBody] RemoveUserRequest request)
        {
            return _removeService.RemoveUser(request);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

