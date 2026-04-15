using UnityEngine;

public abstract class Player : MonoBehaviour
{
    int score = 0;
    Inventory inventory;
    public int getScore() { return score; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GetComponent<Inventory>();
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

    /// <summary>
    /// Potion Methods
    /// </summary>

    // Choose an ingredient (NEEDS FRONT END INTEGRATION)
    public Card ChooseIngredient()
    {
        int rand = Random.Range(0, inventory.items.Count);
        return inventory.items[0];
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
