using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class RemoveShareIsNotExist: RemoveShareResponse
    {
        public RemoveShareRequest Request { get; set; }
        public RemoveShareIsNotExist(RemoveShareRequest request)
        {
            Request = request;
        }
    }
}
