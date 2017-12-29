using MonteCarloLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MonteCarloLib
{
    public class Simulation
    {  
        private Func<int, long, bool> _predicate;   
        public Simulation(Func<int, long, bool> predicate)
        {
            _predicate = predicate; 
        }   
        public void Simulate(Node root, Player player )
        {
            int number = 0;

            Stopwatch stop = Stopwatch.StartNew(); 
            Queue<Node> quue = new Queue<Node>();
              
            while (_predicate(number,stop.ElapsedMilliseconds)) 
            {
                quue.Enqueue(root);

                while (quue.Count > 0)
                {     
                    Node current = quue.Dequeue();    

                    // Selection  
                    if (current.ExpandedNodes.Count > 0)
                    {
                        current = current._ChildNodes.OrderByDescending(c => c.UCB1).FirstOrDefault();                    
                        current._ChildNodes.OrderByDescending(c => c.UCB1).ToList().ForEach(x => quue.Enqueue(x));
                     
                    }    
                    
                    // Expansion 
                    if (current.Points > 0 && current._ChildNodes.Count > 0)
                    {
                        current.ExpandedNodes = current._ChildNodes;
                        current = current.ExpandedNodes.FirstOrDefault();
                    }    

                    // Rollout    
                    while (!player.TakeAction(current, current.GetRandomAction()))
                            player.AcceptLastMove();


                    
                    // Back Propogation
                    while (current != null)
                    { 
                        
                        current.NumberOfVisits++; 
                        if (current.Points == double.MaxValue)
                            current.Points = 0;  
                        current.Points += player.LastAction?._value ?? 0;

                        current = current.Parent;
                        
                       
                    }
                    
                    number++; 
                } 
            }  
            


        }



    }
}
