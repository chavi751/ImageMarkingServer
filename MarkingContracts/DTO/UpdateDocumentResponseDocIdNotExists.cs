using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class UpdateDocumentResponseDocIdNotExists : UpdateDocumentResponse
    {
        public UpdateDocumentRequest Request { get; set; }
        public UpdateDocumentResponseDocIdNotExists(UpdateDocumentRequest request)
        {
            Request = request;
        }
    }
}
