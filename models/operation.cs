namespace iac.models
{
    // Esta classe representa a operação que pode ser feita em um determinado nó
    // origem e destinos são os ids dos jarros de origem e destino
    
    public class Operation
    {
        private ruleTypes.RulesTypes _ruleType;
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
            _ruleType = ruleType;
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
            return _ruleType;
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