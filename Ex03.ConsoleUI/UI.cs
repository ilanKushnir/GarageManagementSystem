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
            Console.WriteLine("Welcom");
            ShowMenu();

            //input
            //questions...
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Menu String builder");
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
