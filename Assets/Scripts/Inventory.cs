using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Card> items = new List<Card>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(Card ingredient)
    {
        ingredient.gameObject.transform.position = transform.position; // Move the ingredient to the inventory's position
        items.Add(ingredient);
        Debug.Log("Added to inventory: " + ingredient);
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
