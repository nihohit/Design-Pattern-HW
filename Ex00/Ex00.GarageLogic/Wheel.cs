using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
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

        public static IEnumerable<Wheel> CreateWheels(string i_ManufacturerName, float i_CurrentWheelPressure,float i_MaxAirPressure, int i_Amount)
        {
            return Enumerable.Range(0, i_Amount).Select(i_Num => new Wheel(i_ManufacturerName, i_CurrentWheelPressure, i_MaxAirPressure));
        }

        public void Fill(float i_AdditionalAir)
        {
            CurrentAirPressure = i_AdditionalAir.CheckLegalAddition(CurrentAirPressure, MaxAirPressure);
        }

        public void FillToMax()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        public override string ToString()
        {
            return string.Format("air pressure: {0}, manufacturer's name: {1}", CurrentAirPressure, ManufacturerName);
        }

        #endregion methods
    }
}