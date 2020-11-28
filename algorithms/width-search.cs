using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class WidthSearch:Algorithm
    {
        public WidthSearch(Node state, Node solution)
        {
            setInitialState(state);
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
            statistics.setStartTime(DateTime.Now.Millisecond);
            statistics.setAlgorithmName("busca-em-largura");
            generatedStates.Clear();
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
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
                        generateSolutionPath(_currentNode);
                        statistics.setSolution(getSolutionFound());
                        statistics.setAverageBranchingFactor(calculateAverageBranchingFactor());
                        statistics.setSolutionCost(getSolutionFound().Count);
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
                                if (hasBeenAlreadyGenerated(aux) == false)
                                {
                                    statistics._totalExpandedNodes += 1;

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
