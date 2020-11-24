using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class OrderedSearch: Algorithm
    {
        public OrderedSearch(Node state, Node solution)
        {
            setInitialState(state);
            setDesiredSolution(solution);
        }
        private Node _currentNode = new Node();
        Queue<Node> openNodes= new Queue<Node>();

        private Rule ruleToApply;
            private List<Node> closedNodes = new List<Node>();

        private First_applicable _firstApplicable = new First_applicable();
        
        Operation operation;

        public void findSolution()
        {
            generatedStates.Clear();
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
            statistics.setStartTime(DateTime.Now.Millisecond);
            _currentNode = getInitialState();
            generatedStates.Add(_currentNode);
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
                        statistics.setAverageBranchingFactor(calculateAverageBranchingFactor());
                        break;
                    }
                    else
                    {
                        _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                        _currentNode.setHasConfigured(true);
                        
                        foreach (Operation possibleOperation in _currentNode.getPossibleOperations())
                        {
                            operation = _firstApplicable.getNextOperationWithWeight(_currentNode.getPossibleOperations());
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