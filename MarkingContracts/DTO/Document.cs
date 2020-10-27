using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class Document
    {
        public string DocumentId { get; set; }
        public string UserID { get; set; }
        public string ImageURL { get; set; }
        public string DocumentName { get; set; }
    }
}
