using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.Diagnostics;
namespace ConsoleApplication1
{
    class Program : TestCases
    {
        public static void print()
        {
            Console.Write("\t\t\t\t\t--------------------------\n");
            Console.Write("\t\t\t\t\t-------Project Name:------\n\n");
            Console.Write("\t\t\t\t\t  Small World Phenomenon\t\n");
            Console.Write("\t\t\t\t\t--------------------------\n");
            Console.Write("\t\t\t\t\t-----------TA:------------\n\n");
            Console.Write("\t\t\t\t\t     [Dr/Reham Ashraf]\n");
            Console.Write("\t\t\t\t\t--------------------------\n");
            Console.Write("\t\t\t\t\t-----------Team:----------\n\n");
            Console.Write("\t\t\t\t\t(1) Abdelrahman Hassan Mohamed Mahmoud (20191700360) [team Leader]\n");
            Console.Write("\t\t\t\t\t(2) Abdelrahman Rezk Ibrahim Eldesoky (20191700337)\n");
            Console.Write("\t\t\t\t\t(3) Mohmmed Mostafa Refaat Abdelhamed (20191700576)\n");
            Console.Write("\t\t\t\t\t(4) Sayed Saied Sayed Mostafa (20191700307)\n\n");
            Console.Write("\t\t\t\t\t-------Project_Catalog:------\n\n");
            Console.Write("\t\t\t\t\t\t   Press\n");
            Console.Write("\t\t\t\t\t-----------------------------\n");
            Console.Write("\t\t\t\tNumber\t\tOptimized\t\tAlgorithm\n\n");
            Console.Write("\t\t\t\t  1\t\t  No\t\t\t  BFS\n\n");
            Console.Write("\t\t\t\t  2\t\t  Yes\t\t\t  Dijkstra\n");
            Console.Write("Choose Number:");
        }
        static void Main(string[] args)
        {
            Stopwatch x = new Stopwatch();
            x.Start();
            print();
            LD_MOVIES();
            LD_QUERY(int.Parse(Console.ReadLine()));
            x.Stop();
            Console.WriteLine("Total Runtime = {0}", x.Elapsed);

        }
    }
}