using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;

using System;
using System.IO;
using System.Net.Http.Headers;

namespace CreateDocument
{
    [Register(Policy.Transient, typeof(ICreateDocumentService))]
    public class CreateDocumentImpl : ICreateDocumentService
    {
        IMarkingDAL _dal;
        public CreateDocumentImpl(IMarkingDAL dal)
        {
            _dal = dal;
        }
        public Response CreateDocument(CreateDocumentRequest request)
        {
            string name = request.Dict["Name"];
            string userId = request.Dict["userId"];
            var fileName = ContentDispositionHeaderValue.Parse
                (request.File.ContentDisposition).FileName.Trim('"');
            string path = Path.Combine("https://localhost:44317/", "Resources/Images/",fileName);
           try
            {
                var ds = _dal.CreateDocument(userId, path, name);
                CreateDocumentResponse retval = new CreateDocumentResponseDocIdExists(request);
                if (ds.Tables.Count > 0)
                {
                    var tbl = ds.Tables[0];
                    if (tbl.Rows.Count == 1)
                    {
                        
                        if (userId == (string)tbl.Rows[0][1])
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

                                retval = new CreateDocumentResponseOK();
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


