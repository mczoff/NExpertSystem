using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NExpertSystem.Sample
{
    static class Program
    {
        static void Main(string[] args)
        {
            RuleInferenceEngine ruleInferenceEngine = new RuleInferenceEngine();

            Rule rule = new Rule("hard_freelancer");
            rule.AddAntecedents(new GreaterEqualClause("experience", "4"));
            rule.Consequent = new BaseClause("freelancer", "easy_freelancer");
            ruleInferenceEngine.Rules.Add(rule);

            rule = new Rule("easy_freelancer");
            rule.AddAntecedents(new IsClause("experience", "1"));
            rule.Consequent = new BaseClause("freelancer", "hard_freelancer");
            ruleInferenceEngine.Rules.Add(rule);

            List<BaseClause> unproved_conditions = new List<BaseClause>();

            ruleInferenceEngine.AddFact(new IsClause("experience", "5"));

            BaseClause conclusion = ruleInferenceEngine.Infer("freelancer", unproved_conditions);

            Console.WriteLine("Conclusion: " + conclusion);
        }
    }
}
