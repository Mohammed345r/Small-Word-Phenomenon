using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MoviesActors
    {
        public class MOVIE
        {
            public string Name;
            public List<string> Actors = new List<string>();
        }
        public class QUERY_ACTS
        {
            public string[] Acts = new string[2];
        }
        public class MARKED
        {
            public int[] Var = new int[4];
            public MARKED() { }
            public MARKED(int x, int y, int z, int w)
            {
                this.Var[0] = x;
                this.Var[1] = y;
                this.Var[2] = z;
                this.Var[3] = w;
            }
        }
        public class PrioQ
        {
            public Dictionary<int, int> _ACTPOS = new Dictionary<int, int>();
            public List<KeyValuePair<int, double>> _BHP = new List<KeyValuePair<int, double>>();
            public void _CHANGE_ELEMENTS(int y, int x) //O(1)
            {
                int[] arr = new int[2];
                arr[0] = x;
                arr[1] = y;
                _ACTPOS[_BHP[arr[1]].Key] = arr[0];
                _ACTPOS[_BHP[arr[0]].Key] = arr[1];
                KeyValuePair<int, double> _F = _BHP[arr[0]];
                _BHP[arr[0]] = _BHP[arr[1]];
                _BHP[arr[1]] = _F;

            }
            public void _CHANGE_VALUES(int nv, int id, float f = 0) //O(1)
            {
                int[] arr = new int[3];
                arr[0] = nv;
                arr[1] = id;
                arr[2] = _ACTPOS[arr[1]];
                _BHP[arr[2]] = new KeyValuePair<int, double>(arr[1], arr[0]);
                _HEAPETB(arr[2]);

            }
            public void _ADD_IN_Q(double d, int i, float f = 0) //O(1)
            {
                Add(i, d); //O(1)
            }
            public bool EMP 
            {
                get //O(1)
                {
                    int x = _BHP.Count;
                    switch (x)
                    {
                        case 0:
                            {
                                return true;
                                break;
                            }
                        default:
                            {
                                return false;
                                break;
                            }
                    }
                }
            }
            public bool CON(float i, int x = 0) //O(1)
            {
                return _ACTPOS.ContainsKey((int)i);
            }
            public void Add(int i, double d, float f = 0, string s = " ") //O(1)
            {
                _BHP.Add(new KeyValuePair<int, double>(i, d));
                int x = _BHP.Count;
                _ACTPOS.Add(i, x - 1);
                _HEAPETB(x - 1);
            }
            public void _HEAPBTE(float pos) //O(1)
            {
                int y = _BHP.Count;
                if (!((int)pos < y)) //O(1)
                {
                    return;
                }
                for (; ; )//O(1)
                {
                    int smallest = (int)pos;
                    int[] va = new int[2];
                    va[0] = (2 * (int)pos) + 1;
                    va[1] = (2 * (int)pos) + 2;
                    bool[] co = new bool[3];
                    co[0] = (va[0] < y) && (_BHP[smallest].Value > _BHP[va[0]].Value);
                    if (co[0])//O(1)
                    {
                        smallest = va[0];
                    }
                    co[1] = (va[1] < y) && (_BHP[smallest].Value > _BHP[va[1]].Value);
                    if (co[1])//O(1)
                    {
                        smallest = va[1];
                    }
                    co[2] = (smallest != (int)pos);
                    if (co[2]) //O(1)
                    {
                        _CHANGE_ELEMENTS((int)pos, smallest);
                        pos = smallest;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            public void _REMOVEBASE() //O(1)
            {
                int[] arr = new int[2];
                arr[0] = 1;
                arr[1] = _BHP.Count;
                if (!(arr[1] > arr[0]))
                {
                    _BHP.Clear();
                    _ACTPOS.Clear();
                    return;
                }
                _ACTPOS.Remove(_BHP[0].Key);
                _BHP[0] = _BHP[(arr[1] - 1)];
                _ACTPOS[_BHP[0].Key] = 0;
                _BHP.RemoveAt((arr[1] - 1));
                _HEAPBTE(0);
            }
            public double _REMOVEVAL() //O(1)
            {
                return DEQ().Value;
            }
            public int _REMOVEKEY()//O(1)
            {
                return DEQ().Key;
            }
            public int _HEAPETB(int position, float f = 0) //O(1)
            {
                int v = _BHP.Count;
                bool x = (!(position < v));
                switch (x) //O(1)
                {
                    case true:
                        {
                            return -1;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                for (; (!(position <= 0)); ) //O(1)
                {
                    int BIGposition;
                    BIGposition = (position - 1) / 2;
                    bool y = (_BHP[BIGposition].Value > _BHP[position].Value);
                    if (y == true)
                    {
                        _CHANGE_ELEMENTS(position, BIGposition);
                        position = BIGposition;
                    }
                    else
                    {
                        break;
                    }
                }
                return position;
            }
            public double _PEEKVAL()//O(1)
            {
                return _PEEK().Value;
            }
            public double _GET_VAL(int i, float f = 0)//O(1)
            {
                bool x = CON(i);
                switch (x)
                {
                    case true:
                        {
                            return _BHP[_ACTPOS[i]].Value;
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException("INDEX ISN'T HERE");
                            break;
                        }
                }
            }
            public KeyValuePair<int, double> DEQ() //O(1)
            {
                bool x = (!EMP);
                switch (x)//O(1)
                {
                    case true:
                        {
                            KeyValuePair<int, double> result = _BHP[0];
                            _REMOVEBASE();//O(1)
                            return result;
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException("PQ EMPTY");
                            break;
                        }
                }
            }
            public KeyValuePair<int, double> _PEEK()
            {
                bool x = (!EMP);
                switch (x)
                {
                    case true:
                        {
                            return _BHP[0];
                            break;
                        }
                    default:
                        {
                            throw new InvalidOperationException("PQ EMPTY");
                            break;
                        }
                }
            }
        }
        public static List<Dictionary<string, string>> _AAM = new List<Dictionary<string, string>>();
        public static List<MOVIE> _All_MOVIE = new List<MOVIE>();
        public static List<Dictionary<int, int>> _ADJ = new List<Dictionary<int, int>>();
        public static Dictionary<int, string> _REV_INC = new Dictionary<int, string>();
        public static Dictionary<string, int> _ACT_INC = new Dictionary<string, int>();
        public static HashSet<string> _ALL_ACTORS = new HashSet<string>();
        public static int iterator = 0;
    }
}

//THE FINAL ORDER OF THIS CODE = O(1)
