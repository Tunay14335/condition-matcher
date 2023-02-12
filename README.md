# Condition Matcher

Makes condition map with initializer structures and execute matcher for invoke their action. Also creates id from bitset with `BitInstructor` for condition arrays.

<br>

### Example
```csharp
using ConditionMatch;

ConditionMatcher conditionMatcher = new ConditionMatcher(
    new Dictionary<Condition, Action>(){
        {
            new Condition(
                name: "example condition",
                instructor: new BitInstructor(true,true,true)
            ),
            () => {
                //code here
            }
        },
        {
            new Condition(
                name: "other condition",
                instructor: new BitInstructor(false,false,true)
            ),
            () => {
                //code here
            }
        },
    });

//Load current states as new BitInstructor
conditionMatcher.Execute(new BitInstructor(true , true , true));

```
