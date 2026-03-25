using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Deck : MonoBehaviour
{

    [SerializeField]
    public List<string> deckCards; //ingiedient of which card is
    public GameObject cardPrefab;

    // Added Colors for testing. an be deleted later with public void SetCardColor(Color color) in card.cs
    public static readonly Color[] VALUE_COLORS = new Color[]
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.black
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Shuffle the deck
    public void ShuffleDeck()
    {
        string temp;
        for (int i = 0;  i < deckCards.Count; i++)
        {
            int rand = Random.Range(0, deckCards.Count - 1);

            temp = deckCards[i];
            deckCards[i] = deckCards[rand];
            deckCards[rand] = temp;
        }
    }

    //Creates a card at the deck's current position, and gives the card object to whatever called it
    public Card DealCard()
    {
        if (deckCards.Count <= 0)
        {
            Debug.LogError("NO MORE CARDS IN DECK");
            return null;
        }

        // Create the Card
        GameObject card = Instantiate(cardPrefab);
        Card c = card.GetComponent<Card>();
        c.ResetCard();

        // Assign number
        /*int value = deckCards[deckCards.Count - 1];
        c.ChangeCardNumber(value);
        c.SetCardColor(VALUE_COLORS[value - 1]);*/

        //Assign card to ingredient
        string ingredient = deckCards[deckCards.Count - 1];
        c.CreateCard(ingredient);
        c.testNum = Random.Range(0, 2);

        // Remove the card from the deck
        deckCards.RemoveAt(deckCards.Count - 1);

        // Return the Card script
        return c;
    }

    //Sameple deck of numbers
    /*public void CreateSampleDeck()
    {
        deckCards.Clear();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                deckCards.Add(i+1);
            }
        }

    }*/

    //Sample deck of strings
    public void CreateSampleDeck()
    {
        deckCards.Clear();

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                deckCards.Add("Berry");
            }
        }

    }
}
