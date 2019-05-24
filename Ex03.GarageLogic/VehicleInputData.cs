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
        public float m_MaxAirPressure;

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
        public Fuel.eFuelType m_FuelType;
        public float m_CurrentFuelCapacity;
        public float m_MaxFuelCapacity;
        // Battery
        public float m_RemainingBatteryTime;
        public float m_MaxBatteryTime;
    }
}
