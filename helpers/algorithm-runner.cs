using System;
using System.Collections.Generic;
using iac.algorithms;
using iac.models;

namespace iac.helpers
{
    public class AlgorithmRunner
    {
        private Backtracking backtracking;
        private DepthSearch depthSearch;
        private WidthSearch widthSearch;
        private OrderedSearch orderedSearch;
        private GreedySearch greedySearch;
        private AStart astar;
        private IdAStart idAstar;
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
                foreach (var instance in list)
                {
                    int aux = instance.getDimension();
                    if (!instancesDimensions.Contains(aux))
                    {
                        instancesDimensions.Add(aux);
                    }   
                }
                instances = list;
            }
        }
        
        public void runAlgorithm(string algorithmIdentifier)
        {
            allstaticstics.Clear();
            Console.WriteLine("Processando...");
            switch (algorithmIdentifier)
            {
                case MenuOptions.backTrackingOption:
                    foreach (var instancesDimension in instancesDimensions)
                    {
                        foreach (var instance in instances)
                        {
                            if (instance.getDimension() == instancesDimension)
                            {   
                                Backtracking backtracking = new Backtracking(instance.getInitialState(),instance.getSolution());
                                backtracking.initalizeAlgorithmRules();
                                backtracking.findSolution();
                                Statistics statistics = backtracking.getStatistics();
                                statistics.setInstanceDimension(instance.getDimension());
                                allstaticstics.Add(statistics);
                            }
                        }
                    }
                    break;
                 case MenuOptions.depthSearchOption:
                     foreach (var instance in instances)
                     {
                         foreach (var instancesDimension in instancesDimensions)
                         {
                             if (instance.getDimension() == instancesDimension)
                             {   
                                 DepthSearch depthSearch = new DepthSearch(instance.getInitialState(),instance.getSolution());
                                 depthSearch.initalizeAlgorithmRules();
                                 depthSearch.findSolution();
                                 Statistics statistics = depthSearch.getStatistics();
                                 statistics.setInstanceDimension(instance.getDimension());
                                 allstaticstics.Add(statistics);
                             }
                         }
                     }
                     
                    break;
                case MenuOptions.widthSearchOption:
                    foreach (var instance in instances)
                    {
                        foreach (var instancesDimension in instancesDimensions)
                        {
                            if (instance.getDimension() == instancesDimension)
                            {   
                                WidthSearch widthSearch = new WidthSearch(instance.getInitialState(),instance.getSolution());
                                widthSearch.initalizeAlgorithmRules();
                                widthSearch.findSolution();
                                Statistics statistics = widthSearch.getStatistics();
                                statistics.setInstanceDimension(instance.getDimension());
                                allstaticstics.Add(statistics);
                            }
                        }
                    }
                    break;
        
                case MenuOptions.orderedSearchOption:
                    foreach (var instance in instances)
                    {
                        foreach (var instancesDimension in instancesDimensions)
                        {
                            if (instance.getDimension() == instancesDimension)
                            {   
                                OrderedSearch orderedSearch = new OrderedSearch(instance.getInitialState(),instance.getSolution());
                                orderedSearch.initalizeAlgorithmRules();
                                orderedSearch.findSolution();
                                Statistics statistics = orderedSearch.getStatistics();
                                statistics.setInstanceDimension(instance.getDimension());
                                allstaticstics.Add(statistics);
                            }
                        }
                    }
                    break;
       
                case MenuOptions.greedySearchOption:
                    foreach (var instance in instances)
                    {
                        foreach (var instancesDimension in instancesDimensions)
                        {
                            if (instance.getDimension() == instancesDimension)
                            {   
                                GreedySearch greedySearch= new GreedySearch(instance.getInitialState(),instance.getSolution());
                                greedySearch.initalizeAlgorithmRules();
                                greedySearch.findSolution();
                                Statistics statistics = greedySearch.getStatistics();
                                statistics.setInstanceDimension(instance.getDimension());
                                allstaticstics.Add(statistics);
                            }
                        }
                    }
                    break;
                case MenuOptions.astarOption:
        
                    foreach (var instance in instances)
                    {
                        foreach (var instancesDimension in instancesDimensions)
                        {
                            if (instance.getDimension() == instancesDimension)
                            {   
                                AStart astar = new AStart(instance.getInitialState(),instance.getSolution());
                                astar.initalizeAlgorithmRules();
                                astar.findSolution();
                                Statistics statistics = astar.getStatistics();
                                statistics.setInstanceDimension(instance.getDimension());
                                allstaticstics.Add(statistics);
                            }
                        }
                    }
                    break; 

                case MenuOptions.idAstarOption:
                    foreach (var instance in instances)
                    {
                        foreach (var instancesDimension in instancesDimensions)
                        {
                            if (instance.getDimension() == instancesDimension)
                            {   
                                IdAStart idAstar = new IdAStart(instance.getInitialState(),instance.getSolution());
                                 idAstar.initalizeAlgorithmRules();
                                idAstar.findSolution();
                                Statistics statistics = idAstar.getStatistics();
                                statistics.setInstanceDimension(instance.getDimension());
                                allstaticstics.Add(statistics);
                            }
                        }
                    }
                    break;
   
            }
            Console.WriteLine("Finalizado.");
        }

    }
}