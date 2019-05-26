using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class VehicleCard
    {
        public enum eVehicleStatus
        {
            InService = 1,
            Fixed,
            Paid
        }

        private string m_OwnerName;
        private string m_Phone;
        private eVehicleStatus m_Status;
        private Vehicle m_Vehicle;

        public VehicleCard(string i_OwnerName, string i_Phone, eVehicleStatus i_Status, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_Phone = i_Phone;
            m_Status = i_Status;
            m_Vehicle = i_Vehicle;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public string Phone
        {
            get { return m_Phone; }
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
