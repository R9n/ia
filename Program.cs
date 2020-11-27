using System.Collections.Generic;
using iac.algorithms;
using iac.helpers;
using iac.models;

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