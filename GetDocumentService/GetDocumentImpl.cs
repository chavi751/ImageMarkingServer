using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace GetDocumentService
{
    [Register(Policy.Transient, typeof(IGetDocumentService))]
    public class GetDocumentImpl : IGetDocumentService
    {
        IMarkingDAL _dal;
        public GetDocumentImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        Response IGetDocumentService.GetDocument(GetDocumentRequest request)
        {
            try
            {
                var ds = _dal.GetDocument(request.docId);
                GetDocumentResponse retval = new GetDocumentDocNotExist(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count >= 1)
                    {
                        retval = new GetDocumentResponseOK();
                       
                            if (request.docId == (string)tbl.Rows[0][0])
                            {
                                
                                retval.document = new Document();
                                retval.document.UserID = (string)tbl.Rows[0][1];
                                retval.document.DocumentName = (string)tbl.Rows[0][3];
                                retval.document.DocumentId = (string)tbl.Rows[0][0];
                                retval.document.ImageURL = (string)tbl.Rows[0][2];
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
