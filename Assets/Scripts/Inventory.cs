using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Card> items = new List<Card>();

    void Awake()
    {
        
    }

    public void AddItem(Card ingredient)
    {
        //WIP CURRENT SOLUTION
        ingredient.gameObject.transform.position = transform.position; // Move the ingredient to the inventory's position
        ingredient.gameObject.GetComponent<Rigidbody>().useGravity = false;

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
