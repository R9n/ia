using System;
using System.Collections.Generic;

namespace iac.models
{
    public class Statistics
    {
        private double _startTime=0.0;
        private double _endTime=0.0;
        private List<Node> _solution=new List<Node>();
        public int _totalExpandedNodes=0;
        public int _totalVisitedNodes=0;
        private double _averageBranchingFactor=0;


        public void printStatistcs()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Total de nós expandidos: "+_totalExpandedNodes);
            Console.WriteLine("Total de nós visitados: "+_totalVisitedNodes);
            Console.WriteLine("Fator médio de ramificação "+_averageBranchingFactor);
            Console.WriteLine("Tempo total de execução: "+getExecutionTime()+"Milissegundos");
            Console.WriteLine("Profundidade da solução: "+getSolutionDeep());
            Console.WriteLine("Caminho da solução:");

            foreach (var s in getSolutionPath())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("===============================================");
        }
        
        public double getExecutionTime()
        {
            return (_endTime - _startTime);
        }

        public void setStartTime(double value)
        {
            _startTime = value;
        }

        public void setEndTime(double value)
        {
            _endTime = value;
        }

        public List<Node> getSolution()
        {
            return _solution;
        }

        public void setSolution(List<Node> solution)
        {
            _solution = solution;
        }

        public int getSolutionDeep()
        {
            return _solution.Count;
        }

        public List<string> getSolutionPath()
        { 
            List<string> path = new List<string>();
            
            for (int i = _solution.Count-1; i>=0; i--)
            {
                path.Add(_solution[i].getOperation());
            }
            return path;
        }

        public void setAverageBranchingFactor(double value)
        {
            _averageBranchingFactor = value;
        }

        public double getAvarageBranchingFactor()
        {
            return _averageBranchingFactor;
        }

    }
}