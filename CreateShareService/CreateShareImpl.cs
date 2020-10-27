using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace CreateShareService
{
    [Register(Policy.Transient, typeof(ICreateShareService))]
    public class CreateShareImpl : ICreateShareService
    {
        IMarkingDAL _dal;
        public CreateShareImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        public Response CreateShare(CreateShareRequest request)
        {
            try
            {
                CreateShareResponse retval = new CreateShareResponseInvalidDocidOrUserid(request);
                var ds = _dal.GetUser(request.user.emailAddress, request.user.UserName);

                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        ds = _dal.CreateShare(request.DocId, request.user.emailAddress);
                        if (ds.Tables.Count > 0)
                        {
                            tbl = ds.Tables[0];
                            if (tbl.Rows.Count == 1)
                            {
                                if (request.DocId == (string)tbl.Rows[0][0]&&
                                    request.user.emailAddress == (string)tbl.Rows[0][1])
                                {
                                    retval = new CreateShareResponseOK();
                                    retval.DocId = (string)tbl.Rows[0][0];
                                    retval.UserId = (string)tbl.Rows[0][1];

                                }

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
