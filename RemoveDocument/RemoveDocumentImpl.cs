using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;

namespace RemoveDocument
{
    [Register(Policy.Transient, typeof(IRemoveDocumentService))]
    public class RemoveDocumentImpl : IRemoveDocumentService
    {
            IMarkingDAL _dal;
            public RemoveDocumentImpl(IMarkingDAL dal)
            {
                _dal = dal;
            }

            Response IRemoveDocumentService.RemoveDocument(RemoveDocumentRequest request)
            {
                try
                {
                RemoveDocumentResponse retval = new RemoveDocumentIsNotExist(request);
                var ds = _dal.GetDocument(request.DocId);
                if (ds.Tables.Count > 0)
                {
                    ds = _dal.RemoveDocument(request.DocId);
                    if (ds.Tables.Count > 0)
                    {
                        var tbl = ds.Tables[0];
                        if (tbl.Rows.Count == 1)
                        {
                            if ((string)tbl.Rows[0][0] == request.DocId)
                            {
                                retval = new RemoveDocumentResponseOK();
                                retval.document = new Document();
                                retval.document.UserID = (string)tbl.Rows[0][1];
                                retval.document.DocumentName = (string)tbl.Rows[0][3];
                                retval.document.DocumentId = (string)tbl.Rows[0][0];
                                retval.document.ImageURL = (string)tbl.Rows[0][2];
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
