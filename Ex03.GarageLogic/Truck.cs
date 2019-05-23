using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public static readonly int sr_NumOfWheels = 12;
        bool m_ContainDangerousSubstances;
        float m_CargoVolume;

        public Truck(string i_ModelName,
                 string i_LicenseNumber,
                 List<Wheel> i_Wheels,
                 EnergySource i_EnergySource,
                 bool i_ContainDangerousSubstances,
                 float i_CargoVolume)
                 : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergySource)
        {
            m_ContainDangerousSubstances = i_ContainDangerousSubstances;
            m_CargoVolume = i_CargoVolume;
        }

        public bool ContainDangerousSubstances
        {
            get { return m_ContainDangerousSubstances; }
            set { m_ContainDangerousSubstances = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

    }
}

    
