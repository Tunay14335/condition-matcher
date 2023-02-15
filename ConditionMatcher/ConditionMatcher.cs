using System;
using System.Collections;
using System.Collections.Generic;

namespace ConditionMatch{
    
    public class ConditionMatcher
    {
        private readonly int ConditionCount = 0;
        private ConditionMap conditionMap;
        
        public ConditionMatcher(ConditionMap conditionMap)
        {
            this.conditionMap = conditionMap;
            var e = conditionMap.GetEnumerator();
            e.MoveNext();
            ConditionCount = e.Current.Key.Instructor.ParameterCount;
        }

        private void Executor(object[] parameterArray)
        {
            HashInstructor hashInstructor = new HashInstructor(parameterArray);

            if(hashInstructor.ParameterCount != ConditionCount)
            {
                throw new Exception($"Mismatching condition count with `hashInstructor`");
            }
            foreach(KeyValuePair<Condition, Action<object[]>> condition in conditionMap)
            {
                HashInstructor currentInstructor = condition.Key.Instructor;
                if(currentInstructor.ParameterCount != ConditionCount)
                {
                    throw new Exception($"Mismatching condition count at \n => \"{condition.Key.Name}\"");
                }
                if(currentInstructor.ignoredIndexes.Count > 0)
                {
                    HashInstructor reval = HashInstructor.Revaluate(parameterArray , currentInstructor.ignoredIndexes);
                    if(currentInstructor.Equals(reval))
                    {
                        condition.Value?.Invoke(parameterArray);
                        continue;
                    }
                }
                if(condition.Key.Instructor.Equals(hashInstructor))
                {
                    condition.Value?.Invoke(parameterArray);
                    continue;
                }
            }
        }
        public void Execute(params object[] parameterArray)
        {
            this.Executor(parameterArray);
        }

    }
}