using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Exceptions
{
    public class WrongFuelException : Exception
    {
        private string m_WrongFuel;
        private string m_Fuel;

        public string WrongFuel
        {
            get { return m_WrongFuel; }
        }

        public string Fuel
        {
            get { return m_Fuel; }
        }

        public WrongFuelException(
                                    Exception i_InnerException, 
                                    string i_WrongFuel, 
                                    string i_Fuel) 
                                    : base(string.Format("Cannot Fuel vehicle using {0} instead of {1}", i_WrongFuel, i_Fuel) ,i_InnerException)
        {
            m_WrongFuel = i_WrongFuel;
            m_Fuel = i_Fuel;
        }

    }
}