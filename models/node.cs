using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace iac.models
{
    public class Node
    {
        private List<Pitcher> _pitchers = new List<Pitcher>();
        private Node father;
        private bool _isProcessed;
        private bool _isInitialState;
        private List<Node> _generatedNodes;
        private string _generatingOperation;
        private List<Operation> possibleOperations;
        private bool _hasConfigured = false;
        private bool _isLeaf = false;
        private int _id;
        private int heuristicValor = 0;

        public Node()
        {
           _id = Global_variables.idsHandler.getNextId();
        }
        
        public Node(Node node)
        {
            father = node.getFather();
            _isInitialState = node.getIsInitialState();
            _generatingOperation = node._generatingOperation;
            possibleOperations = node.getPossibleOperations();
            _hasConfigured = node.getHasConfigured();
            _isLeaf = node.getIsLeaf();
            heuristicValor = node.getHeuristicValor();
            _pitchers = node.getPitchers();
            _id = Global_variables.idsHandler.getNextId();
        }

        
        public int getHeuristicValor()
        {
            return heuristicValor; 
        }
        public void setHeuristicValor(int value)
        {
            heuristicValor= value;
        }
        
        
        
        public int getId()
        {
            return _id; 
        }
        public void setIsLeaf(bool value)
        {
            _isLeaf= value;
        }
        public bool getIsLeaf()
        {
            return _isLeaf; 
        }
        public void setHasConfigured(bool value)
        {
            _hasConfigured= value;
        }
        public bool getHasConfigured()
        {
            return _hasConfigured; 
        }

        

        public bool isEqualTo(Node node)
        {
            bool isEqual = true;
          
            List<Pitcher> node1Pitchers = node.getPitchers();
            
            for (int i = 0; i < node1Pitchers.Count; i++)
            {
                if (node1Pitchers[i].getCurrentVolume() != _pitchers[i].getCurrentVolume())
                {
                    isEqual = false;
                }
            }

            return isEqual;
        }
        
        
        
        public void printState()
        {       
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("É folha ?: "+ getIsLeaf());
            for (int i = 0; i < _pitchers.Count; i++)
            {
                Console.WriteLine("Jarro: "+_pitchers[i].getName() );
                Console.WriteLine("Id: "+_pitchers[i].getId() );
                Console.WriteLine("IsFull: "+_pitchers[i].getIsFull() );
                Console.WriteLine("Volume Atual: "+_pitchers[i].getCurrentVolume());
                Console.WriteLine("Volume Maximo: "+_pitchers[i].getMaxVolume());
                Console.WriteLine("-------------------------------------------------");
                
            }
        }
        
        public void setPossibleOperations(List<Operation> operations)
        {
            possibleOperations= operations;
        }
        public List<Operation> getPossibleOperations()
        {
            return possibleOperations; 
        }


        public void setOperation(string operation)
        {
            _generatingOperation = operation;
        }
        public string getOperation()
        {
            return _generatingOperation; 
        }
        

        public Pitcher getPitcherById(int pitcherId)
        {
            foreach (Pitcher pitcher in _pitchers)
            {
                if (pitcher.getId() == pitcherId)
                {
                    return pitcher;
                }
            }
            return null;
        }

        public void replacePitcherById(int pitcherId, Pitcher newPitcher)
        {
            for (int i = 0; i < _pitchers.Count; i++)
            {
                if (_pitchers[i].getId() == pitcherId)
                {
                    _pitchers[i] = newPitcher;
                    break;
                }
            }
        }
        
        
        
        public void setIsInitialState(bool value)
        {
            _isInitialState = value;
        }
        public bool getIsInitialState()
        {
            return _isInitialState; 
        }
        
        
        public void setFather(Node father)
        {
            this.father = father;
        }
        public Node getFather()
        {
            return father; 
        }
        
        
        public void setPitchers(List<Pitcher> pitchers)
        {
            _pitchers = pitchers;
        }
        public List<Pitcher> getPitchers()
        {
            return _pitchers; 
        }
        
    }
}