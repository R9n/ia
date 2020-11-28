using System;
using System.Linq;
using System.Timers;
using iac.helpers;
using iac.models;

namespace iac
{
    public class Menu
    {
        private string option;
        private AlgorithmRunner algorithmRunner;
        private double time=0.0;
        
        public Menu(DataLoader data)
        {
            algorithmRunner = new AlgorithmRunner(data.getInstances());    
        }

        public void showMenu()
        {
            Console.WriteLine("----------------------------TRABALHO DE IA----------------------------");
            Console.WriteLine("Aluno: Ronaldo Modesto");
            Console.WriteLine();
            Console.WriteLine("Professor: Saulo Villela");
            Console.WriteLine();
            Console.WriteLine("Forma de uso: Selecione uma opção do menu e aperte ENTER");
            Console.WriteLine();
            Console.WriteLine("Digite:");
            Console.WriteLine("1 para rodar as instâncias através do BackTracking");
            Console.WriteLine("2 para rodar as instâncias através da Busca em Profundidade");
            Console.WriteLine("3 para rodar as instâncias através da Busca em Largura");
            Console.WriteLine("4 para rodar as instâncias através da Busca Ordenada");
            Console.WriteLine("5 para rodar as instâncias através da Busca Gulosa");
            Console.WriteLine("6 para rodar as instâncias através da Busca A* (A-Estrela)");
            Console.WriteLine("7 para rodar as instâncias através da Busca IDA* (IDA-Estrela)");
            Console.WriteLine("8 para rodar as todas as instâncias por todos os algoritmos");
            Console.WriteLine("9 Para sair");
            Console.WriteLine();
            while (option != MenuOptions.exitOption)
            {           
                Console.WriteLine("Informe a opção desejada");
                option = Console.ReadLine();
                if (!MenuOptions.validOptinos.Contains(option))
                {
                    Console.WriteLine("Opção Inválida");
                    continue;
                }
                
                if (option == MenuOptions.exitOption)
                {
                    Console.WriteLine("Saindo...");
                    continue;
                }

                if (option == MenuOptions.runAllAlgorithmsOption)
                {
                    Console.WriteLine("Rodando todos os algoritmos");
                    Console.WriteLine("Esta operação pode demorar");
                    time = DateTime.Now.Millisecond;
                    foreach (var validOptino in MenuOptions.validOptinos)
                    {
                        if (validOptino != MenuOptions.runAllAlgorithmsOption && validOptino != MenuOptions.exitOption)
                        {   
                            algorithmRunner.getStatistics().Clear();
                            algorithmRunner.runAlgorithm(validOptino);
                            foreach (var statisticse in algorithmRunner.getStatistics())
                            {
                                statisticse.writeStatistics();
                            }
                        }
                    }

                    time = DateTime.Now.Millisecond - time;
                    
                    Console.WriteLine("Todos os algoritmos foram executados.");
                    Console.WriteLine("Tempo total da execução: "+time+ " Milissegundos" );
                    continue;
                    
                }
                
                algorithmRunner.runAlgorithm(option);
                
                foreach (var statisticse in algorithmRunner.getStatistics())
                {
                   statisticse.writeStatistics();
                }
                
            }
            
        }
        
    }
}