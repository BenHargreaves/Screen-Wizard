using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Services.Contracts;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Web.Http;
using System.Net.Http;
using System;
using System.Collections;

namespace ScreenWizard.Controllers
{
    [RoutePrefix("api/collections")]
    public class CollectionsController : ApiController
    {
        private ICollectionService _collectionService;
        public CollectionsController()
        {
            _collectionService = new CollectionService();
        }
        // GET api/<controller>
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var result = await _collectionService.GetCollections();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}