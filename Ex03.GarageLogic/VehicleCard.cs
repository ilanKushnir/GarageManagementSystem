using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class VehicleCard
    {
        public enum eVehicleStatus
        {
            InService,
            Fixed,
            Paid
        }

        string m_Owner;
        string m_Phone;
        eVehicleStatus m_Status;
        Vehicle m_Vehicle;
    }
}
