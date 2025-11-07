using UnityEngine;

public class EndTurnButtonUi : MonoBehaviour
{
    public void OnClick()
    {
        EnemyTurnGA enemyTurnAction = new(); 
        ActionSystem.Instance.Perform(enemyTurnAction); 
        
    }
}
