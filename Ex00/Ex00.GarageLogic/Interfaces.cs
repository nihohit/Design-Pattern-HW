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

    public interface ICommunicateWithConsole
    {
        string AddGarageEntry(string i_LicenseNumber, string i_OwnerPhoneNumber, string i_OwnerName, string i_VehicleType, string[] i_Args);

        IEnumerable<string> GetVehicleTypes();

        IEnumerable<string> GetNecessaryArgsForType(string i_VehicleType);

        bool IsVehicleInGarage(string i_LicenseNumber);

        void SetVehicleState(string i_LicenseNumber, eVehicleState i_NewVehicleState);

        void FillWheelsToMax(string i_LicenseNumber);

        IEnumerable<KeyValuePair<string, eVehicleState>> GetGarageVehiclesAndStates();

        void FillGas(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmountInLiters);

        void ChargeEngine(string i_LicenseNumber, float i_ChargeHours);

        string GetVehicleInfo(string i_LicenseNumber);
    }
}