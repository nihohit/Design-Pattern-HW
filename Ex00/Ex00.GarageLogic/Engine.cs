﻿using System;

namespace Ex00.GarageLogic
{
    /// <summary>
    /// base class for engines
    /// </summary>
    public abstract class Engine
    {
        /// <summary>
        /// The current amount of energy source in the engine
        /// </summary>
        protected float CurrentEnergySourceAmount { get; private set; }

        /// <summary>
        /// Maximum amount of energy source in the engine
        /// </summary>
        protected float MaximumEnergySourceAmount { get; private set; }

        protected Engine(float i_CurrentEnergySourceAmount, float i_MaximumEnergySourceAmount)
        {
            if (i_CurrentEnergySourceAmount > i_MaximumEnergySourceAmount)
            {
                throw new ArgumentException(
                    "Current energy source {0} value is above the maximum energy source {1}".FormatWith(i_CurrentEnergySourceAmount, i_MaximumEnergySourceAmount));
            }
            if (i_CurrentEnergySourceAmount < 0)
            {
                throw new ArgumentException(
                    "Current energy source value {0} can't be negative".FormatWith(i_CurrentEnergySourceAmount));
            }
            if (i_MaximumEnergySourceAmount <= 0)
            {
                throw new ArgumentException("Maximum energy source value {0} must be greater than 0".FormatWith(i_MaximumEnergySourceAmount));
            }

            CurrentEnergySourceAmount = i_CurrentEnergySourceAmount;
            MaximumEnergySourceAmount = i_MaximumEnergySourceAmount;
        }

        /// <summary>
        /// How full is the engine, in percentages.
        /// </summary>
        /// <returns></returns>
        public float GetFillPercentage()
        {
            return 100 * MaximumEnergySourceAmount / CurrentEnergySourceAmount;
        }

        /// <summary>
        /// Fill the engine by the given amount
        /// </summary>
        /// <param name="i_Amount"></param>
        public void Fill(float i_Amount)
        {
            CurrentEnergySourceAmount = i_Amount.CheckLegalAddition(CurrentEnergySourceAmount, MaximumEnergySourceAmount);
        }
    }
}