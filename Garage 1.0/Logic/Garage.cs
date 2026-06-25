using Garage_1._0.VehicleModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Garage_1._0.Logic
{
    // The <T> makes this a Generic class. 'where T : Vehicle'
    // ensures we only allow objects that inherit from Vehicle.
    public class Garage<T> : IGarage<T> where T : Vehicle
    {
        private readonly T?[] _vehicles; // Fixed size array of type T.
        private int _count = 0; // Keep track of the number of vehicles in the garage.

        public bool IsFull => _count >= _vehicles.Length;

        public Garage(int capacity)//We set the size of the garage when we create it.
        {
            //Validate
            _vehicles = new T[capacity];
        }

        public bool AddVehicle(T vehicle)//Method to park a vehicle in an empty spot.
        {
            if (IsFull) return false; // Checks if the garage is full. stops adding if it is.

            //Validate duplicate regnr!!!!
            if(this.Any(v => v.RegistrationNumber.Equals(vehicle.RegistrationNumber, StringComparison.CurrentCultureIgnoreCase)))
                return false;
            //var index = Array.IndexOf(_vehicles, null);
            //if(index != -1) 
            //{ 
            //    _vehicles[index] = vehicle;
            //    _count++;
            //    return true;
            //}

            for (int i = 0; i < _vehicles.Length; i++) //Loops the array to find a null space
            {
                if (_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;//we place the vehicle in the empty spot.
                    _count++;// Raise the occupancy counter .
                    return true;
                }
            }
            return false; // breaks the loop if we dont find a spot.
        }

        //Method to remove a vehicle by matching is registrationNumber
        public bool RemoveVehicle(string registrationNumber)
        {
            for (int i = 0; i < _vehicles.Length; i++)//Loop the array to find the matching vehicle.
            {
                //if (_vehicles[i] != null && _vehicles[i]!.RegistrationNumber.Equals(registrationNumber,
                //    StringComparison.OrdinalIgnoreCase))//OrdinalIgnoreCase ignores the string case to match the registrationNumber.
               if((FindByRegistration(registrationNumber) != null))
                {
                    _vehicles[i] = null!;//Sets that spot to null to remove the vehicle
                    _count--;// Lowers the occupancy counter.
                    return true;
                }
            }
            return false;
        }

        //Method to find the vehicle or give null if it does not exist.
        public Vehicle? FindByRegistration(string registrationNumber)
        {
            foreach (var vehicle in _vehicles)
            {
                //Check is a spot is occupied and the registration matches.
                if (vehicle != null && vehicle.RegistrationNumber.Equals(registrationNumber,
                  StringComparison.OrdinalIgnoreCase))
                {
                    return vehicle;//Returns the vehicle found that matches the registration.
                }
            }
            return null;
        }

        //Implemnetation of GetEnumerator, allows us to use foreach loops.
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in _vehicles)
            {
                if (vehicle != null)
                {
                    yield return vehicle; // Returns each non-null vehicle
                }
            }
        }

        //Ensures that we have a consistent behavior by redirecting the generic version above.
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
