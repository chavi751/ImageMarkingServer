using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace SignInService
{
    [Register(Policy.Transient, typeof(IsignInService))]
    public class SignInImpl : IsignInService
    {
        IMarkingDAL _dal;
        public SignInImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
       Response IsignInService.SignIn(SignInRequest request)
        {
            try
            {
                var ds = _dal.GetUser(request.EmailAddress,request.UserName);
                SignInResponse retval = new SignInInvalidUserNameOrPasswordResponse(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        if ((Int16)tbl.Rows[0][2] == 0)
                        {
                            retval = new SignInResponseUserUnsubscribe(request);
                            return retval;
                        }
                        if (request.UserName == (string)tbl.Rows[0][1])                     
                        {
                            retval = new SignInResponseOK();
                            retval.emailAddress = (string)tbl.Rows[0][0];
                            retval.UserName = (string)tbl.Rows[0][1];
                        }

                    }
                }

                return retval;
            }
            catch (Exception ex)
            {
                return new ResponseError(ex.Message);
            }

        }
    }
}
    
    

