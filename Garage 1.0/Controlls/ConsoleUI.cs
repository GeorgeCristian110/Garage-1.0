using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_1._0.Controlls;

public class ConsoleUI : IConsoleUI
{
    public string GetInput() => Console.ReadLine() ?? "";
    public void Print(string message) => Console.WriteLine(message);
}
