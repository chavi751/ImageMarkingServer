using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class CreateDocumentRequest
    {
        public IFormFile File { get; set; }
        public Dictionary<string,string> Dict { get; set; }
        /*public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentName { get; set; }
        */
    }
}
