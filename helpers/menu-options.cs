using System;
using System.Collections.Generic;

namespace iac.helpers
{
    //Classe com as opções disponíveis no menu
    public static class MenuOptions
    {
        public const string backTrackingOption = "1";
        public const string depthSearchOption = "2";
        public const string widthSearchOption = "3";
        public const string orderedSearchOption = "4";
        public const string greedySearchOption = "5";
        public const string astarOption = "6";
        public const string idAstarOption = "7";
        public const string runAllAlgorithmsOption = "8";
        public const string exitOption = "9";

        public static string[] validOptinos = {"1","2","3","4","5","6","7","8","9"};


    }
}