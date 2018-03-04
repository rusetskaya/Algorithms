using System;
using System.Collections.Generic;

namespace AlgFirstLabSec
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 8, 6, 3, 6 };
            GraphIndependentSet set = new GraphIndependentSet(array);

            Console.WriteLine("Максимальный суммарный вес в независимом множестве: " + set.CountMax()[set.CountMax().Count - 1]);
            Console.WriteLine("Путь: ");
            foreach (int t in set.FindPath())
            {
                Console.WriteLine(t);
            }

            Console.ReadLine();
        }

        class GraphIndependentSet
        {
            private int[] array = new int[] { };
            List<int> sumWeight = new List<int>();
            List<int> path = new List<int>();

            public GraphIndependentSet(int[] array)
            {
                this.array = array;
            }

            public List<int> CountMax()
            {
                //path.Add(0);
                path.Add(array[0] > array[1] ? 0 : 1);

                sumWeight.Add(0);
                sumWeight.Add(array[0]);
                sumWeight.Add(Math.Max(array[0], array[1]));

                for (int i = 2; i < array.Length; i++)
                {
                    sumWeight.Add(Math.Max(sumWeight[i - 1] + array[i], sumWeight[i]));
                    if (sumWeight[i - 1] + array[i] > sumWeight[i])
                    {
                        path.Add(i);
                    }
                }

                return sumWeight;
            }

            public List<int> FindPath()
            {
                for (int i = path.Count - 1; i > 0; i--)
                {
                    if (path[i] - path[i - 1] < 2)
                    {
                        path.RemoveAt(i - 1);
                    }
                }

                return path;
            }
        }
    }
}
