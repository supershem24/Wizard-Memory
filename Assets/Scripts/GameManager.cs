using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Table table;

    private Card firstCard;
    private Card secondCard;

    private List<Card> matchedCards = new List<Card>();

    public static GameManager instance;
    public static bool playerTurn;

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
            Debug.Log("Match! Keep going");
            Invoke(nameof(HandleMatch), 0.3f);
        }
        else
        {
            Debug.Log("No match!");
            Invoke(nameof(ResetCards), 1f);
        }
    }

    void HandleMatch()
    {
        if (!matchedCards.Contains(firstCard))
        {
            matchedCards.Add(firstCard);
        }
        matchedCards.Add(secondCard);

        firstCard = secondCard;
        secondCard = null;
        playerTurn = true;
    }

    void ResetCards()
    {
        secondCard.ResetCard();
        secondCard = null;

        if (matchedCards.Count == 0)
        {
            firstCard.ResetCard();
        }
        else
        {
            foreach (Card matched in matchedCards)
            {
                table.ReplaceCard(matched);
            }
        }

        matchedCards.Clear();
        firstCard = null;
        EnablePlayerTurn();
    }

    void EnablePlayerTurn()
    {
        playerTurn = true;
    }


}
