using Boats_4_U.Models;
using Boats_4_U.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Boats_4_U.WebAPI.Controllers
{
    [Authorize]
    public class RenterController : ApiController
    {
        public IHttpActionResult Post(RenterCreate renter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRenterService();

            if (!service.CreateRenter(renter))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            RenterService renterService = CreateRenterService();
            var renters = renterService.GetRenters();
            return Ok(renters);
        }

        [Route("api/Renter/{id}")]
        public IHttpActionResult Get(int id)
        {
            RenterService renterService = CreateRenterService();
            var renter = renterService.GetRenterById(id);
            return Ok(renter);
        }

        public IHttpActionResult Put(RenterUpdate renter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRenterService();

            if (!service.UpdateRenter(renter))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRenterService();

            if (!service.DeleteRenter(id))
                return InternalServerError();

            return Ok();
        }

        private RenterService CreateRenterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var renterService = new RenterService(userId);
            return renterService;
        }
    }
}
