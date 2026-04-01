using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<string> items = new List<string>();

    void Awake()
    {
        instance = this;
    }

    public void AddItem(string ingredient)
    {
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
