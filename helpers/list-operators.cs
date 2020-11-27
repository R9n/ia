using System.Collections.Generic;
using iac.models;

namespace iac.helpers
{
    public static class List_operators
    {
        public  static void copyFromToMaintainingState(List<Pitcher> origin, List<Pitcher> destiny)
        {
            foreach (Pitcher pitcher in origin)
            {
               Pitcher newPitcher = new Pitcher(pitcher);
               newPitcher.setId(pitcher.getId());
               destiny.Add(newPitcher);
            }
            
        }

    }
}