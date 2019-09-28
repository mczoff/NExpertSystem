using System;

namespace NExpertSystem
{
    public class BaseClause
    {
        public string Variable { get; }
        public string Value { get; }
        public ConditionType Condition { get; }

        public BaseClause(string variable, string value)
            : this(variable, value, ConditionType.Equal)
        {
        }

        public BaseClause(string variable, string value, ConditionType condition)
        {
            Variable = variable;
            Value = value;
            Condition = condition;
        }

        public virtual IntersectionType Intersect(BaseClause clause)
        {
            throw new NotSupportedException();
        }

        public override string ToString()
            => $"{Variable} - {Condition.ToString()} - {Value}";
    }
}
