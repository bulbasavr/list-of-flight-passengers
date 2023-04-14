using ListOfFlightPassengers.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ListOfFlightPassengers.Models
{
    public static class DataPassengers
    {
        public static ObservableCollection<Passenger> GetAllPassengers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                ObservableCollection<Passenger> result = new ObservableCollection<Passenger>();
                var allPassengers = db.Passengers.ToArray();

                foreach (var passenger in allPassengers)
                {
                    result.Add(passenger);
                }

                return result;
            }
        }

        public static void CreatePassenger(DateTime departureTime, string flightNumber, string passengerName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.Passengers.Any(el => el.DepartureTime == departureTime && el.FlightNumber == flightNumber && el.PassengerName == passengerName);
                if (!checkIsExist)
                {
                    Passenger newPassenger = new Passenger()
                    {
                        DepartureTime = departureTime,
                        FlightNumber = flightNumber,
                        PassengerName = passengerName
                    };

                    PassengerListVM.PassengerList.Add(newPassenger);
                    db.Passengers.Add(newPassenger);
                    db.SaveChanges();
                    MessageBox.Show("New passenger added!");
                }
            }
        }

        public static void DeletePassenger(Passenger passenger)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Passengers.Remove(passenger);
                PassengerListVM.PassengerList.Remove(passenger);
                db.SaveChanges();
            }
        }
    }
}
