using DIContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MarkingContracts.DTO
{
    public class UpdateDocumentResponse : Response
    {
        public Document document { get; set; }
    }
}
