using System;
using System.Collections.Generic;
using iac.models;

namespace iac
{
    public class First_applicable
    {
        public Operation getNextOperation(List<Operation> operations)
        {
            foreach (Operation operation in operations)
            {   
                if (operation.getHasTried()==false)
                {
                    return operation;
                }
            }

            return null;
        }
        
        public Operation getNextOperationWithWeight(List<Operation> operations)
        {
            int weight = 0;
            int aux = 0;
            Operation auxOperation = null;
            foreach (Operation operation in operations)
            {   
                if (operation.getHasTried()==false)
                {
                    switch (operation.getRuleType())
                    {
                        case ruleTypes.RulesTypes.fill:
                            aux = 1;
                            break;
                        case ruleTypes.RulesTypes.drainOut:
                            aux = 1;
                            break;
                        case ruleTypes.RulesTypes.transfer:
                            aux = 1;
                            break;
                        default:
                            aux = 1;
                            break;
                    }
                    if (aux > weight)
                    {
                        weight = aux;
                        auxOperation = operation;
                    }
                }

            }
            return auxOperation;

        }
 
    }
    
    
}