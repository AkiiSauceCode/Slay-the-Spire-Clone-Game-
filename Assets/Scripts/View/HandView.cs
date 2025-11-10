using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;

public class HandView : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    private readonly List<CardView> cards = new();

    public IEnumerator AddCard(CardView cardView)
    {
        cards.Add(cardView);
        yield return UpdateCardPositions(0.15f);
    }
    public CardView RemoveCard(Card card, float updateDuration = 0.15f)
    {
        CardView cardView = GetCardView(card);
        if (cardView == null) return null;
        cards.Remove(cardView);
       StartCoroutine(UpdateCardPositions(0.15f));
        return cardView;
    }
    private CardView GetCardView(Card card)
    {
        return cards.Where(cardView => cardView.Card == card).FirstOrDefault();
    }
    public IEnumerator UpdateCardPositions(float duration)
    {
        if (cards.Count == 0) yield break;
        float cardSpacing = 1f / 9f;
        float firstCardPosition = 0.5f - (cards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < cards.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(Vector3.Cross(-up, forward).normalized, up);
            cards[i].transform.DOMove(splinePosition + transform.position + 0.01f * Vector3.back, duration);
            cards[i].transform.DORotate(rotation.eulerAngles, duration);
        }
        yield return new WaitForSeconds(duration);

    }

 
}
