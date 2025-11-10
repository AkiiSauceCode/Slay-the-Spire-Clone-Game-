using UnityEngine;

public class PlayCardGA : GameAction
{
    public Card Card { get; set; }
    public CardView CardView { get; set; }

    public PlayCardGA(Card card, CardView cardView)
    {
        Card = card;
        CardView = cardView;
    } 
}
