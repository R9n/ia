using System;
using System.Collections.Generic;
using iac.models;

namespace iac.algorithms
{
    public class Backtracking:Algorithm
    {
        public Backtracking(Node state,Node solution)
        {
            setIsInitialState(state);
            setDesiredSolution(solution);
        }
        
         private Node _currentNode= new Node();
         private bool success = false;
         private bool fail = false;
      
        
        private First_applicable _firstApplicable = new First_applicable();

        void generateSolutionList(Node node)
        {
            Node aux = new Node();
            aux = node;
            List<Node> solution = new List<Node>();
            while (aux.getIsInitialState() == false)
            {
                Node aux2 = new Node();
                aux2 = aux;
                solution.Add(aux2);
                aux = aux.getFather();
                
            }
            setSolution(solution);
        }

        Operation operation;
       public void findSolution()
       {
          
           _currentNode = getInitialState();
           generatedStates.Add(_currentNode);
           _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
           _currentNode.setHasConfigured(true);
           while (success == false && fail == false)
            {
                
                if (_currentNode.getHasConfigured()==false)
                {
                    _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                    _currentNode.setHasConfigured(true);
                }
                operation
                    =_firstApplicable.getNextOperation(_currentNode.getPossibleOperations());
                 if (operation != null)
                 {  
                     operation.setHasTried(true);
                     Rule rule = generateRule(operation);

                     _currentNode = rule.applyRule(_currentNode, operation);
                     _currentNode.setPossibleOperations(generateOperationSet(_currentNode));
                     if (hasBeenAlreadyGenerated(_currentNode) == false)
                     { 
                         generatedStates.Add(_currentNode);
                         if (isSolution(_currentNode,getSolution()))
                             
                         {  _currentNode.printState();
                             Console.WriteLine("Testando");
                             successs = true;
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
                     {Console.WriteLine("Fracasso");
                         fail = true;
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