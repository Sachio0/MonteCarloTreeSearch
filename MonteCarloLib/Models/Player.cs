using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarloLib.Models
{
    public   class Player
    { 

        public NodeAction LastAction { set; get; }

        public bool TakeAction(Node node, NodeAction action)
        {
            double res = 0; 
            for (int x = 10; x < 10000; x++)
                res =Math.Sqrt(x) * x;
             

            if (action == null)
                return true;
            LastAction = action;
            node.AvalableActions.Remove(action);
            return action.Terminal;  
        }


        public void AcceptLastMove()
        {

        }



    }
}
