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
                            DriverLastName = e.DriverLastName
                        });
                return query.ToArray();
            }
        }
    }
}
