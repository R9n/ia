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


        private void calculateSolutionCost()
        {
            int cost = 0;
            Node node = _currentNode;
            while (node.getIsInitialState() != true)
            {
                switch (node.getGenereatedByOperation().getRuleType())
                {
                    case ruleTypes.RulesTypes.fill:
                        cost++; 
                        break;
                    case ruleTypes.RulesTypes.transfer:
                        cost++; 
                        break;
                    case ruleTypes.RulesTypes.drainOut:
                        cost++; 
                        break;
                }
                node = node.getFather();

            }
            statistics.setSolutionCost(cost);
        }
        

        public void findSolution()
        {
            statistics.setStartTime(DateTime.Now.Millisecond);
            generatedStates.Clear();
            statistics._totalExpandedNodes += 1;
            statistics._totalVisitedNodes += 1;
            statistics.setAlgorithmName("Busca Ordenada");

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
                        calculateSolutionCost();
                        statistics.setEndTime(DateTime.Now.Millisecond);
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
                                aux.setGenereatedByOperation(operation);
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