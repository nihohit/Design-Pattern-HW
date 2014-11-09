using System;
using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    internal class Truck : Vehicle<GasEngine>, ITruck
    {
        public bool CarryingDangerousMaterials { get; private set; }

        public float MaximumAllowedCarryingWeight { get; private set; }

        public Truck(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            bool i_CarryingDangerousMaterials,
            float i_MaximumAllowedWeight,
            eFuelType i_FuelType,
            float i_CurrentFuelAmount,
            float i_MaximumFuelAmount)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                new GasEngine(i_CurrentFuelAmount, i_MaximumFuelAmount, i_FuelType))
        {
            if (i_MaximumAllowedWeight <= 0)
            {
                throw new ArgumentException(
                    "Maximum allowed weight {0} has to be greater than 0".FormatWith(i_MaximumAllowedWeight));
            }

            CarryingDangerousMaterials = i_CarryingDangerousMaterials;
            MaximumAllowedCarryingWeight = i_MaximumAllowedWeight;
        }

        public override string ToString()
        {
            return "Truck\n{0}\n{1} to carry dangerous materials\nmax allowed weight: {2}".FormatWith(
                        base.ToString(),
                        CarryingDangerousMaterials ? "allowed" : "not allowed",
                        MaximumAllowedCarryingWeight);
        }
    }
}
