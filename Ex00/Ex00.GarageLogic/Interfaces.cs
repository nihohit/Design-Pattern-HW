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
        bool IsVehicleInGarage(string i_LicenseNumber);
        void SetVehicleState(string i_LicenseNumber, eVehicleState i_VehicleState);
        string GetVehicleInfo(string i_LicenseNumber);
        void FillWheelsToMax(string i_LicenseNumber);
        bool HasGasEngine(string i_LicenseNumber);
        bool HasElectricEngine(string i_LicenseNumber);
        void FillGas(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmountInLiters);
        void ChargeEngine(float i_ChargeMinutes);
        Dictionary<string, eVehicleState> GetGarageVehicleAndState();
        List<string> GetGarageVehicle(eVehicleState i_VehicleState);
        string[] GetGarageEntryNeededArgsDisplayNames(eVehicleType i_VehicleState);
        void AddGarageEntry(eVehicleType i_VehicleState, string[] Args);
    }
}