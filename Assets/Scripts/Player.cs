using UnityEngine;

public abstract class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectCardsUpdate();
    }

    internal virtual void SelectCardsUpdate()
    {
        //past here it has to be the current player's turn to interact with things
        if (!(GameManager.currentPlayerTurn == this) || !GameManager.playerTurn)
            return;
    }


}
