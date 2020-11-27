using System;
using System.Collections.Generic;
using System.Linq;
using iac.helpers;
using iac.heuristics;
using iac.models;

namespace iac.algorithms
{
    public class GreedySearch:Algorithm
    {
        
        public GreedySearch(Node state, Node solution)
        {
            setInitialState(state);
            setDesiredSolution(solution);
        }
        private Node _currentNode;
        private  List<Node> closedNodes = new List<Node>();
        List<Node> openNodes= new List<Node>();
        private Operation operation;
        private First_applicable _firstApplicable = new First_applicable();
        private Rule ruleToApply;
        private QuickSort quickSort = new QuickSort();
        private ClosestToSolutionHeuristic heuristic = new ClosestToSolutionHeuristic();
        private Node auxToRemove; 
        public void findSolution()
        {           
            statistics.setStartTime(DateTime.Now.Millisecond);
            generatedStates.Clear();
            _currentNode = getInitialState();
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
            _currentNode.setIsInitialState(true);
            openNodes.Add(_currentNode);
            while (true)
            {
                if (openNodes.Count == 0)
                {
                    statistics.setEndTime(DateTime.Now.Millisecond);
                    break;
                }
                else
                {
                    
                    auxToRemove = openNodes.First();
                    _currentNode = new Node(auxToRemove);
                    openNodes.Remove(auxToRemove);
                    statistics._totalVisitedNodes += 1;
                    statistics._totalExpandedNodes += 1;

                    if (isSolution(_currentNode, getDesiredSolution()))
                    {
                        generateSolutionPath(_currentNode);
                        statistics.setSolution(getSolutionFound());
                        statistics.setAverageBranchingFactor(calculateAverageBranchingFactor());
                        statistics.setEndTime(DateTime.Now.Millisecond);

                       break;
                    }
                    else
                    {
                        _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                        _currentNode.setHasConfigured(true);
                        foreach (Operation possibleOperation in _currentNode.getPossibleOperations())
                        {
                            operation = _firstApplicable.getNextOperation(_currentNode.getPossibleOperations());
                            if (operation != null)
                            {
                                
                                operation.setHasTried(true); 
                                ruleToApply = generateRule(operation);
                                Node aux = ruleToApply.applyRule(_currentNode,operation);
                                aux.printState();
                                if (hasBeenAlreadyGenerated(aux)==false)
                                {
                                    generatedStates.Add(aux);
                                    openNodes.Add(aux);
                                    aux.setHeuristicValor(heuristic.getHeuriscValor(aux,getSolution()));
                                    quickSort.sort(nodes:openNodes,0,openNodes.Count-1);
                                }
                            }
                        }
                        closedNodes.Add(_currentNode);
                    }
                }
            }  
            
        }
        
        
    }
}