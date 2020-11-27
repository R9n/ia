using System;
using System.Collections.Generic;
using System.Linq;
using iac.helpers;
using iac.heuristics;
using iac.models;

namespace iac.algorithms
{
    public class IdAStart:Algorithm
    {
        
        public IdAStart(Node state, Node solution)
        {
            setInitialState(state);
            setDesiredSolution(solution);
        }
        private Node _currentNode =  new Node();
        private  List<Node> openNodes = new List<Node>();
        private  List<Node> closedNodes = new List<Node>();
        private ClosestToSolutionHeuristic heuristics = new ClosestToSolutionHeuristic();
        private Rule ruleToApply;
        private QuickSort quickSort = new QuickSort();
        private Node aux;
        private Operation operation;
        private  First_applicable firstApplicable = new First_applicable();
        private int patamar;
        private int patamar_old = -1;

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
            openNodes.Add(_currentNode);
            
            patamar = _currentNode.getHeuristicValor();
            while(true){
                if (patamar == patamar_old)
                {
                    statistics.setEndTime(DateTime.Now.Millisecond);
                    break;
                }
                else
                {            
                    if (isSolution(_currentNode, getDesiredSolution()) && _currentNode.getHeuristicValor() < patamar)
                    {
                        generateSolutionList(_currentNode);
                        statistics.setSolution(getSolutionFound());
                        statistics.setAverageBranchingFactor(calculateAverageBranchingFactor());
                        statistics.setEndTime(DateTime.Now.Millisecond);
                        break;
                    }
                    else
                    {
                        if (_currentNode.getHeuristicValor() > patamar)
                        {
                            aux = _currentNode.getFather();
                            closedNodes.Add(_currentNode);
                            quickSort.sort(closedNodes,0,closedNodes.Count-1);
                        }

                        if (_currentNode.getPossibleOperations() != null)
                        {
                            operation = firstApplicable.getNextOperation(_currentNode.getPossibleOperations());
                            
                            if (operation != null)
                            {
                                operation.setHasTried(true);
                                ruleToApply = generateRule(operation);
                                _currentNode = ruleToApply.applyRule(_currentNode,operation);
                                statistics._totalExpandedNodes++;
                                if (hasBeenAlreadyGenerated(_currentNode) == false)
                                {                        
                                    statistics._totalVisitedNodes++;
                                    _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                                    _currentNode.setHeuristicValor(heuristics.getHeuriscValor(_currentNode,getDesiredSolution()));
                                    generatedStates.Add(_currentNode);
                                }
                            }
                        }
                        else
                        {
                            if (_currentNode.getIsInitialState())
                            {
                                patamar_old = patamar;
                                patamar = closedNodes.First().getHeuristicValor();
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

        
        


    }
}