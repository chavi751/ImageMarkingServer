using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class GetDocumentResponse:Response
    {
        public Document document  { get; set; }
        
        
    }
}
