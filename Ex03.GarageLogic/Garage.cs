using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private List<VehicleCard> m_Cards;


        public void AddCarToGarage()
        {
            string licenstNumber, owner, phone;
            Vehicle newVehicle;
            VehicleCard newCard;

            VehicleCard cardFound;
            List<Wheel> wheels;
            EnergySource energySource;

            licenstNumber = ConsoleUI.Display.GetLicenstNumberInput();
            if((cardFound = FindCardByLicense(licenstNumber)) != null)
            {
                cardFound.Status = VehicleCard.eVehicleStatus.InService;
                //////////////////////////////// UI output car allready exist on garage
                return;
            }

            newCard = new VehicleCard(owner, phone, newVehicle);

        }

        public VehicleCard FindCardByLicense(string i_LicenseNumber)
        {
            foreach(VehicleCard card in m_Cards)
            {
                if(card.Vehicle.LicenseNumber.Equals(i_LicenseNumber))
                {
                    return card;
                }
            }

            return null;
        }

        public void DisplayLicenseNumbersByStatus(VehicleCard.eVehicleStatus i_Status)
        { }
        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleCard.eVehicleStatus i_NewsStatus)
        { }
        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        { }


    }
}
