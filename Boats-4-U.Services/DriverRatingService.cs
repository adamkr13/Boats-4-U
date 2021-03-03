using Boats_4_U.Data;
using Boats_4_U.Models;
using Boats_4_U.Models.DriverRatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Services
{
    public class DriverRatingService
    {
        private readonly Guid _userId;

        public DriverRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDriverRating(DriverRatingCreate model)
        {
            var entity =

                new DriverRating()
                {
                    ApplicationUser = _userId,
                    DriverId = model.DriverId,
                    DriverFunScore = model.DriverFunScore,
                    DriverSafetyScore = model.DriverSafetyScore,
                    DriverCleanlinessScore = model.DriverCleanlinessScore,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DriverRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DriverRatingListItem> GetDriverRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .DriverRatings
                    .Select(
                        e =>
                        new DriverRatingListItem
                        {
                            DriverId = e.Driver.DriverId,
                            DriverFirstName = e.Driver.DriverFirstName,
                            DriverLastName = e.Driver.DriverLastName,
                            DriverRatings = e.Driver.DriverRatings
                        }
                        );

                return query.ToArray();

            }
        }
    }
}
