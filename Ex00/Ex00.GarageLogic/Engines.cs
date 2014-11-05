using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    public abstract class Engine
    {
        protected float CurrentEnergySourceAmount { get; private set; }

        protected float MaximumEnergySourceAmount { get; private set; }

        public Engine(float i_CurrentEnergySourceAmount, float i_MaximumEnergySourceAmount)
        {
            if(i_CurrentEnergySourceAmount > i_MaximumEnergySourceAmount)
            {
                throw new ArgumentException(
                    "Current energy source {0} value is above the maximum energy source {1}".FormatWith(i_CurrentEnergySourceAmount, i_MaximumEnergySourceAmount));
            }
            if(i_CurrentEnergySourceAmount < 0)
            {
                throw new ArgumentException(
                    "Current energy source value {0} can't be negative".FormatWith(i_CurrentEnergySourceAmount));
            }
            if(i_MaximumEnergySourceAmount <= 0)
            {
                throw new ArgumentException("Maximum energy source value {0} must be greater than 0".FormatWith(i_MaximumEnergySourceAmount));
            }

            CurrentEnergySourceAmount = i_CurrentEnergySourceAmount;
            MaximumEnergySourceAmount = i_MaximumEnergySourceAmount;
        }

        public float GetFillPercentage()
        {
            return 100 * MaximumEnergySourceAmount / CurrentEnergySourceAmount;
        }

        public void Fill(float amount)
        {
            CurrentEnergySourceAmount = amount.CheckLegalAddition(CurrentEnergySourceAmount, MaximumEnergySourceAmount);
        }
    }

    public class GasEngine : Engine
    {

        #region properties

        public eFuelType EngineFuelType { get; private set; }

        public float CurrentFuelAmount { get { return CurrentEnergySourceAmount; } }

        public float MaximumFuelAmount { get { return MaximumEnergySourceAmount; } }

        #endregion properties

        public GasEngine(float i_CurrentFuelAmount, float i_MaximumFuelAmount, eFuelType i_FuelType) : 
            base(i_CurrentFuelAmount, i_MaximumFuelAmount)
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
            return string.Format("fuel amount: {0}, fuel type: {1}", CurrentFuelAmount, EngineFuelType);
        }

    }

    public class ElectricEngine : Engine
    {
        #region properties

        public float CurrentChargeAmount { get { return CurrentEnergySourceAmount; } }

        public float MaximumChargeAmount { get { return MaximumEnergySourceAmount; } }

        #endregion properties

        public ElectricEngine(float i_CurrentCharge, float i_MaximumCharge) : base(i_CurrentCharge, i_MaximumCharge)
        {
        }

        /// <summary>
        /// Charge the engine
        /// </summary>
        /// <param name="i_ChargeHours">amount of charging hours</param>
        public void ChargeEngine(float i_ChargeHours)
        {
            Fill(i_ChargeHours);
        }

        public override string ToString()
        {
            return string.Format("charge amount: {0}", this.CurrentChargeAmount);
        }
    }
}
