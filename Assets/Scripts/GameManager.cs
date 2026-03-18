using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Card firstCard;
    private Card secondCard;

    public static GameManager instance;
    public static bool playerTurn;

    // SHION: Three things
    // A. Make flipping cards have a delay as to not keep cards flipped through spam
    // B. Make the deck have cards that match to actually test matching cards
    // C. Make matching cards leave the game board, and put new cards from the deck in those places.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTurn = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardSelected(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (firstCard.testNum == secondCard.testNum)
        {
            Debug.Log("Match!");
            ResetSelection();
        }
        else
        {
            Debug.Log("No match!");
            Invoke(nameof(ResetCards), 1f);
        }
    }

    void ResetCards()
    {
        firstCard.ResetCard();
        secondCard.ResetCard();
        ResetSelection();
    }

    void ResetSelection()
    {
        firstCard = null;
        secondCard = null;
    }
}
