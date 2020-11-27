using System;
using System.Collections.Generic;
using iac.models;

namespace iac.heuristics
{
    public class ClosestToSolutionHeuristic
    {
        public int getHeuriscValor(Node node, Node solution)
        {
            List<Pitcher> nodePitchers=node.getPitchers();
            List<Pitcher> solutionPitchers = solution.getPitchers();
            int differenceAcumulated = 0;
            
            for (int i = 0; i < nodePitchers.Count; i++)
            { 
                if (solutionPitchers[i].getMaxVolume() > -1)
                {
                    differenceAcumulated += solutionPitchers[i].getCurrentVolume() - nodePitchers[i].getCurrentVolume();
                }
            }
            return Math.Abs(differenceAcumulated);
        }
        
    }
}