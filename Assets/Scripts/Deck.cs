using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Deck : MonoBehaviour
{

    [SerializeField]
    public List<int> deckCards;
    public GameObject cardPrefab;

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
        int temp;
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

        //TESTING STUFF BEGIN
        //GameObject card = Instantiate<GameObject>(cardPrefab);
        //card.GetComponent<Card>().ChangeCardNumber(deckCards[deckCards.Count - 1]);
        //TESTING STUFF END

        //deckCards.RemoveAt(deckCards.Count - 1);
        //return card.GetComponent<Card>();

        // Create the Card
        GameObject card = Instantiate(cardPrefab);
        Card c = card.GetComponent<Card>();
        c.ResetCard();

        // Assign number
        int value = deckCards[deckCards.Count - 1];
        c.ChangeCardNumber(value);

        // Remove the card from the deck
        deckCards.RemoveAt(deckCards.Count - 1);

        // Return the Card script
        return c;
    }

    //Sameple deck of numbers
    public void CreateSampleDeck(int num)
    {
        for(int i = 0; i < num; i++)
        {
            deckCards.Add(i+1);
        }
        
    }
}
