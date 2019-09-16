using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System;
using HikingModelEF;
// using HikingDataModelEF;


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
            return Ok(new HikerDbEntities().Hiker.ToList());
        }

        [HttpGet]
        [Route()]
        [ResponseType(typeof(List<Hiker>))]
        public IHttpActionResult Get(long id)
        {
            return Ok(new HikerDbEntities().Hiker.Single( a => a.Id == id));
        }


        [HttpDelete]
        [Route()]
        public IHttpActionResult Delete(long id)
        {
            using (HikerDbEntities ctx = new HikerDbEntities())
            {
                var hiker = ctx.Hiker.Find(id);
                ctx.Hiker.Remove(hiker);
                ctx.SaveChanges();

                return Ok();
            }
        }

        [HttpPost]
        [Route()]
        [ResponseType(typeof(Hiker))]
        public IHttpActionResult Post(Hiker hiker)
        {
            using(HikerDbEntities ctx = new HikerDbEntities())
            {
                ctx.Hiker.Add(hiker);
                ctx.Entry(hiker).State = (hiker.Id == 0) ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

                return Ok(hiker);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ResponseType(typeof(List<Hiker>))]
        public IHttpActionResult GetIt(long id)
        {
            try
            {
                return Ok(new HikerDbEntities().Hiker.Single(a => a.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
