using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        public static void Run(Garage i_garage)
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
                        validInput = GetValidUserIntChoiceInRange(out userChoice, 1, 7);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Please enter a number.");
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Error: The number should be between 1 to 7.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                    }
                }

                switch (userChoice)
                {
                    case 1:
                        AddNewVehicleToGarage();
                        break;
                    case 2:
                        ShowLicenseNumbersByStatus();
                        break;
                    case 3:
                        ChangeVehicleStatus();
                        break;
                    case 4:
                        InflateVehicleToMax();
                        break;
                    case 5:

                        break;
                    case 6:
                        break;
                    default:
                        userChoice = 0;
                        break;
                }

                userChoice = 0;
            }
            // exit program
        }

        public static bool GetValidUserIntChoiceInRange(out int o_UserChoice, int i_MinValue, int i_MaxValue)
        {
            if (!int.TryParse(Console.ReadLine(), out o_UserChoice))
            {
                throw new FormatException();
            }

            if (o_UserChoice < i_MinValue || o_UserChoice > i_MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            return true;
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


        public static void AddNewVehicleToGarage()
        {
            VehicleInputData vehicleData = GetVehicleDataFromUser();
            // הוספת רכב למוסך צריכה להיות סטטית כי המוסך הקלאס הנוכחי לא מחזיק אובייקט מוסך?
            // ויצירת הרכב חייבת לקרות בתוך מתודת ההוספה במוסך
            ////////////////////////////////////////////

            
        }

        public static void ShowLicenseNumbersByStatus()
        {

        }

        public static void ChangeVehicleStatus()
        {

        }

        public static void InflateVehicleToMax()
        {

        }
        
        public static void FuelOrChargeVehicle()
        { }

        private void FuelVehicle()
        {

        }

        private void ChargeVehicle()
        {

        }

        private void ShowVehicleDataByLicenseNumber()
        {

        }


        /////////////////////////////////////////////////////////////
        
        private static VehicleInputData GetVehicleDataFromUser()
        {
            VehicleInputData o_VehicleData = new VehicleInputData();

            o_VehicleData.m_VehicleType = GetVehicleTypeFromUser();
            /////////////////////////////////////
            




            return o_VehicleData;
        }

        private static eVehicleType GetVehicleTypeFromUser()
        {
            int userChoice = 0;
            bool validInput = false;
            eVehicleType o_VehicleType;
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
                    validInput = GetValidUserIntChoiceInRange(out userChoice, 1, 5);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error: The number should be between 1 to 5.");
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

            return o_VehicleType;
        }
    }
}
