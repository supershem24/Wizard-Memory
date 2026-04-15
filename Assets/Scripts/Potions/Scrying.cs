using UnityEngine;

public class Scrying : Potion
{
    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //Peek at 2 tiles.
    internal override void PotionEffect()
    {

    }
}
