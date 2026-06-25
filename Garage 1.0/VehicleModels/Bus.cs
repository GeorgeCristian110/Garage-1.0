using Garage_1._0.VehicleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get;  }

        public Bus(string registrationNumber, string color, int numberOfWheels,
            string brand, int numberOfSeats)
            : base(registrationNumber, color, numberOfWheels, brand)
        {
            //Validate
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return base.ToString() + $"| The bus has: {NumberOfSeats} seats inside";
        }
    }
}
