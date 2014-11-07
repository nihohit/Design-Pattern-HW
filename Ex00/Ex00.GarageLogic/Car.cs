using System.Collections.Generic;

namespace Ex00.GarageLogic
{
    /// <summary>
    /// Base class for cars
    /// </summary>
    /// <typeparam name="TEngineType"></typeparam>
    internal abstract class Car<TEngineType> : Vehicle<TEngineType> where TEngineType : Engine
    {
        #region fields

        private const int k_MinDoorsAmountForCars = 2;
        private const int k_MaxDoorsAmountForCars = 5;

        #endregion fields

        #region properties

        /// <summary>
        /// Car color
        /// </summary>
        public eColor Color { get; private set; }

        /// <summary>
        /// Amount of doors in car
        /// </summary>
        public int DoorAmount { get; private set; }

        #endregion properties

        protected Car(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eColor i_Color,
            int i_DoorsAmount,
            TEngineType i_Engine)
            : base(
                i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_Engine)
        {
            i_DoorsAmount.CheckLegalValue(k_MinDoorsAmountForCars, k_MaxDoorsAmountForCars);
            DoorAmount = i_DoorsAmount;
            Color = i_Color;
        }

        public override string ToString()
        {
            return string.Format("Car {0} {1}", base.ToString(), string.Format("color: {0}, door amount: {1}", Color, DoorAmount));
        }
    }
}