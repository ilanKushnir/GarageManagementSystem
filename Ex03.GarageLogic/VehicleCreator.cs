using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{

    public enum eVehicleType
    {
        Car,
        ElectricCar,
        Motorcycle,
        ElectricMotorcycle,
        Truck
    }

    public struct VehicleInputData
    {
        // Vehicle
        string m_ModelName;
        string m_LicenseNumber;
        eVehicleType m_VehicleType;
        //Wheels
        string m_WheelsManufacturer;
        List<float> m_CurrentAirPressure;
        float m_MaxAirPressure;

        // Car
        Car.eCarColor m_Color;
        Car.eNumOfDoors m_Doors;

        // Motorcycle
        Motorcycle.eLicenseType m_LicenseType;
        int m_EngineCapacity;

        // Truck
        bool m_ContainDangerousSubstances;
        float m_CargoVolume;

        // EnergySource
        // Fuel
        Fuel.eFuelType m_FuelType;
        float m_CurrentFuelCapacity;
        float m_MaxFuelCapacity;
        // Battery
        float m_RemainingBatteryTime;
        float m_MaxBatteryTime;
    }

    static class VehicleCreator
    {
        public static Vehicle CreateNewVehicle(VehicleInputData input)
        {


            return null;
        }
    }
}
