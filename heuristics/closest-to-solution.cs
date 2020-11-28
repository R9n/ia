using System;
using System.Collections.Generic;
using iac.models;

namespace iac.heuristics
{
    //Classe da heurística
    // Para calcular o valor heurístico eu considero a diferença absuluta 
    // entre os jarros que importam da solução e os jarros correspondentes do estado atual passado
    // Quanto menor for essa diferença, mais perto da solução umi estado está
    
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
                    //diferença acumulada dos jarros que importam
                    // jarros que importam possuem volume máximo maior que -1
                    differenceAcumulated += solutionPitchers[i].getCurrentVolume() - nodePitchers[i].getCurrentVolume();
                }
            }
            return Math.Abs(differenceAcumulated);
        }
        
    }
}