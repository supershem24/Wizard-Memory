using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class Potion : MonoBehaviour
{
    public enum PotionRarity { Common, Rare, Perfect }

    public int points;
    public PotionRarity rarity;

    public static Potion currentPotion;

    public List<GameObject> potionObjects;


    /// <summary>
    /// Whats Needed:
    /// - Crafting potions
    /// - Potion effects
    /// </summary>

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetAttributes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set the attributes of the potion (points, effects, etc.)
    internal virtual void SetAttributes()
    {

    }

    // What the potion does when drank
    internal virtual void PotionEffect()
    {
        currentPotion = this;
        currentPotion = null;
    }

    public virtual void AfterPlayerSelect(Player player)
    {

    }

    public virtual void AfterCardSelect(Player player, Card ingredient)
    {

    }
}
