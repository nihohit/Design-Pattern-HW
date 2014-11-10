namespace Ex00.GarageLogic
{
    /// <summary>
    /// an electric engine
    /// </summary>
    public class ElectricEngine : Engine
    {
        #region properties

        public float CurrentChargeAmount
        {
            get
            {
                return CurrentEnergySourceAmount;
            }
        }

        public float MaximumChargeAmount
        {
            get
            {
                return MaximumEnergySourceAmount;
            }
        }

        #endregion properties

        public ElectricEngine(float i_CurrentCharge, float i_MaximumCharge)
            : base(i_CurrentCharge, i_MaximumCharge, "charge")
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