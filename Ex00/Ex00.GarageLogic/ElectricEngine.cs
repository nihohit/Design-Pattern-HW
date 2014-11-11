namespace Ex00.GarageLogic
{
    /// <summary>
    /// an electric engine
    /// </summary>
    public class ElectricEngine : Engine
    {
        #region properties

        /// <summary>
        /// get battery time left in hours
        /// </summary>
        public float CurrentChargeAmount
        {
            get
            {
                return CurrentEnergySourceAmount / 60;
            }
        }

        /// <summary>
        /// get max battery time in hours
        /// </summary>
        public float MaximumChargeAmount
        {
            get
            {
                return MaximumEnergySourceAmount / 60;
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
        /// <param name="i_ChargeMinutes">amount of charging minutes</param>
        public void ChargeEngine(float i_ChargeMinutes)
        {
            Fill(i_ChargeMinutes);
        }

        public override string ToString()
        {
            return string.Format("Remaining battery time: {0} hours ({1}%)", this.CurrentChargeAmount, GetFillPercentage());
        }
    }
}