using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarkingContracts.DTO;
using System.Net;
using DIContract;

namespace ImageMarking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpPost]
        public Response PostBlog([FromForm] PostBlogModel request)
        {
            Response response=new Response();
            return response;
        }
    }
    

    
    
}
    

