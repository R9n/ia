using System;
using System.Collections.Generic;
using System.IO;

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
        private int instanceDimension;
        private string algorithmName;
        private int solutionCost;


        public void printStatistcs()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Algoritmo : "+algorithmName);
            Console.WriteLine("Dimensão da instência: "+instanceDimension+" jarros");
            Console.WriteLine("Total de nós expandidos: "+_totalExpandedNodes);
            Console.WriteLine("Total de nós visitados: "+_totalVisitedNodes);
            Console.WriteLine("Fator médio de ramificação "+_averageBranchingFactor);
            Console.WriteLine("Tempo total de execução: "+getExecutionTime()+" Milissegundos");
            Console.WriteLine("Custo da solução: "+solutionCost);
            Console.WriteLine("Profundidade da solução: "+getSolutionDeep());
            Console.WriteLine("Caminho da solução:");
            

            foreach (var s in getSolutionPath())
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("===============================================");
        }

        public void writeStatistics()
        {
          
            try
            {
                
                string filePath = @$"./{algorithmName}-for-{instanceDimension}-jarros.txt";
               // string filePath = @$"/home/ark/RiderProjects/iac/generatedStatistics/{algorithmName}-for-{instanceDimension}-pitchers.txt";
                System.IO.File.WriteAllText(filePath, "");
                System.IO.StreamWriter file =
                    new System.IO.StreamWriter(filePath);
                
                file.Write("!");

                file.WriteLine("===============================================");
                file.WriteLine("Algoritmo : "+algorithmName);
                file.WriteLine("Dimensão da instência: "+instanceDimension+" jarros");
                file.WriteLine("Total de nós expandidos: "+_totalExpandedNodes);
                file.WriteLine("Total de nós visitados: "+_totalVisitedNodes);
                file.WriteLine("Fator médio de ramificação "+_averageBranchingFactor);
                file.WriteLine("Custo da solução: "+solutionCost);
                file.WriteLine("Tempo total de execução: "+getExecutionTime()+" Milissegundos");
                file.WriteLine("Profundidade da solução: "+getSolutionDeep());
                file.WriteLine("Caminho da solução:");

                foreach (var s in getSolutionPath())
                {
                    file.WriteLine(s);
                }
                file.WriteLine("===============================================");
                Console.WriteLine($"O resultado da execução do algoritmo {algorithmName} pode ser encontrado em: {filePath}");
                file.Close();   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void setInstanceDimension(int value)
        {
            instanceDimension = value;
        }
        
        public void setSolutionCost(int value)
        {
            solutionCost = value;
        }
        
        

        public void setAlgorithmName(string value)
        {
            algorithmName = value;
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