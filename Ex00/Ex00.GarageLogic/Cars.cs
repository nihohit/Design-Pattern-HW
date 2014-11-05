using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    internal abstract class Car<TEngineType> : Vehicle where TEngineType : Engine
    {
        #region fields

        private const int k_MinDoorsAmountForCars = 2;
        private const int k_MaxDoorsAmountForCars = 5;

        #endregion

        #region properties

        public eColor Color { get; private set; }

        public int DoorAmount { get; private set; }

        #endregion

        protected Car(string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eColor i_Color,
            int i_DoorsAmount,
            TEngineType i_Engine) : 
            base(i_ModelName,
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

    internal class ElectricCar : Car<ElectricEngine>, IElectricCar
    {
        public ElectricEngine Engine { get { return r_engine as ElectricEngine; } }

        public ElectricCar(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eColor i_Color,
            int i_DoorsAmount,
            float i_MaximumCharge,
            float i_CurrentCharge) : base(i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_Color,
                i_DoorsAmount,
                new ElectricEngine(i_CurrentCharge, i_MaximumCharge))
        {
        }
    }

    internal class RegularCar : Car<GasEngine>, IRegularCar
    {
        public GasEngine Engine { get { return r_engine as GasEngine; } }

        public RegularCar(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            eColor i_Color,
            int i_DoorsAmount,
            eFuelType i_FuelType,
            float i_CurrentFuelAmount,
            float i_MaximumFuelAmount) : base(i_ModelName,
                i_LicenseNumber,
                i_Wheels,
                i_Color,
                i_DoorsAmount,
                new GasEngine(i_CurrentFuelAmount, i_MaximumFuelAmount, i_FuelType))
        {
        }
    }
}
