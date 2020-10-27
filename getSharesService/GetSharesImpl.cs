using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace GetSharesService
{
    [Register(Policy.Transient, typeof(IGetSharesService))]
    public class GetSharesImpl : IGetSharesService
    {
        IMarkingDAL _dal;
        public GetSharesImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        public Response GetShares(GetSharesRequest request)
        {
            try
            {
                var ds = _dal.GetSharedDocument(request.DocId);
                GetSharesResponse retval = new GetSharesResponseNoShares(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count >= 1)
                    {

                        retval = new GetSharesResponseOK();
                        retval.Shares = new Share[tbl.Rows.Count];
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            retval.Shares[i] = new Share();
                            retval.Shares[i].DocId = (string)tbl.Rows[i][0];
                            retval.Shares[i].UserId = (string)tbl.Rows[i][1];
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
