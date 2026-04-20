using UnityEngine;
using System;

/// <summary>
/// Potion Effect:
/// 
/// </summary>
public class AcidSpit : Potion
{
    internal override void SetAttributes()
    {
        //points = ;
        //rarity = ;
    }

    //
    internal override void PotionEffect()
    {
        currentPotion = this;
        EndPotionEffect();
    }
}