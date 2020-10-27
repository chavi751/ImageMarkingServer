using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace UpdateDocumentService
{
    [Register(Policy.Transient, typeof(IUpdateDocumentService))]
    public class UpdateDocumentImpl : IUpdateDocumentService
    {
        IMarkingDAL _dal;
        public UpdateDocumentImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        public Response UpdateDocument(UpdateDocumentRequest request)
        {
            string fileName = null;
            string name = request.DocumentName;
            string docId = request.DocumentId;
            string path = request.ImageUrl;
            if (request.File != null)
            {
                name = request.Dict["Name"];
                docId = request.Dict["DocId"];
                fileName = ContentDispositionHeaderValue.Parse
                    (request.File.ContentDisposition).FileName.Trim('"');
                path = Path.Combine("https://localhost:44317/", "Resources/Images/", fileName);
            }
            try
            {
                var ds = _dal.UpdateDocument(docId, name, path);
                UpdateDocumentResponse retval = new UpdateDocumentResponseDocIdNotExists(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {

                        if (docId == (string)tbl.Rows[0][0])
                        {
                            if (request.File != null)
                            {
                                var folderName = Path.Combine("Resources", "Images");
                                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                                if (request.File.Length > 0)
                                {

                                    var fullPath = Path.Combine(pathToSave, fileName);
                                    using (var stream = new FileStream(fullPath, FileMode.Create))
                                    {
                                        request.File.CopyTo(stream);
                                    }
                                }
                            }

                                retval = new UpdateDocumentResponseOK();
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
