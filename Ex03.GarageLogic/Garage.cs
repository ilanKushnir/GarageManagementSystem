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

            try
            {
                foundCard = FindCardByLicense(i_VehicleData.m_LicenseNumber);
            }
            catch(KeyNotFoundException)
            {
                foundCard = null;
            }

            if (foundCard == null)
            {
                newVehicle = VehicleCreator.CreateNewVehicle(i_VehicleData);
                newCard = new VehicleCard(i_Owner, i_Phone, VehicleCard.eVehicleStatus.InService, newVehicle);
                m_Cards.Add(newCard);
            }
            else
            {
                foundCard.Status = VehicleCard.eVehicleStatus.InService;
                throw new VehicleAllreadyInGarageException(new Exception(), foundCard.Vehicle.LicenseNumber);
            }
        }

        public VehicleCard FindCardByLicense(string i_LicenseNumber) 
        {
            VehicleCard o_FoundCard = null;

            o_FoundCard = m_Cards.Find(card => card.Vehicle.LicenseNumber.Equals(i_LicenseNumber));
            if (o_FoundCard == null)
            {
                throw new KeyNotFoundException();       
            }

            return o_FoundCard;
        }

        public Vehicle FindVehicleByLicense(string i_LicenseNumber)
        {
            VehicleCard o_FoundVehicleCard;
            o_FoundVehicleCard = FindCardByLicense(i_LicenseNumber);
            return o_FoundVehicleCard.Vehicle;
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
            VehicleCard cardToChange = null;

            cardToChange =  m_Cards.Find(vehicleToChange => vehicleToChange.Vehicle.LicenseNumber.Equals(i_LicenseNumber));
            if(cardToChange == null)
            {
                throw new KeyNotFoundException();           
            }
            cardToChange.Status = i_NewsStatus;
        }

        public void InflateVehicleWheelsToMax(string i_LicenseNumber)
        {
            Vehicle vehicleToInflate = null;
            List<Wheel> wheels;

            vehicleToInflate = FindVehicleByLicense(i_LicenseNumber);
            // Exception will be trown in a case of bad license number
            wheels = vehicleToInflate.Wheels;

            foreach(Wheel wheel in wheels)
            {
                wheel.InflateToMaxPressure();
            }
        }

        public bool FuelVehicle(string i_LicenseNumber, float i_FuelToAdd, Fuel.eFuelType i_FuelType)
        {
            Vehicle vehicleToFuel = null;
            Fuel engineToFuel = null;

            vehicleToFuel = FindVehicleByLicense(i_LicenseNumber);

            engineToFuel = vehicleToFuel.EnergySource as Fuel;
            if(engineToFuel == null)
            {
                throw new ArgumentNullException();
            }

            engineToFuel.FuelUp(i_FuelToAdd, i_FuelType); // bad values will throw exceptions
            return true;
        }

        public bool ChargeVehicle(string i_LicenseNumber, float i_BatteryTimeToAdd)
        {
            Vehicle vehicleToCharge = null;
            Battery BatteryToCharge = null;

            vehicleToCharge = FindVehicleByLicense(i_LicenseNumber);

            BatteryToCharge = vehicleToCharge.EnergySource as Battery;
            if(BatteryToCharge == null)
            {
                throw new ArgumentNullException();
            }

            BatteryToCharge.ChargeBattery(i_BatteryTimeToAdd); // bad values will throw exceptions
            return true;
        }


    }
}
