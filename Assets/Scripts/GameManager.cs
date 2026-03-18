using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Table table;

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
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            playerTurn = false;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        playerTurn = false;

        if (firstCard.testNum == secondCard.testNum)
        {
            Debug.Log("Match!");
            Invoke(nameof(HandleMatch), 2f);
        }
        else
        {
            Debug.Log("No match!");
            Invoke(nameof(ResetCards), 1f);
        }
    }

    void HandleMatch()
    {
        table.ReplaceCard(firstCard);
        table.ReplaceCard(secondCard);

        ResetSelection();
        EnablePlayerTurn();
    }

    void ResetCards()
    {
        firstCard.ResetCard();
        secondCard.ResetCard();
        ResetSelection();

        EnablePlayerTurn();
    }

    void ResetSelection()
    {
        firstCard = null;
        secondCard = null;
    }

    void EnablePlayerTurn()
    {
        playerTurn = true;
    }


}
