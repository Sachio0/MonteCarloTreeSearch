using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarloLib.Models
{
    public  class NodeAction
    {
        public double _value;
        public bool Terminal { get;   }  

        public NodeAction(double val, bool terminal)
        {
            _value = val;
            Terminal = terminal;  
        }
        
        public double Execute() => _value; 


    }
}
