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

        /// <summary>
        /// This will create a new reservation.
        /// </summary>
        /// <param name="model">This is the model of the reservation and includes Driver Id, Renter Id, Number of Passangers, Date of Reservation, Reservation Duration, Reservation Details and Date the Reservation was made.</param> 
        /// <returns>This does not return anything.</returns>
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
                var driver = ctx.Drivers.Find(model.DriverId);
                

                if (model.NumberOfPassengers > driver.MaximumOccupants - 1)
                    return false;
                
                //if (model.DateReservedFor.DayOfWeek != driver.DaysAvailable)

                ctx.Reservations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// This will get all of the reservations.
        /// </summary>
        /// <returns>This returns the Reservation Id, Reservation Date and the Date the Reservation was made.</returns>
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

        /// <summary>
        /// This will get the reservation by its Id.
        /// </summary>
        /// <param name="id">This is the Id of the Reservation.</param> 
        /// <returns>This returns the Id, Renter Full Name Driver Full Name, Reservation Date, Reservation Duration, Boat Name, Number of Passangers, Reservation Details, Last Four Digits of the Credit Card Number, Estimated Total Cost and Date Reservation was Made.</returns>
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
        /// <summary>
        /// This will get the reservation by a driver Id.
        /// </summary>
        /// <param name="id">This is the Id of the Driver</param>
        /// <returns>This returns the Id, Renter First Name, Renter Last Name, Driver First Name, Driver Last Name, Reservation Date, Reservation Duration, Type of Boat, Number of Passangers, Reservation Details, Credit Card Number, Hourly Rate, and Date Reservation was Made.</returns>
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
        /// <summary>
        /// This will get the reservations for a particular user.
        /// </summary>
        /// <param name="id">This is the Renters Id</param>
        /// <returns>This will return the Resercation Id, Renter First Name, Renter Last Name, Driver First Name, Driver Last Name, Reservation Date, Type of Boat, Number of Passangers, Reservation Details, Credit Card Number, Hourly Rate and Date Reservation was Made.</returns>
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
        /// <summary>
        /// This will get the reservations by a certain date
        /// </summary>
        /// <param name="date">This is the date of interest.</param>
        /// <returns>This will return the Ids, Renter First Name, Renter Last Name, Driver First Name, Driver Last Name, Reservation Date, Reservation Duration, Type of Boat, Number of Passangers, Reservation Details, Credit Card Number,  Hourly Rate and Date Reservation was Made of all the Reservations on that Day.</returns>
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
        /// <summary>
        /// This will all you to update a Reservation.
        /// </summary>
        /// <param name="model">This is the model of the reservation.  It includes the Number of Passangers, Reservation Date, Reservation Duration, Reservation Details and Date Reservation was Made.</param>
        /// <returns>This does not return anything.</returns>
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
        /// <summary>
        /// This will delete a reservation.
        /// </summary>
        /// <param name="reservationId">This is the Id of the Reservation.</param>
        /// <returns>This will not return anything.</returns>
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
        /// <summary>
        /// This helps if the Renter is Null
        /// </summary>
        /// <param name="Id">This is the renter Id</param>
        public void NullRenter(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reservations.Where(e => e.RenterId == Id);
                foreach (var reservation in entity)
                    reservation.RenterId = null;
                var test = (ctx.SaveChanges() > 0);
            }
        }

        /// <summary>
        /// This helps if the Driver is Null
        /// </summary>
        /// <param name="Id">This is the Driver Id</param>
        public void NullDriver(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Reservations.Where(e => e.DriverId == Id);
                foreach (var reservation in entity)
                    reservation.DriverId = null;
                var test = (ctx.SaveChanges() > 0);
            }
        }

    }
}
