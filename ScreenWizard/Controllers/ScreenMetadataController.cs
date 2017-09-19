using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ScreenWizard.Controllers
{
    [RoutePrefix("api")]
    public class ScreenMetadataController : ApiController
    {
        private readonly IScreenService _service;
        public ScreenMetadataController()
        {
            _service = new ScreenService();
        }
        
        [HttpPut]
        [Route("screen")]
        public IHttpActionResult CreateScreen([FromBody] ScreenMetadata screenMetadata)
        {
            
            _service.Create(screenMetadata);
            return Ok(screenMetadata);
        }
        [HttpGet]
        [Route("screen")]
        public async Task<IHttpActionResult> GetScreen()
        {
            try
            {
                var result = await _service.All();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}