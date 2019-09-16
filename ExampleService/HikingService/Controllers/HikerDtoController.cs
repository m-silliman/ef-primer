using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using System;
using HikingModelEF;
using HikingModelEF.Dto;
using HikingModelEF.Helpers;

namespace HikingService.Controllers
{
    [RoutePrefix("api/hikerdto")]
    public class HikerDtoController : ApiController
    {

        [HttpGet]
        [Route("all")]
        [ResponseType(typeof(List<HikerDto>))]
        public IHttpActionResult Get()
        {
            return Ok(new HikerDbEntities().Hiker.ToList().ToDto());
        }

    }

}
