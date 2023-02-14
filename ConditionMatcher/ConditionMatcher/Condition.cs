using System;

namespace ConditionMatch{

    public class Condition
    {
        public Condition(string name, HashInstructor instructor)
        {
            this.Name = name;
            this.Instructor = instructor;
        }
        public override string ToString() => $"{Name} : {Instructor.Value}";
        
        public string Name {get; set;}
        public HashInstructor Instructor {get; set;}
        public int ConditionID => Instructor.Value;
    }

}