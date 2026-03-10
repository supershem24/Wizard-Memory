using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Card : MonoBehaviour
{

    string color;
    string ingridient;
    public int testNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flip();
        }
       
    }

    void Flip()
    {
        Debug.Log("Hello");
    }

    public void ChangeCardNumber(int num)
    {
        testNum = num;
        gameObject.GetComponentInChildren<TMP_Text>().text = num.ToString();
    }
}
