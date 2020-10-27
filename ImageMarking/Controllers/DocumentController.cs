using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DIContract;
using MarkingContracts.DTO;
using MarkingContracts.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageMarking.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        IGetDocumentService _getService;
        IGetAllDocumentService _getAllService;
        ICreateDocumentService _createService;
        IRemoveDocumentService _removeService;
        IUpdateDocumentService _updateService;
        public DocumentController(IGetDocumentService getService,
          ICreateDocumentService createService,
          IRemoveDocumentService removeService,
          IGetAllDocumentService getAllService,
           IUpdateDocumentService updateService)
        {
            _getService = getService;
            _getAllService = getAllService;
            _createService = createService;
            _removeService = removeService;
            _updateService = updateService;
        }
        // POST api/<DocumentController>
        [HttpPost]
        public Response GetDocument([FromBody] GetDocumentRequest request)
        {

            return _getService.GetDocument(request);
        }
        // POST api/<DocumentController>
        [HttpPost]
        public Response GetDocuments([FromBody] GetAllDocumentsRequest request)
        {

            return _getAllService.GetAllDocuments(request);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public Response CreateDocument( )
        {

            CreateDocumentRequest request=new CreateDocumentRequest();
            request.File=Request.Form.Files[0];
            request.Dict= Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            return _createService.CreateDocument(request);
            
        }
        [HttpPost]
        public Response UpdateDocument([FromBody] UpdateDocumentRequest request)
        {
            return _updateService.UpdateDocument(request);
        }
        [HttpPost]
        public Response UpdateDocumentLoadImage()
        {

            UpdateDocumentRequest request = new UpdateDocumentRequest();
            request.File = Request.Form.Files[0];
            request.Dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            return _updateService.UpdateDocument(request);

        }
        
        // POST api/<DocumentController>
        [HttpPost]
        public Response RemoveDocument([FromBody] RemoveDocumentRequest request)
        {
            return _removeService.RemoveDocument(request);
        }

    }
}
