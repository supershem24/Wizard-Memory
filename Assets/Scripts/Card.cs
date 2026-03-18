using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Card : MonoBehaviour
{

    string color;
    string ingridient;
    string rarity;
    public int testNum;

    private bool isFlipped = false;

    // Reference GameManager script
    public GameManager manager;

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
        if (!isFlipped)
        {
            Flip();
            manager.CardSelected(this);
        }
    }

    public void Flip()
    {
        isFlipped = true;
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

    public void ResetCard()
    {
        isFlipped = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void ChangeCardNumber(int num)
    {
        testNum = num;
        gameObject.GetComponentInChildren<TMP_Text>().text = num.ToString();
    }
}
