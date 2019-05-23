using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        string m_ModelName;
        string m_LicenseNumber;
        List<Wheel> m_Wheels;
        EnergySource m_EnergySource;

        public string LicenseNumber
        {
            get { return m_LicenseNumber;}
        }

    }
}
