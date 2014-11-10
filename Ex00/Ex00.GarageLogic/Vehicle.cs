using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    /// <summary>
    /// The base calss for vehicles. Contains all general information about the vehicle
    /// </summary>
    /// <typeparam name="TEngineType"></typeparam>
    internal class Vehicle<TEngineType> : IVehicle
    {
        #region general properties

        public TEngineType Engine { get; private set; }

        public string ModelName { get; private set; }

        public string LicenseNumber { get; private set; }

        public IEnumerable<Wheel> Wheels { get; private set; }

        #endregion general properties

        #region constructors

        protected Vehicle(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            TEngineType i_Engine)
        {
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            Wheels = i_Wheels;
            Engine = i_Engine;
        }

        #endregion constructors

        public override string ToString()
        {
            return
                "license number: {0}\nmodel name: {1}\nnumber of wheels: {2}\n{3}\n{4}".FormatWith(
                    LicenseNumber,
                    ModelName,
                    Wheels.Count(),
                    Wheels.First().ToString(),
                    Engine.ToString());
        }
    }
}