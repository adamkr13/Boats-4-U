using Boats_4_U.Data;
using Boats_4_U.Models.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Services
{
    public class DriverService
    {
        private readonly Guid _userId;

        public DriverService(Guid userId)
        {
            _userId = userId;
        }

        /// <summary>
        /// This will create a new driver!
        /// </summary>
        /// <param name="model">The drivers model, the different aspects of the driver (First Name, Last Name, Hourly Rate, Location, Type of Boat, Days Available, Maximum Number of Occupants).</param> 
        /// <returns>This does not return a value.</returns>
        public bool CreateDriver(DriverCreate model)
        {
            var entity =
                new Driver()
                {
                    ApplicationUser = _userId,
                    DriverFirstName = model.DriverFirstName,
                    DriverLastName = model.DriverLastName,
                    HourlyRate = model.HourlyRate,
                    Location = model.Location,
                    TypeOfBoat = model.TypeOfBoat,
                    DaysAvailable = model.DaysAvailable,
                    MaximumOccupants = model.MaximumOccupants
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Drivers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// This will get all of the drivers!
        /// </summary>
        /// <returns>This will return the Id, First Name, Last Name and Location of all the drivers.</returns>
        public IEnumerable<DriverListItem> GetDrivers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drivers
                        .Select(e => new DriverListItem
                        {
                            DriverId = e.DriverId,
                            ApplicationUser = e.ApplicationUser,
                            DriverFirstName = e.DriverFirstName,
                            DriverLastName = e.DriverLastName,
                            Location = e.Location,
                        });
                return query.ToArray();
            }
        }

        /// <summary>
        /// This will get all of the drivers at a specific location.
        /// </summary>
        /// <param name="location"> This is the location of the driver.</param>
        /// <returns>This will return the Id, First Name, Last Name, Location, Days Available, Type of Boat, Maximum Occupancy and Hourly Rate of all the drivers at that location.</returns>
        public IEnumerable<DriverDetailTwo> GetDriversByLocation(string location)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drivers
                        .Where(e => e.Location == location)
                        .Select(e => new DriverDetailTwo
                        {
                            DriverId = e.DriverId,
                            ApplicationUser = e.ApplicationUser,
                            DriverFirstName = e.DriverFirstName,
                            DriverLastName = e.DriverLastName,
                            Location = e.Location,
                            DaysAvailable = e.DaysAvailable,
                            TypeOfBoat = e.TypeOfBoat,
                            MaximumOccupants = e.MaximumOccupants,
                            HourlyRate = e.HourlyRate
                        });
                return query.ToArray();
            }
        }

        /// <summary>
        /// This will get all of the drivers with a specific type of boat.
        /// </summary>
        /// <param name="boatType">This is the boat type of the driver.</param> 
        /// <returns>This returns the Id, First Name, Last Name, Location, Days Available, Type of Boat, Maximum Occupancy and Hourly Rate of all of the drivers with a specific type of boat.</returns>
        public IEnumerable<DriverDetailTwo> GetDriversByBoatType(BoatType boatType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drivers
                        .Where(e => e.TypeOfBoat == boatType)
                        .Select(e => new DriverDetailTwo
                        {
                            DriverId = e.DriverId,
                            ApplicationUser = e.ApplicationUser,
                            DriverFirstName = e.DriverFirstName,
                            DriverLastName = e.DriverLastName,
                            Location = e.Location,
                            DaysAvailable = e.DaysAvailable,
                            TypeOfBoat = e.TypeOfBoat,
                            MaximumOccupants = e.MaximumOccupants,
                            HourlyRate = e.HourlyRate
                        });
                return query.ToArray();
            }
        }

        /// <summary>
        /// This will get all of the drivers with a specific type of boat.
        /// </summary>
        /// <param name="occupancy">This is the maximum occupancy of the boat desired.</param> 
        /// <returns>This will return the Id, First Name, Last Name, Location, Days Available, Type of Boat, Maximum Occupancy and Hourly Rate of all of the drivers that can hold that many people.</returns>
        public IEnumerable<DriverDetailTwo> GetDriversByOccupancy(int occupancy)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drivers
                        .Where(e => e.MaximumOccupants >= occupancy)
                        .Select(e => new DriverDetailTwo
                        {
                            DriverId = e.DriverId,
                            ApplicationUser = e.ApplicationUser,
                            DriverFirstName = e.DriverFirstName,
                            DriverLastName = e.DriverLastName,
                            Location = e.Location,
                            DaysAvailable = e.DaysAvailable,
                            TypeOfBoat = e.TypeOfBoat,
                            MaximumOccupants = e.MaximumOccupants,
                            HourlyRate = e.HourlyRate
                        });
                return query.ToArray();
            }
        }

        /// <summary>
        /// This gets all of the drivers by which days they are available.
        /// </summary>
        /// <param name="daysOfWeek">This is the days of the week that the driver is available</param> 
        /// <returns>This returns the Id, Firsst Name, Last Name, Location, Days Available, Type of Boat, Maximum Occupancy and Hourly Rate of all of the drivers available on that day.</returns>
        public IEnumerable<DriverDetailTwo> GetDriversByDaysAvailable(DaysOfWeek daysOfWeek)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Drivers
                        .Where(e => e.DaysAvailable.HasFlag(daysOfWeek))
                        .Select(e => new DriverDetailTwo
                        {
                            DriverId = e.DriverId,
                            ApplicationUser = e.ApplicationUser,
                            DriverFirstName = e.DriverFirstName,
                            DriverLastName = e.DriverLastName,
                            Location = e.Location,
                            DaysAvailable = e.DaysAvailable,
                            TypeOfBoat = e.TypeOfBoat,
                            MaximumOccupants = e.MaximumOccupants,
                            HourlyRate = e.HourlyRate
                        });
                return query.ToArray();
            }
        }

        /// <summary>
        /// This will get the driver by their Id.
        /// </summary>
        /// <param name="id">This is the Id of the driver.</param> 
        /// <returns>This will give the Id, Full Name, Location, Days Available, Boat Name, Maximum Occupancy and Hourly Rate of the driver with that Id.</returns>
        public DriverDetail GetDriverById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Drivers
                    .Single(e => e.DriverId == id);
                return
                    new DriverDetail
                    {
                        DriverId = entity.DriverId,
                        ApplicationUser = entity.ApplicationUser,
                        DriverFullName = entity.DriverFullName,
                        Location = entity.Location,
                        DaysAvailable = entity.DaysAvailable,
                        BoatName = entity.BoatName,
                        MaximumOccupants = entity.MaximumOccupants,
                        HourlyRate = entity.HourlyRate                    
                    };
            }
        }

        /// <summary>
        /// This allows you to update the drivers information.
        /// </summary>
        /// <param name="model">This is the model of the drivers updated information</param> 
        /// <returns></returns>
        public bool UpdateDriver(DriverEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Drivers
                    .Single(e => e.DriverId == model.DriverId && e.ApplicationUser == _userId);

                entity.DriverFirstName = model.DriverFirstName;
                entity.DriverLastName = model.DriverLastName;
                entity.HourlyRate = model.HourlyRate;
                entity.Location = model.Location;
                entity.TypeOfBoat = model.TypeOfBoat;
                entity.DaysAvailable = model.DaysAvailable;
                entity.MaximumOccupants = model.MaximumOccupants;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// This will remove the driver from the database
        /// </summary>
        /// <param name="driverId">This is the driversId</param> 
        /// <returns>This does not return anything.</returns>
        public bool DeleteDriver(int driverId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Drivers
                    .Single(e => e.DriverId == driverId && e.ApplicationUser == _userId);

                ctx.Drivers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
