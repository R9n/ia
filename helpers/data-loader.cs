using System;
using System.Collections.Generic;
using iac.models;

namespace iac.helpers
{
    // Esta classe é responsável por carregar as instências
    //Dado que estou aceitando instÂncias de tamanho variado algumas verificações são feitas
    // como por exemplo não é permitido um estado incial com 2 jarros e uma solução com 5 jarros;
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
                // cada linha de informação sobre os jarros possui essas informações: volume máximo, volume atual e nome
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
                pitcher.setIsFull((pitcher.getCurrentVolume()==pitcher.getMaxVolume()));

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
                
                Console.WriteLine("Carregando Dados...");   

                line = file.ReadLine(); 
                
            while(line != null)
            {
               lines++;
                if (!line.StartsWith(InstanceMarkers.commentMarker)) // ignoro linhas que começem com comentário 
                {             
                    if (line == InstanceMarkers.instanceStartMarker) // instancio uma nova instancia de Instância sempre que acho um marcador
                    {                                               // de início de instência  
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
                         
                         line = file.ReadLine(); // avanço para a próxima linha para ler a seçaõ do jos jarros do estado incial
                         
                         while (line != InstanceMarkers.instanceStartMarker && line != InstanceMarkers.instanceFileEndMarker)
                         {
                             inictalStateDimention++;
                             initialStatePitchers.Add(generatePitcher(line));
                             line = file.ReadLine();
                            
                         }

                         if (solutionDimension != inictalStateDimention) // conforme dito não é permitido instancias e estados inicias 
                         {                                              // com dimensões diferentes 
                             throw  new Exception("Instância inválida! A solução desejada e o estado incial devem possuir a mesma" +
                                                  "dimensão");
                         }
                         
                         solution.setPitchers(solutionPitchers);
                         
                         initialState.setPitchers(initialStatePitchers);
                         initialState.setIsInitialState(true);
                         initialState.setOperation("Estado inicial");
                        
                         Instance newInstance = new Instance(initialState,solution,solutionDimension);
                         instances.Add(newInstance);
                         
                         if (line == InstanceMarkers.instanceFileEndMarker)
                         {
                             foreach (var instance in instances)
                             {
                              Console.WriteLine(instance.getInitialState() == null);   
                             }

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