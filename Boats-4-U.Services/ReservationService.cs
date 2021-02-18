﻿using Boats_4_U.Data;
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
        // GET - View all Reservations (for User) - this will only work for Renters ATM
        public IEnumerable<ReservationListItem> GetReservations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reservations
                    .Where(e => e.User == _userId)
                    .Select(
                        e =>
                            new ReservationListItem
                            {
                                ReservationId = e.ReservationId,
                                User = e.User,
                                RenterFullName = e.Renter.RenterFullName,
                                DriverFullName = e.Driver.DriverFullName,
                                DisplayDateReservedFor = e.DisplayDateReservedFor,
                                ReservationDuration = e.ReservationDuration,
                                BoatName = e.Driver.BoatName,
                                NumberOfPassengers = e.NumberOfPassengers,
                                ReservationDetails = e.ReservationDetails,
                                Last4Digits = e.Renter.Last4Digits,
                                EstimatedTotalCost = e.EstimatedTotalCost,
                                DisplayDateReservationMade = e.DisplayDateReservationMade
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
                        User = entity.User,
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
        public IEnumerable<ReservationDetail> GetReservationByDriverId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                    var query =
                        ctx
                        .Reservations
                        .Where(e => e.DriverId == id)
                        .Select(
                            e =>
                                new ReservationDetail
                                {
                                    ReservationId = e.ReservationId,
                                    User = e.User,
                                    RenterFullName = e.Renter.RenterFullName,
                                    DriverFullName = e.Driver.DriverFullName,
                                    DisplayDateReservedFor = e.DisplayDateReservedFor,
                                    ReservationDuration = e.ReservationDuration,
                                    BoatName = e.Driver.BoatName,
                                    NumberOfPassengers = e.NumberOfPassengers,
                                    ReservationDetails = e.ReservationDetails,
                                    Last4Digits = e.Renter.Last4Digits,
                                    EstimatedTotalCost = e.EstimatedTotalCost,
                                    DisplayDateReservationMade = e.DisplayDateReservationMade
                                }
                           );
                    return query.ToArray();
            }
        }
        // GET - View Reservation(s) by Renter - This theoretically is only accessible by unique Renters - Renters will only be able to see Reservations associated with their unique User Id
        public IEnumerable<ReservationDetail> GetReservationByRenterId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reservations
                    .Where(e => e.RenterId == id && e.User == _userId)
                    .Select(
                        e =>
                            new ReservationDetail
                            {
                                ReservationId = e.ReservationId,
                                User = e.User,
                                RenterFullName = e.Renter.RenterFullName,
                                DriverFullName = e.Driver.DriverFullName,
                                DisplayDateReservedFor = e.DisplayDateReservedFor,
                                ReservationDuration = e.ReservationDuration,
                                BoatName = e.Driver.BoatName,
                                NumberOfPassengers = e.NumberOfPassengers,
                                ReservationDetails = e.ReservationDetails,
                                Last4Digits = e.Renter.Last4Digits,
                                EstimatedTotalCost = e.EstimatedTotalCost,
                                DisplayDateReservationMade = e.DisplayDateReservationMade
                            }
                       );
                return query.ToArray();
            }
        }
        // GET - View Reservation(s) by Date
        //public IEnumerable<ReservationDetail> GetReservationByDate(DateTimeOffset date)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Reservations
        //            .Where(e => e.DateReservedFor == date && e.User == _userId)
        //            .Select(
        //                e =>
        //                    new ReservationDetail
        //                    {
        //                        ReservationId = e.ReservationId,
        //                        User = e.User,
        //                        RenterFullName = e.Renter.RenterFullName,
        //                        DriverFullName = e.Driver.DriverFullName,
        //                        DisplayDateReservedFor = e.DisplayDateReservedFor,
        //                        ReservationDuration = e.ReservationDuration,
        //                        BoatName = e.Driver.BoatName,
        //                        NumberOfPassengers = e.NumberOfPassengers,
        //                        ReservationDetails = e.ReservationDetails,
        //                        Last4Digits = e.Renter.Last4Digits,
        //                        EstimatedTotalCost = e.EstimatedTotalCost,
        //                        DisplayDateReservationMade = e.DisplayDateReservationMade
        //                    }
        //               );
        //        return query.ToArray();
        //    }
        //}
        // PUT - Update Reservation

        // DELETE - Delete Reservation

    }
}
