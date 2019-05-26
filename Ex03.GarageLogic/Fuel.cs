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
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private eFuelType m_FuelType;
        private float m_CurrentFuelCapacity;
        private float m_MaxFuelCapacity;

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public float MaxFuelCapacity
        {
            get { return m_MaxFuelCapacity; }
        }

        public float CurrentFuelCapacity
        {
            get { return m_CurrentFuelCapacity; }
        }

        public Fuel(float i_CurrentFuelCapacity, float i_MaxFuelCapacity, eFuelType i_FuelType)
        {
            m_CurrentFuelCapacity = i_CurrentFuelCapacity;
            m_MaxFuelCapacity = i_MaxFuelCapacity;
            m_FuelType = i_FuelType;
            UpdateEnergyPercentage();
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
                UpdateEnergyPercentage();
            }
            else
            {
                throw new WrongFuelException(new Exception(), i_FuelType.ToString(), m_FuelType.ToString());
            }
        }

        public void UpdateEnergyPercentage()
        {
            float percentageCaculation = m_CurrentFuelCapacity * 100.0f / m_MaxFuelCapacity;
            m_EnergyPercentage = (float)Math.Round(percentageCaculation, 2);           
        }
    }
}
