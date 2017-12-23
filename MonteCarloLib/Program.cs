using MonteCarloLib.Models;
using System;

namespace MonteCarloLib
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Monte Carlo  Algorithm Tests");

            while (true)
            {
                Console.WriteLine(); 

                var s1 = new Node("nod1");
                s1.AddAction(new NodeAction(10, true)); 


                var s2 = new Node("nod2");
                s2.AddAction(new NodeAction(new Random().Next(100), true));
                s2.AddAction(new NodeAction(10, false)); 
                var s3 = new Node("nod3");
                s3.AddAction(new NodeAction(new Random().Next(100), true));
                s3.AddAction(new NodeAction(20, false)); 
                 
                var s4 = new Node("nod4");  
                s4.AddAction(new NodeAction(new Random().Next(100), true));
                s4.AddAction(new NodeAction(2, false)); 
                var s5 = new Node("nod5"); 
                s5.AddAction(new NodeAction(new Random().Next(100), true));
                s5.AddAction(new NodeAction(2, false)); 
                var s6 = new Node("nod6");
                s6.AddAction(new NodeAction(new Random().Next(100), true)); 
                var s7 = new Node("nod7");
                s7.AddAction(new NodeAction(2, true));

                s2.AddChild(s4);
                s2.AddChild(s5); 
                s3.AddChild(s6);
                s3.AddChild(s7); 
                s1.AddChild(s2);
                s1.AddChild(s3);


                var simulation = new Simulation((int visit, long time) => visit < 100); 
                simulation.Simulate(s1, new Player());


                PrintTree(s1, "", false);

                Console.WriteLine();
                Console.ReadLine();
            }
             
        
        }



         
         





        /// <summary>
        /// PrintTree 
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="indent"></param>
        /// <param name="last"></param>
        /// <param name="weight"></param>
        static void PrintTree(Node tree, string indent, bool last, float weight = 0)
        {

            Console.WriteLine($" {indent}-{tree.ToString()}    ");
            indent += last ? "   " : "|  ";
            for (int i = 0; i < tree._ChildNodes.Count; i++)
                PrintTree(tree._ChildNodes[i], indent, i == tree._ChildNodes.Count - 1);
        }



    }
}
