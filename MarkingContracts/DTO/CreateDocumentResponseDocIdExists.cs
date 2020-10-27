using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class CreateDocumentResponseDocIdExists : CreateDocumentResponse
    {
        public CreateDocumentRequest Request { get; set; }
        public CreateDocumentResponseDocIdExists(CreateDocumentRequest request)
        {
            Request = request;
        }
    }
}
