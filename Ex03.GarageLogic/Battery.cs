using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Battery : EnergySource
    {
        float m_RemainingBatteryTime;
        float m_MaxBatteryTime;

        public float RemainingBatteryTime
        {
            get { return m_RemainingBatteryTime; }
        } 

        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTime; }
        }

        public Battery(float i_RemainingBatteryTime, float i_MaxBatteryTime)
        {
            m_RemainingBatteryTime = i_RemainingBatteryTime;
            m_MaxBatteryTime = i_MaxBatteryTime;
            UpdateEnergyPercentage();
        }

        public void ChargeBattery(float i_TimeToCharge)
        {
            if (m_RemainingBatteryTime + i_TimeToCharge > m_MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(new Exception(), 0, m_MaxBatteryTime);
            }

            m_RemainingBatteryTime += i_TimeToCharge;
            UpdateEnergyPercentage();
        }

        public void UpdateEnergyPercentage()
        {
            float percentageCaculation = m_RemainingBatteryTime * 100.0f / m_MaxBatteryTime;
            m_EnergyPercentage = (float)Math.Round(percentageCaculation, 2);
        }
    }
}
