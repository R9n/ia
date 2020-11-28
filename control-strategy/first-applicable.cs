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
                    return operation; // devolvo a primeira operação que ainda não foi tentada
                }
            }

            return null;
        }
        
        
        // essa função é utilizada na busca ordenada, considerando que todas as operações possuem pesos 1
        public Operation getNextOperationWithWeight(List<Operation> operations)
        {
            int weight = Int32.MaxValue;
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
                    if (aux < weight)
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