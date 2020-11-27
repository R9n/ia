using iac.helpers;

//  Trabalho de inteligência Artificial 
//  Professor: Saulo Villela
//  Aluno: Ronaldo Modesto
//  Local:Universidade Federal de Juiz de Fora

namespace iac
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLoader dataLoader = new DataLoader("/home/ark/RiderProjects/iac/instancia.txt");
            Menu menu= new Menu(dataLoader);
            menu.showMenu();
        }
    }
}