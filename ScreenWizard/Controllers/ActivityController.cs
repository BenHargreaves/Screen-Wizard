using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ScreenWizard.Controllers
{
    [RoutePrefix("api/activity")]
    public class ActivityController : ApiController
    {
        private readonly IActivityService _service;
        public ActivityController()
        {
            _service = new ActivityService();
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
        [Route("get/{id}", Name = "Activity")]
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
        public IHttpActionResult Create([FromBody] Activity activity)
        {
            try
            {
                _service.Create(activity);
                return Ok(activity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}