using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }
}
