﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Red = 1,
            Blue,
            Black,
            Grey
        }

        public enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public static readonly int sr_NumOfWheels = 4;
        public static readonly int sr_MaxAirPressure = 31;
        public static readonly int sr_MaxFuelCapacity = 55;
        public static readonly float sr_MaxBatteryTime = 1.8f;
        public static readonly Fuel.eFuelType sr_FuelType = Fuel.eFuelType.Octan96;
        private eCarColor m_Color;
        private eNumOfDoors m_Doors;

        public Car(string i_ModelName, 
                   string i_LicenseNumber, 
                   List<Wheel> i_Wheels, 
                   EnergySource i_EnergySource, 
                   eCarColor i_Color,
                   eNumOfDoors i_Doors) 
                   : base(i_ModelName, i_LicenseNumber, i_Wheels, i_EnergySource)
        {
            Color = i_Color;
            Doors = i_Doors;
        }

        public eCarColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumOfDoors Doors
        {
            get { return m_Doors; }
            set { m_Doors = value; }
        }
    }
}
