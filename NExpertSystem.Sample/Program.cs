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

            Rule rule = new Rule("seo_hard_freelancer");
            rule.AddAntecedents(new GreaterEqualClause("experience", "4"));
            rule.AddAntecedents(new IsClause("type", "SEO"));
            rule.Consequent = new BaseClause("freelancer", "Oleg");
            ruleInferenceEngine.Rules.Add(rule);

            rule = new Rule("seo_easy_freelancer");
            rule.AddAntecedents(new LessClause("experience", "4"));
            rule.AddAntecedents(new IsClause("type", "SEO"));
            rule.Consequent = new BaseClause("freelancer", "Ivan");

            ruleInferenceEngine.Rules.Add(rule);

            List<BaseClause> unproved_conditions = new List<BaseClause>();

            Console.WriteLine("Write freencer experience:");
            ruleInferenceEngine.AddFact(new IsClause("experience", Console.ReadLine()));

            BaseClause conclusion = ruleInferenceEngine.Infer("freelancer", unproved_conditions);

            Console.WriteLine("Conclusion: " + conclusion);
        }
    }
}
