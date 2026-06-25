using Garage_1._0.Interfaces;
using Garage_1._0.Logic;
using Garage_1._0.VehicleModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Controlls
{
    public class StartUp
    {
        private readonly IConsoleUI _ui;

        public StartUp(IConsoleUI ui)
        {
            _ui = ui;
        }
        public IHandler Init()
        {
           _ui.Print("---Welcome to the Garage! Let's start!---");
           Console.WriteLine();

           Console.Write("Please enter the garage size: ");
           string sizeInput = Console.ReadLine() ?? "";


           int size = 0;
           while(!int.TryParse(sizeInput, out size))
           {
                Console.WriteLine("Invalid size please enter a number");
                sizeInput = Console.ReadLine() ?? "";
           }

            var garage = new Garage<Vehicle>(size);

            Handler handler = new Handler(garage);

            Console.WriteLine($"A garage of size {size} was created!");

            Console.Write("Populate the garage with default vehicles? (y/n): ");
            string populateChoice = Console.ReadLine() ?? "";

            if (populateChoice.ToLower() == "y")
                handler.PopulateGarage();
            else
                Console.WriteLine("Starting with an empty garage!");
            Console.WriteLine();


           return handler;

        }
    }
}
