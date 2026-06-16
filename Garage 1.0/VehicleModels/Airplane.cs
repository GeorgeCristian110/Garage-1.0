using Garage_1._0.VehicleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; protected set; }
        public Airplane(string registrationNumber, string color, int numberOfWheels,
            string brand, int numberOfEngines)
            : base(registrationNumber, color, numberOfWheels, brand)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return base.ToString() + $"| The airplane has: {NumberOfEngines} engines";
        }
    }
}
