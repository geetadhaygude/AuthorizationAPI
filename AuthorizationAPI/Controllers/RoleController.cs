using AuthorizationAPI.Handler;
using AuthorizationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthorizationAPI.Controllers
{
    [LogFilter]
    
    public class RoleController : ApiController
    {
        [HttpGet]
        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        [Route("api/AdminOnly/{id:int}")]//accepts only id as int
        public HttpResponseMessage ForAdminRole(int id)
        {
            //return "For Admin role only";
            return Request.CreateResponse(HttpStatusCode.OK, "For Admin role only");
            
        }


        
        [Authorize(Roles = "teamlead")]
        [Route("api/teamlead")]
        public string ForTeamLeadRole(int id)
        {
            return "For Team lead Role only";
        }

        [HttpGet]
        [Authorize(Roles = "advisor")]
        [Route("api/advisor")]
        public string advisor()
        {
            return "for only advisor";
        }

        [HttpGet]
        [Authorize(Roles = "admin,teamlead")]
        [Route("api/forTeamLeadAndAdmin")]
        public string AdminAndTeamlead()
        {
            return "for only admin and teamlead";
        }

        [HttpPost]
        [Route("api/saveDate")]
        public HttpResponseMessage savePersonData(Person obj)
        {
            if (ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, ModelState.Select(a => a.Value.Errors).Where(b => b.Count > 0).ToList());

        }
    }
}
