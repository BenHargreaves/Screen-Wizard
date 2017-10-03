using System;
using System.Web.Http;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ScreenWizard.Controllers
{
    [RoutePrefix("api/invoice")]
    public class InvoiceController : ApiController
    {
        private readonly IInvoiceService _service;
        public InvoiceController()
        {
            _service = new InvoiceService();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
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

        [HttpGet]
        [Route("get/{id}", Name = "Invoice")]
        public async Task<IHttpActionResult> Find(string id)
        {
            try
            {
                var MongoObjectId = ObjectId.Parse(id);

                var result = await _service.Find(MongoObjectId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("create")]
        public  IHttpActionResult Create([FromBody]Invoice invoice)
        {
            _service.Create(invoice);
            return Ok(invoice);
        }
    }
}