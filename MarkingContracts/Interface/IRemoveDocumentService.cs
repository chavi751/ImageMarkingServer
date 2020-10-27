using DIContract;
using MarkingContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.Interface
{
    public interface IRemoveDocumentService
    {
        public Response RemoveDocument(RemoveDocumentRequest request);
    }
}
