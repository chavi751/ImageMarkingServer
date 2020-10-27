using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetAllDocumentsResponse : Response
    {
        public Document[] array  { get; set; }
        
        
    }
}
