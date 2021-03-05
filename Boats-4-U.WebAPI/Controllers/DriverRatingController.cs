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
        [HttpPost]
        public IHttpActionResult Post(DriverRatingCreate rating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDriverRatingService();

            if (!service.CreateDriverRating(rating))
                return InternalServerError();

            return Ok("Rating was succesffully created");
        }

        [HttpGet]
        [Route("api/DriverRating/{id}")]
        public IHttpActionResult Get(int id)
        {
            var service = CreateDriverRatingService();
            var rating = service.GetDriverRatingById(id);
            return Ok(rating);
        }

        private DriverRatingService CreateDriverRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ratingService = new DriverRatingService(userId);
            return ratingService;
        }
    }
}
