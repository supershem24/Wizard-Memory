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
        currentDeck.CreateSampleDeck(10);
        currentDeck.ShuffleDeck();
        SetUpLayout();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Setting up on layout based on grid pattern
    void SetUpLayout()
    {
        field = new Card[LAYOUTWIDTH][];

        for (int i = 0; i < LAYOUTWIDTH; i++)
        {
            field[i] = new Card[LAYOUTHEIGHT];
            for (int j = 0; j < LAYOUTHEIGHT; j++)
            {
                Card currentCard = currentDeck.DealCard();

                if (currentCard == null)
                {
                    Debug.LogError("Ran out of cards while setting up!");
                    return;
                }

                Vector3 pos = new Vector3(TABLECENTER.x + GRIDGAP * (1.5f - i), TABLECENTER.y + CARDPLACEMENTHEIGHT, TABLECENTER.z + GRIDGAP * (1.5f - j) + 0.7f);
                currentCard.transform.position = pos;

                currentCard.ResetCard();
                currentCard.SetGridPosition(i, j);

                field[i][j] = currentCard;
            }
        }
    }

    public void ReplaceCard(Card oldCard)
    {
        int x = oldCard.gridX;
        int y = oldCard.gridY;

        Vector3 pos = oldCard.transform.position;

        // Remove old card
        Destroy(oldCard.gameObject);

        // If deck is empty, just leave it empty
        if (currentDeck.deckCards.Count == 0)
        {
            field[x][y] = null;
            return;
        }

        Card newCard = currentDeck.DealCard();

        newCard.transform.position = pos;
        newCard.SetGridPosition(x, y);

        field[x][y] = newCard;
    }
}
