using Garage_1._0.Interfaces;
using Garage_1._0.VehicleModels;
using Garage_1._0.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Logic
{
    public class Handler : IHandler
    {
        private IGarage<Vehicle> _garage;

        public bool IsGarageFull => _garage.IsFull;

        public Handler(IGarage<Vehicle> vehicles)
        {
            _garage = vehicles;
        }

        public string AddVehicle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.RegistrationNumber)) // make sure the registration number is not null or white space
            {
                return "Registration number can not be empty.";
            }

            if ((_garage.FirstOrDefault(v => v.RegistrationNumber == v.RegistrationNumber) != null)) //make sure there can't be vehicle with the same registration number.
            {
                return "A vehicle with that registration number is already registred.";
            }

            if (vehicle.NumberOfWheels < 0)
                return "The numbers of wheels can not be nagative!";
            
            bool added = _garage.AddVehicle(vehicle); // tries to add the vehicle into the garage

            if (added) // Show the result based if there was free space or not
                return "The vehicle was parked!";
            else
                return "Garage is full. No more spaces to park in!";
        }


        public bool RemoveVehicle(string registrationNumber)
        {
            return _garage.RemoveVehicle(registrationNumber);
        }

        public Vehicle? FindByRegistration(string registrationNumber)
        {
            return _garage.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
        }

        public IEnumerable<string> GetAllVehicles()
        {
            return _garage.Select(v => v.ToString()); // Return all vehicles in the garage
        }

        public void PopulateGarage()
        {
            AddVehicle(new Car("ABC123", "Red", 4, "Toyota", "Gasoline"));
            AddVehicle(new Motorcycle("XYZ789", "Blue", 2, "Yamaha", 600));
            AddVehicle(new Bus("NJH456", "Yellow", 8, "Mercedes", 60));
            AddVehicle(new Boat("Bar321", "White", 0, "Bay", 10.5));
            AddVehicle(new Airplane("NYO220", "Black", 3, "Boeing", 6));
        }

        public IEnumerable<string> GetVehicleTypes() //Group the vehicles by their type and returns the count for each
        {
            return _garage
                .GroupBy(v => v.GetType().Name) // Groupings is done by class name
                .Select(g => $"{g.Key}: {g.Count()}"); //Formating the output to show for example: Car : 2
        }

        public IEnumerable<Vehicle> SearchVechicles(Func<Vehicle, bool> filter) //Filters the vehicles using a custom condition passed in as a function.
        {
            return _garage.Where(filter); // Linq to applay the filter to each vehicle.
        }
    }
}
