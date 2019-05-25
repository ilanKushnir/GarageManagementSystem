using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{

    public enum eVehicleType
    {
        Car = 1,
        ElectricCar,
        Motorcycle,
        ElectricMotorcycle,
        Truck
    }


    public static class VehicleCreator
    {
        public static Vehicle CreateNewVehicle(VehicleInputData i_VehicleData)
        {
            Vehicle o_NewVehicle = null;
            List<Wheel> o_WheelsList = CreateWheelsList(i_VehicleData);
            EnergySource o_EnergySource = CreateEnergySource(i_VehicleData);

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

        private static List<Wheel> CreateWheelsList(VehicleInputData i_VehicleData)
        {
            List<Wheel> o_WheelsList = new List<Wheel>();
            int numOfWheels = 0;

            switch (i_VehicleData.m_VehicleType)
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
                Wheel newWheel = new Wheel(i_VehicleData.m_WheelsManufacturer,
                                           i_VehicleData.m_CurrentAirPressure,
                                           i_VehicleData.m_MaxAirPressure);
                o_WheelsList.Add(newWheel);
            }

            return o_WheelsList;
        }

        private static EnergySource CreateEnergySource(VehicleInputData i_VehicleData)
        {
            EnergySource o_energySource = null;

            switch(i_VehicleData.m_VehicleType)
            {
                case eVehicleType.Car:
                case eVehicleType.Motorcycle:
                case eVehicleType.Truck:
                    o_energySource = new Fuel(i_VehicleData.m_CurrentFuelCapacity,
                                              i_VehicleData.m_MaxFuelCapacity,
                                              i_VehicleData.m_FuelType);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    o_energySource = new Battery(i_VehicleData.m_RemainingBatteryTime,
                                                 i_VehicleData.m_MaxBatteryTime);
                    break;
                default:
                    break;
            }

            return o_energySource;
        }
    }
}
