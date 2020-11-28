using System;
using System.Collections.Generic;
using System.Linq;
using iac.rules;

namespace iac.models
{
    
    // Classe base dos algoritmos. Esta classe contém métodos que todos os algoritmos teriam de implementar
    //fazendo a extensão dela nas classes de algoritmos evitamos a repetição de código
    
    public class Algorithm
    {
        List<Node> _solutionFound = new List<Node>();
        public Statistics statistics = new Statistics();
        Node _InitialState;
        Node _desiredSolution;
        public List<Node> leafs= new List<Node>();
        List<Rule> rules = new List<Rule>();
        public List<Node> generatedStates= new List<Node>();
        public void initalizeAlgorithmRules()
        {
            //Método que carrega as regras que estarão disponíveis para os algoritmos/
            //Pode-se criar mais regras sem problemas
            Drain_out drainOut = new Drain_out();
            Fill fill = new Fill();
            Transfer transfer = new Transfer();
            
           rules.Add(transfer);
           rules.Add(drainOut);
           rules.Add(fill);
        }

        
        //método que verifica se um dado nó já foi gerado
        public bool hasBeenAlreadyGenerated(Node node
        )
        {
            bool hasAlreadyGenerated = false;

            foreach (Node generatedState in generatedStates)
            {
                if (generatedState.isEqualTo(node))
                {
                    hasAlreadyGenerated = true;
                }
            }
          
            return hasAlreadyGenerated;
        }
        
        // Método que gera o conjunto de operações que são possíveis de se aplicar a um determinado nó
        public List<Operation> generateOperationSet(Node node)
        {
            List<Operation> operations = new List<Operation>();
            
            foreach (Rule rule in rules)
            {
                foreach (Operation operation in rule.getOperationSet(node))
                {    
                    operations.Add(operation);
                }
            }
            return operations;
        }
        
        //método que gera uma regra a partir de um tipo de regra e devolve uma instância do tipo Ryle
        public Rule generateRule(Operation operation)
        {
            switch (operation.getRuleType())
            {
                case ruleTypes.RulesTypes.fill:
                    return new Fill();
                case ruleTypes.RulesTypes.transfer:
                    return new Transfer();
                case ruleTypes.RulesTypes.drainOut:
                    return new Drain_out();
                default:
                    return null;
            }
        }

        //gera o caminho solução a partir de um nó passado
        public  void generateSolutionPath(Node node)
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
        
        //Calcula o fator médio de ramificação
        public double calculateAverageBranchingFactor()
        {
            Node aux ;
            int treeHeigth = 0;
            if (_solutionFound.Count > 0)
            {
                aux = _solutionFound.First();
                foreach (Node node in leafs)
                {
                    if (node.getId() > aux.getId())
                    {
                        aux = node;
                    }
                }

                while (aux.getIsInitialState() == false)
                {
                    treeHeigth++;
                    aux = aux.getFather();
                }
                return treeHeigth/((generatedStates.Count+ 0.0) - (leafs.Count+0.0));

            }

            return 0;

        }
        
        //Verifica se um dado nó é solução
        public  bool isSolution(Node node,Node solution)
        {
            List<Pitcher> solutionPitchers = solution.getPitchers();
            List<Pitcher> nodePitchers = node.getPitchers();
            
            for (int i = 0; i < solutionPitchers.Count; i++)
            {
                if (solutionPitchers[i].getMaxVolume() != -1)
                {
                    if (solutionPitchers[i].getCurrentVolume() == nodePitchers[i].getCurrentVolume())
                    {
                        return true;
                    }
                    
                }
                
            }
            return false;
        }
        
        public void setSolution(List<Node> solution)
        {
            _solutionFound = solution;
        }
        
        public List<Node> getSolutionFound()
        {
            return _solutionFound;
        }

        public void addRule(Rule rule)
        {
            rules.Add(rule);
        }
        
        public List<Rule> getRules()
        {
            return rules;
        }
        
        public Statistics getStatistics()
        {
            return statistics;
        }
        
        public Node getSolution()
        {
            return _desiredSolution;
        }
        
        
        public void setDesiredSolution(Node value)
        {
            _desiredSolution = value;
        }

        public Node getDesiredSolution()
        {
            return _desiredSolution;
        }

        public void setInitialState(Node value)
        {
            _InitialState = value;
        }

        public Node getInitialState()
        {
            return _InitialState;
        }

        
    }
}