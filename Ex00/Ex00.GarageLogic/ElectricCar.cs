using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    /// <summary>
    /// A car with an electric engine
    /// </summary>
    internal class ElectricCar : Car<ElectricEngine>, IElectricCar
    {
        public ElectricCar(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eColor i_Color,
            int i_DoorsAmount,
            float i_MaximumCharge,
            float i_CurrentCharge)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_Color,
                i_DoorsAmount,
                new ElectricEngine(i_CurrentCharge, i_MaximumCharge))
        {
        }
    }
}