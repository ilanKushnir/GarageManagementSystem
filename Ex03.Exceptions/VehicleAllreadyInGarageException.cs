using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Exceptions
{
    public class VehicleAllreadyInGarageException : Exception
    {
        private string m_LicenseNumber;
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public VehicleAllreadyInGarageException(Exception i_InnerException,
                                                string i_LicenseNumber)
                                                : base(string.Format("Vehicle with number license {0} allready exists in garage. Status changed to InService", i_LicenseNumber), 
                                                      i_InnerException)
        {
            m_LicenseNumber = i_LicenseNumber;
        }
    }
}
