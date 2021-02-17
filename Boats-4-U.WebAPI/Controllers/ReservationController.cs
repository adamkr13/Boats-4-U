using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Boats_4_U.WebAPI.Controllers
{
    public class ReservationController : ApiController
    {
        // POST
        [HttpPost]
        public IHttpActionResult Post(ReservationCreate reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState)
            }

            var service = CreateReservationService();

            if (!service.CreateReservation(reservation))
                return InternalServerError();

            return Ok("Your reservation was successfully created.");
        }
        // GET

        // PUT

        // DELETE

        // Helper

        private ReservationService CreateReservationService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            ReservationService reservationService = new ReservationService(userId);
            return reservationService;
        }
    }
}
