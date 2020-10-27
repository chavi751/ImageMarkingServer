using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace GetAllDocumentsService
{
    [Register(Policy.Transient, typeof(IGetAllDocumentService))]
    public class GetAllDocumentImpl : IGetAllDocumentService
    {
        IMarkingDAL _dal;
        public GetAllDocumentImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        public Response GetAllDocuments(GetAllDocumentsRequest request)
        {
            try
            {
                var ds = _dal.GetDocuments(request.userId);
                GetAllDocumentsResponse retval = new GetAllDocumentsUserNotExist(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count >= 1)
                    {
                        retval = new GetAllDocumentsResponseOK();
                        retval.array = new Document[tbl.Rows.Count];
                        for (int i = 0; i < tbl.Rows.Count; i++)
                        {
                            if (request.userId == (string)tbl.Rows[i][1] || tbl.Rows.Count >= 1)
                            {

                                retval.array[i] = new Document();
                                retval.array[i].UserID = (string)tbl.Rows[i][1];
                                retval.array[i].DocumentName = (string)tbl.Rows[i][3];
                                retval.array[i].DocumentId = (string)tbl.Rows[i][0];
                                retval.array[i].ImageURL = (string)tbl.Rows[i][2];
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
