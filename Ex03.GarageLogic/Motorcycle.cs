using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
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
                          eLicenseType m_LicenseType,
                          int m_EngineCapacity) 
                          : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergySource)
        {

        }
    }
}
