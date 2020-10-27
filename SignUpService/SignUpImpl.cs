using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace SignUpService
{
    [Register(Policy.Transient, typeof(ISignUpService))]
    public class SignUpImpl : ISignUpService
    {
        IMarkingDAL _dal;
        public SignUpImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }


        public Response SignUp(SignUpRequest request)
        {
            try
            {
                var ds = _dal.GetUser(request.emailAddress, request.UserName);
                SignUpResponse retval = new SignUpResponseEmailAddressExists(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        return retval;
                    }
                    else if (tbl.Rows.Count == 0)
                    {
                        ds = _dal.CreateUser(request.emailAddress, request.UserName);
                        tbl = ds.Tables[0];
                        if (tbl.Rows.Count == 1)
                        {
                            if (request.emailAddress == (string)tbl.Rows[0][0]
                                && request.UserName == (string)tbl.Rows[0][1])
                            {
                                retval = new SignUpResponseOK();
                                retval.EmailAddress = (string)tbl.Rows[0][0];
                                retval.UserName= (string)tbl.Rows[0][1];
                            }

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
