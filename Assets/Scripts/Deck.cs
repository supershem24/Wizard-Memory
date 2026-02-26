using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{

    public List<Card> deckCards;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShuffleDeck();
        DealCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //UNTESTED
    void ShuffleDeck()
    {
        List<Card> newCards = new List<Card>(deckCards.Count);
        for (int i = 0;  i < deckCards.Count; i++)
        {
            int rand = Random.Range(0, deckCards.Count - 1);
            if (newCards[rand] != null)
            {
                i--;
                continue;
            }

            newCards[rand] = deckCards[i];
        }
        deckCards = newCards;
    }

    //UNTESTED
    Card DealCard()
    {
        if (deckCards.Count <= 0)
            Debug.LogError("NO MORE CARDS IN DECK"); return null;

        Card card = deckCards[-1];
        deckCards.RemoveAt(deckCards.Count - 1);
        return card;
    }
}
