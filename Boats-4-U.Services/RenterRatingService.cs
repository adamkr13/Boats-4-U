using Boats_4_U.Data;
using Boats_4_U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Services
{
    public class RenterRatingService
    {
        private readonly Guid _userId;

        public RenterRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRenterRating(RenterRatingCreate model)
        {
            var entity =

                new RenterRating()
                {
                    ApplicationUser = _userId,
                    RenterId = model.RenterId,
                    RenterCleanlinessScore = model.RenterCleanlinessScore,
                    RenterSafetyScore = model.RenterSafetyScore,
                    RenterPunctualityScore = model.RenterPunctualityScore,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.RenterRatings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public RenterRatingDetail GetRenterRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RenterRatings
                    .Single(e => e.RenterRatingId == id);
                return
                new RenterRatingDetail
                {
                    RenterRatingId = entity.RenterRatingId,
                    ApplicationUser = entity.ApplicationUser,
                    RenterId = entity.RenterId,
                    RenterFullName = entity.Renter.RenterFullName,
                    RenterCleanlinessScore = entity.RenterCleanlinessScore,
                    RenterSafetyScore = entity.RenterSafetyScore,
                    RenterPunctualityScore = entity.RenterPunctualityScore,
                    AverageRenterRating = entity.AverageRenterRating
                };
            }
        }
    }
}
