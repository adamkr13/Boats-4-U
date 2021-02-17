using Boats_4_U.Data;
using Boats_4_U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Services
{
    public class ReservationService
    {
        private readonly Guid _userId;

        public ReservationService(Guid userId)
        {
            _userId = userId;
        }

        // POST - Create new Reservation
        public bool CreateReservation(ReservationCreate model)
        {
            var entity =

                new Reservation()
                {
                    User = _userId,
                    DriverId = model.DriverId,
                    RenterId = model.RenterId,
                    NumberOfPassengers = model.NumberOfPassengers,
                    DateReservedFor = model.DateReservedFor,
                    ReservationDuration = model.ReservationDuration,
                    ReservationDetails = model.ReservationDetails,
                    DateReservationMade = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reservations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // GET - View all Reservations

        // GET - View Reservation(s) by Driver

        // GET - View Reservation(s) by Renter

        // GET - View Reservatio(s) by Date

        // PUT - Update Reservation

        // DELETE - Delete Reservation

    }
}
