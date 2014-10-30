using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    internal abstract class Vehicle
    {
        #region fields

        private readonly string m_ModelName;

        private readonly string m_LicenseNumber;

        private float m_RemainingEnergyPercentage;

        private IEnumerable<Wheel> m_Wheels;

        private readonly FuelEngine m_FuelEngine;

        private readonly ElectricEngine m_ElectricEngine;

        #endregion fields
    }
}