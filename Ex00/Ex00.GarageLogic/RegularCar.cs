using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    internal class RegularCar : Car<GasEngine>, IRegularCar
    {
        public RegularCar(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eColor i_Color,
            int i_DoorsAmount,
            eFuelType i_FuelType,
            float i_CurrentFuelAmount,
            float i_MaximumFuelAmount)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_Color,
                i_DoorsAmount,
                new GasEngine(i_CurrentFuelAmount, i_MaximumFuelAmount, i_FuelType))
        {
        }
    }
}