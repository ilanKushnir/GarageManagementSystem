using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private List<VehicleCard> m_Cards;


        public void AddCarToGarage()
        { }

        private bool isLicenseExistOnGarage(string i_LicenseNumber)
        {
            foreach(VehicleCard card in m_Cards)
            {
                if(strcmp(card.Vehicle.LicenseNumber))
            }
        }

        public void DisplayLicenseNumbersByStatus(VehicleCard.eVehicleStatus i_Status)
        { }
        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleCard.eVehicleStatus i_NewsStatus)
        { }
        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        { }


    }
}
