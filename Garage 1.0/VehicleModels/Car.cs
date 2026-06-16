using Garage_1._0.VehicleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    public class Car : Vehicle
    {

        public string FuelType { get; protected set; } = string.Empty;

        public Car(string registrationNumber, string color, int numberOfWheels, 
            string brand, string fuelType) 
            : base(registrationNumber, color, numberOfWheels, brand)
        {
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return base.ToString() + $"| This car's fuel type is: {FuelType}";
        }
    }
}
