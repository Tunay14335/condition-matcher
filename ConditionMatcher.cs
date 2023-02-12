using System.Collections;

namespace ConditionMatch{
    
    public class ConditionMatcher
    {
        private readonly int ConditionCount = 0;
        public Dictionary<Condition, Action> conditionMap;

        public ConditionMatcher(Dictionary<Condition, Action> conditionMap)
        {
            this.conditionMap = conditionMap;
            var e = conditionMap.GetEnumerator();
            e.MoveNext();
            ConditionCount = e.Current.Key.Instructor.BitCount;
        }

        public void Execute(BitInstructor bitInstructor)
        {
            if(bitInstructor.BitCount != ConditionCount)
            {
                throw new Exception($"Mismatching condition count with `bitInstructor`");
            }
            foreach(KeyValuePair<Condition, Action> condition in conditionMap)
            {
                if(condition.Key.Instructor.BitCount != ConditionCount)
                {
                    throw new Exception($"Mismatching condition count at \n => \"{condition.Key.Name}\"");
                }
                if (condition.Key.Instructor.Equals(bitInstructor))
                {
                    condition.Value?.Invoke();
                    return;
                }
            }
        }
        public void Execute(params bool[] bitArray)
        {
            this.Execute(bitArray);
        }
        public void Execute(BitArray bitArray)
        {
            bool[] boolArray = new bool[bitArray.Count];
            bitArray.CopyTo(boolArray,0);
            this.Execute(boolArray);
        }

    }
}