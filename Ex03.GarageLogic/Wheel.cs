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

        public string Manufacturer
        {
            get { return m_Manufacturer; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public void Inflate(float i_AirToAdd)
        {

        }
    }
}
