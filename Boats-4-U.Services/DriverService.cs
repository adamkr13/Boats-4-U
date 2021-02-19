using Boats_4_U.Data;
using Boats_4_U.Models.Driver;
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
                    User = _userId,
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
                            DriverFirstName = e.DriverFirstName,
                            DriverLastName = e.DriverLastName,
                            HourlyRate = e.HourlyRate,
                            Location = e.Location,
                            TypeOfBoat = e.TypeOfBoat,
                            //DaysAvailable = e.DaysAvailable,
                            MaximumOccupants = e.MaximumOccupants
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
                        DriverFirstName = entity.DriverFirstName,
                        DriverLastName = entity.DriverLastName,
                        HourlyRate = entity.HourlyRate,
                        Location = entity.Location,
                        TypeOfBoat = entity.TypeOfBoat,
                        DaysAvailable = entity.DaysAvailable,
                        MaximumOccupants = entity.MaximumOccupants                        
                    };
            }
        }

        public bool UpdateDriver(DriverEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Drivers
                    .Single(e => e.DriverId == model.DriverId && e.User == _userId);

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
                    .Single(e => e.DriverId == driverId && e.User == _userId);

                ctx.Drivers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
