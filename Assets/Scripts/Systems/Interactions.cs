using UnityEngine;

public class Interactions : Singleton<Interactions>
{
    public bool PlayerIsDraggingCard { get; set; } = false;
    public bool PlayerCanInteract()
    {
        if (!ActionSystem.Instance.IsPerforming) return true;
        else return false;

    }
    public bool PlayerCanHover()
    {
        if (PlayerIsDraggingCard) return false;
        return true;
    }




}
