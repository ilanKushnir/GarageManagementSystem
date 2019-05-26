using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public enum eVehicleType
        {
            Car = 1,
            ElectricCar,
            Motorcycle,
            ElectricMotorcycle,
            Truck
        }

        public static Vehicle CreateNewVehicle(VehicleInputData i_VehicleData)
        {
            Vehicle o_NewVehicle = null;
            List<Wheel> o_WheelsList = createWheelsList(i_VehicleData);
            EnergySource o_EnergySource = createEnergySource(i_VehicleData);

            switch (i_VehicleData.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.ElectricCar:
                    o_NewVehicle = new Car(i_VehicleData.m_ModelName,
                                           i_VehicleData.m_LicenseNumber,
                                           o_WheelsList,
                                           o_EnergySource,
                                           i_VehicleData.m_Color,
                                           i_VehicleData.m_Doors);
                    break;
                case eVehicleType.Motorcycle:
                case eVehicleType.ElectricMotorcycle:
                    o_NewVehicle = new Motorcycle(i_VehicleData.m_ModelName,
                                                  i_VehicleData.m_LicenseNumber,
                                                  o_WheelsList,
                                                  o_EnergySource,
                                                  i_VehicleData.m_LicenseType,
                                                  i_VehicleData.m_EngineCapacity);
                    break;
                case eVehicleType.Truck:
                    o_NewVehicle = new Truck(i_VehicleData.m_ModelName,
                                             i_VehicleData.m_LicenseNumber,
                                             o_WheelsList,
                                             o_EnergySource,
                                             i_VehicleData.m_ContainDangerousSubstances,
                                             i_VehicleData.m_CargoVolume);
                    break;
                default:
                    break;
            }

            return o_NewVehicle;
        }

        private static List<Wheel> createWheelsList(VehicleInputData i_VehicleData)
        {
            List<Wheel> o_WheelsList = new List<Wheel>();
            int numOfWheels = 0;
            float maxAirPressure = 0;

            switch (i_VehicleData.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.ElectricCar:
                    numOfWheels = Car.sr_NumOfWheels;
                    maxAirPressure = Car.sr_MaxAirPressure;
                    break;
                case eVehicleType.Motorcycle:
                case eVehicleType.ElectricMotorcycle:
                    numOfWheels = Motorcycle.sr_NumOfWheels;
                    maxAirPressure = Motorcycle.sr_MaxAirPressure;
                    break;
                case eVehicleType.Truck:
                    numOfWheels = Truck.sr_NumOfWheels;
                    maxAirPressure = Truck.sr_MaxAirPressure;
                    break;
                default:
                    break;
            }

            for (int i = 0; i < numOfWheels; i++)
            {
                Wheel newWheel = new Wheel(i_VehicleData.m_WheelsManufacturer,
                                           i_VehicleData.m_CurrentAirPressure,
                                           maxAirPressure);
                o_WheelsList.Add(newWheel);
            }

            return o_WheelsList;
        }

        private static EnergySource createEnergySource(VehicleInputData i_VehicleData)
        {
            EnergySource o_energySource = null;
            Fuel.eFuelType fuelType = 0;
            float maxFuelCapacity = 0;
            float maxBatteryTime = 0;

            switch (i_VehicleData.m_VehicleType)
            {
                case eVehicleType.Car:
                    fuelType = Car.sr_FuelType;
                    maxFuelCapacity = Car.sr_MaxFuelCapacity;
                    break;
                case eVehicleType.Motorcycle:
                    fuelType = Motorcycle.sr_FuelType;
                    maxFuelCapacity = Motorcycle.sr_MaxFuelCapacity;
                    break;
                case eVehicleType.Truck:
                    fuelType = Truck.sr_FuelType;
                    maxFuelCapacity = Truck.sr_MaxFuelCapacity;
                    break;
                case eVehicleType.ElectricCar:
                    maxBatteryTime = Car.sr_MaxBatteryTime;
                    break;
                case eVehicleType.ElectricMotorcycle:
                    maxBatteryTime = Motorcycle.sr_MaxBatteryTime;
                    break;
                default:
                    break;
            }

            switch (i_VehicleData.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.Motorcycle:
                case eVehicleType.Truck:
                    o_energySource = new Fuel(i_VehicleData.m_CurrentFuelCapacity,
                                              maxFuelCapacity,
                                              fuelType);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    o_energySource = new Battery(i_VehicleData.m_RemainingBatteryTime,
                                                 maxBatteryTime);
                    break;
                default:
                    break;
            }

            return o_energySource;
        }
    }
}
