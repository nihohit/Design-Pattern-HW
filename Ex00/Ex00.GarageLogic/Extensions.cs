namespace Ex00.GarageLogic
{
    public static class Extensions
    {
        public static float CheckLegalAddition(this float i_ReceivedValue, float i_CurrentValue, float i_MinValue, float i_MaxValue)
        {
            var resultingValue = i_CurrentValue + i_ReceivedValue;
            if (resultingValue > i_MaxValue || resultingValue < i_MinValue)
            {
                throw new ValueOutOfRangeException(resultingValue, i_MinValue, i_MaxValue);
            }

            return resultingValue;
        }

        public static float CheckLegalAddition(this float i_ReceivedValue, float i_CurrentValue, float i_MaxValue)
        {
            return i_ReceivedValue.CheckLegalAddition(i_CurrentValue, 0, i_MaxValue);
        }

        public static void CheckLegalValue(this int i_Value, int i_MinValue, int i_MaxValue)
        {
            if (i_MinValue > i_Value || i_Value > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_Value, i_MinValue, i_MaxValue);
            }
        }

        public static string FormatWith(this string str, params object[] formattingInfo)
        {
            return string.Format(str, formattingInfo);
        }
    }
}