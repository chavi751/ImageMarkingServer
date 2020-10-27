using DIContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class RemoveDocumentResponse:Response
    {
        public Document document { get; set; }
    }
}
