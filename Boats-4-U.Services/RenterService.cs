﻿using Boats_4_U.Data;
using Boats_4_U.Models;
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
                    User = _userId,
                    RenterFirstName = model.RenterFirstName,
                    RenterLastName = model.RenterLastName,
                    RenterAge = model.RenterAge,
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
                        .Where(e => e.User == _userId)
                        .Select(e => new RenterListItem
                        {
                            RenterId = e.RenterId,
                            RenterAge = e.RenterAge,
                            RenterFirstName = e.RenterFirstName,
                            RenterLastName = e.RenterLastName,
                            CreditCardNumber = e.CreditCardNumber
                        }
                        );

                return query.ToArray();
            }
        }

        //Get by ID
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
                        RenterFirstName = entity.RenterFirstName,
                        RenterLastName = entity.RenterLastName,
                        RenterAge = entity.RenterAge,
                        
                    };
            }
        }

        //Update
        public bool UpdateRenter(RenterUpdate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Renters
                    .Single(e => e.RenterId == model.RenterId && e.User == _userId);

                entity.RenterFirstName = model.RenterFirstName;
                entity.RenterLastName = model.RenterLastName;
                entity.RenterAge = model.RenterAge;
                entity.CreditCardNumber = model.CreditCardNumber;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete
        public bool DeleteRenter(int renterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Renters
                    .Single(e => e.RenterId == renterId && e.User == _userId);

                ctx.Renters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
