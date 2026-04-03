using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Board board;
    public GameObject playerPrefab;
    public Deck deck;

    private Card firstCard;
    private Card secondCard;
    private string firstColor;
    private string secondColor;

    private List<Card> matchedCards = new List<Card>();

    public static GameManager instance;
    public static bool playerTurn;
    public static Player currentPlayerTurn;
    List<Player> players = new List<Player>();

    /// <summary>
    /// INGREDIENT DICTIONARY
    /// </summary>

    //Dictionary containing every ingredient as well as attributes.
    private static Dictionary<string, Tuple<string, string>> ingredientDict = new Dictionary<string, Tuple<string, string>>()
    {
        {"Cone", new Tuple<string, string>("Red", "Common")},
        {"Pelt", new Tuple<string, string>("Red", "Common")},
        {"Horn", new Tuple<string, string>("Red", "Common")},
        {"Snow", new Tuple<string, string>("Red", "Rare")},
        {"Fang", new Tuple<string, string>("Red", "Rare")},
        {"Icicle", new Tuple<string, string>("Red", "Perfect")},
        {"Core", new Tuple<string, string>("Red", "Perfect")},
        {"Strand", new Tuple<string, string>("Yellow", "Common")},
        {"Iron", new Tuple<string, string>("Yellow", "Common")},
        {"Oiled", new Tuple<string, string>("Yellow", "Common")},
        {"Cloud", new Tuple<string, string>("Yellow", "Rare")},
        {"Wing", new Tuple<string, string>("Yellow", "Rare")},
        {"Zenith", new Tuple<string, string>("Yellow", "Perfect")},
        {"Cell", new Tuple<string, string>("Yellow", "Perfect")},
        {"Grass", new Tuple<string, string>("Green", "Common")},
        {"Fungi", new Tuple<string, string>("Green", "Common")},
        {"Vine", new Tuple<string, string>("Green", "Common")},
        {"Branch", new Tuple<string, string>("Green", "Rare")},
        {"Root", new Tuple<string, string>("Green", "Rare")},
        {"Tear", new Tuple<string, string>("Green", "Perfect")},
        {"Rose", new Tuple<string, string>("Green", "Perfect")},
        {"Waxed", new Tuple<string, string>("Blue", "Common")},
        {"Web", new Tuple<string, string>("Blue", "Common")},
        {"Berry", new Tuple<string, string>("Blue", "Common")},
        {"Powder", new Tuple<string, string>("Blue", "Rare")},
        {"Gland", new Tuple<string, string>("Blue", "Rare")},
        {"Gem", new Tuple<string, string>("Blue", "Perfect")},
        {"Stone", new Tuple<string, string>("Blue", "Perfect")},
        {"LMagic", new Tuple<string, string>("Colorless", "Common")},
        {"GMagic", new Tuple<string, string>("Colorless", "Rare")},
        {"PMagic", new Tuple<string, string>("Colorless", "Perfect")},
        {"Moon", new Tuple<string, string>("Black", "Common")},
        {"Scale", new Tuple<string, string>("Black", "Common")},
        {"Bottle", new Tuple<string, string>("Black", "Rare")},
        {"Heart", new Tuple<string, string>("Black", "Perfect")},
    };

    //get if the ingredient is in the list
    public static bool isIngredient(string ingredient)
    {
        return GameManager.ingredientDict.ContainsKey(ingredient);
    }

    //get the attributes from an ingrident in the list
    public static Tuple<string, string> getIngridentAttributes(string ingredient)
    {
        if (!GameManager.ingredientDict.ContainsKey(ingredient))
        {
            Debug.LogError("Ingredient not found in ingredient list: " + ingredient);
            return null;
        }
        return ingredientDict[ingredient];
    }

    //get eash ingredient in the list
    public static List<string> getAllIngredients()
    {
        List<string> ingredients = new List<string>();
        foreach (string ingredient in GameManager.ingredientDict.Keys)
        {
            ingredients.Add(ingredient);
        }
        return ingredients;
    }


    /// <summary>
    /// END INGREDIENT DICTIONARY
    /// </summary>

    void Awake()
    {
        playerTurn = true;
        instance = this;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Starts the game, can be used to reset the game as well
    void StartGame()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
        deck = GameObject.FindGameObjectWithTag("Deck").GetComponent<Deck>();

        int amountOfPlayers = 2; //TEMPORARY, CHANGE LATER
        for (int i = 0; i < amountOfPlayers; i++)
        {
            GameObject playerObj = Instantiate(playerPrefab);
            players.Add(playerObj.GetComponent<Player>());
        }
        currentPlayerTurn = players[0];

        deck.CreateSampleDeck();
        deck.ShuffleDeck();
        board.SetUpLayout();


    }

    public void CardSelected(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            firstColor = card.getColor();
        }
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            secondColor = card.getColor();
            playerTurn = false;
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        playerTurn = false;

        //(POSIBLE EDGE CASE OF BOTH COLORLESS UNTESTED)
        if(firstColor == "Colorless" || secondColor == "Colorless")
        {
            Debug.Log("Colorless card selected! Match!");
            firstColor = firstColor != "Colorless" ? firstColor : secondColor;
            Invoke(nameof(HandleMatch), 0.3f);
            return;
        }

        if (firstColor == secondColor)
        {
            Debug.Log("Match! Keep going");
            Invoke(nameof(HandleMatch), 0.3f);
        }
        else
        {
            Debug.Log("No match!");
            Invoke(nameof(ResetCards), 1f);
        }
    }

    void HandleMatch()
    {
        if (!matchedCards.Contains(firstCard))
        {
            matchedCards.Add(firstCard);
        }
        matchedCards.Add(secondCard);

        firstCard = secondCard;
        secondCard = null;
        playerTurn = true;
    }

    void ResetCards()
    {
        secondCard.Flip();
        secondCard = null;

        if (matchedCards.Count == 0)
        {
            firstCard.Flip();
        }
        else
        {
            foreach (Card matched in matchedCards)
            {
                board.ReplaceCard(matched);
            }
        }

        matchedCards.Clear();
        firstCard = null;
        SwitchPlayerTurn();
    }

    void SwitchPlayerTurn()
    {
        players.RemoveAt(0);
        players.Append(currentPlayerTurn);
        currentPlayerTurn = players[0];
        playerTurn = true;
    }


}
