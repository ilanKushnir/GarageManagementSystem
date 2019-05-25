using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutOfRangeException(
                                        Exception i_InnerException,
                                        float i_MinValue, 
                                        float i_MaxValue) 
                                        : base(
                                              string.Format("Value is out of range, range should be between {0} - {1}",i_MinValue,i_MaxValue),
                                              i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
