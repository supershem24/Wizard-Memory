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
        currentPotion = this;
        GameManager.instance.ChoosePlayer();
    }

    public override void AfterPlayerSelect(Player player)
    {
        //getIngredient = true;
        player.ChooseIngredient();
    }

    public override void AfterCardSelect(Player player, Card ingredient)
    {

        player.RemoveIngredient(ingredient);
        GameManager.currentPlayerTurn.AddIngredient(ingredient);
        currentPotion = null;
    }
}
