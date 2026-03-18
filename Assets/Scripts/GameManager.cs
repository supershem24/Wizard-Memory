using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Card firstCard;
    private Card secondCard;

    public static GameManager instance;
    public static bool playerTurn;


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
