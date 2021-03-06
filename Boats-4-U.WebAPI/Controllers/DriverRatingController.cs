using Boats_4_U.Models.DriverRatingModels;
using Boats_4_U.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Boats_4_U.WebAPI.Controllers
{
    public class DriverRatingController : ApiController
    {
        /// <summary>
        /// This will allow user to post rating for a Driver.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>"Rating was successfully created."</returns>
        [HttpPost]
        public IHttpActionResult Post(DriverRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDriverRatingService();

            if (!service.CreateDriverRating(rating))
                return InternalServerError();

            return Ok("Rating was succesffully created.");
        }

        /// <summary>
        /// This will get a specific Driver rating by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of Driver rating.</returns>
        [HttpGet]
        [Route("api/DriverRating/{id}")]
        public IHttpActionResult Get(int id)
        {
            var service = CreateDriverRatingService();
            var rating = service.GetDriverRatingById(id);
            return Ok(rating);
        }

        /// <summary>
        /// This will allow user to update a specific Driver rating by its Id.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns>"Driver rating has been successfully updated."</returns>
        [HttpPut]
        public IHttpActionResult Put(DriverRatingUpdate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var service = CreateDriverRatingService();

            if (!service.UpdateDriverRating(rating))
                return InternalServerError();

            return Ok($"Driver rating has been successfully updated.");
        }

        /// <summary>
        /// This will allow user to delete a specific Driver rating by its Id.
        /// </summary>
        /// <param name="driverRatingId"></param>
        /// <returns>"Driver rating has been successfully deleted."</returns>
        [HttpDelete]
        [Route("api/DriverRating/{driverRatingId}")]
        public IHttpActionResult Delete(int driverRatingId)
        {
            var service = CreateDriverRatingService();

            if (!service.DeleteDriverRating(driverRatingId))
                return InternalServerError();

            return Ok($"Driver rating has been successfully deleted.");
        }

        private DriverRatingService CreateDriverRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new DriverRatingService(userId);
            return ratingService;
        }
    }
}
