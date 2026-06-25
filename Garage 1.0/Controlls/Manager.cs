using Garage_1._0.Interfaces;
using Garage_1._0.VehicleModels;
using Garage_1._0.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Garage_1._0.Controlls
{
    public class Manager 
    {
        private IHandler _handler;
        private IConsoleUI ui;

        public Manager(IHandler handler, IConsoleUI ui)
        {
            _handler = handler;
            this.ui = ui;
        }

        public void ShowMainMenu()
        {
            bool isActive = true;
            while (isActive)
            {
                ui.Print("Choose the option you want to proceed with: ");
                ui.Print("1. Park a vehicle ");
                ui.Print("2. Remove vehicle ");
                ui.Print("3. Show all parked vehicles ");
                ui.Print("4. Find vehicle by registration number ");
                ui.Print("5. Find vehicles by properties ");
                ui.Print("6. Show vehicle type and the count ");
                ui.Print("0. Exit main menu ");

                string userChoice = ui.GetInput();

                switch (userChoice)
                {
                    case "1":
                        Console.Clear();
                        ParkVehicle();
                        break;

                    case "2":
                        Console.Clear();
                        RemoveVehicle();
                        break;

                    case "3":
                        Console.Clear();
                        ShowAllParkedVehicles();
                        break;

                    case "4":
                        Console.Clear();
                        FindVehicleByRegistrationNumber();
                        break;

                    case "5":
                        Console.Clear();
                        FindVehiclesByProperties();
                        break;

                    case "6":
                        Console.Clear();
                        ShowVehiclesTypeAndCount();
                        break;

                    case "0":
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Please try using an existing choice!");
                        break;

                }
            }
        }


        private void ParkVehicle()
        {
            if (_handler.IsGarageFull)
            {
                Console.WriteLine("....");
                return;
            }

            Console.WriteLine("Sekect vehicle type:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Bus");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Airplane");

            string userChoice = Console.ReadLine() ?? "";

            string[] validChoices = { "1", "2", "3", "4", "5" };

            if(!validChoices.Contains(userChoice))
            {
                Console.WriteLine("Invalid option try again");
                return;
            }

            Console.Write("Registration number: ");
            string reg = Console.ReadLine() ?? "";

            Console.Write("Color: ");
            string color = Console.ReadLine() ?? "";

            Console.Write("Number of wheels: ");
            int.TryParse(Console.ReadLine(), out int wheels);

            Console.Write("Brand: ");
            string brand = Console.ReadLine() ?? "";

            Vehicle? vehicle = null;

            switch (userChoice)
            {
                case "1":
                    Console.Write("Whats the fuel type? Gasloine or Diesel: ");
                    string fuelInput = Console.ReadLine()!;
                    vehicle = new Car(reg, color, wheels, brand, fuelInput);
                    break;

                case "2":
                    Console.Write("What is the cylinder volume? Enter volume: ");
                    int.TryParse(Console.ReadLine(), out int cylinderInput);
                    vehicle = new Motorcycle(reg, color, wheels, brand, cylinderInput);
                    break;

                case "3":
                    Console.Write("Enter the number of seats inside the vehicle: ");
                    int.TryParse(Console.ReadLine(), out int seatsInput);
                    vehicle = new Bus(reg, color, wheels, brand, seatsInput);
                    break;

                case "4":
                    Console.Write("Enter the vehicles lenght. Lenght: ");
                    double.TryParse(Console.ReadLine(), out double lenghtInput);
                    vehicle = new Boat(reg, color, wheels, brand, lenghtInput);
                    break;

                case "5":
                    Console.Write("Enter the number of engines: ");
                    int.TryParse(Console.ReadLine(), out int engineInput);
                    vehicle = new Airplane(reg, color, wheels, brand, engineInput);
                    break;

            }
            if (vehicle == null)
                return;

            Console.WriteLine(_handler.AddVehicle(vehicle));
            Console.WriteLine();
        }

        private void RemoveVehicle()
        {
            Console.Write("Please enter your registrating number: ");
            string userInput = Console.ReadLine() ?? "";

            bool success = _handler.RemoveVehicle(userInput);

            if (success) 
                Console.WriteLine("Vehicle left the garage");
            else 
                Console.WriteLine("No vehicle was found!");

            Console.WriteLine();
        }

        private void ShowAllParkedVehicles()
        {
            var vehicles = _handler.GetAllVehicles();

            if (!vehicles.Any())
            {
                Console.WriteLine("The garage is empty. No vehicles can be shown!");
                Console.WriteLine();
                return;
            }
            
        foreach (string vehicle in _handler.GetAllVehicles())
          {
            ui.Print(vehicle);
          }
            
            Console.WriteLine();
        }

        private void FindVehicleByRegistrationNumber()
        {
            Console.Write("Please enter your vehicles registration number: ");
            string userInput = Console.ReadLine() ?? "";

            Vehicle? vehicle = _handler.FindByRegistration(userInput);

            if (vehicle == null)
                Console.WriteLine("Sorry no vehicle with that registraion number was found in the garage!");
            else
                Console.WriteLine(vehicle);

            Console.WriteLine();
        }

        private void FindVehiclesByProperties()
        {
            Console.Write("Enter the color wished: ");
            string colorInput = Console.ReadLine() ?? "";

            Console.Write("Enter the number of wheels: ");
            string wheelsInput = Console.ReadLine() ?? "";

            Console.Write("Enter the vehicle type: ");
            string typeInput = Console.ReadLine() ?? "";

            var results = _handler.SearchVechicles(v =>
            {
                if (!string.IsNullOrWhiteSpace(colorInput) && !v.Color.Equals(colorInput, StringComparison.OrdinalIgnoreCase))
                    return false;

                if (!string.IsNullOrWhiteSpace(wheelsInput) && int.TryParse(wheelsInput, out var wheels) && v.NumberOfWheels != wheels)
                    return false;

                if (!string.IsNullOrWhiteSpace(typeInput) && !v.GetType().Name.Equals(typeInput, StringComparison.OrdinalIgnoreCase))
                    return false;

                else
                    return true;

            });

            foreach (var vechicle in results)
            {
                Console.WriteLine(vechicle);
            }

            if (!results.Any())
                Console.WriteLine("No vehicles matched your choices.");

            Console.WriteLine();
        }

        private void ShowVehiclesTypeAndCount()
        {
            foreach (string vehicleType in _handler.GetVehicleTypes())
            {
                Console.WriteLine(vehicleType);
            }
            Console.WriteLine();
        }

    }

}
