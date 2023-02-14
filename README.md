# Condition Matcher

Makes condition map with initializer structures and execute matcher for invoke their action. Also creates id from hash with `HashInstructor` for condition arrays.

<br>

### Example
```csharp
using ConditionMatch;

ConditionMatcher conditionMatcher = new ConditionMatcher(
    new Dictionary<Condition, Action>(){
        {
            new Condition(
                name: "example condition",
                instructor: new HashInstructor(true,"example",3.14f)
            ),
            () => {
                //code here
            }
        },
        {
            new Condition(
                name: "other condition",
                instructor: new HashInstructor(false,"other",0.02f)
            ),
            () => {
                //code here
            }
        },
    });

//Load current states as new HashInstructor
conditionMatcher.Execute(true,"example",3.14f);

```

<br>
<br>

### ParameterMode.ANY


This mode ignore applied parameters. When executing matcher revaluate from parameterArray then creates an new HashInstructor and matching with current Instructor.

### Example

```csharp
using ConditionMatch;

ConditionMatcher conditionMatcher = new ConditionMatcher(
    new Dictionary<Condition, Action>(){
        {
            new Condition(
                name: "example condition",
                instructor: new HashInstructor(true,"example",ParameterMode.ANY)
            ),
            () => {
                //code here
            }
        },
        {
            new Condition(
                name: "other condition",
                instructor: new HashInstructor(false,"other",0.02f)
            ),
            () => {
                //code here
            }
        },
    });

//Load current states as new HashInstructor
conditionMatcher.Execute(true,"example",100f);

```

That expression works for `name: "example condition"`. Also, the executor runs the others if there are more possible conditions.