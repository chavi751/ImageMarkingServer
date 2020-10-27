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
    public class DocumentMarkersController : ControllerBase
    {
        ICreateMarkerService _createService;
        IRemoveMarkerService _removeService;
        IGetMarkersService _getService;
        IUpdateMarkerService _updateService;
        IMessanger _messanger;
        public DocumentMarkersController(ICreateMarkerService createService,
        IRemoveMarkerService removeService,
        IGetMarkersService getService,
        IUpdateMarkerService updateService,
         IMessanger messanger)
        {
            _createService = createService;
            _removeService = removeService;
            _getService = getService;
            _updateService = updateService;
            _messanger = messanger;
        }
        // GET api/<DocumentMarkersController>/5
        [HttpPost]
        public Response GetMarkers([FromBody] GetMarkersRequest request)
        {

            return _getService.GetMarkers(request);
        }

        // POST api/<DocumentMarkersController>
        [HttpPost]
        public Response CreateMarker([FromBody] CreateMarkerRequest request)
        {
            
            return _createService.CreateMarker(request);
            
        }
        // POST api/<DocumentMarkersController>
        [HttpPost]
        public Response UpdateMarker([FromBody] UpdateMarkerRequest request)
        {
            return _updateService.UpdateMarker(request);
        }
        // POST api/<DocumentMarkersController>
        [HttpPost]
        public Response RemoveMarker([FromBody] RemoveMarkerRequest request)
        {
            return _removeService.RemoveMarker(request);
        }
      

    }
}

