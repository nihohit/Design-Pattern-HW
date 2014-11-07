using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    /// <summary>
    /// An electric motorcycle
    /// </summary>
    internal class ElectricMotorcycle : Motorcycle<ElectricEngine>, IElectricMotorcycle
    {
        public ElectricMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eLicense i_LicenseType,
            int i_EngineSize,
            float i_CurrentCharge,
            float i_MaximumCharge)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_LicenseType,
                i_EngineSize,
                new ElectricEngine(i_CurrentCharge, i_MaximumCharge))
        {
        }
    }
}