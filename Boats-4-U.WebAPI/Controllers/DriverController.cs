using Boats_4_U.Models.Driver;
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
    public class DriverController : ApiController
    {
        private DriverService CreateDriverService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var driverService = new DriverService(userId);
            return driverService;
        }

        public IHttpActionResult Get()
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDrivers();
            return Ok(drivers);
        }
        public IHttpActionResult GetByLocation(string location)
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDriversByLocation(location);
            return Ok(drivers);
        }

        public IHttpActionResult GetByMaxOccupants(int occupancy)
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDriversByOccupancy(occupancy);
            return Ok(drivers);
        }

        public IHttpActionResult Post(DriverCreate driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDriverService();

            if (!service.CreateDriver(driver))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            DriverService driverService = CreateDriverService();
            var driver = driverService.GetDriverById(id);
            return Ok(driver);
        }

        public IHttpActionResult Put(DriverEdit driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDriverService();

            if (!service.UpdateDriver(driver))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDriverService();

            if (!service.DeleteDriver(id))
                return InternalServerError();

            return Ok();
        }
    }
}
