# MonteCarloTreeSearch

Simplified Monte-Carlo  Tree search implementation   example project 

# The Monte Carlo Method:  
 
Monte Carlo methods (or Monte Carlo experiments) are a broad class of computational algorithms that rely on repeated random sampling to obtain numerical results.
 
In other words, Monte Carlo method allow you build forecasts models by randomly sampling given set of states. Which can be very useful in building a vast range of forecasts and game ai development.  
 
     
  
## 1 Tree Traversal:  

At First step we starting from  State(0)   and then we have to ask ourselves : “Is current Node is a  leaf node ? (has not been expanded yet)”
If  yes then  “is the current value of node == 0”  if yes then  go directly to rollout phase  
Otherwise   if it is not a leaf node then set the current state first child that maximize UCB1 (See example project ), repeat this step until leaf node will be found..   
    
## 2 Node Expansion   
 
  At second step we have to ask “If it is a leaf node”  and it’s value > 0   then we do expansion  
  Foreach available action form current add new state to tree , set current = first new added node  
   
## 3 Rollout (Simulation)  
 
Rollout is a process of randomly sampling available actions of given state until we get terminal state “Win/Lose”
     
## 4 Backpropagation :   

   Finally, we backpropagate last result and number of visits back to the parent node.  
   After algorithm starts from step 1 and it’s running infinity or until infinity number of iterations.


