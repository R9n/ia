using System.Collections.Generic;

namespace iac.models
{
    public abstract class Rule
    {
        public int pitcherToApplyId;
        private ruleTypes.RulesTypes _ruleTypes;
 
        public void setRuleType(ruleTypes.RulesTypes  ruleType)
        {
            _ruleTypes = ruleType;
        }
        public ruleTypes.RulesTypes getRuleType()
        {
            return  _ruleTypes;
        }
        public void setPitcherToApplyId(int id)
        {
            pitcherToApplyId = id;
        }
        public int getPitcherToApplyId()
        {
            return  pitcherToApplyId;
        }
        
        
        
        public  abstract  List<Operation> getOperationSet(Node node);
        public  abstract Node applyRule(Node node,Operation operation);

        
    }
}