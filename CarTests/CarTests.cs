using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        Car test_car;
        [TestInitialize]
        public void CreateCarObject()
        {
            test_car = new Car("Toyota", "Prius", 10, 50);
        }
        [TestMethod]
        public void TestInitialGasTank()
        {
           // Car testCar = new Car("Toyota", "Corolla", 10, 50);
            Assert.AreEqual(10, test_car.GasTankLevel, .001);
        }
        [TestMethod]
        //TODO: gasTankLevel is accurate after driving within tank range
        public void TestGasTankAfterDriving()
        {
            test_car.Drive(50);
            Assert.AreEqual(9, test_car.GasTankLevel, .001);
        }
        //TODO: gasTankLevel is accurate after attempting to drive past tank range
        [TestMethod]
        public void TestGasTankAfterExceedingTankRange()
        {
            test_car.Drive(451);
            Assert.IsTrue(1 > test_car.GasTankLevel);
        }
        //  TODO: can't have more gas than tank size, expect an exception
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestGasOverfillException()
        {
            test_car.AddGas(5);
            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank");
        }

    }
}
