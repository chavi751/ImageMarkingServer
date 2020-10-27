using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class RemoveDocumentIsNotExist: RemoveDocumentResponse
    {
        public RemoveDocumentRequest Request { get; set; }
        public RemoveDocumentIsNotExist(RemoveDocumentRequest request)
        {
            Request = request;
        }
    }
}
