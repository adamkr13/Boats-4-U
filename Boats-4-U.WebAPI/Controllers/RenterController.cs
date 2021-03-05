using Boats_4_U.Models;
using Boats_4_U.Models.Renter;
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
        /// <summary>
        /// This allows a renter to be created
        /// </summary>
        /// <param name="renter"></param>
        /// <returns>This returns the statment "The Renter was Successfully Created!"</returns>
        public IHttpActionResult Post(RenterCreate renter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRenterService();

            if (!service.CreateRenter(renter))
                return InternalServerError();

            return Ok("The Renter was Successfully Created!");
        }

        /// <summary>
        /// This allows all of the renters to be retrieved
        /// </summary>
        /// <returns>This returns all of the renters</returns>
        public IHttpActionResult Get()
        {
            RenterService renterService = CreateRenterService();
            var renters = renterService.GetRenters();
            return Ok(renters);
        }

        /// <summary>
        /// This allows a particular renter to be retrieved
        /// </summary>
        /// <param name="id"></param>
        /// <returns>This returns the particular renter of interest</returns>
        [Route("api/Renter/{id}")]
        public IHttpActionResult Get(int id)
        {
            RenterService renterService = CreateRenterService();
            var renter = renterService.GetRenterById(id);
            return Ok(renter);
        }

        /// <summary>
        /// This allows a renter's information to be edited
        /// </summary>
        /// <param name="renter"></param>
        /// <returns>This returns the statment "The Renter was Successfully Updated!"</returns>
        public IHttpActionResult Put(RenterUpdate renter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRenterService();

            if (!service.UpdateRenter(renter))
                return InternalServerError();

            return Ok("The Renter was Successfully Updated!");
        }

        /// <summary>
        /// This allows a renter to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns>This returns the statment "The Renter was Successfully Deleted!"</returns>
        [Route("api/Renter/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reservationService = new ReservationService(userId);

            reservationService.NullRenter(id);

            var service = CreateRenterService();

            if (!service.DeleteRenter(id))
                return InternalServerError();

            return Ok("The Renter was Successfully Deleted!");
        }

        private RenterService CreateRenterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var renterService = new RenterService(userId);
            return renterService;
        }
    }
}
