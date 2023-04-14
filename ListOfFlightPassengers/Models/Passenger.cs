using System;
using System.Windows;

namespace ListOfFlightPassengers.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string? FlightNumber { get; set; }
        public string? PassengerName { get; set; }

        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new RelayCommand(obj =>
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to delete passenger?", "Delete", MessageBoxButton.YesNoCancel);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            DataPassengers.DeletePassenger(this);
                        }
                    }));
            }
        }
    }
}
