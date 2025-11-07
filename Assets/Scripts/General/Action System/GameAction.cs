using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public abstract class GameAction
{
    public List<GameAction> PreReactions { get; private set; } = new();
    public List<GameAction> PreformReactions { get; private set; } = new();
    public List<GameAction> PostReaction { get; private set; } = new();
}
