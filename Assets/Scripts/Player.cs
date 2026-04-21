using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public abstract class Player : MonoBehaviour
{
    public static CardSelectionType requestedParent = CardSelectionType.BoardFlip;
    public enum CardSelectionType { BoardFlip, Inventory, BoardSeek, BoardTrap, None }

    int score = 0;
    public Inventory inventory;
    public int getScore() { return score; }

    public bool getIngredient = false;
    public bool getPlayer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        SelectCardsUpdate();
    }

    //Allows the player's score to be changed by a certain amount, can be positive or negative (returns the new score after the change)
    public int AddScore(int scoreChange)
    {
        score += scoreChange;
        return score;
    }

    internal virtual void SelectCardsUpdate()
    {
        //past here it has to be the current player's turn to interact with things
        if (!(GameManager.currentPlayerTurn == this) || !GameManager.playerTurn)
            return;
    }

    //NEEEED FOR FRONT INTEGRATION ON INTERACTING WITH CARDS

    /*internal virtual void SelectCards()
    {
        //past here it has to be the current player's turn to interact with things
        if (!(GameManager.currentPlayerTurn == this) || !GameManager.playerTurn)
            return;
    }*/

    public virtual void AfterMatching()
    {
        GameManager.instance.SwitchPlayerTurn();
    }

    /// <summary>
    /// Potion Methods
    /// </summary>

    // Choose an ingredient (NEEDS FRONT END INTEGRATION)
    public void ChooseIngredient()
    {
        //Change camera scene (TODO: Change to inventory camera for the current player)
        CameraSwitch.wantedCamera = GetComponentInChildren<Camera>();
        GameManager.instance.cameraManager.CycleCamera();

        //Set boolean to true to choose an ingriedient for a potion
        requestedParent = CardSelectionType.Inventory;
    }

    //Add an ingredient to the player's inventory (NEEDS FRONT END INTEGRATION)
    public void AddIngredient(Card ingredient)
    {
        inventory.AddItem(ingredient);
    }

    //Remove an ingredient from the player's inventory (NEEDS FRONT END INTEGRATION)
    public void RemoveIngredient(Card ingredient)
    {
        inventory.RemoveItem(ingredient);
    }


}
