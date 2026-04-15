using UnityEngine;


public class Transforming : Potion
{

    internal override void SetAttributes()
    {
        points = 2;
        rarity = PotionRarity.Common;
    }

    //Replace any non-Perfect ingredient required to brew a potion with any ingredient. (NOT CERTAIN HOW TO DO THIS)
    internal override void PotionEffect()
    {

    }
}
