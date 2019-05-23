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

        public Battery(float i_RemainingBatteryTime, float i_MaxBatteryTime)
        {
            m_RemainingBatteryTime = i_RemainingBatteryTime;
            m_MaxBatteryTime = i_MaxBatteryTime;
        }

        public void ChargeBattery(float i_TimeToCharge)
        {

        }
    }
}
