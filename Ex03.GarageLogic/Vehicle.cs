using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels;
        protected EnergySource m_EnergySource;

        public Vehicle(string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, EnergySource i_EnergySource)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = i_Wheels;
            m_EnergySource = i_EnergySource;
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

    }
}
