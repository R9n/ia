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
            Pitcher pitcherE = new Pitcher();
            List<Pitcher> solutionPitchers = new List<Pitcher>();

            pitcherC.setMaxVolume(2);
            pitcherC.setCurrentVolume(2);
            pitcherC.setName("A");

            pitcherD.setMaxVolume(-1);
            pitcherD.setCurrentVolume(1);
            pitcherD.setName("B");
            
            pitcherE.setMaxVolume(-1);
            pitcherE.setCurrentVolume(3);
            pitcherE.setName("C");
            

            solutionPitchers.Add(pitcherC);
            solutionPitchers.Add(pitcherD);
            solutionPitchers.Add(pitcherE);
        
            
            solution.setPitchers(solutionPitchers);


            //initial state
            Node initialState = new Node();
            Pitcher pitcherA = new Pitcher();
            Pitcher pitcherB = new Pitcher();
            Pitcher pitcherF = new Pitcher();
            
            pitcherB.setCurrentVolume(0);
            pitcherB.setMaxVolume(3);
            pitcherB.setName("B");
            
            pitcherA.setName("A");
            pitcherA.setMaxVolume(4);
            pitcherA.setCurrentVolume(0);
            
            pitcherF.setName("C");
            pitcherF.setMaxVolume(5);
            pitcherF.setCurrentVolume(0);
            
            
            List<Pitcher> pitchers = new List<Pitcher>();
            
            pitchers.Add(pitcherA);
            pitchers.Add(pitcherB);
            pitchers.Add(pitcherF);
         
            
            initialState.setPitchers(pitchers);
            initialState.setIsInitialState(true);
            initialState.setFather(null);
            
            initialState.setOperation("Estado inicial");


            Backtracking backtracking = new Backtracking(initialState, solution);
            backtracking.initalizeAlgorithmRules();
            
            DepthSearch depthSearch = new DepthSearch(initialState, solution);
            depthSearch.initalizeAlgorithmRules();
            
            depthSearch.findSolution();

            foreach (Node node in depthSearch.getSolutionFound())
            {
                Console.WriteLine(node.getOperation());
            }
        }
    }
}