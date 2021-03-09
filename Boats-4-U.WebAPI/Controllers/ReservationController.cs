using Boats_4_U.Models;
using Boats_4_U.Models.ReservationModels;
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
        /// <summary>
        /// This allows a reservation to be created
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>"The reservation was successfully created."</returns>
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

        /// <summary>
        /// This allows all of the reservations to be retrieved
        /// </summary>
        /// <returns>This returns all of the reservations</returns>

        // GET
        [HttpGet]
        public IHttpActionResult Get()
        {
            ReservationService reservationService = CreateReservationService();
            var reservations = reservationService.GetReservations();
            return Ok(reservations);
        }
        
        /// <summary>
        /// This allows a particular reservation to be retrieved by its Id
        /// </summary>
        /// <param name="id">This is the Id of the interesed reservation</param>
        /// <returns>This returns the desired reservation</returns>
        [Route("api/Reservation/{id}")]
        public IHttpActionResult GetByReservationId(int id)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationById(id);
            return Ok(reservation);
        }

        /// <summary>
        /// This allows all the retrieval of all of the reservations of a particular driver
        /// </summary>
        /// <param name="id">This is the id of that driver</param>
        /// <returns>This returns the particular driver's reservations</returns>
        [Route("api/Reservation/GetByDriverId/{id}")]
        public IHttpActionResult GetByDriverId(int id)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationByDriverId(id);
            return Ok(reservation);
        }

        /// <summary>
        /// This allows the retrieval of all of the reservations of a particular renter
        /// </summary>
        /// <param name="id">This is the id of that renter</param>
        /// <returns>This returns the particular renter's reservations</returns>
        [Route("api/Reservation/GetByRenterId/{id}")]
        public IHttpActionResult GetByRenterId(int id)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationByRenterId(id);
            return Ok(reservation);
        }
        
        /// <summary>
        /// This allows the reservations for a particular date to be retrieved
        /// </summary>
        /// <param name="date"></param>
        /// <returns>This returns all of the reservations on that date</returns>
        [Route("api/Reservation/GetByDate/{date}")]
        public IHttpActionResult GetByDate(DateTimeOffset date)
        {
            ReservationService reservationService = CreateReservationService();
            var reservation = reservationService.GetReservationByDate(date);
            return Ok(reservation);
        }

        /// <summary>
        /// This allows a reservation to be changed
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns>"The reservation was successfully updated."</returns>
        [HttpPut]
        public IHttpActionResult Put(ReservationEdit reservation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReservationService();

            if (!service.UpdateReservation(reservation))
                return InternalServerError();

            return Ok("The reservation was successfully updated.");
        }

        /// <summary>
        /// This allows a particular reservation to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns>"The reservation was successfully deleted."</returns>
        [Route("api/Reservation/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReservationService();

            if (!service.DeleteReservation(id))
                return InternalServerError();

            return Ok("The reservation was successfully deleted.");
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
