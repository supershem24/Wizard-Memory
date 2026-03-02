using UnityEngine;

public class Table : MonoBehaviour
{
    const int LAYOUTWIDTH = 4;
    const int LAYOUTHEIGHT = 4;

    [SerializeField]
    public Deck currentDeck;

    Card[][] field; //PLACEHOLDER FOR PHYSICAL PLACE

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUpLayout();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //UNFINISHED
    void SetUpLayout()
    {
        field = new Card[LAYOUTWIDTH][];
        Card currentCard;

        for (int i = 0; i < LAYOUTWIDTH; i++)
        {
            field[i] = new Card[LAYOUTHEIGHT];
            for(int j = 0; j < LAYOUTHEIGHT; j++)
            {
                currentCard = currentDeck.DealCard();
                field[i][j] = currentCard;
            }
        }
        
    }
}
