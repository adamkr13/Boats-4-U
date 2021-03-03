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

        // POST
        public bool CreateRenter(RenterCreate model)
        {
            var entity =

                new Renter()
                {
                    ApplicationUser = _userId,
                    RenterFirstName = model.RenterFirstName,
                    RenterLastName = model.RenterLastName,
                    DateOfBirth = model.DateOfBirth,
                    CreditCardNumber = model.CreditCardNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Renters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET
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
                            RenterFirstName = e.RenterFirstName,
                            RenterLastName = e.RenterLastName,
                            DateOfBirth = e.DateOfBirth
                        }
                        );
                return query.ToArray();
            }
        }

        // GET by Id
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
                        ApplicationUser = entity.ApplicationUser,
                        RenterFullName = entity.RenterFullName,
                        RenterAge = entity.RenterAge
                    };
            }
        }

        // PUT
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

        // DELETE
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
