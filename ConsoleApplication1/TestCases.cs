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
    class TestCases : GlobalAlgorithms
    {
        public static void LD_MOVIES()
        {
            string[] mo = new string[7];
            /*Sample*/
            mo[0] = "movies1sample.txt";
            /*Complete small case 1*/
            mo[1] = "Movies193comsmall.txt";
            /*Complete small case 2*/
            mo[2] = "Movies187comsmall.txt";
            /*Complete medium case 1*/
            mo[3] = "Movies967commed.txt";
            /*Complete medium case 2*/
            mo[4] = "Movies4736commed.txt";
            /*Complete large*/
            mo[5] = "Movies14129comlrg.txt";
            /*Complete extreme*/
            mo[6] = "Movies122806comex.txt";
            FileStream MOVIE_FILE; StreamReader MOVIE_READER;
            MOVIE_FILE = new FileStream(mo[0], FileMode.Open, FileAccess.Read);
            MOVIE_READER = new StreamReader(MOVIE_FILE);
            string ln = null;
            for (; ; )
            {
                if (MOVIE_READER.Peek() == -1)
                {
                    break;
                }
                else
                {
                    MOVIE MOVIE;
                    MOVIE = new MOVIE();
                    ln = MOVIE_READER.ReadLine();
                    char slash = '/';
                    string[] split = ln.Split(slash);
                    int indx2 = 0, endloop2 = 10;
                    for (; ; indx2 -= -1)
                    {
                        if (!(indx2 >= endloop2))
                        {
                            switch (indx2)
                            {
                                case 0:
                                    {
                                        MOVIE.Name = split[indx2];
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
                    int indx = 1, endloop = split.Count();
                    for (; ; indx -= -1)
                    {
                        if (!(indx >= endloop))
                        {
                            _ALL_ACTORS.Add(split[indx]);

                            MOVIE.Actors.Add(split[indx]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    _All_MOVIE.Add(MOVIE);
                }
            }
            MOVIE_READER.Close();
            GRAPH();
        }
        public static void LD_QUERY(int ch)
        {
            string[] qu = new string[11];
            /*Sample*/
            qu[0] = "queries1sample.txt";
            /*Complete small case 1*/
            qu[1] = "queries110comsmall.txt";
            /*Complete small case 2*/
            qu[2] = "queries50comsmall.txt";
            /*Complete medium case 1*/
            qu[3] = "queries85commed.txt";
            qu[4] = "queries4000commed.txt";
            /*Complete medium case 2*/
            qu[5] = "queries110commed.txt";
            qu[6] = "queries2000commed.txt";
            /*Complete large*/
            qu[7] = "queries26comlrg.txt";
            qu[8] = "queries600comlrg.txt";
            /*Complete extreme*/
            qu[9] = "queries22comex.txt";
            qu[10] = "queries200comex.txt";
            FileStream QUERY_FILE; StreamReader QUERY_READER;
            QUERY_FILE = new FileStream(qu[0], FileMode.Open, FileAccess.Read); 
            QUERY_READER = new StreamReader(QUERY_FILE);
            string[] output = new string[5];
            output[0] = "Query";
            output[1] = "Degree";
            output[2] = "Relation";
            output[3] = "Chain";
            output[4] = "\t";
            string _Actor = null;
            int end = -1;
            switch (ch)
            {
                case 1:
                    {
                        Console.WriteLine(" _____________________________________");
                        Console.WriteLine("|" + output[0] + "|" + output[4] + output[1] + "|" + output[2] + " " + "|" + output[4] + output[3] + " " + "|");
                        Console.WriteLine("|_____|_______|_________|_____________|\n");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(" _____________");
                        Console.WriteLine("|" + output[0] + "|" + output[4] + output[1] + "|");
                        Console.WriteLine("|_____|_______|\n");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("invalid input , enter (1 or 2)");
                        break;
                    }
            }
            Stopwatch stopwatch1 = new Stopwatch(); Stopwatch stopwatch2 = new Stopwatch();
            for (; ; )
            {
                if (QUERY_READER.Peek() == end)
                {
                    break;
                }
                else
                {
                    QUERY_ACTS QUERY;
                    QUERY = new QUERY_ACTS();
                    _Actor = QUERY_READER.ReadLine();
                    char slash = '/';
                    string[] split = _Actor.Split(slash);
                    for (int i = 0; i <= 1; i++)
                    {
                        QUERY.Acts[i] = split[i];
                    }
                    switch (ch)
                    {
                        case 1:
                            {
                                stopwatch1.Start();
                                bfs_Algo(QUERY.Acts[0], QUERY.Acts[1]);
                                stopwatch1.Stop();
                                break;
                            }
                        case 2:
                            {
                                stopwatch2.Start();
                                DijkAlgo(QUERY.Acts[0], QUERY.Acts[1]);
                                stopwatch2.Stop();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            QUERY_READER.Close();
            switch (ch)
            {
                case 1:
                    {
                        Console.WriteLine("Execution Time [before optimized] = {0}", stopwatch1.Elapsed);
                        Console.WriteLine("Execution Time [before optimized] = {0} ms", stopwatch1.ElapsedMilliseconds);

                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Execution Time [after optimized] = {0}", stopwatch2.Elapsed);
                        Console.WriteLine("Execution Time [after optimized] = {0} ms", stopwatch2.ElapsedMilliseconds);
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
