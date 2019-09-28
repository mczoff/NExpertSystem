using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpertSystem
{
    public class RuleInferenceEngine : IInferenceEngine
    {
        private RuleEngine FactsEngine { get; }
        public Collection<Rule> Rules { get; }

        public RuleInferenceEngine()
        {
            FactsEngine = new RuleEngine();
            Rules = new Collection<Rule>();
        }

        public void AddFact(BaseClause baseClause)
        {
            FactsEngine.Facts.Add(baseClause);
        }

        public BaseClause Infer(string goal_rulename, ICollection<BaseClause> unproved_conditions)
        {
            BaseClause conclusion = default;

            foreach (Rule rule in Rules)
            {
                foreach (BaseClause antecedent in rule.Antecedents)
                {
                    if (FactsEngine.IsFact(antecedent))
                    {
                        return rule.Consequent;
                    }

                    break;
                }
            }

            return null;
        }
    }
}
