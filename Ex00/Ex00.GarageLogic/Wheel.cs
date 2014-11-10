using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    /// <summary>
    /// A vehicle's wheel
    /// </summary>
    public class Wheel
    {
        #region properties

        public string ManufacturerName { get; private set; }

        public float CurrentAirPressure { get; private set; }

        public float MaxAirPressure { get; private set; }

        #endregion properties

        #region constructor

        public Wheel(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaxAirPressure = i_MaxAirPressure;
        }

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
            : this(i_ManufacturerName, i_MaxAirPressure, i_MaxAirPressure)
        {
        }

        #endregion constructor

        #region methods

        /// <summary>
        /// Create a set of wheels with the given parameters
        /// </summary>
        /// <param name="i_ManufacturerName">The wheel's name</param>
        /// <param name="i_CurrentWheelPressure">The current pressure in the wheels</param>
        /// <param name="i_MaxAirPressure">the maximum air pressure of the wheels</param>
        /// <param name="i_Amount">the amount of wheels to create</param>
        /// <returns></returns>
        public static IEnumerable<Wheel> CreateWheels(string i_ManufacturerName, float i_CurrentWheelPressure, float i_MaxAirPressure, int i_Amount)
        {
            return Enumerable.Range(0, i_Amount).Select(i_Num => new Wheel(i_ManufacturerName, i_CurrentWheelPressure, i_MaxAirPressure));
        }

        /// <summary>
        /// Fill a wheel with the given amount of air
        /// </summary>
        /// <param name="i_AdditionalAir"></param>
        public void Fill(float i_AdditionalAir)
        {
            CurrentAirPressure = i_AdditionalAir.CheckLegalAddition(CurrentAirPressure, MaxAirPressure);
        }

        /// <summary>
        /// Fill a wheel to its maximum capacity
        /// </summary>
        public void FillToMax()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format("wheels manufacturer's name: {0}\nwheels air pressure: {1}\nwheels max air pressure: {2}", ManufacturerName, CurrentAirPressure, MaxAirPressure);
        }

        #endregion methods
    }
}