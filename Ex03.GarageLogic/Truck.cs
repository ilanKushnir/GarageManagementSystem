using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public static readonly int sr_NumOfWheels = 12;
        public static readonly int sr_MaxAirPressure = 26;
        public static readonly int sr_MaxFuelCapacity = 110;
        public static readonly Fuel.eFuelType sr_FuelType = Fuel.eFuelType.Soler;

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

    
