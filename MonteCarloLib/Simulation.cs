using MonteCarloLib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MonteCarloLib
{
    public class Simulation
    { 

        private Func<int, long, bool> _predicate;  
        
        public Simulation(Func<int, long, bool> predicate)
        {
            _predicate = predicate; 
        }
              
        public void Simulate(Node root, Player player)
        {
            int number = 0;

            Stopwatch stop = Stopwatch.StartNew();
             
            while (_predicate(number,stop.ElapsedMilliseconds))
            { 
                Node current = root;

                if (current.ExpandedNodes.Count>0)
                { 
                    current = current._ChildNodes.OrderByDescending(c => c.UCB1).FirstOrDefault(); 
                }   

                // Leaf Node 
                if (current.ExpandedNodes.Count == 0)
                {
                     if (current.Points>0)
                    {
                        current.ExpandedNodes = current._ChildNodes;
                        current = current.ExpandedNodes.FirstOrDefault();  
                    } 
                }     

                // Rollout :   
                while (!player.TakeAction(current, current.GetRandomAction()))
                {
                    if (player.LastAction != null)
                    {
                        current.Points += player.LastAction._value; 
                    } 
                }     

                // Back Prop:  
                while (current != null)
                {
                    current.NumberOfVisits++;
                    current.Points += player.LastAction?._value ?? 0; 
                    current = current.Parent;
                }  

                number++;  
            } 
        }



    }
}
