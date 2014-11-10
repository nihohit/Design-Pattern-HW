namespace Ex00.GarageLogic
{
    public static class Extensions
    {
        /// <summary>
        /// checks if a given addition is within a legal range
        /// </summary>
        /// <param name="i_ReceivedValue"> the amount to add</param>
        /// <param name="i_CurrentValue"> the current value</param>
        /// <param name="i_MinValue">the minimal acceptable value</param>
        /// <param name="i_MaxValue"> the maximal acceptable value</param>
        /// <returns></returns>
        public static float CheckLegalAddition(this float i_ReceivedValue, float i_CurrentValue, float i_MinValue, float i_MaxValue)
        {
            var resultingValue = i_CurrentValue + i_ReceivedValue;
            if (resultingValue > i_MaxValue || resultingValue < i_MinValue)
            {
                throw new ValueOutOfRangeException(resultingValue, i_MinValue, i_MaxValue);
            }

            return resultingValue;
        }

        /// <summary>
        /// checks if a given addition is within a legal range, from zero to a given maximum
        /// </summary>
        /// <param name="i_ReceivedValue"> the amount to add</param>
        /// <param name="i_CurrentValue"> the current value</param>
        /// <param name="i_MaxValue"> the maximal acceptable value</param>
        /// <returns></returns>
        public static float CheckLegalAddition(this float i_ReceivedValue, float i_CurrentValue, float i_MaxValue)
        {
            return i_ReceivedValue.CheckLegalAddition(i_CurrentValue, 0, i_MaxValue);
        }

        /// <summary>
        /// Check if a given value is within a given range
        /// </summary>
        /// <param name="i_Value"></param>
        /// <param name="i_MinValue"></param>
        /// <param name="i_MaxValue"></param>
        public static void CheckLegalValue(this int i_Value, int i_MinValue, int i_MaxValue)
        {
            if (i_MinValue > i_Value || i_Value > i_MaxValue)
            {
                throw new ValueOutOfRangeException(i_Value, i_MinValue, i_MaxValue);
            }
        }

        /// <summary>
        /// Format a given string with given args.
        /// </summary>
        /// <param name="i_Str"></param>
        /// <param name="i_FormattingInfo"></param>
        /// <returns></returns>
        public static string FormatWith(this string i_Str, params object[] i_FormattingInfo)
        {
            return string.Format(i_Str, i_FormattingInfo);
        }
    }
}