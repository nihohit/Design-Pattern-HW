using System;
using System.Linq;

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
            float resultingValue = i_CurrentValue + i_ReceivedValue;
            if (resultingValue > i_MaxValue || resultingValue < i_MinValue)
            {
                throw new ValueOutOfRangeException(Math.Max(0, i_MinValue - i_CurrentValue), i_MaxValue - i_CurrentValue, i_ReceivedValue);
            }

            return resultingValue;
        }

        /// <summary>
        /// checks if a given addition is within a legal range of zero to a given maximum
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
                throw new ValueOutOfRangeException(i_MinValue, i_MaxValue, i_Value);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_ArgumentName"></param>
        /// <returns></returns>
        public static string GetDisplayNameOfArgument(string i_ArgumentName)
        {
            string displayNameOfArgument = string.Empty;
            foreach (char ch in i_ArgumentName.Substring(2))
            {
                if (char.IsLower(ch))
                {
                    displayNameOfArgument += ch.ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    displayNameOfArgument += " " + ch.ToString(System.Globalization.CultureInfo.InvariantCulture).ToLower();
                }
            }
            
            return displayNameOfArgument.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_Value"></param>
        /// <returns></returns>
        public static string ToFirstLatterUpperRestLower(string i_Value)
        {
            return i_Value.Substring(0, 1).ToUpper() + i_Value.Substring(1).ToLower();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_ParmName"></param>
        /// <param name="i_EnumType"></param>
        /// <param name="i_Value"></param>
        /// <returns></returns>
        public static bool ValidateParamValueIsEnumName(string i_ParmDisplayName, Type i_EnumType, string i_Value, out string o_EnumStringValue)
        {
            const bool v_ValidEnumName = true;
            string[] enumTypes = Enum.GetNames(i_EnumType);
            if (string.IsNullOrEmpty(i_Value))
            {
                throw new FormatException(string.Format("{0} cannot be empty", i_ParmDisplayName));
            }
            
            int valueNameIndex = Array.FindIndex(enumTypes, 0, i_name => 0 == string.Compare(i_name, i_Value.Trim(), StringComparison.OrdinalIgnoreCase));
            if (valueNameIndex == -1)
            {
                string validTypes = string.Join(",", enumTypes);
                throw new FormatException(string.Format("{0} must be one of these: {1}", i_ParmDisplayName, validTypes));
            }

            o_EnumStringValue = enumTypes[valueNameIndex];
            return v_ValidEnumName;
        }
    }
}