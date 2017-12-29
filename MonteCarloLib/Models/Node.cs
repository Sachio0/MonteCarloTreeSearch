using System;
using System.Collections.Generic;
using System.Text;

namespace MonteCarloLib.Models
{
    public class Node
    {
        public double Points { set; get; }

        public Node Parent { set; get; }

        public int NumberOfVisits { set; get; }

        public List<NodeAction> AvalableActions { set; get; }

        public  List<Node> _ChildNodes;

        public List<Node> ExpandedNodes { set; get; }
         
         
        public string Name { set; get; } 

        public double Value { set; get; }

        public double UCB1
        {
            get
            {
                if (Parent != null && Parent.NumberOfVisits>0)
                {
                   var res =  (Points/NumberOfVisits) +   (Math.Sqrt(2 * Math.Log(Parent.NumberOfVisits) / Parent.NumberOfVisits+ NumberOfVisits));
                    if (double.IsNaN(res))
                        return double.MaxValue;
                    return res; 
                } 
                return 0;
            }
        }  

        public Node()
        {
            _ChildNodes = new List<Node>();
            AvalableActions = new List<NodeAction>();
            ExpandedNodes = new List<Node>();
        }


        public Node(string name):this()
        {
            Name = name;  
        }
         
        public void AddChild(Node node)
        {
            node.Parent = this;
            _ChildNodes.Add(node);
        }

        public void AddAction(NodeAction action) => AvalableActions.Add(action);
          
        
        public override string ToString() => $"{Name}=>{NumberOfVisits} - {UCB1}"; 
        
         
        public NodeAction GetRandomAction()
        {
            var random = new Random();
            if (AvalableActions.Count > 0)
                return AvalableActions[random.Next(AvalableActions.Count-1)];  
            return null; 
           
        }


    }
}
