using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class EnergySource
    {
        protected float m_EnergyPercentage;

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
        }
    }
}
