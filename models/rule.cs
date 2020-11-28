using System.Collections.Generic;

namespace iac.models
{
    //Classe base que modela uma regra
    //É extendida em todas as outras regras criadas para evitar repetição de código
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