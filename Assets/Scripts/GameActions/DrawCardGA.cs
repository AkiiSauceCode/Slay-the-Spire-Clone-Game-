using UnityEngine;

public class DrawCardsGA : GameAction
{
 public int Amount { get; private set; }
 
    public DrawCardsGA(int amount)
    {
        Amount = amount;
    }
}
