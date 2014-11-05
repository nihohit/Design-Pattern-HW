using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex00.GarageLogic
{
    internal class Vehicle : IVehicle
    {
        #region general fields

        protected readonly Engine r_engine;

        #endregion general fields

        #region general properties

        public string ModelName { get; private set; }

        public string LicenseNumber { get; private set; }

        public IEnumerable<Wheel> Wheels { get; private set; }

        #endregion general properties

        #region constructors

        protected Vehicle(
            string i_ModelName,
            string i_LicenseNumber,
            IEnumerable<Wheel> i_Wheels,
            Engine engine)
        {
            ModelName = i_ModelName;
            LicenseNumber = i_LicenseNumber;
            Wheels = i_Wheels;
            r_engine = engine;
        }

        #endregion constructors

        public override string ToString()
        {
            return 
                "model name: {1}, license number: {2}, wheels state:{3}, engine: {4}".FormatWith(
                    ModelName,
                    LicenseNumber,
                    string.Join(",", Wheels.Select(i_Wheel => i_Wheel.ToString())),
                    r_engine.ToString());
        }
    }
}