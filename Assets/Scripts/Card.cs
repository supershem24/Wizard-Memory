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

    //MAKE AN ISWILD VARIABLE

    public int gridX;
    public int gridY;

    private bool isFlipped = false;

    public bool IsFlipped { get { return isFlipped; } }

    private Rigidbody rigidbody;
    private Vector3 tempPos; // Temporary variable to store position during physics interactions


    // Awake is called once before the first execution of Update before the MonoBehaviour is created
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        tempPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnMouseDown()
    {
        if (GameManager.playerTurn && !isFlipped)
        {
            Flip();
            GameManager.instance.CardSelected(this);
        }
    }*/

    //Flip the Card faceup
    public void Flip()
    {
        isFlipped = !isFlipped;
        //transform.position = tempPos;
        //rigidbody.AddForce(new Vector3(0, 100, 0));
        //rigidbody.AddTorque(new Vector3(-50, 0, 0)); ANIMATION ATTEMPT, NOT WORKING
        if (isFlipped) { transform.rotation = Quaternion.Euler(0, 0, 0); }
        else { transform.rotation = Quaternion.Euler(0, 0, 180); }
    }

    //Flip the Card facedown
    public void ResetCard()
    {
        isFlipped = false;
        transform.rotation = Quaternion.Euler(0, 0, 180);
        tempPos = transform.position;
    }

    //Testing for changing the card number, probably have to do this with the other attruibutes of the card
    /*public void ChangeCardNumber(int num)
    {
        testNum = num;
        gameObject.GetComponentInChildren<TMP_Text>().text = num.ToString();
    }*/

    //Create the card using the GameManager IngrideientDict to find out the rarity and color of an ingredient
    public void CreateCard(string ingredient)
    {
        this.ingredient = ingredient;
        Tuple<string,string> tempAttributes = GameManager.getIngridentAttributes(ingredient);
        color = tempAttributes.Item1;
        rarity = tempAttributes.Item2;
        //make the top of the card the correct face based on the ingredient
        faceMesh.material = Resources.Load<Material>("2DMaterials/" + ingredient + "M");
    }

    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }

    public string GetIngredient()
    {
        return ingredient;
    }
}
