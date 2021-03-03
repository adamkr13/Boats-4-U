using Boats_4_U.Data;
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
        /// <summary>
        /// This allow a driver to be created
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>This does not return anything</returns>
        public IHttpActionResult Post(DriverCreate driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDriverService();

            if (!service.CreateDriver(driver))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// This allows all of the drivers to be retreived
        /// </summary>
        /// <returns>This returns all of the drivers</returns>
        public IHttpActionResult Get()
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDrivers();
            return Ok(drivers);
        }

        /// <summary>
        /// This allows a particular driver to be retrieved by their Id
        /// </summary>
        /// <param name="id">This is the Driver Id</param>
        /// <returns>This returns that particular Driver</returns>
        [Route("api/Driver/{id}")]
        public IHttpActionResult Get(int id)
        {
            DriverService driverService = CreateDriverService();
            var driver = driverService.GetDriverById(id);
            return Ok(driver);
        }

        /// <summary>
        /// This allows all drivers at a certain location to be retreived
        /// </summary>
        /// <param name="location">This is the location of interest</param>
        /// <returns>This returns the drivers at that particular location</returns>
        [Route("api/Driver/GetByLocation/{location}")]
        public IHttpActionResult GetByLocation(string location)
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDriversByLocation(location);
            return Ok(drivers);
        }

        /// <summary>
        /// This allows all of the drivers with a certain occupancy to be retrieved
        /// </summary>
        /// <param name="occupancy">This is the desired occupancy</param>
        /// <returns></returns>
        [Route("api/Driver/GetByOccupancy/{occupancy}")]
        public IHttpActionResult GetByMaxOccupants(int occupancy)
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDriversByOccupancy(occupancy);
            return Ok(drivers);
        }

        /// <summary>
        /// This allows all of the drivers with a certain boat type to be retrieved
        /// </summary>
        /// <param name="boatType">This is the desired boat type</param>
        /// <returns>This returns all drivers with the particular boat type</returns>
        [Route("api/Driver/GetyByBoatType/{boatType}")]
        public IHttpActionResult GetByBoatType(BoatType boatType)
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDriversByBoatType(boatType);
            return Ok(drivers);
        }

        /// <summary>
        /// This allow all of the drivers that are available on a certain day to be retrieved
        /// </summary>
        /// <param name="daysOfWeek">This is the desired day of the week</param>
        /// <returns>This returns all drivers that are available on that particular day</returns>
        [Route("api/Driver/GetByDaysOfWeek/{daysOfWeek}")]
        public IHttpActionResult GetByDaysAvailable(DaysOfWeek daysOfWeek)
        {
            DriverService driverService = CreateDriverService();
            var drivers = driverService.GetDriversByDaysAvailable(daysOfWeek);
            return Ok(drivers);
        }

        /// <summary>
        /// This allow a drivers information to be changed
        /// </summary>
        /// <param name="driver"></param>
        /// <returns>This does not return anything</returns>
        public IHttpActionResult Put(DriverEdit driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDriverService();

            if (!service.UpdateDriver(driver))
                return InternalServerError();

            return Ok();
        }

        /// <summary>
        /// This allows a particular Driver to be deleted
        /// </summary>
        /// <param name="id">This is the Id of the driver to be deleted</param>
        /// <returns>This does not return anything</returns>
        [Route("api/Driver/{id}")]
        public IHttpActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var reservationService = new ReservationService(userId);

            reservationService.NullDriver(id);

            var service = CreateDriverService();

            if (!service.DeleteDriver(id))
                return InternalServerError();

            return Ok();
        }

        private DriverService CreateDriverService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var driverService = new DriverService(userId);
            return driverService;
        }
    }
}
