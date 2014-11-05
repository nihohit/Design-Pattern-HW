using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    public interface IVehicle
    {
        string ModelName { get; }

        string LicenseNumber { get; }

        IEnumerable<Wheel> Wheels { get; }
    }

    public interface IElectricVehicle
    {
        ElectricEngine Engine { get; }
    }

    public interface IRegularVehicle
    {
        GasEngine Engine { get; }
    }

    public interface IMotorcycle : IVehicle
    {
        eLicense LicenseType { get; }

        int EngineSize { get; }
    }

    public interface IElectricMotorcycle : IMotorcycle, IElectricVehicle
    {
    }

    public interface IRegularMotorcycle : IMotorcycle, IRegularVehicle
    {
    }

    public interface ICar : IVehicle
    {
        eColor Color { get; }

        int DoorAmount { get; }
    }

    public interface IElectricCar : ICar, IElectricVehicle
    {
    }

    public interface IRegularCar : ICar, IRegularVehicle
    {
    }

    public interface ITruck : IRegularVehicle
    {
        bool CarryingDangerousMaterials { get; }

        float MaximumAllowedCarryingWeight { get; }
    }
}