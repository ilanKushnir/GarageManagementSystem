using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            A1,
            A2,
            B
        }

        public static readonly int sr_NumOfWheels = 2;
        public static readonly int sr_MaxAirPressure = 33;
        public static readonly int sr_MaxFuelCapacity = 8;
        public static readonly float sr_MaxBatteryTime = 1.4f;
        public static readonly Fuel.eFuelType sr_FuelType = Fuel.eFuelType.Octan95;

        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
        }

        public Motorcycle(string i_ModelName,
                          string i_LicenseNumber,
                          List<Wheel> i_Wheels,
                          EnergySource i_EnergySource,
                          eLicenseType i_LicenseType,
                          int i_EngineCapacity) 
                          : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergySource)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
