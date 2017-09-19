using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Reflection;

namespace ScreenWizard.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _service;
        public CustomerController()
        {
            _service = new CustomerService();
        }


        [HttpGet]
        [Route("fields")]
        public List<FieldMetadata> GetFields()
        {

            var fieldList = new List<FieldMetadata>();

            var customer = new Customer();

            var properties = _service.GetFields(customer);
            foreach (var p in properties)
            {
                string name = p.Name;
                var value = p.PropertyType.Name;
                fieldList.Add(new FieldMetadata { Name = name, Type = value });

            }
            return fieldList;
        }

        // GET api/<controller>
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

        // GET api/<controller>/5
        [HttpGet()]
        [Route("get/{id}", Name = "Customer")]
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

        // POST api/<controller>
        [HttpPut]
        [Route("create")]
        public IHttpActionResult Create([FromBody]Customer customer)
        {
            _service.Create(customer);
            return Ok(customer);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}