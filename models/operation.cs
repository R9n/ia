namespace iac.models
{
    public class Operation
    {
        private ruleTypes.RulesTypes _rule;
        private int _origin;
        private int _destiny;
        private bool _hasTried;

        public Operation(ruleTypes.RulesTypes ruleType, int origin, int destiny, bool hasTried=false)
        {
            setRule(ruleType);
            setOrigin(origin);
            setDestiny(destiny);
            setHasTried(hasTried);
        }
        
        public void setRule(ruleTypes.RulesTypes ruleType)
        {
            _rule = ruleType;
        }

        public void setOrigin(int id)
        {
            _origin = id;
        }

        public void setDestiny(int id)
        {
            _destiny = id;
        }

        public void setHasTried(bool value)
        {
            _hasTried = value;
        }

        public ruleTypes.RulesTypes getRuleType()
        {
            return _rule;
        }

        public int getOrigin()
        {
            return _origin;
        }

        public int getDestiny()
        {
            return _destiny;
        }

        public bool getHasTried()
        {
            return _hasTried;
        }
        
        
    }
}