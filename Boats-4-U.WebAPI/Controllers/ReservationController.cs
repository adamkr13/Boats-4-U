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
    public class ReservationController : ApiController
    {
        // POST
        [HttpPost]
        public IHttpActionResult Post(ReservationCreate reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateReservationService();

            if (!service.CreateReservation(reservation))
                return InternalServerError();

            return Ok("Your reservation was successfully created.");
        }
        // GET
        [HttpGet]
        public IHttpActionResult Get()
        {
            ReservationService reservationService = CreateReservationService();
            var reservations = reservationService.GetReservations();
            return Ok(reservations);
        }
        // GET Reservation by Reservation Id
        [Route("api/Reservation/{id}")]
        public IHttpActionResult GetByReservationId(int id)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationById(id);
            return Ok(reservation);
        }
        // GET Reservation by Driver Id
        [Route("api/Reservation/GetByDriverId/{id}")]
        public IHttpActionResult GetByDriverId(int id)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationByDriverId(id);
            return Ok(reservation);
        }
        // GET Reservation by Renter Id
        [Route("api/Reservation/GetByRenterId/{id}")]
        public IHttpActionResult GetByRenterId(int id)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationByRenterId(id);
            return Ok(reservation);
        }
        // GET Reservation by Date
        [Route("api/Reservation/GetByDate/{date}")]
        public IHttpActionResult GetByDate(DateTimeOffset date)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationByDate(date);
            return Ok(reservation);
        }

        // PUT
        [HttpPut]
        public IHttpActionResult Put(ReservationEdit reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReservationService();

            if (!service.UpdateReservation(reservation))
                return InternalServerError();

            return Ok();
        }
        // DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReservationService();

            if (!service.DeleteReservation(id))
                return InternalServerError();

            return Ok();
        }
        // Helper
        private ReservationService CreateReservationService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            ReservationService reservationService = new ReservationService(userId);
            return reservationService;
        }
    }
}
