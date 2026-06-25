using Garage_1._0.VehicleModels;

namespace Garage_1._0.Logic;

public interface IGarage<T> : IEnumerable<T> where T : Vehicle
{
    bool AddVehicle(T vehicle);
    Vehicle? FindByRegistration(string registrationNumber);
    bool RemoveVehicle(string registrationNumber);
    bool IsFull { get; }
}