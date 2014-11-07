using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    internal class RegularMotorcycle : Motorcycle<GasEngine>, IRegularMotorcycle
    {
        public RegularMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eLicense i_LicenseType,
            int i_EngineSize,
            eFuelType i_FuelType,
            float i_CurrentFuelAmount,
            float i_MaximumFuelAmount)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_LicenseType,
                i_EngineSize,
                new GasEngine(i_CurrentFuelAmount, i_MaximumFuelAmount, i_FuelType))
        {
        }
    }
}