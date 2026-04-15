using UnityEngine;
using System;

/// <summary>
/// Potion Effect:
/// Draw an ingredient from the draw pile.
/// </summary>
public class Tinkering : Potion
{

    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //Draw an ingredient from the draw pile.
    internal override void PotionEffect()
    {
        Card ingredient = GameManager.instance.deck.DealCard();
        if(ingredient == null)
        {
            Debug.Log("No more cards in the deck to draw.");
            return;
        }
        GameManager.currentPlayerTurn.AddIngredient(ingredient);
    }
}
