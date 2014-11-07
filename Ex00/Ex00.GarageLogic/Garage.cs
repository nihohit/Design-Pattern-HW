using System;
using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    using System.Linq;

    public class Garage : ICommunicateWithConsole
    {
        #region private fields

        private readonly Dictionary<string, GarageEntry> r_VehiclesInGarage = new Dictionary<string, GarageEntry>();

        private readonly VehicleMaker r_VehicleMaker = new VehicleMaker();

        #endregion private fields

        #region methods

        private GarageEntry AddVehicleToGarage(string i_OwnerPhoneNumber, string i_OwnerName, string i_VehicleType, string[] i_Args)
        {
            IVehicle vehicle = r_VehicleMaker.CreateVehicle(i_VehicleType, i_Args);
            GarageEntry garageEntry = new GarageEntry(i_OwnerName, i_OwnerPhoneNumber, vehicle);
            this.r_VehiclesInGarage[vehicle.LicenseNumber] = garageEntry;
            return garageEntry;
        }

        private GarageEntry getEntryOrFail(string i_LicenseNumber)
        {
            GarageEntry garageEntry;
            if (!this.r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out garageEntry))
            {
                throw new ArgumentException(string.Format("Vehicle {0} not in garage.", i_LicenseNumber));
            }

            return garageEntry;
        }

        #endregion methods

        #region ICommunicateWithConsole

        public string AddGarageEntry(string i_LicenseNumber, string i_OwnerPhoneNumber, string i_OwnerName, string i_VehicleType, string[] i_Args)
        {
            GarageEntry garageEntry;
            if (!this.r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out garageEntry))
            {
                garageEntry = AddVehicleToGarage(i_OwnerPhoneNumber, i_OwnerName, i_VehicleType, i_Args);
                return string.Format("Received {0}", garageEntry);
            }

            garageEntry.VehicleState = eVehicleState.UnderRepair;
            return string.Format("Already contains {0}", garageEntry);
        }

        public IEnumerable<string> GetVehicleTypes()
        {
            return r_VehicleMaker.GetAllSupportedTypesAndArguments().Select(i_Pair => i_Pair.Key);
        }

        public IEnumerable<string> GetNecessaryArgsForType(string i_VehicleType)
        {
            return r_VehicleMaker.GetAllSupportedTypesAndArguments()
                .First(i_Pair => i_Pair.Key.Equals(i_VehicleType))
                .Value.Select(i_Param => i_Param.Name);
        }

        public void SetVehicleState(string i_LicenseNumber, eVehicleState i_NewVehicleState)
        {
            getEntryOrFail(i_LicenseNumber).VehicleState = i_NewVehicleState;
        }

        public void FillWheelsToMax(string i_LicenseNumber)
        {
            foreach (var wheel in getEntryOrFail(i_LicenseNumber).Vehicle.Wheels)
            {
                wheel.FillToMax();
            }
        }

        public IEnumerable<KeyValuePair<string, eVehicleState>> GetGarageVehiclesAndStates()
        {
            return this.r_VehiclesInGarage.ToDictionary(i_Pair => i_Pair.Key, i_Pair => i_Pair.Value.VehicleState);
        }

        public void FillGas(string i_LicenseNumber, eFuelType i_FuelType, float i_FuelAmountInLiters)
        {
            GarageEntry garageEntry = getEntryOrFail(i_LicenseNumber);
            IRegularVehicle fuelBasedVehicle = garageEntry.Vehicle as IRegularVehicle;
            if (fuelBasedVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} isn't fuel based", garageEntry));
            }

            fuelBasedVehicle.Engine.FillFuel(i_FuelAmountInLiters, i_FuelType);
        }

        public void ChargeEngine(string i_LicenseNumber, float i_ChargeHours)
        {
            GarageEntry garageEntry = getEntryOrFail(i_LicenseNumber);
            IElectricVehicle electricVehicleVehicle = garageEntry.Vehicle as IElectricVehicle;
            if (electricVehicleVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} isn't electric", garageEntry));
            }

            electricVehicleVehicle.Engine.ChargeEngine(i_ChargeHours);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return this.r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {
            return getEntryOrFail(i_LicenseNumber).Vehicle.ToString();
        }

        #endregion ICommunicateWithConsole
    }
}