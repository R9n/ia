using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class Backtracking : Algorithm
    {
        public Backtracking(Node state, Node solution)
        {
            setInitialState(state);
            setDesiredSolution(solution);
        }
        private Node _currentNode = new Node();
        private First_applicable _firstApplicable = new First_applicable();
        private Operation operation;
        public void findSolution()
        {               
            statistics.setStartTime(DateTime.Now.Millisecond);
            statistics.setAlgorithmName("backTracking");
            generatedStates.Clear();
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
            _currentNode = getInitialState();
            generatedStates.Add(_currentNode);
            _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
            _currentNode.setHasConfigured(true);

            while (true)
            {
                if (_currentNode.getHasConfigured() == false)
                {
                    _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                    _currentNode.setHasConfigured(true);
                }
              
                operation
                    = _firstApplicable.getNextOperation(_currentNode.getPossibleOperations());
                if (operation != null)
                { 
                    operation.setHasTried(true);
                    Rule rule = generateRule(operation);
                    _currentNode = rule.applyRule(_currentNode, operation);
                    _currentNode.setGenereatedByOperation(operation);
                    statistics._totalExpandedNodes += 1;
                    statistics._totalVisitedNodes += 1;
                    _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                    if (hasBeenAlreadyGenerated(_currentNode) == false)
                    {
                        generatedStates.Add(_currentNode);
                        if (isSolution(_currentNode, getSolution()))

                        {
                            generateSolutionPath(_currentNode);
                            _currentNode.setIsLeaf(true);
                            leafs.Add(_currentNode);
                            statistics.setSolution(getSolutionFound());
                            statistics.setAverageBranchingFactor(calculateAverageBranchingFactor());
                            statistics.setSolutionCost(getSolutionFound().Count);
                            statistics.setEndTime(DateTime.Now.Millisecond);
                            break;
                        }
                    }
                    else
                    {   
                        _currentNode = _currentNode.getFather();
                    }
                }
                else
                {
                    _currentNode.setIsLeaf(true);
                    leafs.Add(_currentNode);
                    if (_currentNode.getIsInitialState())
                    {
                        statistics.setEndTime(DateTime.Now.Millisecond);
                        break;
                    }
                    else
                    {
                        _currentNode = _currentNode.getFather();
                    }
                }
            }
        }
    }
}