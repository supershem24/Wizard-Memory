using UnityEngine;

public class Frenzy : Potion
{
    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //If you make no matches this turn, steal 2 ingredients from an opponent.
    internal override void PotionEffect()
    {
        GameManager.instance.ChoosePlayer();
        //Card ingredient = player.ChooseIngredient();
        //player.RemoveIngredient(ingredient);
        //GameManager.currentPlayerTurn.AddIngredient(ingredient);
    }
}
