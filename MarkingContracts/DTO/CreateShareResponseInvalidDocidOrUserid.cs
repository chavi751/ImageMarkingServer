using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class CreateShareResponseInvalidDocidOrUserid : CreateShareResponse
    {
        public CreateShareRequest Request { get; set; }
        public CreateShareResponseInvalidDocidOrUserid(CreateShareRequest request)
        {
            Request = request;
        }
    }
}
