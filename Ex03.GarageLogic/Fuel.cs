using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Fuel : EnergySource
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

        public Fuel(float i_CurrentFuelCapacity, float i_MaxFuelCapacity)
        {
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
            m_MaxFuelCapacity = i_MaxFuelCapacity;
        }

        public void FuelUp(float i_FuelToAdd, eFuelType i_FuelType)              
        {
            if (i_FuelType.Equals(m_FuelType))
            {
                if(m_CurrentFuelCapacity + i_FuelToAdd > m_MaxFuelCapacity)
                {
                    throw new ValueOutOfRangeException(new Exception(), 0, m_MaxFuelCapacity);
                }

                m_CurrentFuelCapacity += i_FuelToAdd;
            }
            else
            {
                throw new WrongFuelException(new Exception(), i_FuelType.ToString(), m_FuelType.ToString());
            }
        }
    }
}
