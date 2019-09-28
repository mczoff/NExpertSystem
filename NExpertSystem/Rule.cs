using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NExpertSystem
{
    public class Rule
    {
        public BaseClause Consequent { get; set; }
        public IEnumerable<BaseClause> Antecedents { get; }
        public bool Fired { get; }
        public string Name { get; }
        public int Index { get; }

        public Rule(string name)
        {
            Name = name;

            Antecedents = new Collection<BaseClause>();
        }

        public void AddAntecedents(BaseClause clause)
        {
            (Antecedents as Collection<BaseClause>).Add(clause);
        }
    }
}
