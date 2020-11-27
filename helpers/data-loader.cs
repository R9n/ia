using System;
using System.Collections.Generic;
using iac.models;

namespace iac.helpers
{
    public class DataLoader
    {
        private List<Instance> instances = new List<Instance>();
        

        public void setInstances(List<Instance> value)
        {
            instances = value;
        }

        public List<Instance> getInstances()
        {
            return instances;
        }


        private Pitcher generatePitcher(string dataString)
        {
            int maxVolumeIndex = 0;
                int currentVolumeIndex = 1;
                int nameIndex = 2;
            
                Pitcher pitcher = new Pitcher();
            
                if (dataString.Equals(""))
                {
                    return pitcher;
                }
                
                var data = dataString.Split(",");
                pitcher.setMaxVolume(Int32.Parse(data[maxVolumeIndex]));
                pitcher.setCurrentVolume(Int32.Parse(data[currentVolumeIndex]));
                pitcher.setName(data[nameIndex]);

                return pitcher;
            
        }
        
        public DataLoader(string dataPath)
        {
            int lines = 0;
            string line;
            int solutionDimension = 0;
            int inictalStateDimention = 0;
            if (dataPath.Equals(""))
            {
                throw new Exception("O caminho do arquivo de instências não pode ser vazio");
            }
            try
            {
                System.IO.StreamReader file =
                    new System.IO.StreamReader(dataPath);
                line = file.ReadLine();
            while(line != null)
            {
               lines++;
                if (!line.StartsWith(InstanceMarkers.commentMarker))
                {             
                    if (line == InstanceMarkers.instanceStartMarker)
                    {    
                         Node solution = new Node();
                         Node initialState = new Node();
                         List<Pitcher> solutionPitchers = new List<Pitcher>();
                         List<Pitcher> initialStatePitchers = new List<Pitcher>();
                         solutionDimension = 0;
                         inictalStateDimention = 0;
                        
                         line = file.ReadLine();
                         
                         while (line != InstanceMarkers.solutionEndMarker )
                         {
                             solutionDimension++;
                             solutionPitchers.Add(generatePitcher(line));
                             line = file.ReadLine();
                         }
                         
                         line = file.ReadLine();
                         
                         while (line != InstanceMarkers.instanceStartMarker && line != InstanceMarkers.instanceFileEndMarker)
                         {
                             inictalStateDimention++;
                             initialStatePitchers.Add(generatePitcher(line));
                             line = file.ReadLine();
                            
                         }

                         if (solutionDimension != inictalStateDimention)
                         {
                             throw  new Exception("Instância inválida! A solução desejada e o estado incial devem possuir a mesma" +
                                                  "dimensão");
                         }
                         
                         solution.setPitchers(solutionPitchers);
                         initialState.setPitchers(initialStatePitchers);
                         initialState.setIsInitialState(true);
                             
                         Instance newInstance = new Instance(initialState,solution,solutionDimension);
                         instances.Add(newInstance);
                         
                         if (line == InstanceMarkers.instanceFileEndMarker)
                         {
                             break;
                         }
                    }
                }
                else
                {
                    line = file.ReadLine();
                }

                
            }
            file.Close();  
            if (lines==0)
            {
                throw new Exception("Arquivo de instâncias vazio");
            }
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }

        }
    }
        
}