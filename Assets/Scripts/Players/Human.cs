using UnityEngine;

public class Human : Player
{
    
    internal override void SelectCardsUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position into the world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast and check if it hits anything
            if (Physics.Raycast(ray, out hit))
            {
                // A hit was detected, you can now access the hit object
                GameObject selectedObject = hit.collider.gameObject;
                //Debug.Log("Selected Object: " + selectedObject.name);

                //past here it has to be the player's turn to interact with things
                if (!(GameManager.currentPlayerTurn == this) || !GameManager.playerTurn)
                    return;

                //for interacting with unflipped cards
                if (selectedObject.GetComponent<Card>() != null && !selectedObject.GetComponent<Card>().IsFlipped)
                {
                    Card selectedCard = selectedObject.GetComponent<Card>();
                    selectedCard.Flip();
                    GameManager.instance.CardSelected(selectedCard);
                }
            }
        }
    }

}
