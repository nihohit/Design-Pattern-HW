namespace Ex00.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///
    /// </summary>
    public class VehicleMaker
    {
        #region consts

        // truck consts
        private const int k_TruckAmountOfWheels = 14;
        private const float k_TruckFuelEngineCapacity = 180;
        private const float k_TruckMaxWheelPressure = 23;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        // car consts
        private const float k_CarFuelEngineCapacity = 44;
        private const float k_CarMaxWheelPressure = 27;
        private const float k_CarMaxElectricEngineCharge = 3.3f;
        private const int k_CarAmountOfWheels = 4;
        private const eFuelType k_CarFuelType = eFuelType.Octan98;

        // motorcylce consts
        private const eFuelType k_BikeFuelType = eFuelType.Octan95;
        private const int k_BikeAmountOfWheels = 2;
        private const float k_BikeFuelEngineCapacity = 7.2f;
        private const float k_BikeMaxElectricEngineCharge = 2.4f;
        private const float k_BikekMaxWheelPressure = 33;

        // reflection consts
        private const string k_CreationMethodBeginning = "create";

        private readonly int r_LengthOfCreate = k_CreationMethodBeginning.Length;

        private IEnumerable<KeyValuePair<string, ParameterInfo[]>> m_SupportedTypes;

        #endregion consts

        #region methods

        /// <summary>
        /// return all supported vehicle types, and the arguments needed to create them.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, ParameterInfo[]>> GetAllSupportedTypesAndArguments()
        {
            if (m_SupportedTypes != null)
            {
                return m_SupportedTypes;
            }

            MethodInfo[] methods = typeof(VehicleMaker).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            IEnumerable<MethodInfo> creationMethods = methods.Where(i_Method => i_Method.Name.StartsWith(k_CreationMethodBeginning));

            m_SupportedTypes = creationMethods.ToDictionary(
                i_MethodInfo => i_MethodInfo.Name.Substring(r_LengthOfCreate),
                i_MethodInfo => i_MethodInfo.GetParameters());
            return m_SupportedTypes;
        }

        /// <summary>
        /// create a new vehicle of the given type with given arguments
        /// </summary>
        /// <param name="i_VehicleType"></param>
        /// <param name="i_Args"></param>
        /// <returns></returns>
        public IVehicle CreateVehicle(string i_VehicleType, IEnumerable<string> i_Args)
        {
            MethodInfo method = typeof(VehicleMaker).GetMethod(
                "{0}{1}".FormatWith(k_CreationMethodBeginning, i_VehicleType), BindingFlags.NonPublic | BindingFlags.Instance);

            ParameterInfo[] methodParameters = method.GetParameters();

            try
            {
                return (IVehicle)method.Invoke(this, parseParameters(methodParameters, i_Args));
            }
            catch (Exception e)
            {
                if (e is System.Reflection.TargetInvocationException)
                {
                    throw e.InnerException;
                }
                else
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// try to parse the received arguments into the relevant parameter types
        /// </summary>
        /// <param name="i_MethodParameters"></param>
        /// <param name="i_Args"></param>
        /// <returns></returns>
        private object[] parseParameters(ParameterInfo[] i_MethodParameters, IEnumerable<string> i_Args)
        {
            string[] argsArray = i_Args as string[] ?? i_Args.ToArray();
            int argCount = argsArray.Count();
            if (argCount != i_MethodParameters.Length)
            {
                throw new ArgumentException(
                    "Not given enough arguments. Expected {0} and received {1}"
                    .FormatWith(i_MethodParameters.Length, argCount));
            }

            object[] requestedParams = new object[i_MethodParameters.Length];
            int i = 0;
            foreach (string arg in argsArray)
            {
                requestedParams[i] = convertValue(i_MethodParameters[i].Name, i_MethodParameters[i].ParameterType, arg);
                i++;
            }

            return requestedParams;
        }

        private object convertValue(string i_ArgumentName, Type i_ArgumentType, string i_AargumenValue)
        {
            object argumenValue;
            string i_ArgumentDisplayName = Extensions.ToFirstLatterUpperRestLower(Extensions.GetDisplayNameOfArgument(i_ArgumentName));
            
            if (i_ArgumentType.BaseType == typeof (Enum))
            {
                Extensions.ValidateParamValueIsEnumName(i_ArgumentDisplayName, i_ArgumentType, i_AargumenValue);
            }

            TypeConverter converter = TypeDescriptor.GetConverter(i_ArgumentType);
            try
            {
                argumenValue = converter.ConvertFrom(i_AargumenValue);
            }
            catch (Exception exception)
            {
                throw new ArgumentException(getBetterErrorMsgForConvertError(i_ArgumentDisplayName, converter, exception.Message));
            }

            return argumenValue;
        }

        private string getBetterErrorMsgForConvertError(string i_ArgumentDisplayName, TypeConverter i_Converter, string i_OrigErrorMsg)
        {
            string msgSuffix  = "";
            if (i_Converter.GetStandardValuesSupported())
            {
                string validValues = "";
                foreach (var value in i_Converter.GetStandardValues())
                {
                    validValues += value.ToString();
                    validValues += ", ";
                }
                validValues = validValues.Trim();
                validValues = validValues.TrimEnd(',');
                msgSuffix = "valid values are: {0}".FormatWith(validValues);
            }
            else if (i_Converter is System.ComponentModel.SingleConverter)
            {
                msgSuffix = i_OrigErrorMsg;
            }

            return string.Format("{0} got invalid input. {1}", i_ArgumentDisplayName, msgSuffix);
        }

        #endregion methods

        #region creation methods

        private ITruck createTruck(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            bool i_CarryingDangerousMaterials,
            float i_MaximumAllowedWeight,
            float i_CurrentWheelPressure,
            float i_CurrentFuelAmount)
        {
            return new Truck(
                i_ModelName,
                i_LicenseNumber,
                Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_TruckMaxWheelPressure, k_TruckAmountOfWheels),
                i_CarryingDangerousMaterials,
                i_MaximumAllowedWeight,
                k_TruckFuelType,
                i_CurrentFuelAmount,
                k_TruckFuelEngineCapacity);
        }

        private IRegularMotorcycle createRegularMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eLicense i_LicenseType,
            int i_EngineSize,
            float i_CurrentWheelPressure,
            float i_CurrentFuelAmount)
        {
            return new RegularMotorcycle(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_BikekMaxWheelPressure, k_BikeAmountOfWheels),
                 i_LicenseType,
                 i_EngineSize,
                 k_BikeFuelType,
                 i_CurrentFuelAmount,
                 k_BikeFuelEngineCapacity);
        }

        private IElectricMotorcycle createElectricMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eLicense i_LicenseType,
            int i_EngineSize,
            float i_CurrentWheelPressure,
            float i_CurrentCharge)
        {
            return new ElectricMotorcycle(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_BikekMaxWheelPressure, k_BikeAmountOfWheels),
                 i_LicenseType,
                 i_EngineSize,
                 i_CurrentCharge,
                 k_BikeMaxElectricEngineCharge);
        }

        private IRegularCar createRegularCar(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eColor i_Color,
            int i_DoorsAmount,
            float i_CurrentWheelPressure,
            float i_CurrentFuelAmount)
        {
            return new RegularCar(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_CarMaxWheelPressure, k_CarAmountOfWheels),
                 i_Color,
                 i_DoorsAmount,
                 k_CarFuelType,
                 i_CurrentFuelAmount,
                 k_CarFuelEngineCapacity);
        }

        private IElectricCar createElectricCar(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturerName,
            eColor i_Color,
            int i_DoorsAmount,
            float i_CurrentWheelPressure,
            float i_CurrentCharge)
        {
            return new ElectricCar(
                 i_ModelName,
                 i_LicenseNumber,
                 Wheel.CreateWheels(i_WheelManufacturerName, i_CurrentWheelPressure, k_CarMaxWheelPressure, k_CarAmountOfWheels),
                 i_Color,
                 i_DoorsAmount,
                 i_CurrentCharge,
                 k_CarMaxElectricEngineCharge);
        }

        #endregion creation methods
    }
}