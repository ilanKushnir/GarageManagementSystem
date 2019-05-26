using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInputData
    {
        // Vehiclee
        public string m_ModelName;
        public string m_LicenseNumber;
        public eVehicleType m_VehicleType;
        //Wheels
        public string m_WheelsManufacturer;
        public float m_CurrentAirPressure;

        // Car
        public Car.eCarColor m_Color;
        public Car.eNumOfDoors m_Doors;

        // Motorcycle
        public Motorcycle.eLicenseType m_LicenseType;
        public int m_EngineCapacity;

        // Truck
        public bool m_ContainDangerousSubstances;
        public float m_CargoVolume;

        // EnergySource
        // Fuel
        public float m_CurrentFuelCapacity;
        // Battery
        public float m_RemainingBatteryTime;
    }
}
