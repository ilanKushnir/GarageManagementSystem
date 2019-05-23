using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<VehicleCard> m_Cards;


        public void AddCarToGarage(string i_Owner, string i_Phone, ref VehicleInputData i_VehicleData)
        {
            VehicleCard newCard;
            Vehicle newVehicle;

            newVehicle = VehicleCreator.CreateNewVehicle(i_VehicleData);
            newCard = new VehicleCard(i_Owner, i_Phone, VehicleCard.eVehicleStatus.InService, newVehicle);

            if(m_Cards.Count == 0)
            {
                m_Cards = new List<VehicleCard>();
            }

            m_Cards.Add(newCard);
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

        public List<string> DisplayLicenseNumbersByStatus(VehicleCard.eVehicleStatus i_Status)
        {
            List<string> o_licenstNumbers = new List<string>();

            foreach(VehicleCard card in m_Cards)
            {
                if(card.Status.Equals(i_Status))
                {
                    o_licenstNumbers.Add(card.Vehicle.LicenseNumber);
                }

            }

            return o_licenstNumbers;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, VehicleCard.eVehicleStatus i_NewsStatus) 
        {
            VehicleCard cardToChange;

            cardToChange =  m_Cards.Find(vehicleToChange => vehicleToChange.Vehicle.LicenseNumber.Equals(i_LicenseNumber));
            cardToChange.Status = i_NewsStatus;         /// exception
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToInflate;
            List<Wheel> wheels;

            vehicleToInflate = m_Cards.Find(toInflate => toInflate.Vehicle.LicenseNumber.Equals(i_LicenseNumber)).Vehicle;
            wheels = vehicleToInflate.Wheels;

            foreach(Wheel wheel in wheels)
            {
                wheel.Inflate(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }


    }
}
