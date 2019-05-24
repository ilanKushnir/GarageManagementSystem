using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

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

    public static class VehicleCreator
    {
        public static Vehicle CreateNewVehicle(ref VehicleInputData input)
        {
            Vehicle o_NewVehicle = null;
            List<Wheel> o_WheelsList = CreateWheelsList(ref input);
            EnergySource o_EnergySource = CreateEnergySource(ref input);

            switch (input.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.ElectricCar:
                    o_NewVehicle = new Car(input.m_ModelName,
                                           input.m_LicenseNumber,
                                           o_WheelsList,
                                           o_EnergySource,
                                           input.m_Color,
                                           input.m_Doors);
                    break;
                case eVehicleType.Motorcycle:
                case eVehicleType.ElectricMotorcycle:
                    o_NewVehicle = new Motorcycle(input.m_ModelName,
                                                  input.m_LicenseNumber,
                                                  o_WheelsList,
                                                  o_EnergySource,
                                                  input.m_LicenseType,
                                                  input.m_EngineCapacity);
                    break;
                case eVehicleType.Truck:
                    o_NewVehicle = new Truck(input.m_ModelName,
                                             input.m_LicenseNumber,
                                             o_WheelsList,
                                             o_EnergySource,
                                             input.m_ContainDangerousSubstances,
                                             input.m_CargoVolume);
                    break;
                default:
                    break;
            }

            return o_NewVehicle;
        }

        private static List<Wheel> CreateWheelsList(ref VehicleInputData input)
        {
            List<Wheel> o_WheelsList = new List<Wheel>();
            int numOfWheels = 0;

            switch (input.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.ElectricCar:
                    numOfWheels = Car.sr_NumOfWheels;
                    break;
                case eVehicleType.Motorcycle:
                case eVehicleType.ElectricMotorcycle:
                    numOfWheels = Motorcycle.sr_NumOfWheels;
                    break;
                case eVehicleType.Truck:
                    numOfWheels = Motorcycle.sr_NumOfWheels;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < numOfWheels; i++)
            {
                Wheel newWheel = new Wheel(input.m_WheelsManufacturer,
                                           input.m_CurrentAirPressure,
                                           input.m_MaxAirPressure);
                o_WheelsList.Add(newWheel);
            }

            return o_WheelsList;
        }

        private static EnergySource CreateEnergySource(ref VehicleInputData input)
        {
            EnergySource o_energySource = null;

            switch(input.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.Motorcycle:
                case eVehicleType.Truck:
                    o_energySource = new Fuel(input.m_CurrentFuelCapacity,
                                              input.m_MaxFuelCapacity);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    o_energySource = new Battery(input.m_RemainingBatteryTime,
                                                 input.m_MaxBatteryTime);
                    break;
                default:
                    break;
            }

            return o_energySource;
        }
    }
}
