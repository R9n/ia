using System;
using System.Collections.Generic;
using System.Linq;

namespace iac.helpers
{
    public class Ids_handler
    {
        private List<int> _generatedIds = new List<int>();

        public int getNextId()
        {
            int nextId;
            if (_generatedIds.Count == 0)
            {
                nextId = 0;
            }
            else
            {
                nextId = _generatedIds.Last()+1;
            }
            _generatedIds.Add(nextId);
            return nextId;

        }
        
    }
}