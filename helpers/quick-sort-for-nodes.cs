using System;
using System.Collections.Generic;
using iac.models;

namespace iac.helpers
{
    public class QuickSort
    {
        public void sort(List<Node>nodes, int left, int right)
        {
            if (left < right)
            {
                int pivot = partition(nodes, left, right);

                if (pivot > 1)
                {
                    sort(nodes, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    sort(nodes, pivot + 1, right);
                }
            }

        }

        public static int partition(List<Node>nodes, int left, int right)
        {
            int pivot = nodes[left].getHeuristicValor();
            while (true)
            {
                while (nodes[left].getHeuristicValor() < pivot)
                {
                    left++;
                } 
                Console.WriteLine("right " + right);
                Console.WriteLine("size "+ nodes.Count);
                while (nodes[right].getHeuristicValor() > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (nodes[left].getHeuristicValor() == nodes[right].getHeuristicValor()) return right;

                    Node temp = nodes[left];
                    nodes[left] = nodes[right];
                    nodes[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}