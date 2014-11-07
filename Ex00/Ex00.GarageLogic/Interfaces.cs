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
        /// <summary>
        /// Try to add a vehicle to the garage. If it isn't in create a new entry. If it is, update it's state.
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_OwnerPhoneNumber"></param>
        /// <param name="i_OwnerName"></param>
        /// <param name="i_VehicleType"></param>
        /// <param name="i_Args"></param>
        /// <returns></returns>
        string AddAVehicleToGarage(string i_LicenseNumber, string i_OwnerPhoneNumber, string i_OwnerName, string i_VehicleType, string[] i_Args);

        /// <summary>
        /// Get all vehicle types currently supported by the garage
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetSupportedVehicleTypes();

        /// <summary>
        /// Get the names of the necessary arguments to create a new vehicle of a given type.
        /// </summary>
        /// <param name="i_VehicleType"></param>
        /// <returns></returns>
        IEnumerable<string> GetNecessaryArgsForType(string i_VehicleType);

        /// <summary>
        /// Check if vehicle is in garage
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        bool IsVehicleInGarage(string i_LicenseNumber);

        /// <summary>
        /// Set the state of a vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_NewVehicleState"></param>
        void SetVehicleState(string i_LicenseNumber, eVehicleState i_NewVehicleState);

        /// <summary>
        /// Completely fill the wheels of a given vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        void FillWheelsToMax(string i_LicenseNumber);

        /// <summary>
        /// Get all vehicles in the garage, and their respective states
        /// </summary>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> GetGarageVehiclesAndStates();

        /// <summary>
        /// Fill the gas in a regular vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_FuelType"></param>
        /// <param name="i_FuelAmountInLiters"></param>
        void FillGas(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmountInLiters);

        /// <summary>
        /// Charge the engine of an electric vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_ChargeHours"></param>
        void ChargeEngine(string i_LicenseNumber, float i_ChargeHours);

        /// <summary>
        /// Get the information of the given vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        string GetVehicleInfo(string i_LicenseNumber);
    }
}