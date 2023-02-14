using System;

namespace ConditionMatch{

    public class HashInstructor : IEquatable<HashInstructor>
    {
        
        public HashInstructor(params object[] objects)
        {
            ignoredIndexes = new List<uint>(objects.Length/2);
            int value = 0;
            for(uint i = 0 ; i < objects.Length ; i++)
            {
                if(objects[i].GetType() == typeof(ParameterMode))
                {
                    ignoredIndexes.Add(i);
                }
                value ^= objects[i].GetHashCode();
            }
            m_value = value;
        }

        public static HashInstructor Revaluate(object[] objects , List<uint> ignoredIndexes)
        {
            object[] current = new object[objects.Length];
            objects.CopyTo(current , 0);

            Type t_parameterMode = typeof(ParameterMode);

            for(uint i = 0 ; i < ignoredIndexes.Count ; i++)
            {
                current[ignoredIndexes[(int)i]] = ParameterMode.ANY;
            }
            return new HashInstructor(current);
        }
        public List<uint> ignoredIndexes {get; private set;}

        public int Value => m_value;
        private int m_value = 0;

        public bool Equals(HashInstructor? obj)
        {
            return obj != null && obj.Value == this.Value;
        }
        public override string ToString() => m_value.ToString();

        public int ParameterCount {get; private set;}
    }
    public enum ParameterMode
    {
        ANY
    }
}