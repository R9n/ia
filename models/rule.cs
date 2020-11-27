using System.Collections.Generic;

namespace iac.models
{
    public abstract class Rule
    {
        private ruleTypes.RulesTypes _ruleTypes;
        public int weight = 1;
        
        public void setRuleType(ruleTypes.RulesTypes  ruleType)
        {
            _ruleTypes = ruleType;
        }
        public ruleTypes.RulesTypes getRuleType()
        {
            return  _ruleTypes;
        }
        
        public  abstract  List<Operation> getOperationSet(Node node);
        public  abstract Node applyRule(Node node,Operation operation);
    }
}