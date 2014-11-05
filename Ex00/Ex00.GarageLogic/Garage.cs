using System;
using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    #region Garage

    public class Garage
    {
        #region private fields

        private readonly Dictionary<string, GarageEntry> m_VehiclesInGarage = new Dictionary<string, GarageEntry>();

        #endregion private fields

        #region methods

        public string AddVehicle(IVehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            GarageEntry garageEntry;
            if (!m_VehiclesInGarage.TryGetValue(i_Vehicle.LicenseNumber, out garageEntry))
            {
                garageEntry = new GarageEntry(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
                m_VehiclesInGarage[i_Vehicle.LicenseNumber] = garageEntry;
                return string.Format("Received {0}", garageEntry);
            }

            garageEntry.VehicleState = eVehicleState.UnderRepair;
            return string.Format("Already contains {0}", garageEntry);
        }

        public IEnumerable<GarageEntry> GetEntries()
        {
            return m_VehiclesInGarage.Values;
        }

        public void SetNewState(string i_LicenseNumber, eVehicleState i_NewState)
        {
            getEntryOrFail(i_LicenseNumber).VehicleState = i_NewState;
        }

        public void RefillTires(string i_LicenseNumber)
        {
            foreach (var wheel in getEntryOrFail(i_LicenseNumber).Vehicle.Wheels)
            {
                wheel.FillToMax();
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, eFuelType i_FuelType, float i_AmountToFill)
        {
            GarageEntry garageEntry = getEntryOrFail(i_LicenseNumber);
            IRegularVehicle fuelBasedVehicle = garageEntry.Vehicle as IRegularVehicle;
            if (fuelBasedVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} isn't fuel based", garageEntry));
            }

            fuelBasedVehicle.Engine.FillFuel(i_AmountToFill, i_FuelType);
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_AmountToCharge)
        {
            GarageEntry garageEntry = getEntryOrFail(i_LicenseNumber);
            IElectricVehicle electricVehicleVehicle = garageEntry.Vehicle as IElectricVehicle;
            if (electricVehicleVehicle == null)
            {
                throw new ArgumentException(string.Format("Vehicle {0} isn't electric", garageEntry));
            }

            electricVehicleVehicle.Engine.ChargeEngine(i_AmountToCharge);
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {
            return getEntryOrFail(i_LicenseNumber).ToString();
        }

        private GarageEntry getEntryOrFail(string i_LicenseNumber)
        {
            GarageEntry garageEntry;
            if (!m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out garageEntry))
            {
                throw new ArgumentException(string.Format("Vehicle {0} not in garage.", i_LicenseNumber));
            }

            return garageEntry;
        }

        #endregion methods
    }

    #endregion Garage
}