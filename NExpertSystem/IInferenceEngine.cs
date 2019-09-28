using System.Collections.Generic;

namespace NExpertSystem
{
    public interface IInferenceEngine
    {
        BaseClause Infer(string goal_rulename, ICollection<BaseClause> unproved_conditions);
    }
}
