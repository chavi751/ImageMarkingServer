using System;
using System.Collections.Generic;
using System.Text;

namespace MarkingContracts.DTO
{
    public class SignInInvalidUserNameOrPasswordResponse:SignInResponse
    {
        public SignInRequest Request { get; set; }
        public SignInInvalidUserNameOrPasswordResponse(SignInRequest request)
        {
            Request = request;
        }
        
    }
}
