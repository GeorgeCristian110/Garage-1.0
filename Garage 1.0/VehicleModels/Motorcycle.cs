using Garage_1._0.VehicleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; protected set; }

        public Motorcycle(string registrationNumber, string color, 
            int numberOfWheels, string brand, int cylinderVolume)
            : base(registrationNumber, color, numberOfWheels, brand)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string ToString()
        {
            return base.ToString() + $"| The cylinder volume is: {CylinderVolume}";
        }
    }
}
