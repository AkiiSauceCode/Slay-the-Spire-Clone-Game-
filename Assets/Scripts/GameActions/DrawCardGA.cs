using UnityEngine;

public class DrawCardGA : GameAction
{
 public int Amount { get; private set; }
 
    public DrawCardGA(int amount)
    {
        Amount = amount;
    }
}
