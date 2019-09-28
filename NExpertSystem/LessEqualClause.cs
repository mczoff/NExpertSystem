namespace NExpertSystem
{
    public class LessEqualClause : BaseClause
    {
        public LessEqualClause(string variable, string value)
           : base(variable, value, ConditionType.LessOrEqual)
        {
        }

        public override IntersectionType Intersect(BaseClause clause)
        {
            //Then check numeric type
            if (double.TryParse(Value, out double currentClauseValue) && double.TryParse(clause.Value, out double innerClauseValue))
            {
                if (clause.Condition == ConditionType.Less)
                {
                    if (currentClauseValue >= innerClauseValue)
                    {
                        return IntersectionType.Include;
                    }
                    else
                    {
                        return IntersectionType.None;
                    }
                }

                if (clause.Condition == ConditionType.LessOrEqual)
                {
                    if (currentClauseValue >= innerClauseValue)
                    {
                        return IntersectionType.Include;
                    }
                    else
                    {
                        return IntersectionType.None;
                    }
                }

                if (clause.Condition == ConditionType.Equal)
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


                if (clause.Condition == ConditionType.Greater)
                {
                    if (currentClauseValue < innerClauseValue)
                    {
                        return IntersectionType.MutuallyExclude;
                    }
                    else
                    {
                        return IntersectionType.None;
                    }
                }

                if (clause.Condition == ConditionType.GreaterOrEqual)
                {
                    if (currentClauseValue <= innerClauseValue)
                    {
                        return IntersectionType.MutuallyExclude;
                    }
                    else
                    {
                        return IntersectionType.None;
                    }
                }
            }

            return IntersectionType.None;
        }
    }
}
