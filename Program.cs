using System;
using System.Collections.Generic;
using iac.algorithms;
using iac.models;

namespace iac
{
    class Program
    {
        static void Main(string[] args)
        {
            //solução  
            Node solution = new Node();
            Pitcher pitcherC = new Pitcher();
            Pitcher pitcherD = new Pitcher();
            List<Pitcher> solutionPitchers = new List<Pitcher>();

            pitcherC.setMaxVolume(1);
            pitcherC.setCurrentVolume(2);
            pitcherC.setName("A");

            pitcherD.setMaxVolume(-1);
            pitcherD.setCurrentVolume(1);
            pitcherD.setName("B");
            

            solutionPitchers.Add(pitcherC);
            solutionPitchers.Add(pitcherD);
        
            
            solution.setPitchers(solutionPitchers);


            //initial state
            Node initialState = new Node();
            Pitcher pitcherA = new Pitcher();
            Pitcher pitcherB = new Pitcher();
            
            pitcherB.setCurrentVolume(0);
            pitcherB.setMaxVolume(3);
            pitcherB.setName("B");
            
            pitcherA.setName("A");
            pitcherA.setMaxVolume(4);
            pitcherA.setCurrentVolume(0);
            
            
            List<Pitcher> pitchers = new List<Pitcher>();
            
            pitchers.Add(pitcherA);
            pitchers.Add(pitcherB);
         
            
            initialState.setPitchers(pitchers);
            initialState.setIsInitialState(true);
            initialState.setFather(null);
            
            initialState.setOperation("Estado inicial");


            Backtracking backtracking = new Backtracking(initialState, solution);
            backtracking.initalizeAlgorithmRules();
            
            backtracking.findSolution();

            foreach (Node node in backtracking.getSolutionFound())
            {
                Console.WriteLine(node.getOperation());
            }
        }
    }
}