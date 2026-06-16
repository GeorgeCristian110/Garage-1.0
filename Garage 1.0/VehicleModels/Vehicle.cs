using Garage_1._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.VehicleModels
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; protected set; } = string.Empty;

        public string Color { get; protected set; } = string.Empty;

        public int NumberOfWheels { get; protected set; }

        public string Brand { get; protected set; } = string.Empty;


        public Vehicle(string registrationNumber, string color, int numberOfWheels, string brand)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Brand = brand;
        }

        public override string ToString()
        {
            return $"{GetType().Name} - {Brand} | Reg: {RegistrationNumber} | Color: {Color} | Wheels: {NumberOfWheels}";
        }
    }

}
