using Garage_1._0.Controlls;
using Garage_1._0.Interfaces;
using Garage_1._0.Logic;

namespace Garage_1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUI();
            var startup =  new StartUp(ui);

            IHandler handler = startup.Init();
            var manager = new Manager(handler, ui);
            manager.ShowMainMenu();

        }
    }
}
