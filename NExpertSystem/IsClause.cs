using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpertSystem
{
    public class IsClause : BaseClause
    {
        public IsClause(string variable, string value)
            : base(variable, value)
        {

        }

        public override IntersectionType Intersect(BaseClause clause)
        {
            if(clause.Condition == ConditionType.Equal)
            {
                if (clause.Value == Value)
                {
                    return IntersectionType.Include;
                }
                else
                {
                    return IntersectionType.MutuallyExclude;
                }
            }

            //Then check numeric type
            if(double.TryParse(Value, out double currentClauseValue) && double.TryParse(clause.Value, out double innerClauseValue))
            {
                if(clause.Condition == ConditionType.Less)
                {
                    if(currentClauseValue < innerClauseValue)
                    {
                        return IntersectionType.Include;
                    }
                    else
                    {
                        return IntersectionType.MutuallyExclude;
                    }
                }

                if (clause.Condition == ConditionType.LessOrEqual)
                {
                    if (currentClauseValue <= innerClauseValue)
                    {
                        return IntersectionType.Include;
                    }
                    else
                    {
                        return IntersectionType.MutuallyExclude;
                    }
                }

                if (clause.Condition == ConditionType.Greater)
                {
                    if (currentClauseValue > innerClauseValue)
                    {
                        return IntersectionType.Include;
                    }
                    else
                    {
                        return IntersectionType.MutuallyExclude;
                    }
                }

                if (clause.Condition == ConditionType.GreaterOrEqual)
                {
                    if (currentClauseValue >= innerClauseValue)
                    {
                        return IntersectionType.Include;
                    }
                    else
                    {
                        return IntersectionType.MutuallyExclude;
                    }
                }
            }

            return IntersectionType.None;
        }
    }
}
