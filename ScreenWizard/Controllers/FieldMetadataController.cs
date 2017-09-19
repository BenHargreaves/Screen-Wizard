using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ScreenWizard.Controllers
{
    [RoutePrefix("api")]
    public class FieldMetadataController : ApiController
    {
        private readonly IFieldService _service;
        public FieldMetadataController()
        {
            _service = new FieldService();
        }
        [HttpGet]
        [Route("{table}/TESTfields", Name = "FieldMetadata")]
        public async Task<IHttpActionResult> GetFields(string table)
        {
            try
            {

                var result = await _service.All(table);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}