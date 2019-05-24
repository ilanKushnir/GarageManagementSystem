using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<VehicleCard> m_Cards;

        public Garage()
        {
            m_Cards = new List<VehicleCard>();
        }

        public void AddVehicleToGarage(string i_Owner, string i_Phone, VehicleInputData i_VehicleData)
        {
            VehicleCard newCard, foundCard;
            Vehicle newVehicle; 

            foundCard = FindCardByLicense(i_VehicleData.m_LicenseNumber);
            if (foundCard != null)
            {
                foundCard.Status = VehicleCard.eVehicleStatus.InService;
                throw new VehicleAllreadyInGarageException(new Exception(), foundCard.Vehicle.LicenseNumber);
            }

            newVehicle = VehicleCreator.CreateNewVehicle(i_VehicleData);
            newCard = new VehicleCard(i_Owner, i_Phone, VehicleCard.eVehicleStatus.InService, newVehicle);
            m_Cards.Add(newCard);
        }

        public VehicleCard FindCardByLicense(string i_LicenseNumber) 
        {
            VehicleCard o_FoundCard;

            o_FoundCard = m_Cards.Find(card => card.Vehicle.LicenseNumber.Equals(i_LicenseNumber));

            return o_FoundCard;
        }

        public List<string> GetLicenseNumbersByStatus(VehicleCard.eVehicleStatus i_Status)
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
