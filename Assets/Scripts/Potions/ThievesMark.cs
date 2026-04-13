using UnityEngine;

/// <summary>
/// Potion Effect:
/// Steal an ingredient from an opponent.
/// </summary>
public class ThievesMark : Potion
{

    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //Steal an ingredient from an opponent.
    internal override void PotionEffect()
    {
        Player player = GameManager.instance.ChoosePlayer();
        Card ingredient = player.ChooseIngredient();
        player.RemoveIngredient(ingredient);
        GameManager.currentPlayerTurn.AddIngredient(ingredient);
    }
}
