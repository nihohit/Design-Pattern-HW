using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    internal abstract class Motorcycle<TEngineType> : Vehicle, IMotorcycle where TEngineType : Engine
    {
        #region properties

        public eLicense LicenseType { get; private set; }

        public int EngineSize { get; private set; }

        #endregion

        protected Motorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eLicense i_LicenseType,
            int i_EngineSize,
            TEngineType i_Engine) : 
            base(i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_Engine)
        {
            if (i_EngineSize <= 0)
            {
                throw new ArgumentException(
                    "Engine size {0} has to be greater than 0".FormatWith(i_EngineSize));
            }

            EngineSize = i_EngineSize;
            LicenseType = i_LicenseType;
        }

        public override string ToString()
        {
            return "{0}, license type: {0}, engine size: {1}".FormatWith(base.ToString(), LicenseType, EngineSize);
        }
    }

    internal class ElectricMotorcycle : Motorcycle<ElectricEngine>, IElectricMotorcycle
    {
        public ElectricEngine Engine { get { return r_engine as ElectricEngine; } }

        public ElectricMotorcycle(string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eLicense i_LicenseType,
            int i_EngineSize,
            float i_CurrentCharge,
            float i_MaximumCharge) : base(i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_LicenseType,
                i_EngineSize,
                new ElectricEngine(i_CurrentCharge, i_MaximumCharge))
        {}
    }

    internal class RegularMotorcycle : Motorcycle<GasEngine>, IRegularMotorcycle
    {
        public GasEngine Engine { get { return r_engine as GasEngine; } }

        public RegularMotorcycle(string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eLicense i_LicenseType,
            int i_EngineSize,
            eFuelType i_FuelType,
            float i_CurrentFuelAmount,
            float i_MaximumFuelAmount) : base(i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_LicenseType,
                i_EngineSize,
                new GasEngine(i_CurrentFuelAmount, i_MaximumFuelAmount, i_FuelType))
        {}
    }
}
