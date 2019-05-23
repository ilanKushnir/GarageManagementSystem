using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        public  enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        public static readonly int sr_NumOfWheels = 2;
        eLicenseType m_LicenseType;
        int m_EngineCapacity;
    }
}
