using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class UpdateDocumentRequest
    {
        public IFormFile File { get; set; }
        public Dictionary<string,string> Dict { get; set; }
        public string DocumentName { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentId { get; set; }

    }
}
