using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Scoreboard : MonoBehaviour
{

    public List<Player> players = new List<Player>();
    public List<int> scores = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(Player player, int changedScore)
    {
        for(int i = 0; i <= players.Count; i++)
        {
            if(i == players.Count)
            {
                Debug.LogError("Player not found in scoreboard: " + player.ToString());
                break;
            }
            if (players[i] == player)
            {
                scores[i] = changedScore;
                break;
            }
        }
        DisplayScore();
    }

    public void DisplayScore()
    {
        string scoreText = "Scores:\n";
        for (int i = 0; i < players.Count; i++)
        {
            scoreText += players[i].name + ": " + scores[i] + "\n";
        }
        gameObject.GetComponentInChildren<TMP_Text>().text = scoreText;
    }
}
