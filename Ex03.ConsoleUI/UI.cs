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
            string userInput = string.Empty;
            int userChoice = 0;
            bool valueInRange = false;
            Console.WriteLine("Welcome To Garage Manager By Ilan & Ofir" + Environment.NewLine);

            while(userChoice != 7)
            {
                ShowMenu();

                while(valueInRange == false)
                {
                    userChoice = getUserChoice();
                    valueInRange = validateUserChoice(userChoice);
                }

                switch(userChoice)
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
                        break;
                }
            }
            // exit program
        }

        public static int getUserChoice()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static bool validateUserChoice(int userChoice)
        {
            return userChoice <= 7 && userChoice >= 1;
        }

        public static void ShowMenu()
        {
            StringBuilder menu = new StringBuilder("Menu" + Environment.NewLine + "Please choose which action to make by inserting a chioce number below:" + Environment.NewLine);
            menu.Append("1) Add a new vehicle to garage" + Environment.NewLine);
            menu.Append("2) Show license numbers by status" + Environment.NewLine);
            menu.Append("3) Change car status" + Environment.NewLine);
            menu.Append("4) Inflate car wheels to maximum" + Environment.NewLine);
            menu.Append("5) Fuel/Charge vehicle" + Environment.NewLine);
            menu.Append("6) Show vehicle full data" + Environment.NewLine);
            menu.Append("7) Exit" + Environment.NewLine);
            menu.Append("Please choose: " + Environment.NewLine);
            Console.WriteLine(menu);
        }

        
        ////////////////////////////////
        

        public static void AddNewVehicleToGarage()
        {
            int userChoice = 0;
            StringBuilder userPrompt = new StringBuilder("Please choose vehicle type:" + Environment.NewLine);
            userPrompt.Append(" 1) Car" + Environment.NewLine);
            userPrompt.Append(" 2) Electric Car" + Environment.NewLine);
            userPrompt.Append(" 3) Motorcycle" + Environment.NewLine);
            userPrompt.Append(" 4) Electric Motorcycle" + Environment.NewLine);
            userPrompt.Append(" 5) Truck" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while(userChoice < 1 && userChoice > 5)
            {
                userChoice = Int32.Parse(Console.ReadLine());

                //catch(FormatException ex)
                {

                }
            }





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
    }
}
