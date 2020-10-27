using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class SignUpResponseEmailAddressExists:SignUpResponse
    {
        public SignUpRequest Request { get; set; }
        public SignUpResponseEmailAddressExists(SignUpRequest request)
        {
            Request = request;
        }
    }
}
