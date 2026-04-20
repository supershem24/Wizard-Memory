using UnityEngine;

public class Human : Player
{
    
    internal override void SelectCardsUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse position into the world
            Ray ray = CameraSwitch.currentCamera.ScreenPointToRay(Input.mousePosition);
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
                
                //if the selected object is a player icon, and the player potion select is true (TODO CHANGE HERE FOR ICON)
                if(selectedObject.GetComponent<PlayerIcon>() != null && getPlayer)
                {
                    getPlayer = false;
                    Potion.currentPotion.AfterPlayerSelect(selectedObject.GetComponent<PlayerIcon>().connectedPlayer);
                }
                //send the selected player to the current potion

                //for interacting with cards
                if (selectedObject.GetComponent<Card>() != null)
                {
                    if (requestedParent == CardSelectionType.Inventory && selectedObject.transform.parent.tag == "Inventory")
                    {
                        selectedObject.GetComponent<Card>().SelectCard();
                        Potion.currentPotion.AfterCardSelect(selectedObject.GetComponent<Card>());
                        return;
                    }
                    else if(requestedParent == CardSelectionType.BoardFlip && selectedObject.transform.parent == GameManager.instance.board.transform)
                    {
                        selectedObject.GetComponent<Card>().OnCardClicked();
                        return;
                    }
                    //SELECT CARDS WILL GO HERE INSTAD
                }
            }
        }
    }

}
