using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class CreateShareRequest
    {
        public User user { get; set; }
        public string DocId { get; set; }
        
    }
}
