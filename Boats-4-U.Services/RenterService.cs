using Boats_4_U.Data;
using Boats_4_U.Models;
using Boats_4_U.Models.Renter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Services
{
    public class RenterService
    {
        private readonly Guid _userId;

        
        public RenterService(Guid userId)
        {  
            _userId = userId;
        }

        /// <summary>
        /// This will create a new renter!
        /// </summary>
        /// <param name="model">The renters model, the different aspects of the renter (First Name, Last Name, Date of Birth and Credit Card Number).</param> 
        /// <returns>This does not return a value.</returns>
        public bool CreateRenter(RenterCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =

                new Renter()
                {
                    ApplicationUser = _userId,
                    RenterFirstName = model.RenterFirstName,
                    RenterLastName = model.RenterLastName,
                    DateOfBirth = model.DateOfBirth,
                    CreditCardNumber = model.CreditCardNumber,
                    UserCreatedRenter = ctx.Users.Single(r => r.Id == _userId.ToString()).UserName,
                };

                ctx.Renters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// This will get all Renters in the database.
        /// </summary>
        /// <returns>This returns the Id, First Name, Last Name and Date of Birth for all of the renters.</returns>
        public IEnumerable<RenterListItem> GetRenters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Renters
                        .Select(e => new RenterListItem
                        {
                            RenterId = e.RenterId,
                            ApplicationUser = e.ApplicationUser,
                            UserCreatedRenter = e.UserCreatedRenter,
                            RenterFirstName = e.RenterFirstName,
                            RenterLastName = e.RenterLastName,
                            DateOfBirth = e.DateOfBirth,
                            RenterRatings = e.RenterRatings,
                            LoggedInUser = ctx.Users.FirstOrDefault(d => d.Id == _userId.ToString()).UserName
                        }
                        );
                return query.ToArray();
            }
        }

        /// <summary>
        /// This will get the renter by his Id number.
        /// </summary>
        /// <param name="id">This is his personal Id number.</param> 
        /// <returns>This returns the Id, Full Name and Age of the renter.</returns>
        public RenterDetail GetRenterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Renters
                    .Single(e => e.RenterId == id);
                return
                    new RenterDetail
                    {
                        RenterId = entity.RenterId,
                        UserCreatedRenter = entity.UserCreatedRenter,
                        RenterFullName = entity.RenterFullName,
                        RenterAge = entity.RenterAge,
                        Rating = entity.Rating,
                        Recommended = entity.Recommended,
                        LoggedInUser = ctx.Users.FirstOrDefault(d => d.Id == _userId.ToString()).UserName
                    };
            }
        }

        /// <summary>
        /// This will update the information of the renter.
        /// </summary>
        /// <param name="model">This is the model and it includes the updated First Name, Last Name, Date of Birth and Credit Card Number of the renter.</param> 
        /// <returns>This does not return anything.</returns>
        public bool UpdateRenter(RenterUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Renters
                    .Single(e => e.RenterId == model.RenterId && e.ApplicationUser == _userId);

                entity.RenterFirstName = model.RenterFirstName;
                entity.RenterLastName = model.RenterLastName;
                entity.DateOfBirth = model.DateOfBirth;
                entity.CreditCardNumber = model.CreditCardNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// This will delete a renter.
        /// </summary>
        /// <param name="renterId">This is the renters Id.</param> 
        /// <returns>This does not return anything.</returns>
        public bool DeleteRenter(int renterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Renters
                    .Single(e => e.RenterId == renterId && e.ApplicationUser == _userId);

                ctx.Renters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
