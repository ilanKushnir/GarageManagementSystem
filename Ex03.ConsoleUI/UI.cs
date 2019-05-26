using System;
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

            printWelcomeMessage();

            while (userChoice != 8)
            {
                PrintMenu();

                while (validInput == false)
                {
                    try
                    {
                        validInput = getValidIntFromUserInRange(out userChoice, 1, 8);
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
                        addNewVehicleToGarage(i_Garage);    ////
                        break; 
                    case 2:
                        showLicenseNumbersByStatus(i_Garage);   ///////
                        break;
                    case 3:
                        changeVehicleStatus(i_Garage);          /////////////////////////////
                        break;
                    case 4:
                        inflateVehicleToMax(i_Garage);          //////////////////
                        break;
                    case 5:
                        fuelVehicle(i_Garage);
                        break;
                    case 6:
                        chargeVehicle(i_Garage);
                        break;
                    case 7:
                        showVehicleDataByLicenseNumber(i_Garage);       ////////////////////
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                    default:
                        userChoice = 0;
                        break;
                }

                Console.WriteLine("Press any key to continue..." + Environment.NewLine);
                Console.ReadKey();
                validInput = false;
                userChoice = 0;
            }
        }

        private static void printWelcomeMessage()
        {
            StringBuilder welcome = new StringBuilder();
            // ASCII art
            welcome.Append(Environment.NewLine + " Welcome to:                    /\\\\      _____                    \r\n                 ,-----,       /  \\\\____/__|__\\_                  \r\n              ,--'---:---`--, /  |  _     |     `|                \r\n             ==(o)-----(o)==J    `(o)-------(o)=                  \r\n``````````````````````````````````````````````````````````````````\r\n  _____                         __  ___                           \r\n / ___/__  _______  ___  ___   /  |/  /__  ___  ___  ___  ___ ____\r\n/ (_ / _ `/ __/ _ `/ _ `/ -_) / /|_/ / _ `/ _ \\/ _ `/ _ `/ -_) __/\r\n\\___/\\_,_/_/  \\_,_/\\_, /\\__/ /_/  /_/\\_,_/_//_/\\_,_/\\_, /\\__/_/   \r\n                  /___/                            /___/          \r\n                          By Ilan & Ofir                          \r\n");
            Console.WriteLine(welcome);
        }

        private static void PrintMenu()
        {
            StringBuilder menu = new StringBuilder(Environment.NewLine);
            menu.Append(" Please choose which action to make by inserting a chioce number below: " + Environment.NewLine);
            menu.Append(" __________________________________" + Environment.NewLine);
            menu.Append("  1) Add a new vehicle to garage" +    Environment.NewLine);
            menu.Append("  2) Show license numbers by status" + Environment.NewLine);
            menu.Append("  3) Change car status" +              Environment.NewLine);
            menu.Append("  4) Inflate car wheels to maximum" +  Environment.NewLine);
            menu.Append("  5) Fuel vehicle" +                   Environment.NewLine);
            menu.Append("  6) Charge vehicle" +                 Environment.NewLine);
            menu.Append("  7) Show vehicle full data" +         Environment.NewLine);
            menu.Append("  8) Exit" +                           Environment.NewLine);
            menu.Append(" ----------------------------------" + Environment.NewLine + Environment.NewLine);
            menu.Append(" Please choose and press Enter: " +    Environment.NewLine);

            Console.WriteLine(menu);
        }

        private static void addNewVehicleToGarage(Garage i_Garage)
        {
            string ownerNameInput = string.Empty;
            string ownerPhoneNumberInput = string.Empty;
            VehicleInputData o_VehicleData;
            
            getOwnerNameFromUser(out ownerNameInput);
            getOwnerPhoneNumberFromUser(out ownerPhoneNumberInput);
            o_VehicleData = getVehicleDataFromUser();
            
            try
            {
                i_Garage.AddVehicleToGarage(ownerNameInput, ownerPhoneNumberInput, o_VehicleData);
                Console.WriteLine("The car added successfuly to the garage" + Environment.NewLine);
            }
            catch (VehicleAllreadyInGarageException ex)
            {
                Console.WriteLine("Vehicle with license number " + ex.LicenseNumber + " is allready taken care in the garage." + Environment.NewLine + "Status changed to InService");
            }
        }

        private static void showLicenseNumbersByStatus(Garage i_Garage)
        {
            VehicleCard.eVehicleStatus vehicleStatus;
            List<String> licenseNumbersList;
            StringBuilder sb = new StringBuilder();

            getVehicleStatusFromUser(out vehicleStatus);
            licenseNumbersList = i_Garage.GetLicenseNumbersByStatus(vehicleStatus);

            if(licenseNumbersList.Count == 0)
            {
                sb.Append(string.Format("Vehicle with status {0} not found " + Environment.NewLine, vehicleStatus.ToString()));
            }
            else
            {
                sb.Append(string.Format("Vehicles with status {0} in garage: " + Environment.NewLine, vehicleStatus.ToString()));
                foreach (string licensNumber in licenseNumbersList)
                {
                    sb.Append(licensNumber + Environment.NewLine);
                }
            }

            Console.WriteLine(sb);
        }


        private static void changeVehicleStatus(Garage i_Garage)
        {
            string licenseNumber = null;
            VehicleCard.eVehicleStatus newVehicleStatus = 0;

            getVehicleLicenseNumberFromUser(out licenseNumber);
            getVehicleStatusFromUser(out newVehicleStatus); 

            try
            {                                                                     
                i_Garage.ChangeVehicleStatus(licenseNumber, newVehicleStatus);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("License number does not exist on garage");
            }
        }

        private static void inflateVehicleToMax(Garage i_Garage)
        {
            string licenseNumber;
            try
            {
                getVehicleLicenseNumberFromUser(out licenseNumber);
                i_Garage.InflateVehicleWheelsToMax(licenseNumber);
                Console.WriteLine("Vehicles wheels inflated to max successfuly");
            }
            catch(KeyNotFoundException)
            {
                Console.WriteLine("License number does not exist on garage");
            }
        }

        private static void fuelVehicle(Garage i_Garage)
        {
            string licenseNumber = null;
            Fuel.eFuelType fuelType;
            float fuelToAdd;

            getVehicleLicenseNumberFromUser(out licenseNumber);
            getFuelTypeFromUser(out fuelType);
            getFuelToAddFromUser(out fuelToAdd);

            try
            {
                i_Garage.FuelVehicle(licenseNumber, fuelToAdd, fuelType);
                Console.WriteLine("Vehicle fueled to successfuly");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("License Number does not exist in the garage");
            }
            catch (ArgumentNullException) // electric vehicle
            {
                Console.WriteLine("The vehicle has no fuel tank");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine("Cannot fuel vehilce over the maximum fuel capacity of" + ex.MaxValue);
            }
            catch (WrongFuelException ex)
            {
                Console.WriteLine("Cannot fuel vehicle with {0} fuel type instead of {1}", ex.WrongFuel, ex.Fuel);
            }
        }

        private static void chargeVehicle(Garage i_Garage)
        {
            string licenseNumber = null;
            float batteryTimeToAdd;
            bool validInput = false;

            getVehicleLicenseNumberFromUser(out licenseNumber);
            getBatteryTimeToAddFromUser(out batteryTimeToAdd);

            try
            {
                validInput = i_Garage.ChargeVehicle(licenseNumber, batteryTimeToAdd);
                Console.WriteLine("Vehicle charged successfuly");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("License Number does not exist in the garage");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The vehicle has no Battery");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine("Cannot charge battery over " + ex.MaxValue);
            }
        }

        private static void showVehicleDataByLicenseNumber(Garage i_Garage)
        {
            string licenseNumber = string.Empty;
            Vehicle vehicleToShow;
            VehicleCard cardToShow;
            StringBuilder outputString = new StringBuilder();
            VehicleCreator.eVehicleType vehicleType = 0;

            getVehicleLicenseNumberFromUser(out licenseNumber);
            
            try
            {
                cardToShow = i_Garage.FindCardByLicense(licenseNumber);
                vehicleToShow = cardToShow.Vehicle;
                vehicleType = Vehicle.GetVehicleType(vehicleToShow);

                outputString.Append(Environment.NewLine);
                outputString.Append("************************ License Number: " + licenseNumber + " ************************" + Environment.NewLine);
                outputString.Append(" + Model name: " + vehicleToShow.ModelName + Environment.NewLine);
                outputString.Append(" + Owner name: " + cardToShow.OwnerName + Environment.NewLine);
                outputString.Append(" + Vehicle status: " + cardToShow.Status + Environment.NewLine);
                outputString.Append(" + Energy percentage: " + vehicleToShow.EnergySource.EnergyPercentage + "%" + Environment.NewLine);

                switch(vehicleType)
                {
                    case VehicleCreator.eVehicleType.Car:
                    case VehicleCreator.eVehicleType.Motorcycle:
                    case VehicleCreator.eVehicleType.Truck:
                        outputString.Append(" + Fuel type: " + ((Fuel)vehicleToShow.EnergySource).FuelType.ToString() + Environment.NewLine);
                        outputString.Append(" + Max fuel capacity: " + ((Fuel)vehicleToShow.EnergySource).MaxFuelCapacity + Environment.NewLine);
                        outputString.Append(" + Current fuel capacity: " + ((Fuel)vehicleToShow.EnergySource).CurrentFuelCapacity + Environment.NewLine);
                        break;
                    case VehicleCreator.eVehicleType.ElectricCar:
                    case VehicleCreator.eVehicleType.ElectricMotorcycle:
                        outputString.Append(" + Max battery time: " + ((Battery)vehicleToShow.EnergySource).MaxBatteryTime + Environment.NewLine);
                        outputString.Append(" + Remaining battery time: " + ((Battery)vehicleToShow.EnergySource).RemainingBatteryTime + Environment.NewLine);
                        break;
                    default:
                        break;
                }

                switch (vehicleType)
                {
                    case VehicleCreator.eVehicleType.Car:
                    case VehicleCreator.eVehicleType.ElectricCar:
                        outputString.Append(" + Vehicle color: " + ((Car)vehicleToShow).Color.ToString() + Environment.NewLine);
                        outputString.Append(" + Number of doors: " + ((Car)vehicleToShow).Doors + Environment.NewLine);
                        break;
                    case VehicleCreator.eVehicleType.Motorcycle:
                    case VehicleCreator.eVehicleType.ElectricMotorcycle:
                        outputString.Append(" + License type: " + ((Motorcycle)vehicleToShow).LicenseType + Environment.NewLine);
                        outputString.Append(" + Engine capacity: " + ((Motorcycle)vehicleToShow).EngineCapacity + Environment.NewLine);
                        break;
                    case VehicleCreator.eVehicleType.Truck:
                        outputString.Append(" + Contains dangerous substances? ");
                        if(((Truck)vehicleToShow).ContainDangerousSubstances == true)
                        {
                            outputString.Append("Yes" + Environment.NewLine);
                        }
                        else
                        {
                            outputString.Append("No" + Environment.NewLine);
                        }
                        outputString.Append(" + Cargo volume: " + ((Truck)vehicleToShow).CargoVolume + Environment.NewLine);
                        break;
                    default:
                        break;
                }

                outputString.Append(" + Wheels data: ");

                for (int i = 0; i < vehicleToShow.Wheels.Count; i++)
                {
                    if (i != 0)
                    {
                        outputString.Append("                ");
                    }
                    outputString.Append((i + 1) + ") ");
                    outputString.Append("Manufacturer: " + vehicleToShow.Wheels[i].Manufacturer + ", ");
                    outputString.Append("Max air pressure: " + vehicleToShow.Wheels[i].MaxAirPressure + ", ");
                    outputString.Append("Current air pressure: " + vehicleToShow.Wheels[i].CurrentAirPressure);
                    outputString.Append(Environment.NewLine);
                }

                outputString.Append("**************************************************************************" + Environment.NewLine);
            }
            catch (KeyNotFoundException)
            {
                outputString.Append(string.Format("There is no vehicle with the license number: " + licenseNumber + " inthe garage"));
            }

            Console.WriteLine(outputString);
        }

        private static VehicleInputData getVehicleDataFromUser()
        {
            VehicleInputData o_VehicleData = new VehicleInputData();

            getVehicleLicenseNumberFromUser(out o_VehicleData.m_LicenseNumber);
            getVehicleTypeFromUser(out o_VehicleData.m_VehicleType);
            getVehicleModelNameFromUser(out o_VehicleData.m_ModelName);
            getVehicleSpecificDataFromUserByType(o_VehicleData.m_VehicleType, o_VehicleData);
            getWheelsDataFromUser(o_VehicleData.m_VehicleType,
                                  out o_VehicleData.m_WheelsManufacturer,
                                  out o_VehicleData.m_CurrentAirPressure);
            return o_VehicleData;
        }

        private static void getVehicleSpecificDataFromUserByType(VehicleCreator.eVehicleType i_VehicleType,
                                                                 VehicleInputData o_VehicleData)
        {
            switch (i_VehicleType)
            {
                case VehicleCreator.eVehicleType.Car:
                case VehicleCreator.eVehicleType.ElectricCar:
                    getVehicleColorFromUser(out o_VehicleData.m_Color);
                    getVehicleNumberOfDoorsFromUser(out o_VehicleData.m_Doors);
                    break;
                case VehicleCreator.eVehicleType.Motorcycle:
                case VehicleCreator.eVehicleType.ElectricMotorcycle:
                    getVehicleLicenseTypeFromUser(out o_VehicleData.m_LicenseType);
                    getVehicleEngineCapacityFromUser(out o_VehicleData.m_EngineCapacity);
                    break;
                case VehicleCreator.eVehicleType.Truck:
                    getVehicleDangerousSubstancesDataFromUser(out o_VehicleData.m_ContainDangerousSubstances);
                    getVehicleCargoVolumeFromUser(out o_VehicleData.m_CargoVolume);
                    break;
                default:
                    break;
            }

            switch (i_VehicleType)
            {
                case VehicleCreator.eVehicleType.Car:
                    getFuelCurrentCapacityFromUser(out o_VehicleData.m_CurrentFuelCapacity, Car.sr_MaxFuelCapacity);
                    break;
                case VehicleCreator.eVehicleType.Motorcycle:
                    getFuelCurrentCapacityFromUser(out o_VehicleData.m_CurrentFuelCapacity, Motorcycle.sr_MaxFuelCapacity);
                    break;
                case VehicleCreator.eVehicleType.Truck:
                    getFuelCurrentCapacityFromUser(out o_VehicleData.m_CurrentFuelCapacity, Truck.sr_MaxFuelCapacity);
                    break;
                case VehicleCreator.eVehicleType.ElectricCar:
                    getVehicleBatteryDataFromUser(out o_VehicleData.m_RemainingBatteryTime, Car.sr_MaxBatteryTime);
                    break;
                case VehicleCreator.eVehicleType.ElectricMotorcycle:
                    getVehicleBatteryDataFromUser(out o_VehicleData.m_RemainingBatteryTime, Motorcycle.sr_MaxBatteryTime);
                    break;
                default:
                    break;
            }
        }

        private static void getOwnerNameFromUser(out string o_OwnerName)
        {
            string stringInput = string.Empty;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's owner name:" + Environment.NewLine);
            userPrompt.Append(" ---------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = getNameStringFromUser(out stringInput);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The name's length should be " + ex.MinValue + " to " + ex.MaxValue + " chars");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Error: The name can't be empty");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: The name should contain only letters and spaces");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);

            o_OwnerName = stringInput;
        }

        private static void getOwnerPhoneNumberFromUser(out string o_OwnerPhoneNumber)
        {
            string phoneInput = string.Empty;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter owner's phone number:" + Environment.NewLine);
            userPrompt.Append(" ---------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = getValidPhoneNumberFromUser(out phoneInput);
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Error: The phone number's length should be 10 digits");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Error: The phone number can't be empty");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Only digits allowed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);

            o_OwnerPhoneNumber = phoneInput;
        }

        private static void getVehicleTypeFromUser(out VehicleCreator.eVehicleType o_VehicleType)
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
                    validInput = getValidIntFromUserInRange(out userChoice, 1, 5);
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

            o_VehicleType = (VehicleCreator.eVehicleType)userChoice;
        }

        

        private static void getVehicleLicenseTypeFromUser(out Motorcycle.eLicenseType o_LicenseType)
        {
            int userChoice = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose your vehicle's license type:" + Environment.NewLine);
            userPrompt.Append("  1) A" + Environment.NewLine);
            userPrompt.Append("  2) A1" + Environment.NewLine);
            userPrompt.Append("  3) A2" + Environment.NewLine);
            userPrompt.Append("  4) B" + Environment.NewLine);
            userPrompt.Append(" ------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = getValidIntFromUserInRange(out userChoice, 1, 4);
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

            o_LicenseType = (Motorcycle.eLicenseType)userChoice;
        }

        private static void getVehicleColorFromUser(out Car.eCarColor o_VehicleColor)
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
                    validInput = getValidIntFromUserInRange(out userChoice, 1, 4);
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

            o_VehicleColor = (Car.eCarColor)userChoice;
        }

        private static void getVehicleNumberOfDoorsFromUser(out Car.eNumOfDoors o_NumOfDoors)
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
                    validInput = getValidIntFromUserInRange(out userChoice, 2, 5);
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

            o_NumOfDoors = (Car.eNumOfDoors)userChoice;
        }

        private static void getVehicleStatusFromUser(out VehicleCard.eVehicleStatus o_VehicleStatus)
        {
            int userChoice = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose vehicle status:"             + Environment.NewLine);
            userPrompt.Append("  1) In service"                                + Environment.NewLine);
            userPrompt.Append("  2) Fixed"                                     + Environment.NewLine);
            userPrompt.Append("  3) Paid"                                      + Environment.NewLine);
            userPrompt.Append(" ---------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = getValidIntFromUserInRange(out userChoice, 1, 3);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The choice should be between " + ex.MinValue + " to " + ex.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            o_VehicleStatus = (VehicleCard.eVehicleStatus)userChoice;
        }

        private static void getVehicleDangerousSubstancesDataFromUser(out bool o_ContainsDangerousSubstances)
        {
            int userChoice = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" -----------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Does your vehicle contain dangerous substances:" + Environment.NewLine);
            userPrompt.Append("  1) Yes" + Environment.NewLine);
            userPrompt.Append("  2) No" +  Environment.NewLine);
            userPrompt.Append(" -----------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = getValidIntFromUserInRange(out userChoice, 1, 2);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please choose 1 for yes and 2 for no.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The choice should be " + ex.MinValue + " - " + ex.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            }

            o_ContainsDangerousSubstances = (userChoice == 1);
        }

        private static void getVehicleModelNameFromUser(out string o_ModelName)
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
                    validInput = getStringInLengthRangeFromUser(out stringInput, 1, 100);
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

        private static void getVehicleLicenseNumberFromUser(out string o_LicenseNumber)
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
                    validInput = getStringInLengthRangeFromUser(out stringInput, 7, 8);
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

        private static void getWheelsDataFromUser(VehicleCreator.eVehicleType i_VehicleType,
                                                  out string o_Manufacturer,
                                                  out float o_CurrentAirPressure)
        {
            float pressureInput = 0;
            float maxAirPressure = 0;
            string stringInput = string.Empty;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            switch(i_VehicleType)
            {
                case VehicleCreator.eVehicleType.Car:
                case VehicleCreator.eVehicleType.ElectricCar:
                    maxAirPressure = Car.sr_MaxAirPressure;
                    break;
                case VehicleCreator.eVehicleType.Motorcycle:
                case VehicleCreator.eVehicleType.ElectricMotorcycle:
                    maxAirPressure = Motorcycle.sr_MaxAirPressure;
                    break;
                case VehicleCreator.eVehicleType.Truck:
                    maxAirPressure = Truck.sr_MaxAirPressure;
                    break;
                default:
                    break;
            }

            userPrompt.Append(" ---------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter wheels manufacturer name:" + Environment.NewLine);
            userPrompt.Append(" ---------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = getStringInLengthRangeFromUser(out stringInput, 1, 100);
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
                    validInput = getValidFloatFromUserInRange(out pressureInput, 0, maxAirPressure);
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

        private static void getFuelTypeFromUser(out Fuel.eFuelType o_FuelType)
        {
            bool validInput = false;
            int userChoice = 0;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ---------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Please choose your vehicle's fuel type:" + Environment.NewLine);
            userPrompt.Append("  1) Octan95" + Environment.NewLine);
            userPrompt.Append("  2) Octan96" + Environment.NewLine);
            userPrompt.Append("  3) Octan98" + Environment.NewLine);
            userPrompt.Append("  4) Soler" + Environment.NewLine);
            userPrompt.Append(" ---------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            while (validInput == false)
            {
                try
                {
                    validInput = getValidIntFromUserInRange(out userChoice, 1, 4);
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

            o_FuelType = (Fuel.eFuelType)userChoice;
        }

        private static void getFuelToAddFromUser(out float o_FuelToAdd)
        {
            float capacityInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter how much fuel you want to add:" + Environment.NewLine);
            userPrompt.Append(" ------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out capacityInput, 0, float.MaxValue);
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
            o_FuelToAdd = capacityInput;
        }

        private static void getMaxFuelCapacityFromUser(out float o_MaxFuelCapacity)
        {
            float capacityInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" ----------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's max fuel capacity:" + Environment.NewLine);
            userPrompt.Append(" ----------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out capacityInput, 0, float.MaxValue);
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
        }

        private static void getFuelCurrentCapacityFromUser(out float o_CurrentFuelCapacity,
                                                           float i_MaxFuelCapacity)
        {
            float capacityInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

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
                    validInput = getValidFloatFromUserInRange(out capacityInput, 0, i_MaxFuelCapacity);
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



        private static void getBatteryTimeToAddFromUser(out float o_TimeToAdd)
        {
            float timeInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" -----------------------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter how much time you want to add to the battery (hours):" + Environment.NewLine);
            userPrompt.Append(" -----------------------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out timeInput, 0, float.MaxValue);
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
            o_TimeToAdd = timeInput;
        }

        private static void getVehicleBatteryDataFromUser(out float o_RemainingBatteryTime,
                                                          float i_MaxBatteryTime)
        {
            float timeInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();
            
            userPrompt.Append(" -----------------------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter remaining vehicle's battery time (hours):" + Environment.NewLine);
            userPrompt.Append(" -----------------------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            do
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out timeInput, 0, i_MaxBatteryTime);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a floating point number");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: The time should be a positive number," + Environment.NewLine +
                                      "       and smaller then the maximum time (" + ex.MaxValue + ")");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);

            o_RemainingBatteryTime = timeInput;
        }

        private static void getVehicleEngineCapacityFromUser(out int o_EngineCapacity)
        {
            int capacityInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" --------------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's engine capacity:" + Environment.NewLine);
            userPrompt.Append(" --------------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    validInput = getValidIntFromUserInRange(out capacityInput, 0, Int32.MaxValue);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a natural number");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine("Error: Please enter a positive number, not bigger than " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unknown error occured: " + Environment.NewLine + ex.Message + Environment.NewLine);
                }
            } while (validInput == false);

            o_EngineCapacity = capacityInput;
        }

        private static void getVehicleCargoVolumeFromUser(out float o_CargoVolume)
        {
            float volumeInput = 0;
            bool validInput = false;
            StringBuilder userPrompt = new StringBuilder();

            userPrompt.Append(" -----------------------------" + Environment.NewLine);
            userPrompt.Append(" Enter vehicle's cargo volume:" + Environment.NewLine);
            userPrompt.Append(" -----------------------------" + Environment.NewLine);

            Console.Write(userPrompt + Environment.NewLine);

            validInput = false;
            do
            {
                try
                {
                    validInput = getValidFloatFromUserInRange(out volumeInput, 0, float.MaxValue);
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

            o_CargoVolume = volumeInput;
        }

        private static bool getValidIntFromUserInRange(out int o_UserInput, int i_MinValue, int i_MaxValue)
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

        private static bool getValidFloatFromUserInRange(out float o_UserInput, float i_MinValue, float i_MaxValue)
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
        private static bool getStringInLengthRangeFromUser(out string o_UserInput, int i_MinLength, int i_MaxLength)
        {
            string userInput;
            userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                throw new NullReferenceException();
            }
            else if(userInput.Length < i_MinLength || userInput.Length > i_MaxLength)
            {
                throw new ValueOutOfRangeException(new Exception(), i_MinLength, i_MaxLength);
            }

            o_UserInput = userInput;
            return true;
        }

        private static bool getNameStringFromUser(out string o_UserInput)
        {
            string userInput;
            userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                throw new NullReferenceException();
            }
            else if (userInput.Length > 200)
            {
                throw new ValueOutOfRangeException(new Exception(), 0, 200);
            }
            foreach (char c in userInput)
            {
                if((c == ' ' || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')) == false)
                {
                    throw new FormatException();
                }
            }

            o_UserInput = userInput;
            return true;
        }

        private static bool getValidPhoneNumberFromUser(out string o_PhoneNumber)
        {
            string userInput;
            userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                throw new NullReferenceException();
            }
            else if (userInput.Length != 10)
            {
                throw new ValueOutOfRangeException(new Exception(), 10, 10);
            }

            foreach (char c in userInput)
            {
                if (c < '0' || c > '9')
                    throw new FormatException();
            }

            o_PhoneNumber = userInput;
            return true;
        }
    }
}
