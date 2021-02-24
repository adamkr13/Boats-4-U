using Boats_4_U.Data;
using Boats_4_U.Models;
using Boats_4_U.Models.ReservationModels;
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
                    ApplicationUser = _userId,
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
        // GET - View all Reservations (for all Users)
        public IEnumerable<ReservationListItem> GetReservations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reservations
                    .Select(
                        e =>
                            new ReservationListItem
                            {
                                ReservationId = e.ReservationId,
                                ApplicationUser = e.ApplicationUser,
                                DateReservedFor = e.DateReservedFor,
                                DateReservationMade = e.DateReservationMade
                            }
                        );
                return query.ToArray();
            }
        }
        // GET - View Reservation by Reservation ID - This theoretically will work for Drivers and Renters with the correct Id
        public ReservationDetail GetReservationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Reservation entity =
                    ctx
                    .Reservations
                    .Single(e => e.ReservationId == id);
                return
                    new ReservationDetail
                    {
                        ReservationId = entity.ReservationId,
                        ApplicationUser = entity.ApplicationUser,
                        RenterFullName = entity.Renter.RenterFullName,
                        DriverFullName = entity.Driver.DriverFullName,
                        DisplayDateReservedFor = entity.DisplayDateReservedFor,
                        ReservationDuration = entity.ReservationDuration,
                        BoatName = entity.Driver.BoatName,
                        NumberOfPassengers = entity.NumberOfPassengers,
                        ReservationDetails = entity.ReservationDetails,
                        Last4Digits = entity.Renter.Last4Digits,
                        EstimatedTotalCost = entity.EstimatedTotalCost,
                        DisplayDateReservationMade = entity.DisplayDateReservationMade
                    };
            }
        }
        // GET - View Reservation(s) by Driver - This theoretically will work for Drivers or Renters wanting to view Reservations by a particular Driver - would like to only allow Driver role to have access to this service
        public IEnumerable<ReservationDetailTwo> GetReservationByDriverId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                    var query =
                        ctx
                        .Reservations
                        .Where(e => e.DriverId == id)
                        .Select(
                            e =>
                                new ReservationDetailTwo
                                {
                                    ReservationId = e.ReservationId,
                                    ApplicationUser = e.ApplicationUser,
                                    RenterFirstName = e.Renter.RenterFirstName,
                                    RenterLastName = e.Renter.RenterLastName,
                                    DriverFirstName = e.Driver.DriverFirstName,
                                    DriverLastName = e.Driver.DriverLastName,
                                    DateReservedFor = e.DateReservedFor,
                                    ReservationDuration = e.ReservationDuration,
                                    TypeOfBoat = e.Driver.TypeOfBoat,
                                    NumberOfPassengers = e.NumberOfPassengers,
                                    ReservationDetails = e.ReservationDetails,
                                    CreditCardNumber = e.Renter.CreditCardNumber,
                                    HourlyRate = e.Driver.HourlyRate,
                                    DateReservationMade = e.DateReservationMade
                                }
                           );
                    return query.ToArray();
            }
        }
        // GET - View Reservation(s) by Renter - This theoretically is only accessible by unique Renters - Renters will only be able to see Reservations associated with their unique User Id
        public IEnumerable<ReservationDetailTwo> GetReservationByRenterId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reservations
                    .Where(e => e.RenterId == id && e.ApplicationUser == _userId)
                    .Select(
                        e =>
                            new ReservationDetailTwo
                            {
                                ReservationId = e.ReservationId,
                                ApplicationUser = e.ApplicationUser,
                                RenterFirstName = e.Renter.RenterFirstName,
                                RenterLastName = e.Renter.RenterLastName,
                                DriverFirstName = e.Driver.DriverFirstName,
                                DriverLastName = e.Driver.DriverLastName,
                                DateReservedFor = e.DateReservedFor,
                                ReservationDuration = e.ReservationDuration,
                                TypeOfBoat = e.Driver.TypeOfBoat,
                                NumberOfPassengers = e.NumberOfPassengers,
                                ReservationDetails = e.ReservationDetails,
                                CreditCardNumber = e.Renter.CreditCardNumber,
                                HourlyRate = e.Driver.HourlyRate,
                                DateReservationMade = e.DateReservationMade

                            }
                       );
                return query.ToArray();
            }
        }
        // GET - View Reservation(s) by Date
        public IEnumerable<ReservationDetailTwo> GetReservationByDate(DateTimeOffset date)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reservations
                    .Where(e => e.DateReservedFor == date)
                    .Select(
                        e =>
                            new ReservationDetailTwo
                            {
                                ReservationId = e.ReservationId,
                                ApplicationUser = e.ApplicationUser,
                                RenterFirstName = e.Renter.RenterFirstName,
                                RenterLastName = e.Renter.RenterLastName,
                                DriverFirstName = e.Driver.DriverFirstName,
                                DriverLastName = e.Driver.DriverLastName,
                                DateReservedFor = e.DateReservedFor,
                                ReservationDuration = e.ReservationDuration,
                                TypeOfBoat = e.Driver.TypeOfBoat,
                                NumberOfPassengers = e.NumberOfPassengers,
                                ReservationDetails = e.ReservationDetails,
                                CreditCardNumber = e.Renter.CreditCardNumber,
                                HourlyRate = e.Driver.HourlyRate,
                                DateReservationMade = e.DateReservationMade
                            }
                       );
                return query.ToArray();
            }
        }
        // PUT - Update Reservation
        public bool UpdateReservation(ReservationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reservations
                    .Single(e => e.ReservationId == model.ReservationId && e.ApplicationUser == _userId);

                entity.NumberOfPassengers = model.NumberOfPassengers;
                entity.DateReservedFor = model.DateReservedFor;
                entity.ReservationDuration = model.ReservationDuration;
                entity.ReservationDetails = model.ReservationDetails;
                entity.DateReservationMade = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        // DELETE - Delete Reservation
        public bool DeleteReservation(int reservationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reservations
                    .Single(e => e.ReservationId == reservationId && e.ApplicationUser == _userId);

                ctx.Reservations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
