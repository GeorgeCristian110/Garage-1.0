namespace Garage_1._0.Interfaces
{
    public interface IVehicle
    {
        string Brand { get; /*set;*/ }
        
        string Color { get; /*set;*/ }
        
        int NumberOfWheels { get; /*set;*/ }
        
        string RegistrationNumber { get; /*set;*/ }
       
        string ToString();
    }
}