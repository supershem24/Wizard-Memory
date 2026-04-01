using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

                if (!GameManager.playerTurn)
                    return;

                if(selectedObject.GetComponent<Card>() != null)
                {
                    Card selectedCard = selectedObject.GetComponent<Card>();
                    selectedCard.Flip();
                    GameManager.instance.CardSelected(selectedCard);
                }
            }
        }
    }

    
    void SelectCard()
    {
        
    }
}
