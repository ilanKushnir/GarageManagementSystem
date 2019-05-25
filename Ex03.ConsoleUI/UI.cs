﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
using Ex03.Exceptions;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        public static void Run(Garage i_Garage)
        {
            //string userInput = string.Empty;
            int    userChoice = 0;
            bool   validInput = false;

            PrintWelcomeMessage();

            while (userChoice != 7)
            {
                PrintMenu();

                while (validInput == false)
                {
                    try
                    {
                        validInput = GetValidIntFromUserInRange(out userChoice, 1, 7);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Please enter a number.");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine("Error: The number should be between " + ex.MinValue + " to " + ex.MaxValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                    }
                }

                switch (userChoice)
                {
                    case 1:
                        AddNewVehicleToGarage(i_Garage);
                        break;
                    case 2:
                        ShowLicenseNumbersByStatus();
                        break;
                    case 3:
                        ChangeVehicleStatus(i_Garage);
                        break;
                    case 4:
                        InflateVehicleToMax();
                        break;
                    case 5:

                        break;
                    case 6:
                        ShowVehicleDataByLicenseNumber(i_Garage);
                        break;
                    default:
                        //userChoice = 0;
                        break;
                }

                userChoice = 0;
            }
            // exit program
        }

       


        public static void PrintWelcomeMessage()
        {
            StringBuilder welcome = new StringBuilder();
            // ASCII art
            welcome.Append(Environment.NewLine + " Welcome to:                    /\\\\      _____                    \r\n                 ,-----,       /  \\\\____/__|__\\_                  \r\n              ,--'---:---`--, /  |  _     |     `|                \r\n             ==(o)-----(o)==J    `(o)-------(o)=                  \r\n``````````````````````````````````````````````````````````````````\r\n  _____                         __  ___                           \r\n / ___/__  _______  ___  ___   /  |/  /__  ___  ___  ___  ___ ____\r\n/ (_ / _ `/ __/ _ `/ _ `/ -_) / /|_/ / _ `/ _ \\/ _ `/ _ `/ -_) __/\r\n\\___/\\_,_/_/  \\_,_/\\_, /\\__/ /_/  /_/\\_,_/_//_/\\_,_/\\_, /\\__/_/   \r\n                  /___/                            /___/          \r\n                          By Ilan & Ofir                          \r\n");
            Console.WriteLine(welcome);
        }

        public static void PrintMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.Append(" Please choose which action to make by inserting a chioce number below: " + Environment.NewLine);
            menu.Append(" __________________________________" + Environment.NewLine);
            menu.Append("  1) Add a new vehicle to garage" +    Environment.NewLine);
            menu.Append("  2) Show license numbers by status" + Environment.NewLine);
            menu.Append("  3) Change car status" +              Environment.NewLine);
            menu.Append("  4) Inflate car wheels to maximum" +  Environment.NewLine);
            menu.Append("  5) Fuel/Charge vehicle" +            Environment.NewLine);
            menu.Append("  6) Show vehicle full data" +         Environment.NewLine);
            menu.Append("  7) Exit" +                           Environment.NewLine);
            menu.Append(" ----------------------------------" + Environment.NewLine + Environment.NewLine);
            menu.Append(" Please choose and press Enter: " +    Environment.NewLine);

            Console.WriteLine(menu);
        }


        ////////////////////////////////


        public static void AddNewVehicleToGarage(Garage i_Garage)
        {
            VehicleInputData vehicleData = GetVehicleDataFromUser();

            try
            {
              //  i_Garage.AddVehicleToGarage(owner, phone, vehicleData);
            }
            catch(VehicleAllreadyInGarageException ex)
            {
                Console.WriteLine("Vehicle with license number " + ex.LicenseNumber + " is allready taken care in garage. Status changed to InService");
            }

            // הוספת רכב למוסך צריכה להיות סטטית כי המוסך הקלאס הנוכחי לא מחזיק אובייקט מוסך?
            // ויצירת הרכב חייבת לקרות בתוך מתודת ההוספה במוסך
            ////////////////////////////////////////////

            
        }

        public static void ShowLicenseNumbersByStatus()
        {

        }

        public static void ChangeVehicleStatus(Garage i_Garage)
        {
            string o_LicenseNumber;
            VehicleCard.eVehicleStatus o_NewStatus = 0;

            GetVehicleLicenseNumberFromUser(out o_LicenseNumber);
            //GetVehicleStatusFromUser(out o_NewStatus);              /// add method!

            try
            {
                i_Garage.ChangeVehicleStatus(o_LicenseNumber, o_NewStatus);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine("License number " + ex.Message + " does not exist on garage");
            }
        }

        public static void InflateVehicleToMax(Garage i_Garage)
        {
            string o_LicenseNumber;
            GetVehicleLicenseNumberFromUser(out o_LicenseNumber);
            i_Garage.InflateVehicleWheelsToMax(o_LicenseNumber);
        }
        
        public static void FuelOrChargeVehicle()
        { }

        private void FuelVehicle()
        {

        }

        private void ChargeVehicle()
        {

        }

        public static void ShowVehicleDataByLicenseNumber(Garage i_Garage)
        {

        }


        /////////////////////////////////////////////////////////////
        
        private static VehicleInputData GetVehicleDataFromUser()
        {
            VehicleInputData o_VehicleData = new VehicleInputData();

            GetVehicleLicenseNumberFromUser(out o_VehicleData.m_LicenseNumber);
            GetVehicleTypeFromUser(out o_VehicleData.m_VehicleType);
            GetVehicleModelNameFromUser(out o_VehicleData.m_ModelName);
            GetVehicleSpecificDataFromUserByType(out o_VehicleData.m_VehicleType, out o_VehicleData);
            GetWheelsDataFromUser(out o_VehicleData.m_WheelsManufacturer,
                                  out o_VehicleData.m_CurrentAirPressure,
                                  out o_VehicleData.m_MaxAirPressure);


            ////// GET... SPECIFIC DATA BY TYPE .....
            /////////////////////////////////////
            




            return o_VehicleData;
        }

        private static void GetVehicleTypeFromUser(out eVehicleType o_VehicleType)
        {
            int userChoice = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose your vehicle type:" + Environment.NewLine);
            userPrompt.Append("  1) Car" + Environment.NewLine);
            userPrompt.Append("  2) Electric Car" + Environment.NewLine);
            userPrompt.Append("  3) Motorcycle" + Environment.NewLine);
            userPrompt.Append("  4) Electric Motorcycle" + Environment.NewLine);
            userPrompt.Append("  5) Truck" + Environment.NewLine);
            userPrompt.Append(" ---------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = GetValidIntFromUserInRange(out userChoice, 1, 5);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The number should be between " + ex.MinValue +" to " + ex.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            switch(userChoice)
            {
                case 1:
                    o_VehicleType = eVehicleType.Car;
                    break;
                case 2:
                    o_VehicleType = eVehicleType.ElectricCar;
                    break;
                case 3:
                    o_VehicleType = eVehicleType.Motorcycle;
                    break;
                case 4:
                    o_VehicleType = eVehicleType.ElectricMotorcycle;
                    break;
                case 5:
                    o_VehicleType = eVehicleType.Truck;
                    break;
                default:
                    o_VehicleType = 0;
                    break;
            }
        }

        public static void GetVehicleColorFromUser(out Car.eCarColor o_VehicleColor)
        {
            int userChoice = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" -----------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose your vehicle's color:" + Environment.NewLine);
            userPrompt.Append("  1) Red" +                             Environment.NewLine);
            userPrompt.Append("  2) Blue" +                            Environment.NewLine);
            userPrompt.Append("  3) Black" +                           Environment.NewLine);
            userPrompt.Append("  4) Grey" +                            Environment.NewLine);
            userPrompt.Append(" -----------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = GetValidIntFromUserInRange(out userChoice, 1, 4);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The number should be between " + ex.MinValue + " to " + ex.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            switch (userChoice)
            {
                case 1:
                    o_VehicleColor = Car.eCarColor.Red;
                    break;
                case 2:
                    o_VehicleColor = Car.eCarColor.Blue;
                    break;
                case 3:
                    o_VehicleColor = Car.eCarColor.Black;
                    break;
                case 4:
                    o_VehicleColor = Car.eCarColor.Grey;
                    break;
                default:
                    o_VehicleColor = 0;
                    break;
            }
        }

        public static void GetVehicleNumberOfDoorsFromUser(out Car.eNumOfDoors o_NumOfDoors)
        {
            int userChoice = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose your vehicle's number of doors:" + Environment.NewLine);
            userPrompt.Append("  2" +                                            Environment.NewLine);
            userPrompt.Append("  3" +                                            Environment.NewLine);
            userPrompt.Append("  4" +                                            Environment.NewLine);
            userPrompt.Append("  5" +                                            Environment.NewLine);
            userPrompt.Append(" ---------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = GetValidIntFromUserInRange(out userChoice, 2, 5);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The number of doors should be between " + ex.MinValue + " to " + ex.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            switch (userChoice)
            {
                case 2:
                    o_NumOfDoors = Car.eNumOfDoors.Two;
                    break;
                case 3:
                    o_NumOfDoors = Car.eNumOfDoors.Three;
                    break;
                case 4:
                    o_NumOfDoors = Car.eNumOfDoors.Four;
                    break;
                case 5:
                    o_NumOfDoors = Car.eNumOfDoors.Five;
                    break;
                default:
                    o_NumOfDoors = 0;
                    break;
            }
        }


        private static void GetVehicleModelNameFromUser(out string o_ModelName)
        {
            string stringInput = string.Empty;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's model name:" + Environment.NewLine);
            userPrompt.Append(" ---------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = GetStringInLengthRangeFromUser(out stringInput, 1, 100);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The model name's length should be " + ex.MinValue + " to " + ex.MaxValue + " chars");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Error: The model name can't be empty");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_ModelName = stringInput;
        }


        private static void GetVehicleLicenseNumberFromUser(out string o_LicenseNumber)
        {
            string stringInput = string.Empty;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" -------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's license number:" + Environment.NewLine);
            userPrompt.Append(" -------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = GetStringInLengthRangeFromUser(out stringInput, 7, 8);
                }
                catch (ValueOutOfRangeException ex )
                {
                    Console.WriteLine("Error: The vehicle license number length should be " + ex.MinValue + " to " + ex.MaxValue + " chars");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Error: The license number can't be empty");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_LicenseNumber = stringInput;
        }


        private static void GetVehicleSpecificDataFromUserByType(eVehicleType i_VehicleType,
                                                                 VehicleInputData o_VehicleData)
        {
            switch(i_VehicleType)
            {
                case eVehicleType.Car:
                    GetVehicleColorFromUser(out o_VehicleData.m_Color);
                    GetVehicleNumberOfDoorsFromUser(out o_VehicleData.m_Doors);
                    GetVehicleFuelDataFromUser(o_VehicleData);
                    break;
                case eVehicleType.ElectricCar:
                    GetVehicleColorFromUser(out o_VehicleData.m_Color);
                    GetVehicleNumberOfDoorsFromUser(out o_VehicleData.m_Doors);
                    GetVehicleBatteryDataFromUser(o_VehicleData);
                    break;
                case eVehicleType.Motorcycle:
                    GetVehicleLicenseTypeFromUser(out o_VehicleData.m_LicenseType);
                    GetVehicleEngineCapacityFromUser(out o_VehicleData.m_EngineCapacity);
                    GetVehicleFuelDataFromUser(o_VehicleData);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    GetVehicleLicenseTypeFromUser(out o_VehicleData.m_LicenseType);
                    GetVehicleEngineCapacityFromUser(out o_VehicleData.m_EngineCapacity);
                    GetVehicleBatteryDataFromUser(o_VehicleData);
                    break;
                case eVehicleType.Truck:
                    GetVehicleDangerousSubstancesDataFromUser(out o_VehicleData.m_ContainDangerousSubstances);
                    GetVehicleCargoVolumeFromUser(out o_VehicleData.m_CargoVolume);
                    GetVehicleFuelDataFromUser(o_VehicleData);
                    break;
                case default:
                    break;
            }
        }


        private static void GetWheelsDataFromUser(out string o_Manufacturer,
                                                  out float o_CurrentAirPressure,
                                                  out float o_MaxAirPressure)
        {
            float pressureInput = 0;
            string stringInput = string.Empty;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter wheels manufacturer name:" + Environment.NewLine);
            userPrompt.Append(" ---------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = GetStringInLengthRangeFromUser(out stringInput, 1, 100);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The manufacturer's name length should be " + ex.MinValue + " to " + ex.MaxValue + " chars");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Error: The name can't be empty");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_Manufacturer = stringInput;

            userPrompt.Clear();
            userPrompt.Append(" -------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter manufacturer maximum pressure allowed" + Environment.NewLine);
            userPrompt.Append(" -------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    GetValidFloatFromUserInRange(out pressureInput, 0, float.MaxValue);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a floating point number");
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Error: Please enter a positive number");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_MaxAirPressure = pressureInput;

            userPrompt.Clear();
            userPrompt.Append(" -----------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter current wheels pressure" + Environment.NewLine);
            userPrompt.Append(" -----------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            pressureInput = 0;
            validInput = false;
            do
            {
                try
                {
                    GetValidFloatFromUserInRange(out pressureInput, 0, o_MaxAirPressure);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a floating point number");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The pressure should be positive number," + Environment.NewLine +
                                      "       and smaller then the maximum pressure (" + ex.MaxValue + ")");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_CurrentAirPressure = pressureInput;
        }

        private static void GetVehicleFuelDataFromUser(out Fuel.eFuelType o_FuelType,
                                                       out float o_CurrentFuelCapacity,
                                                       out float o_MaxFuelCapacity)
        {
            float capacityInput = 0;
            string stringInput = string.Empty;
            bool validInput = false;
            int userChoice = 0;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose your vehicle's fuel type:" + Environment.NewLine);
            userPrompt.Append("  1) Octan95" + Environment.NewLine);
            userPrompt.Append("  2) Octan96" + Environment.NewLine);
            userPrompt.Append("  3) Octan98" + Environment.NewLine);
            userPrompt.Append("  4) Soler" +   Environment.NewLine);
            userPrompt.Append(" ---------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = GetValidIntFromUserInRange(out userChoice, 1, 4);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The choice number should be between " + ex.MinValue + " to " + ex.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            switch (userChoice)
            {
                case 5:
                    o_FuelType = Fuel.eFuelType.Octan95;
                    break;
                case 2:
                    o_FuelType = Fuel.eFuelType.Octan96;
                    break;
                case 3:
                    o_FuelType = Fuel.eFuelType.Octan98;
                    break;
                case 4:
                    o_FuelType = Fuel.eFuelType.Soler;
                    break;
                default:
                    o_FuelType = 0;
                    break;
            }
            
            userPrompt.Clear();
            userPrompt.Append(" ----------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's max fuel capacity:" + Environment.NewLine);
            userPrompt.Append(" ----------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    GetValidFloatFromUserInRange(out capacityInput, 0, float.MaxValue);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a floating point number");
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Error: Please enter a positive number");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_MaxFuelCapacity = capacityInput;

            userPrompt.Clear();
            userPrompt.Append(" --------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter current vehicle's fuel capacity:" + Environment.NewLine);
            userPrompt.Append(" --------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            capacityInput = 0;
            validInput = false;
            do
            {
                try
                {
                    GetValidFloatFromUserInRange(out capacityInput, 0, o_MaxFuelCapacity);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a floating point number");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The capacity should be a positive number," + Environment.NewLine +
                                      "       and smaller then the maximum capacity (" + ex.MaxValue + ")");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);
            o_CurrentFuelCapacity = capacityInput;
        }

        public static bool GetValidIntFromUserInRange(out int o_UserInput, int i_MinValue, int i_MaxValue)
        {
            if (int.TryParse(Console.ReadLine(), out o_UserInput) == false)
            {
                throw new FormatException();
            }

            if (o_UserInput < i_MinValue || o_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(new Exception(), i_MinValue, i_MaxValue);
            }

            return true;
        }

        public static bool GetValidFloatFromUserInRange(out float o_UserInput, float i_MinValue, float i_MaxValue)
        {
            if (float.TryParse(Console.ReadLine(), out o_UserInput) == false)
            {
                throw new FormatException();
            }

            if (o_UserInput < i_MinValue || o_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(new Exception(), i_MinValue, i_MaxValue);
            }

            return true;
        }

       

        public static bool GetStringInLengthRangeFromUser(out string o_UserInput, int i_MinLength, int i_MaxLength)
        {
            string userInput;
            userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                throw new NullReferenceException();
            }
            else if(userInput.Length < i_MaxLength || userInput.Length > i_MaxLength)
            {
                throw new ValueOutOfRangeException(new Exception(), i_MinLength, i_MaxLength);
            }

            o_UserInput = userInput;
            return true;
        }
    }
}
