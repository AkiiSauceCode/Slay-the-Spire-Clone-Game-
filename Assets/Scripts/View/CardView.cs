using TMPro;
using UnityEngine;


public class CardView : MonoBehaviour
{
   [SerializeField] private TMP_Text title;
   [SerializeField] private TMP_Text description;
   [SerializeField] private TMP_Text mana;
   [SerializeField] private SpriteRenderer imageSR;
   [SerializeField] private GameObject wrapper;
   [SerializeField] private LayerMask dropLayer;

   public Card Card { get; private set; }
   private Vector3 dragStartPosition;
   private Quaternion dragStartRotation;


   public void Setup(Card card)
   {
      Card = card;
      title.text = card.Title;
      description.text = card.Description;
      mana.text = card.Mana.ToString();
      imageSR.sprite = card.Image;
   }

   void OnMouseEnter()
   {
      if(!Interactions.Instance.PlayerCanHover()) return;
      wrapper.SetActive(false);
      Vector3 pos = new(transform.position.x, -2, 0);
      CardViewHoverSystem.Instance.Show(Card, pos);
    }

   void OnMouseExit()
   {
      if(!Interactions.Instance.PlayerCanHover()) return;
      wrapper.SetActive(true);
      CardViewHoverSystem.Instance.Hide();
   }
   void OnMouseDown()
   {
      if (!Interactions.Instance.PlayerCanInteract()) return;
      Interactions.Instance.PlayerIsDraggingCard = true;
      wrapper.SetActive(true);
      CardViewHoverSystem.Instance.Hide();
      dragStartPosition = transform.position;
      dragStartRotation = transform.rotation;
      transform.rotation = Quaternion.Euler(0, 0, 0);
      transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);

   }
   void OnMouseDrag()
   {
      if (!Interactions.Instance.PlayerCanInteract()) return;
      transform.position = MouseUtil.GetMousePositionInWorldSpace(-1);

   }
   void OnMouseUp()
   {
      if (!Interactions.Instance.PlayerCanInteract()) return;
      if (ManaSystem.Instance.HasEnoughMana(Card.Mana) && Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hitInfo, 10f, dropLayer))

      {
         PlayCardGA playCardGA = new(Card);
         ActionSystem.Instance.Perform(playCardGA);

         Debug.Log("Played Card: " + Card.Title);
      }
      else
      {
         transform.position = dragStartPosition;
         transform.rotation = dragStartRotation;
      }
      Interactions.Instance.PlayerIsDraggingCard = false;

   }


}
