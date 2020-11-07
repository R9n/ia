using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class Backtracking : Algorithm
    {
        public Backtracking(Node state, Node solution)
        {
            setIsInitialState(state);
            setDesiredSolution(solution);
        }

        private Node _currentNode = new Node();
        
        private First_applicable _firstApplicable = new First_applicable();

        Operation operation;

        public void findSolution()
        {
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
                    _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                    if (hasBeenAlreadyGenerated(_currentNode) == false)
                    {
                        generatedStates.Add(_currentNode);
                        if (isSolution(_currentNode, getSolution()))

                        {
                            _currentNode.printState();
                            generateSolutionList(_currentNode);
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
                    if (_currentNode.getIsInitialState())
                    {
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