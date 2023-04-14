using ListOfFlightPassengers.Models;
using System;
using System.Collections.ObjectModel;

namespace ListOfFlightPassengers.ViewModels
{
    public class PassengerListVM
    {
        public DateTime NewDepartureTime { get; set; } = DateTime.Now;
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public string? NewFlightNumber { get; set; }
        public string? NewPassengerName { get; set; }
        public static ObservableCollection<Passenger> PassengerList { get; set; } = DataPassengers.GetAllPassengers();

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        int seconds = 0;
                        DateTime newDepartureTime = new DateTime(NewDepartureTime.Year, NewDepartureTime.Month, NewDepartureTime.Day, Hours, Minutes, seconds);
                        DataPassengers.CreatePassenger(newDepartureTime, NewFlightNumber, NewPassengerName);
                    }));
            }
        }
    }
}
