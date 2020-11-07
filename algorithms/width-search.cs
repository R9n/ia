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
            _currentNode = getInitialState();
            openNodes.Enqueue(_currentNode);
            while (true)
            {
                if (openNodes.Count == 0)
                {
                    _currentNode.printState();
                    break;
                }
                else
                {
                    _currentNode = openNodes.Dequeue();
                    if (isSolution(_currentNode, getDesiredSolution()))
                    {
                        generateSolutionList(_currentNode);
                        
                       break;
                    }
                    else
                    {
                        _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                        _currentNode.setHasConfigured(true);
                        
                        foreach (Operation possibleOperation in _currentNode.getPossibleOperations())
                        {
                            
                                ruleToApply = generateRule(possibleOperation);
                                Node aux = ruleToApply.applyRule(_currentNode,possibleOperation);
                                if (hasBeenAlreadyGenerated(aux) == false)
                                {
                                    generatedStates.Add(aux);
                                    openNodes.Enqueue(aux);
                                }
                        }
                        closedNodes.Add(_currentNode);
                    }
                }
            }  
            
        }
        
    }
}
