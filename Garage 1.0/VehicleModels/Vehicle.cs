using Garage_1._0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.VehicleModels
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; protected set; } 

        public string Color { get;  } 
        public int NumberOfWheels { get;  }

        public string Brand { get;  } 


        public Vehicle(string registrationNumber, string color, int numberOfWheels, string brand)
        {
            //Validate
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
