using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestSystem : MonoBehaviour
{

    [SerializeField] private List<CardData> deckData;
    
    private void Start()
    {
        CardSystem.Instance.Setup(deckData);
    }



}
