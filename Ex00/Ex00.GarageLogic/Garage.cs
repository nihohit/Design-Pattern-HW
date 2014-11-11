using System;
using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    using System.Linq;

    /// <summary>
    /// The garage holds vehicles and communicates with the console.
    /// </summary>
    public class Garage : ICommunicateWithConsole
    {
        #region private fields

        private readonly Dictionary<string, GarageEntry> r_VehiclesInGarage = new Dictionary<string, GarageEntry>();

        private readonly VehicleMaker r_VehicleMaker = new VehicleMaker();

        #endregion private fields

        #region private methods

        /// <summary>
        /// After checking that a vehicle isn't in the garage, create a new vehicle and add it to the garage.
        /// </summary>
        /// <param name="i_OwnerPhoneNumber">owner phone number</param>
        /// <param name="i_OwnerName">owner's name</param>
        /// <param name="i_VehicleType">type of vehicle</param>
        /// <param name="i_Args">arguments for vehicle creation</param>
        /// <returns></returns>
        private GarageEntry addVehicleToGarage(string i_OwnerPhoneNumber, string i_OwnerName, string i_VehicleType, string[] i_Args)
        {
            IVehicle vehicle = r_VehicleMaker.CreateVehicle(i_VehicleType, i_Args);
            GarageEntry garageEntry = new GarageEntry(i_OwnerName, i_OwnerPhoneNumber, vehicle);
            this.r_VehiclesInGarage[vehicle.LicenseNumber] = garageEntry;
            return garageEntry;
        }

        /// <summary>
        /// Try to get a vehicle from the garage, and if not in, throw ArgumentException
        /// </summary>
        /// <param name="i_LicenseNumber">License number of said vehicle</param>
        /// <returns></returns>
        private GarageEntry getEntryOrFail(string i_LicenseNumber)
        {
            GarageEntry garageEntry;
            if (!this.r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out garageEntry))
            {
                throw new ArgumentException(string.Format("Vehicle {0} not in garage.", i_LicenseNumber));
            }

            return garageEntry;
        }

        #endregion private methods

        #region ICommunicateWithConsole

        /// <summary>
        /// Try to add a vehicle to the garage. If it isn't in create a new entry. If it is, update it's state.
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_OwnerPhoneNumber"></param>
        /// <param name="i_OwnerName"></param>
        /// <param name="i_VehicleType"></param>
        /// <param name="i_Args"></param>
        /// <returns></returns>
        public string AddAVehicleToGarage(string i_LicenseNumber, string i_OwnerPhoneNumber, string i_OwnerName, string i_VehicleType, string[] i_Args)
        {
            GarageEntry garageEntry;
            if (!this.r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out garageEntry))
            {
                garageEntry = this.addVehicleToGarage(i_OwnerPhoneNumber, i_OwnerName, i_VehicleType, i_Args);
                return string.Format("{0}", garageEntry);
            }

            garageEntry.VehicleState = eVehicleState.UnderRepair;
            return string.Format("Already contains {0}\n{1}", i_LicenseNumber, garageEntry);
        }

        /// <summary>
        /// Get all vehicle types currently supported by the garage
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSupportedVehicleTypes()
        {
            return r_VehicleMaker.GetAllSupportedTypesAndArguments().Select(i_Pair => i_Pair.Key);
        }

        /// <summary>
        /// Get the names of the necessary arguments to create a new vehicle of a given type.
        /// </summary>
        /// <param name="i_VehicleType"></param>
        /// <returns></returns>
        public IEnumerable<string> GetNecessaryArgsForType(string i_VehicleType)
        {
            return r_VehicleMaker.GetAllSupportedTypesAndArguments()
                .First(i_Pair => i_Pair.Key.Equals(i_VehicleType))
                .Value.Select(i_Param => i_Param.Name);
        }

        /// <summary>
        /// Set the state of a vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_NewVehicleState"></param>
        public void SetVehicleState(string i_LicenseNumber, string i_NewVehicleState)
        {
            const bool v_IgnoreCase = true;
            string vehicleState;
            //// ValidateParamValueIsEnumName throw FormatException if i_NewVehicleState is not a eVehicleState enum name
            if (Extensions.ValidateParamValueIsEnumName("Vehicle state", typeof(eVehicleState), i_NewVehicleState, out vehicleState)) 
            {
                eVehicleState newVehicleState = (eVehicleState)Enum.Parse(typeof(eVehicleState), vehicleState, v_IgnoreCase); //// will succesed to parse becouse validated
                getEntryOrFail(i_LicenseNumber).VehicleState = newVehicleState;
            }
        }

        /// <summary>
        /// Completely fill the wheels of a given vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        public void FillWheelsToMax(string i_LicenseNumber)
        {
            foreach (Wheel wheel in getEntryOrFail(i_LicenseNumber).Vehicle.Wheels)
            {
                wheel.FillToMax();
            }
        }

        /// <summary>
        /// Get all vehicles in the garage, and their respective states
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> GetGarageVehiclesAndStates()
        {
            return this.r_VehiclesInGarage.ToDictionary(i_Pair => i_Pair.Key, i_Pair => i_Pair.Value.VehicleState.ToString());
        }

        /// <summary>
        /// Fill the gas in a regular vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_FuelType"></param>
        /// <param name="i_FuelAmountInLiters"></param>
        public void FillFuel(string i_LicenseNumber, string i_FuelType, float i_FuelAmountInLiters)
        {
            GarageEntry garageEntry = getEntryOrFail(i_LicenseNumber);
            IRegularVehicle fuelBasedVehicle = garageEntry.Vehicle as IRegularVehicle;
            if (fuelBasedVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle '{0}' isn't fuel based", i_LicenseNumber));
            }

            const bool v_IgnoreCase = true;
            string fuelTypeString;
            //// ValidateParamValueIsEnumName throw FormatException if i_FuelType is not a eFuelType enum name
            if (Extensions.ValidateParamValueIsEnumName("Fuel type", typeof(eFuelType), i_FuelType, out fuelTypeString)) 
            {
                eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), i_FuelType, v_IgnoreCase); ////will succesed to parse becouse validated
                fuelBasedVehicle.Engine.FillFuel(i_FuelAmountInLiters, fuelType);
            }
        }

        /// <summary>
        /// Charge the engine of an electric vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_ChargeMinutes"></param>
        public void ChargeEngine(string i_LicenseNumber, float i_ChargeMinutes)
        {
            GarageEntry garageEntry = getEntryOrFail(i_LicenseNumber);
            IElectricVehicle electricVehicleVehicle = garageEntry.Vehicle as IElectricVehicle;
            if (electricVehicleVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} isn't electric", i_LicenseNumber));
            }

            electricVehicleVehicle.Engine.ChargeEngine(i_ChargeMinutes);
        }

        /// <summary>
        /// Check if vehicle is in garage
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return this.r_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }

        /// <summary>
        /// Get the information of the given vehicle
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        public string GetVehicleInfo(string i_LicenseNumber)
        {
            return getEntryOrFail(i_LicenseNumber).Vehicle.ToString();
        }

        public IEnumerable<string> GetVehiclesStates()
        {
            return Enum.GetNames(typeof(eVehicleState)).AsEnumerable();
        }

        #endregion ICommunicateWithConsole
    }
}