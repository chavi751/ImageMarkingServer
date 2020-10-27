using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class PostBlogModel
    {
        public string Name { get; set; }
        public IFormFile TileImage { get; set; }
    }
}
