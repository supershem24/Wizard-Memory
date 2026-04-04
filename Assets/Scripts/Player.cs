using UnityEngine;

public abstract class Player : MonoBehaviour
{
    int score = 0;
    public int getScore() { return score; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SelectCardsUpdate();
    }

    //Allows the player's score to be changed by a certain amount, can be positive or negative (returns the new score after the change)
    public int ChangeScore(int scoreChange)
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


}
