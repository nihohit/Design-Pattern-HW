using System;

namespace Ex00.GarageLogic
{
    public class GasEngine : Engine
    {
        #region properties

        public eFuelType EngineFuelType { get; private set; }

        public float CurrentFuelAmount
        {
            get
            {
                return CurrentEnergySourceAmount;
            }
        }

        public float MaximumFuelAmount
        {
            get
            {
                return MaximumEnergySourceAmount;
            }
        }

        #endregion properties

        public GasEngine(float i_CurrentFuelAmount, float i_MaximumFuelAmount, eFuelType i_FuelType) :
            base(i_CurrentFuelAmount, i_MaximumFuelAmount, "fuel")
        {
            EngineFuelType = i_FuelType;
        }

        /// <summary>
        /// Fill the engine's fuel
        /// </summary>
        /// <param name="i_FuelAmount">amount of fuel</param>
        /// <param name="i_FuelType">type of fuel</param>
        public void FillFuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            if (EngineFuelType != i_FuelType)
            {
                throw new ArgumentException(
                    string.Format("{0} is the wrong fuel type. Expected {1}", i_FuelType, EngineFuelType));
            }

            Fill(i_FuelAmount);
        }

        public override string ToString()
        {
            return string.Format("fuel amount: {0} liters ({1}%), fuel type: {2}", CurrentFuelAmount, GetFillPercentage(), EngineFuelType);
        }
    }
}