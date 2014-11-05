using System;

namespace Ex00.GarageLogic
{
    #region ValueOutOfRangeException

    public class ValueOutOfRangeException : Exception
    {
        #region properties

        public float MinValue { get; private set; }

        public float MaxValue { get; private set; }

        public float ReceivedValue { get; private set; }

        #endregion properties

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_ReceivedValue) :
            base(string.Format(
            "Receieved value {0}, when legal values can only be between {1} and {2}",
            i_ReceivedValue,
            i_MinValue,
            i_MaxValue))
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
            ReceivedValue = i_ReceivedValue;
        }
    }

    #endregion ValueOutOfRangeException
}