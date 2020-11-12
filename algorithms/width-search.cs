using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class WidthSearch:Algorithm
    {
        public WidthSearch(Node state, Node solution)
        {
            setIsInitialState(state);
            setDesiredSolution(solution);
        }
        private Node _currentNode;
        
        private  List<Node> closedNodes = new List<Node>();
        Queue<Node> openNodes= new Queue<Node>();
        private Operation operation;
        private First_applicable _firstApplicable = new First_applicable();
        private Rule ruleToApply;


        public void findSolution()
        {
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
            statistics.setStartTime(DateTime.Now.Millisecond);
            _currentNode = getInitialState();
            openNodes.Enqueue(_currentNode);
            while (true)
            {
                if (openNodes.Count == 0)
                {
                    statistics.setEndTime(DateTime.Now.Millisecond);
                    break;
                }
                else
                {
                    _currentNode = openNodes.Dequeue();
                    statistics._totalVisitedNodes += 1;

                    if (isSolution(_currentNode, getDesiredSolution()))
                    {
                        generateSolutionList(_currentNode);
                        statistics.setEndTime(DateTime.Now.Millisecond);
                        statistics.setSolution(getSolutionFound());
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
                                statistics._totalExpandedNodes += 1;

                                if (hasBeenAlreadyGenerated(aux) == false)
                                {
                                    generatedStates.Add(aux);
                                    openNodes.Enqueue(aux);
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
