using System;
using System.Collections.Generic;
using System.Linq;
using iac.helpers;
using iac.heuristics;
using iac.models;

namespace iac.algorithms
{
    public class AStart:Algorithm
    {
        public AStart(Node state, Node solution)
        {
            setInitialState(state);
            setDesiredSolution(solution);
        }
        private Statistics _statistics = new Statistics();
        private Node _currentNode =  new Node();
        private  List<Node> openNodes = new List<Node>();
        private  List<Node> closedNodes = new List<Node>();
        private ClosestToSolutionHeuristic heuristics = new ClosestToSolutionHeuristic();
        private Rule ruleToApply;
        private QuickSort quickSort = new QuickSort();
        private Node auxRemove;
        private Operation operation;
        private  First_applicable firstApplicable = new First_applicable();
            
        
        public void findSolution()
        {
            generatedStates.Clear();
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
            statistics.setStartTime(DateTime.Now.Millisecond);
            _currentNode = getInitialState();
            generatedStates.Add(_currentNode);
            _currentNode.setHeuristicValor(heuristics.getHeuriscValor(_currentNode,getSolution()));
            _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
            _currentNode.setHasConfigured(true);
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
                    _currentNode = new Node(openNodes.First());
                     openNodes.Remove(openNodes.First());

                   
                     if (isSolution(_currentNode, getDesiredSolution()))
                     {
                         generateSolutionList(_currentNode);
                         statistics.setEndTime(DateTime.Now.Millisecond);
                         statistics.setSolution(getSolutionFound());
                         statistics.setAverageBranchingFactor(calculateAverageBranchingFactor());
                         break;
                     }
                    else
                    {
                        statistics._totalVisitedNodes += 1;
                        foreach (var possibleOperation in _currentNode.getPossibleOperations())
                        {
                            
                            operation = firstApplicable.getNextOperation(_currentNode.getPossibleOperations());
                            if (operation != null)
                            {   operation.setHasTried(true); 
                                ruleToApply = generateRule(operation);
                                Node aux = ruleToApply.applyRule(_currentNode, operation);
                                if (hasBeenAlreadyGenerated(aux) == false)
                                {
                                    aux.setPossibleOperations(generateOperationSet(aux));
                                    
                                    int minHeuristicValue = _currentNode.getHeuristicValor();
                                    
                                    aux.setHeuristicValor(
                                        heuristics.getHeuriscValor(aux,getDesiredSolution()) +
                                        minHeuristicValue
                                    );
                                    
                                    statistics._totalExpandedNodes += 1;
                                    generatedStates.Add(aux);
                                    openNodes.Add(aux);
                                }
                            }
                            
                        }
                    }
                    closedNodes.Add(_currentNode);
                    quickSort.sort(openNodes,0,openNodes.Count-1);
                }
             
               

            }
        }

    }
}