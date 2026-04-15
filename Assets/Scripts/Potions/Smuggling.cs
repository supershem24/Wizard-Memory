using UnityEngine;

public class Smuggling : Potion
{
    public static bool smugglingUsed = false;

    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //Gain all revealed ingredients this turn when matching, even if you fail to make a match.
    internal override void PotionEffect()
    {
        smugglingUsed = true;
    }
}
