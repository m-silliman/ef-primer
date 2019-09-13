using HikingDataModel;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System;

namespace HikingService.Controllers
{
    [RoutePrefix("api/hiker")]
    public class HikerController : ApiController
    {

        [HttpGet]
        [Route("all")]
        [ResponseType(typeof(List<Hiker>))]
        public IHttpActionResult Get()
        {
            return Ok(new DataContext().Hikers.ToList());
        }

        [HttpGet]
        [Route()]
        [ResponseType(typeof(List<Hiker>))]
        public IHttpActionResult Get(long id)
        {
            return Ok(new DataContext().Hikers.Single( a => a.Id == id));
        }


        [HttpPost]
        [Route()]
        [ResponseType(typeof(Hiker))]
        public IHttpActionResult Post(Hiker hiker)
        {
            hiker.Id = System.DateTime.Today.Ticks;
            return Ok(hiker);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(List<Hiker>))]
        public IHttpActionResult GetIt(long id)
        {
            try
            {
                return Ok(new DataContext().Hikers.Single(a => a.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
