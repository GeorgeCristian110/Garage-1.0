using Garage_1._0.VehicleModels;

namespace Garage_1._0.Interfaces
{
    public interface IHandler
    {
        string AddVehicle(Vehicle vehicle);
        Vehicle? FindByRegistration(string registrationNumber);
        IEnumerable<Vehicle> GetAllVehicles();
        IEnumerable<string> GetVehicleTypes();
        void PopulateGarage();
        bool RemoveVehicle(string registrationNumber);
        IEnumerable<Vehicle> SearchVechicles(Func<Vehicle, bool> filter);
    }
}