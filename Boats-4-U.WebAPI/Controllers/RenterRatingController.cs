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
    public class RenterRatingController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(RenterRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRenterRatingService();

            if (!service.CreateRenterRating(rating))
                return InternalServerError();

            return Ok("Rating was succesffully created");
        }

        [HttpGet]
        [Route("api/RenterRating/{id}")]
        public IHttpActionResult Get(int id)
        {
            var service = CreateRenterRatingService();
            var rating = service.GetRenterRatingById(id);
            return Ok(rating);
        }

        private RenterRatingService CreateRenterRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new RenterRatingService(userId);
            return ratingService;
        }
    }
}
