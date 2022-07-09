using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GlobalAlgorithms : MoviesActors
    {
        public static void GRAPH() //O(N^3)
        {
            int x = 0, y = _ALL_ACTORS.Count();
            for (; ; x -= -1)// N * O(1) = O(N)
            {
                bool z = (!(x >= y));
                if ((z))
                {
                    _ADJ.Add(new Dictionary<int, int>());
                    _AAM.Add(new Dictionary<string, string>());
                }
                else
                {
                    break;
                }
            }
            foreach (string i in _ALL_ACTORS) // N* O(1) = O(N)
            {
                _ACT_INC.Add(i, iterator);

                _REV_INC.Add(iterator, i);

                iterator -= -1;

            }
            foreach (MOVIE it in _All_MOVIE) //N * O(N^2) = O(N^3)
            {
                int v1 = 0;
                int vv = it.Actors.Count();
                for (; ; v1 -= -1) // N * O(N) = O(N^2)
                {
                    bool cc1 = (!(v1 >= vv));
                    if (cc1)
                    {
                        int v2 = 0;
                        for (; ; v2 -= -1) // N * O(1) = O(N)
                        {
                            bool cc2 = (!(v2 >= vv));
                            if (cc2)
                            {
                                int[] tmp = new int[2];
                                tmp[0] = _ACT_INC[it.Actors[v1]];
                                tmp[1] = _ACT_INC[it.Actors[v2]];
                                bool cc3 = (it.Actors[v1] != it.Actors[v2]);
                                switch (cc3)//O(1)
                                {
                                    case true:
                                        {
                                            bool cc4 = (_ADJ[tmp[0]].ContainsKey(tmp[1]));
                                            switch (cc4) //O(1)
                                            {
                                                case false:
                                                    {
                                                        _AAM[tmp[0]].Add(_REV_INC[tmp[1]], it.Name);
                                                        _ADJ[tmp[0]].Add(tmp[1], 1);
                                                        break;
                                                    }
                                                case true:
                                                    {
                                                        _ADJ[tmp[0]][tmp[1]] -= -1;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        public static void bfs_Algo(string Act1, string Act2)  //O(N)
        {
            int[] ar = new int[2];
            ar[0] = _ACT_INC[Act1];
            ar[1] = _ACT_INC[Act2];
            Dictionary<int, MARKED> AllMarked;
            AllMarked = new Dictionary<int, MARKED>();
            Queue<int> N;
            N = new Queue<int>();
            N.Enqueue(ar[0]);
            MARKED srcN;
            srcN = new MARKED(ar[0], 0, 0, -1);
            AllMarked.Add(ar[0], srcN);
            bool dstFound = false;
            MARKED dstN;
            dstN = new MARKED();
            for (; ; ) // 1* O(N)
            {
                if (N.Any() == false) //O(1)
                {
                    break;
                }
                else // 1* O(N)
                {
                    int[] ar2 = new int[1];
                    ar2[0] = N.Dequeue();
                    bool a1 = ((ar[0] != ar[1]));
                    if (!a1) //O(1)
                    {
                        Console.WriteLine(_REV_INC[ar[0]] + "/" + _REV_INC[ar[1]] + "\t" + 0 + "\t" + 0 + "\t");
                        Console.WriteLine();
                        break;
                    }
                    bool a2 = ((AllMarked[ar2[0]].Var[2] < dstN.Var[2]));
                    if (!a2 && dstFound) //O(N)
                    {
                        Console.Write(_REV_INC[ar[0]] + "/" + _REV_INC[ar[1]] + "\t" + dstN.Var[2] + "\t" + dstN.Var[1] + "\t");
                        Stack<int> printer;
                        printer = new Stack<int>();
                        MARKED present;
                        present = new MARKED();
                        printer.Push(dstN.Var[0]);
                        present = dstN;
                        int ind = 0;
                        for (; ; ind -= -1) //O(N)
                        {
                            if (!(ind >= dstN.Var[2]))
                            {
                                present = AllMarked[present.Var[3]];
                                printer.Push(present.Var[0]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.Write("\t");
                        int[] actor = new int[2];
                        actor[0] = printer.Pop();
                        actor[1] = printer.Peek();
                        Console.Write(_AAM[actor[0]][_REV_INC[actor[1]]]);
                        for (; ; )//O(1)
                        {
                            if (printer.Count() > 1)
                            {
                                Console.Write(" => ");
                                actor[0] = printer.Pop();
                                actor[1] = printer.Peek();
                                Console.Write(_AAM[actor[0]][_REV_INC[actor[1]]]);
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                    foreach (KeyValuePair<int, int> ii in _ADJ[ar2[0]])// 1 * O(1)= O(1)
                    {
                        MARKED present_N;
                        present_N = new MARKED();
                        bool aa1 = (AllMarked.ContainsKey(ii.Key));
                        if (!aa1) 
                        {
                            present_N = new MARKED(ii.Key, AllMarked[ar2[0]].Var[1] + ii.Value, AllMarked[ar2[0]].Var[2] + 1, ar2[0]);
                            AllMarked.Add(ii.Key, present_N);
                            N.Enqueue(ii.Key);
                        }
                        bool aa2 = (ii.Key != ar[1]);
                        bool tot = (!(!aa2 && !dstFound));
                        if (!tot)
                        {
                            dstN = present_N;
                            dstFound = true;
                        }
                        bool bab = (!(!aa2 && dstFound && ((AllMarked[ar2[0]].Var[2] + 1) <= dstN.Var[2])));
                        if (!bab)
                        {
                            bool xy = ((AllMarked[ar2[0]].Var[1] + ii.Value > dstN.Var[1]));
                            if (xy)
                            {
                                dstN.Var[1] = AllMarked[ar2[0]].Var[1] + ii.Value;
                                dstN.Var[3] = ar2[0];
                            }
                        }

                    }
                }
            }
        }
        public static void DijkAlgo(string x, string y)// O(N)
        {
            PrioQ PrQu;
            PrQu = new PrioQ();
            double[] arr = new double[2];
            arr[0] = 1000000;
            arr[1] = -1;
            int index1 = 0;
            for (; ; index1 -= -1) // N * O(1) = O(N)
            {
                if (!((index1 == _ACT_INC.Count) || (index1 > _ACT_INC.Count)))
                {
                    PrQu._ADD_IN_Q(arr[0], index1);
                }
                else
                {
                    break;
                }
            }
            PrQu._CHANGE_VALUES(0, _ACT_INC[x]);
            while (!PrQu.EMP) // 1 * O(1)
            {
                KeyValuePair<int, double> c = PrQu.DEQ();
                double pv = c.Value;
                int pi = c.Key;
                if (pi == _ACT_INC[y]) //O(1)
                {
                    arr[1] = pv;
                    break;
                }
                foreach (KeyValuePair<int, int> itm in _ADJ[pi]) //1 * O(1)
                { 
                    int tx = 0;
                    if (PrQu.CON((int)itm.Key, tx))
                    {
                        bool b1 = (pv != arr[0]) && (pv + 1 < PrQu._GET_VAL((int)itm.Key));
                        if (b1)
                        {
                            PrQu._CHANGE_VALUES((int)pv + 1, (int)itm.Key);
                        }
                    }

                }
            }
            bool cond = (arr[1] != -1);
            switch (cond)
            {
                case true:
                    {
                        Console.WriteLine(x + "/" + y + "\t" + arr[1] + "\n");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}

// time of complexity of GRAPH() = O(N^3)
//time of complexity of bfs_Algo() = O(N)
// time of complexity of DijkAlgo() = O(logn)




