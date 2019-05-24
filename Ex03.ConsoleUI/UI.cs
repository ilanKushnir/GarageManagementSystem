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
            Console.WriteLine("Welcome To Garage Manager By Ilan & Ofir" + Environment.NewLine);

            while(userChoice != 7)
            {
                bool result = false;
                ShowMenu();

                while(!result)
                {
                    userChoice = getUserChoice();
                    result = validateUserChoice(userChoice);
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
                //throw new FormatException("bla");
            }
        }

        public static bool validateUserChoice(int userChoice)
        {
            return userChoice <= 7 && userChoice >= 1;
        }

        public static void ShowMenu()
        {
            StringBuilder menu = new StringBuilder("Hello" + Environment.NewLine + "Please choose which action to make by inserting a chioce number below:" + Environment.NewLine);
            List<string> options = new List<string>();
            options.Add("1) Add a new vehicle to garage" + Environment.NewLine);
            options.Add("2) Show license numbers by status" + Environment.NewLine);
            options.Add("3) Change car status" + Environment.NewLine);
            options.Add("4) Inflate car wheels to maximum" + Environment.NewLine);
            options.Add("5) Fuel/Charge vehicle" + Environment.NewLine);
            options.Add("6) Show vehicle full data" + Environment.NewLine);
            options.Add("7) Exit" + Environment.NewLine);

            menu.Append(options);
            menu.Append("Please choose: " + Environment.NewLine);
            Console.WriteLine(menu);
        }

        
        ////////////////////////////////
        

        private void AddNewVehicleToGarage()
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
                catch(FormatException ex)
                {

                }
            }





        }

        private void ShowLicenseNumbersByStatus()
        {

        }

        private void ChangeVehicleStatus()
        {

        }

        private void InflateVehicleToMax()
        {

        }
        
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
