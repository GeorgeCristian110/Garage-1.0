using Garage_1._0.Logic;
using Garage_1._0.VehicleModels;
using Garage_1._0.Vehicles;
using NUnit.Framework;

namespace Garage_1._0_Tests
{
    [TestFixture]
    public class GarageTests
    {
        [Test]
        public void AddVehicle_WhenGarageHasSpace_True()
        {
            // Arrange
            var garage = new Garage<Vehicle>(5);
            Vehicle car = new Car("JJK333", "Blue", 4, "Bmw", "Gasoline");

            // Act
            bool result = garage.AddVehicle(car);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddVehicle_WhenGrageIsFull_False()
        {
           //Arrange 
           var garage = new Garage<Vehicle>(1);
           Vehicle car1 = new Car("JJK200", "Silvr", 4, "Mercedes", "Diesel");
           Vehicle car2 = new Car("JJK111", "White", 4, "Audi", "Gasoline");

           garage.AddVehicle(car1);
           
           //Act
           bool result = garage.AddVehicle(car2);

           //Assert
           Assert.IsFalse(result);
        
        }
        
        [Test]
        public void RemoveVehicle_WhenVehicleIsParked_True()
        {
            //Arrange
            var garage = new Garage<Vehicle>(1);
            Vehicle car = new Car("Nnq213", "Green", 4, "Saab", "Diesel");

            garage.AddVehicle(car);

            //Act
            bool result  = garage.RemoveVehicle("Nnq213");

           //Asssert
           Assert.IsTrue(result);
        }

        [Test]
        public void RemoveVehicle_WhenVehicleIsNotParked_False()
        {
            //Arrange
            var garage = new Garage<Vehicle>(1);
            Vehicle car = new Car("Nnq213", "Green", 4, "Saab", "Diesel");

            //Act
            bool result = garage.RemoveVehicle("Nnq213");

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void FindVehicle_ByItsRegistration_True()
        {
            //Arrange
            var garage = new Garage<Vehicle>(1);
            Vehicle car = new Car("Nnw213", "Green", 4, "Saab", "Diesel");

            garage.AddVehicle(car);

            //Act
            var result = garage.FindByRegistration("Nnw213");

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void FindVehicle_ByRegistratio_WhenNotParked_False()
        {
            //Arrange
            var garage = new Garage<Vehicle>(1);
            Vehicle car = new Car("Nnw213", "Green", 4, "Saab", "Diesel");

            //Act
            var result = garage.FindByRegistration("Nnw213");

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void FindVehicle_ByRegistration_CaseNotSensitive_True()
        {
            //Arrange
            var garage = new Garage<Vehicle>(1);
            Vehicle car = new Car("LOL120", "Green", 4, "Saab", "Diesel");

            garage.AddVehicle(car);

            //Act
            var result = garage.FindByRegistration("lol120");

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Testing()
        {
            //Arrange
            var garage = new Garage<Vehicle>(2);
            Vehicle car = new Car("LOL120", "Green", 4, "Saab", "Diesel");
            Vehicle car2 = new Car("LOL120", "Green", 4, "Saab", "Diesel");

            garage.AddVehicle(car);

            //Act
            var result = garage.AddVehicle(car2);

            //Assert
            Assert.False(result);
        }

        [Test]

        public void GetEnumerator_WhenAddedVehicles_ReturnAll()
        {
            //Arrange
            var garage = new Garage<Vehicle>(3);
            Vehicle car = new Car("Lmo112", "Green", 4, "Saab", "Diesel");
            Vehicle car2 = new Car("Pmw235", "Grey", 4, "Mazda", "Diesel");

            garage.AddVehicle(car);
            garage.AddVehicle(car2);

            //Act
            int count = 0;
            foreach (var vehicle in garage)
                count++;

            //Assert
            Assert.AreEqual(2, count);

        }
    } 
}

 