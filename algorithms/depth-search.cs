using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class DepthSearch:Algorithm
    {
        
        public DepthSearch(Node state, Node solution)
        {
            setIsInitialState(state);
            setDesiredSolution(solution);
        }
        private Node _currentNode;
        
        private  List<Node> closedNodes = new List<Node>();
        Stack<Node> openNodes= new Stack<Node>();
        private Operation operation;
        private First_applicable _firstApplicable = new First_applicable();
        private Rule ruleToApply;


        public void findSolution()
        {
            _currentNode = getInitialState();
            openNodes.Push(_currentNode);
            while (true)
            {
                if (openNodes.Count == 0)
                {
                    Console.WriteLine("fracasso");
                    break;
                }
                else
                {
                    _currentNode = openNodes.Pop();
                    if (isSolution(_currentNode, getDesiredSolution()))
                    {
                        generateSolutionList(_currentNode);
                       _currentNode.printState();
Console.WriteLine("============================");   
getDesiredSolution().printState();
                       

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
                                    openNodes.Push(aux);
                                    Console.WriteLine(openNodes.Count);
                                }
                        }
                        closedNodes.Add(_currentNode);
                    }
                }
            }  
            
        }



    }
}