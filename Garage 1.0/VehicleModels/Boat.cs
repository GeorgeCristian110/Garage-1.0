using Garage_1._0.VehicleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    public class Boat : Vehicle
    {
        public double Length { get; protected set; }
        
        public Boat(string registrationNumber, string color, int numberOfWheels,
            string brand, double length)
            : base(registrationNumber, color, numberOfWheels, brand)
        {
            Length = length;
        }

        public override string ToString()
        {
            return base.ToString() + $"| The boat lenght is: {Length}m";
        }
    }
}
