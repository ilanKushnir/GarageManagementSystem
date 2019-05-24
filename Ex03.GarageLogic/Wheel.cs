using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        string m_Manufacturer;
        float m_CurrentAirPressure;
        float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get { return MaxAirPressure; }
        }

        public float CurretnAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public void Inflate(float i_AirToAdd)
        {
            m_CurrentAirPressure = (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure) ? m_MaxAirPressure : m_CurrentAirPressure + i_AirToAdd;
        }
    }
}
