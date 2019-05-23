using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        string m_Manufacturer;
        float m_CurrentAirPressure;
        float m_MaxAirPressure;

        public Wheel(string i_Manufacturer, 
                     float i_CurrentAirPressure,
                     float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void Inflate(float i_AirToAdd)
        {

        }
    }
}
