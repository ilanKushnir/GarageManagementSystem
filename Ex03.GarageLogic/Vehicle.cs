using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.Exceptions;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels;
        protected EnergySource m_EnergySource;

        public Vehicle(string i_ModelName, string i_LicenseNumber, List<Wheel> i_Wheels, EnergySource i_EnergySource)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = i_Wheels;
            m_EnergySource = i_EnergySource;
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public EnergySource EnergySource
        {
            get { return m_EnergySource; }
        }

        public static VehicleCreator.eVehicleType GetVehicleType(Vehicle i_Vehicle)
        {
            VehicleCreator.eVehicleType o_VehicleType = 0;

            if (i_Vehicle is Car && i_Vehicle.EnergySource is Fuel)
            {
                o_VehicleType = VehicleCreator.eVehicleType.Car;
            }
            else if (i_Vehicle is Car && i_Vehicle.EnergySource is Battery)
            {
                o_VehicleType = VehicleCreator.eVehicleType.ElectricCar;
            }
            else if (i_Vehicle is Motorcycle && i_Vehicle.EnergySource is Fuel)
            {
                o_VehicleType = VehicleCreator.eVehicleType.Motorcycle;
            }
            else if (i_Vehicle is Motorcycle && i_Vehicle.EnergySource is Battery)
            {
                o_VehicleType = VehicleCreator.eVehicleType.ElectricMotorcycle;
            }
            else if (i_Vehicle is Truck)
            {
                o_VehicleType = VehicleCreator.eVehicleType.Truck;
            }
            else
            {
                o_VehicleType = 0;
            }

            return o_VehicleType;
        }
    }
}
