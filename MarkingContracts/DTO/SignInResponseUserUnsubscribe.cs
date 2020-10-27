using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
   public class SignInResponseUserUnsubscribe:SignInResponse
    {
        public SignInRequest Request { get; set; }
        public SignInResponseUserUnsubscribe(SignInRequest request)
        {
            Request = request;
        }
    }
}
