using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Collections.Generic;

public class Card : MonoBehaviour
{

    string color;
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
    public void ChangeCardNumber(int num)
    {
        testNum = num;
        gameObject.GetComponentInChildren<TMP_Text>().text = num.ToString();
    }

    //Create the card using a json list to find out the rarity and color of an ingredient
    public void CreateCard(string ingredient)
    {
        this.ingredient = ingredient;
        
    }

    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }

    // Code added for testing purpose, can be deleted later with the public static readonly Color[] VALUE_COLORS = new Color[] in deck.cs
    public void SetCardColor(Color color)
    {
        MeshRenderer mr = GetComponentInChildren<MeshRenderer>();
        if (mr != null)
        {
            Material mat = new Material(mr.material);
            mat.SetColor("_BaseColor", color);
            mr.material = mat;
        }
        else
        {
            Debug.LogError("No MeshRenderer found in children!");
        }
    }
}
