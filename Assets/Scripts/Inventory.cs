using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Card> items = new List<Card>();

    public float spacing = 1.2f;
    public int columns = 4;

    void Awake()
    {
        
    }

    public void AddItem(Card ingredient)
    {
        ingredient.transform.SetParent(this.transform);

        int index = items.Count;

        int row = index / columns;
        int col = index % columns;

        Vector3 offset = new Vector3(col * spacing, 0, -row * spacing);
        ingredient.transform.localPosition = offset;

        Rigidbody rb = ingredient.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        ingredient.transform.rotation = Quaternion.Euler(0, 0, 0);

        //WIP CURRENT SOLUTION
        //ingredient.gameObject.transform.position = transform.position; // Move the ingredient to the inventory's position
        //ingredient.gameObject.GetComponent<Rigidbody>().useGravity = false;

        items.Add(ingredient);
        Debug.Log("Added to inventory: " + ingredient);
    }

    //Removes the item from the inventory (DOES NOT DESTROY THE GAME OBJECT, JUST REMOVES IT FROM THE LIST)
    public Card RemoveItem(Card ingredient)
    {
        if (items.Contains(ingredient))
        {
            items.Remove(ingredient);
            Debug.Log("Removed from inventory: " + ingredient);
            return ingredient;
        }
        else
        {
            Debug.LogWarning("Attempted to remove an item that is not in the inventory: " + ingredient);
            return null;
        }
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
