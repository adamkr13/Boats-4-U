 using Boats_4_U.Data;
using Boats_4_U.Models;
using Boats_4_U.Models.RenterRatingModels;
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
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                new RenterRating()
                {
                    ApplicationUser = _userId,
                    RenterId = model.RenterId,
                    RenterCleanlinessScore = model.RenterCleanlinessScore,
                    RenterSafetyScore = model.RenterSafetyScore,
                    RenterPunctualityScore = model.RenterPunctualityScore,
                    UserCreatedRenterRating = ctx.Users.Single(rr => rr.Id == _userId.ToString()).UserName,
                };

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
                    UserCreatedRenterRating = entity.UserCreatedRenterRating,
                    RenterId = entity.RenterId,
                    RenterFullName = entity.Renter.RenterFullName,
                    RenterCleanlinessScore = entity.RenterCleanlinessScore,
                    RenterSafetyScore = entity.RenterSafetyScore,
                    RenterPunctualityScore = entity.RenterPunctualityScore,
                    AverageRenterRating = entity.AverageRenterRating,
                    LoggedInUser = ctx.Users.FirstOrDefault(d => d.Id == _userId.ToString()).UserName
                };
            }
        }

        public bool UpdateRenterRating(RenterRatingUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RenterRatings
                    .Single(e => e.RenterRatingId == model.RenterRatingId && e.ApplicationUser == _userId);

                entity.RenterId = model.RenterId;
                entity.RenterCleanlinessScore = model.RenterCleanlinessScore;
                entity.RenterSafetyScore = model.RenterSafetyScore;
                entity.RenterPunctualityScore = model.RenterPunctualityScore;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRenterRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .RenterRatings
                    .Single(e => e.RenterRatingId == id && e.ApplicationUser == _userId);

                ctx.RenterRatings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
