using Boats_4_U.Models;
using Boats_4_U.Models.RenterRatingModels;
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
    public class RenterRatingController : ApiController
    {
        /// <summary>
        /// This will allow a user to post a rating for a renter
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>"The renter rating was successfully created."</returns>
        [HttpPost]
        public IHttpActionResult Post(RenterRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRenterRatingService();

            if (!service.CreateRenterRating(rating))
                return InternalServerError();

            return Ok("The renter rating was succesffully created.");
        }

        /// <summary>
        /// This will allow a user to get a specific renter rating by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of a renter rating</returns>
        [HttpGet]
        [Route("api/RenterRating/{id}")]
        public IHttpActionResult Get(int id)
        {
            var service = CreateRenterRatingService();
            var rating = service.GetRenterRatingById(id);
            return Ok(rating);
        }

        /// <summary>
        /// This will allow user to update a specific renter rating by its Id
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>"The renter rating has been successfully updated."</returns>
        [HttpPut]
        public IHttpActionResult Put(RenterRatingUpdate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var service = CreateRenterRatingService();

            if (!service.UpdateRenterRating(rating))
                return InternalServerError();

            return Ok("The renter rating has been successfully updated.");
        }

        /// <summary>
        /// This will allow user to delete a specific Renter rating by its Id
        /// </summary>
        /// <param name="renterRatingId"></param>
        /// <returns>"The renter rating has been successfully deleted."</returns>
        [HttpDelete]
        [Route("api/RenterRating/{renterRatingId}")]
        public IHttpActionResult Delete(int renterRatingId)
        {
            var service = CreateRenterRatingService();

            if (!service.DeleteRenterRating(renterRatingId))
                return InternalServerError();

            return Ok("The renter rating has been successfully deleted.");
        }

        private RenterRatingService CreateRenterRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new RenterRatingService(userId);
            return ratingService;
        }
    }
}
