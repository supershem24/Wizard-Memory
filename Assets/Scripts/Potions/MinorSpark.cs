using UnityEngine;

public class MinorSpark : Potion
{
    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //Gain 3 points.
    internal override void PotionEffect()
    {
        GameManager.currentPlayerTurn.AddScore(3);
    }
}
