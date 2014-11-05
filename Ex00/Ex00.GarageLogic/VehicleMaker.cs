namespace Ex00.GarageLogic
{
    public class VehicleMaker
    {
        #region consts

        private const int k_TruckAmountOfWheels = 14;
        private const float k_TruckFuelEngineCapacity = 180;
        private const float k_TruckMaxWheelPressure = 23;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        private const float k_CarFuelEngineCapacity = 44;
        private const float k_CarMaxWheelPressure = 27;
        private const float k_CarMaxElectricEngineCharge = 3.3f;
        private const int k_CarAmountOfWheels = 4;
        private const eFuelType k_CarFuelType = eFuelType.Octan98;

        private const eFuelType k_BikeFuelType = eFuelType.Octan95;
        private const int k_BikeAmountOfWheels = 2;
        private const float k_BikeFuelEngineCapacity = 7.2f;
        private const float k_BikeMaxElectricEngineCharge = 2.4f;
        private const float k_BikekMaxWheelPressure = 33;

        #endregion consts

        #region creation methods

        public static ITruck CreateTruck(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            bool i_CarryingDangerousMaterials,
            float i_MaximumAllowedWeight, 
            float i_CurrentWheelPressure,
            float i_CurrentFuelAmount)
        {
            return new Truck(
                i_ModelName,
                i_LicenseNumber,
                Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_TruckMaxWheelPressure, k_TruckAmountOfWheels),
                i_CarryingDangerousMaterials,
                i_MaximumAllowedWeight,
                k_TruckFuelType,
                i_CurrentFuelAmount,
                k_TruckFuelEngineCapacity);
        }

        public static IRegularMotorcycle CreateRegularMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eLicense i_LicenseType,
            int i_EngineSize,
            float i_CurrentWheelPressure,
            float i_CurrentFuelAmount)
        {
            return new RegularMotorcycle(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_BikekMaxWheelPressure, k_BikeAmountOfWheels),
                 i_LicenseType,
                 i_EngineSize,
                 k_BikeFuelType,
                 i_CurrentFuelAmount,
                 k_BikeFuelEngineCapacity);
        }

        public static IElectricMotorcycle CreateElectricMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eLicense i_LicenseType,
            int i_EngineSize,
            float i_CurrentWheelPressure,
            float i_CurrentCharge)
        {
            return new ElectricMotorcycle(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_BikekMaxWheelPressure, k_BikeAmountOfWheels),
                 i_LicenseType,
                 i_EngineSize,
                 i_CurrentCharge,
                 k_BikeMaxElectricEngineCharge);
        }

        public static IRegularCar CreateRegularCar(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eColor i_Color,
            int i_DoorsAmount,
            float i_CurrentWheelPressure,
            float i_CurrentFuelAmount)
        {
            return new RegularCar(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_CarMaxWheelPressure, k_CarAmountOfWheels),
                 i_Color,
                 i_DoorsAmount,
                 k_CarFuelType,
                 i_CurrentFuelAmount,
                 k_CarFuelEngineCapacity);
        }

        public static IElectricCar CreaElectricCar(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eColor i_Color,
            int i_DoorsAmount,
            float i_CurrentWheelPressure,
            float i_CurrentCharge)
        {
            return new ElectricCar(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_CarMaxWheelPressure, k_CarAmountOfWheels),
                 i_Color,
                 i_DoorsAmount,
                 i_CurrentCharge,
                 k_CarMaxElectricEngineCharge);
        }

        #endregion creation methods
    }
}