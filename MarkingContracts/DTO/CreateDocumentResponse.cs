using DIContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MarkingContracts.DTO
{
    public class CreateDocumentResponse : Response
    {
        public Document document { get; set; }
    }
}
