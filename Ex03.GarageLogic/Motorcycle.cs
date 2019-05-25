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
        eLicenseType m_LicenseType;
        int m_EngineCapacity;

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
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
