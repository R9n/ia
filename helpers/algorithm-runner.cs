using System;
using System.Collections.Generic;
using iac.algorithms;
using iac.models;

namespace iac.helpers
{
    // Essa classe é responsável por executar os algoritmos. Ou seja, ela é quem efetivamente roda
    // os algoritmos a partir de uma opção passada para a função  "runAlgorithm(int option)"
    // essas opções são as mesmas encontradas no menu, ou seja 1...7,
    public class AlgorithmRunner
    {
        private Backtracking backtracking;
        private DepthSearch depthSearch;
        private WidthSearch widthSearch;
        private OrderedSearch orderedSearch;
        private GreedySearch greedySearch;
        private AStart astar;
        private IdAStar idAstar;
        private List<Statistics> allstaticstics = new List<Statistics>();
        List<int> instancesDimensions = new List<int>();
        private List<Instance> instances;

        public List<Statistics> getStatistics()
        {
            return allstaticstics;
        }

        public AlgorithmRunner(List<Instance> list)
        {
            if (list != null)
            {
                instances = list;
            }
        }
        
        
        
        // A partir de uma opção passar eu rodo um algoritmo específico para cada instancia da lista de instancias
        public void runAlgorithm(string algorithmIdentifier)
        {
            allstaticstics.Clear();
            Console.WriteLine("Processando...");
            switch (algorithmIdentifier)
            {
                case MenuOptions.backTrackingOption:foreach (var instance in instances)
                    {
                        Console.WriteLine("Rodando o algoritmo BackTracking... ");
                            Backtracking backtracking = new Backtracking(instance.getInitialState(),instance.getSolution());
                            backtracking.initalizeAlgorithmRules();
                            backtracking.findSolution();
                            Statistics statistics = backtracking.getStatistics();
                            statistics.setInstanceDimension(instance.getDimension());
                            allstaticstics.Add(statistics);
                    }
                    break;
                 case MenuOptions.depthSearchOption:
                     foreach (var instance in instances)
                     {
                         Console.WriteLine("Rodando o algoritmo Busca em Profundidade... ");
                         DepthSearch depthSearch = new DepthSearch(instance.getInitialState(),instance.getSolution());
                         depthSearch.initalizeAlgorithmRules();
                         depthSearch.findSolution();
                         Statistics statistics = depthSearch.getStatistics();
                         statistics.setInstanceDimension(instance.getDimension());
                         allstaticstics.Add(statistics);
                     }
                     
                    break;
                case MenuOptions.widthSearchOption:
                    foreach (var instance in instances)
                    {                        
                        Console.WriteLine("Rodando o algoritmo Busca em Largura... ");
                        WidthSearch widthSearch = new WidthSearch(instance.getInitialState(),instance.getSolution());
                        widthSearch.initalizeAlgorithmRules();
                        widthSearch.findSolution();
                        Statistics statistics = widthSearch.getStatistics();
                        statistics.setInstanceDimension(instance.getDimension());
                        allstaticstics.Add(statistics);
                    }
                    break;
        
                case MenuOptions.orderedSearchOption:
                    foreach (var instance in instances)
                    {
                        Console.WriteLine("Rodando o algoritmo Busca Ordenada... ");
                        OrderedSearch orderedSearch = new OrderedSearch(instance.getInitialState(),instance.getSolution());
                        orderedSearch.initalizeAlgorithmRules();
                        orderedSearch.findSolution();
                        Statistics statistics = orderedSearch.getStatistics();
                        statistics.setInstanceDimension(instance.getDimension());
                        allstaticstics.Add(statistics);
                    }
                    break;
       
                case MenuOptions.greedySearchOption:
                    foreach (var instance in instances)
                    {
                        Console.WriteLine("Rodando o algoritmo Busca Gulosa... ");
                        GreedySearch greedySearch= new GreedySearch(instance.getInitialState(),instance.getSolution());
                        greedySearch.initalizeAlgorithmRules();
                        greedySearch.findSolution();
                        Statistics statistics = greedySearch.getStatistics();
                        statistics.setInstanceDimension(instance.getDimension());
                        allstaticstics.Add(statistics);
                    }
                    break;
                case MenuOptions.astarOption:
        
                    foreach (var instance in instances)
                    {
                        Console.WriteLine("Rodando o algoritmo A*... ");

                        AStart astar = new AStart(instance.getInitialState(),instance.getSolution());
                        astar.initalizeAlgorithmRules();
                        astar.findSolution();
                        Statistics statistics = astar.getStatistics();
                        statistics.setInstanceDimension(instance.getDimension());
                        allstaticstics.Add(statistics);
                    }
                    break; 

                case MenuOptions.idAstarOption:
                    foreach (var instance in instances)
                    {
                        Console.WriteLine("Rodando o algoritmo IDA*... ");
                        IdAStar idAstar = new IdAStar(instance.getInitialState(),instance.getSolution());
                        idAstar.initalizeAlgorithmRules();
                        idAstar.findSolution();
                        Statistics statistics = idAstar.getStatistics();
                        statistics.setInstanceDimension(instance.getDimension());
                        allstaticstics.Add(statistics);
                    }
                    break;

            }
        }

    }
}