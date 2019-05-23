using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        public static readonly int sr_NumOfWheels = 12;
        bool m_ContainDangerousSubstances;
        float m_CargoVolume;
    }
}
