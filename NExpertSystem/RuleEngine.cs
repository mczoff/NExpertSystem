using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpertSystem
{
    public class RuleEngine
    {
        public ICollection<BaseClause> Facts { get; set; }

        public RuleEngine()
        {
            Facts = new Collection<BaseClause>();
        }

        public bool IsNotFact(BaseClause clause)
        {
            foreach (BaseClause fact in Facts)
            {
                if (fact.Intersect(clause) == IntersectionType.MutuallyExclude)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFact(BaseClause clause)
        {
            foreach (BaseClause fact in Facts)
            {
                if (fact.Intersect(clause) == IntersectionType.Include)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
