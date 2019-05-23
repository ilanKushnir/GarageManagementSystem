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

        public VehicleCard(string i_Owner, string i_Phone, eVehicleStatus i_Status, Vehicle i_Vehicle)
        {
            m_Owner = i_Owner;
            m_Phone = i_Phone;
            m_Status = i_Status;
            m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public eVehicleStatus Status
        {
            get { return m_Status; }
            set { m_Status = value;  }
        }
    }
}
