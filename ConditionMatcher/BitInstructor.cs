using System;
using System.Linq;

namespace ConditionMatch
{
    public class BitInstructor : IEquatable<BitInstructor>
    {
        public BitInstructor(params bool[] bitArray)
        {
            BitCount = bitArray.Count<bool>();
            if(BitCount > 32)
            {
                throw new Exception("`bitArray` length must be lower than 32");
            }
            m_value = 0;
            m_value |= bitArray[0] ? 1 : 0;
            for(int i = 1 ; i < bitArray.Length ; i++)
            {
                m_value <<= 1;
                m_value |= bitArray[i] ? 1 : 0;
            }
        }
        public bool Equals(BitInstructor? obj)
        {
            return obj != null && obj.Value == this.Value;
        }

        public override string ToString() => m_value.ToString();

        public int BitCount {get; private set;}

        public int Value => m_value;
        private int m_value;

    }
}