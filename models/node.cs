using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace iac.models
{
    public class Node
    {
        private List<Pitcher> _pitchers = new List<Pitcher>();
        private Node _father;
        private bool _isProcessed;
        private bool _isInitialState;
        private List<Node> _generatedNodes;
        private string _generatingOperation;
        private List<Operation> possibleOperations;
        private bool _hasConfigured = false;


        
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
        
        
        public int getPitcherIndexById(int id)
        {
            for (int i = 0; i < _pitchers.Count; i++)
            {
                if (_pitchers[i].getId() == id)
                {
                    return i;
                }
            }
            return -1;
        }
        
        public void printState()
        {
            for (int i = 0; i < _pitchers.Count; i++)
            {
                Console.WriteLine("Jarro: "+_pitchers[i].getName() );
                Console.WriteLine("Id: "+_pitchers[i].getId() );
                Console.WriteLine("ISFull: "+_pitchers[i].getIsFull() );
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
        
        public void setGeneratedNodes(Node node)
        {
            _generatedNodes.Add(node);
        }
        public List<Node> getGeneratedNodes()
        {
            return _generatedNodes; 
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

        
        
        public void setIsProcessed(bool value)
        {
            _isProcessed = value;
        }
        public bool getIsProcessed()
        {
            return _isProcessed; 
        }
        
        public void setFather(Node father)
        {
            _father = father;
        }
        public Node getFather()
        {
            return _father; 
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