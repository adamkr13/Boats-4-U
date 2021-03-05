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
                            DriverRatings = e.DriverRatings
                        });
                return query.ToArray();
            }
        }
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
                            HourlyRate = e.HourlyRate,
                            DriverRatings = e.DriverRatings
                        });
                return query.ToArray();
            }
        }

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
                            HourlyRate = e.HourlyRate,
                            DriverRatings = e.DriverRatings
                        });
                return query.ToArray();
            }
        }

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
                            HourlyRate = e.HourlyRate,
                            DriverRatings = e.DriverRatings
                        });
                return query.ToArray();
            }
        }

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
                            HourlyRate = e.HourlyRate,
                            DriverRatings = e.DriverRatings
                        });
                return query.ToArray();
            }
        }

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
                        HourlyRate = entity.HourlyRate,    
                        Rating = entity.Rating
                    };
            }
        }

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
