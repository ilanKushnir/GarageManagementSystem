using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Fuel : EnergySource
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        eFuelType m_FuelType;
        float m_CurrentFuelCapacity;
        float m_MaxFuelCapacity;

        public void FuelUp(float i_FuelToAdd, eFuelType i_FuelType)                 ///////////////////////
        { }
    }
}
