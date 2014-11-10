using System;
using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    internal abstract class Motorcycle<TEngineType> : Vehicle<TEngineType>, IMotorcycle where TEngineType : Engine
    {
        #region properties

        public eLicense LicenseType { get; private set; }

        public int EngineSize { get; private set; }

        #endregion properties

        protected Motorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eLicense i_LicenseType,
            int i_EngineSize,
            TEngineType i_Engine) :
            base(
                i_ModelName,
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
            return "{0}, license type: {1}, engine size: {2}".FormatWith(base.ToString(), LicenseType, EngineSize);
        }
    }
}