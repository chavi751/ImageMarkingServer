using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SharedDocumentsController : ControllerBase
    {
        ICreateShareService _createService;
        IGetSharesService _getSharesService;
        IGetSharedDocumentsService _getShareService;
        IRemoveShareService _removeService;
        public SharedDocumentsController(
        ICreateShareService createService,
        IGetSharedDocumentsService getShareService,
        IGetSharesService getSharesService,
        IRemoveShareService removeService)
        {
            _createService = createService;
            _getShareService = getShareService;
            _getSharesService = getSharesService;
            _removeService = removeService;
        }
        // GET api/<SharedDocumentsController>/5
        [HttpPost]
        public Response GetSharedDocuments([FromBody] GetSharedDocumentsRequest request)
        {

            return _getShareService.GetSharedDocuments(request);
        }

        [HttpPost]
        public Response GetShares([FromBody] GetSharesRequest request)
        {

            return _getSharesService.GetShares(request);
        }

        // POST api/<SharedDocumentsController>
        [HttpPost]
        public Response CreateShare([FromBody] CreateShareRequest request)
        {
            return _createService.CreateShare(request);
        }
        // POST api/<SharedDocumentsController>
        [HttpPost]
        public Response RemoveShare([FromBody] RemoveShareRequest request)
        {
            return _removeService.RemoveShare(request);
        }

    }
}


