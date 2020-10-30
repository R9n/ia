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
    }
}