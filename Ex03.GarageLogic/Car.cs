using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        public enum eCarColor
        {
            Red,
            Blue,
            Black,
            Grey
        }

        public enum  eNumOfDoors        ///////////////////////////////// ??
        {
            2,
            3,
            4,
            5
        }

        public static readonly int sr_NumOfWheels = 4;

        eCarColor m_Color;
        eNumOfDoors m_Doors;

    }
}
