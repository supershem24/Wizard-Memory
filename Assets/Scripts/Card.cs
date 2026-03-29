using TMPro;
using UnityEngine;
//using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System;

public class Card : MonoBehaviour
{

    [SerializeField]
    MeshRenderer faceMesh;

    string color;
    public string getColor() { return color; }

    string ingredient;
    string rarity;
    public int testNum;

    public int gridX;
    public int gridY;

    private bool isFlipped = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (GameManager.playerTurn && !isFlipped)
        {
            Flip();
            GameManager.instance.CardSelected(this);
        }
    }

    //Flip the Card faceup
    public void Flip()
    {
        isFlipped = true;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    //Flip the Card facedown
    public void ResetCard()
    {
        isFlipped = false;
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    //Testing for changing the card number, probably have to do this with the other attruibutes of the card
    /*public void ChangeCardNumber(int num)
    {
        testNum = num;
        gameObject.GetComponentInChildren<TMP_Text>().text = num.ToString();
    }*/

    //Create the card using a json list to find out the rarity and color of an ingredient
    public void CreateCard(string ingredient)
    {
        this.ingredient = ingredient;
        Tuple<string,string> tempAttributes = GameManager.getIngridentAttributes(ingredient);
        color = tempAttributes.Item1;
        rarity = tempAttributes.Item2;
        faceMesh.material = Resources.Load<Material>("2DMaterials/" + ingredient + "M");
    }

    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }
}
