using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private List<CardData> deckData;
    private void Start()
    {
        CardSystem.Instance.Setup(deckData);
        
        RefillManaGA refillManaGA = new();
        ActionSystem.Instance.Perform(refillManaGA, () =>
        {
            DrawCardsGA drawCardsGA = new(5);
            ActionSystem.Instance.Perform(drawCardsGA);
        });
    }

}
