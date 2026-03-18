using UnityEngine;

public class Table : MonoBehaviour
{
    const int LAYOUTWIDTH = 4;
    const int LAYOUTHEIGHT = 4;
    const float CARDPLACEMENTHEIGHT = 0.5f;

    [SerializeField]
    Vector3 TABLECENTER;
    float GRIDGAP = 1.4f; //Gap between centers of cards
    const float CARDWIDTH = 1;
    const float CARDHEIGHT = 1;

    [SerializeField]
    public Deck currentDeck;
    Card[][] field; //PLACEHOLDER FOR PHYSICAL PLACE

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TABLECENTER = gameObject.transform.position;
        currentDeck.CreateSampleDeck(40);
        currentDeck.ShuffleDeck();
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
                currentCard.transform.position = new Vector3(TABLECENTER.x + GRIDGAP*(1.5f-i), TABLECENTER.y + CARDPLACEMENTHEIGHT, TABLECENTER.z + GRIDGAP * (1.5f - j) + 0.7f);
                Debug.Log(currentCard.testNum);
                field[i][j] = currentCard;
            }
        }
        
    }
}
