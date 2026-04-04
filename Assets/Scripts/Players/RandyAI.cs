using UnityEngine;

public class RandyAI : Player
{
    
    internal override void SelectCardsUpdate()
    {
        //past here it has to be the AI's turn to interact with things
        if (!(GameManager.currentPlayerTurn == this) || !GameManager.playerTurn)
            return;

        int randomX = Random.Range(0, Board.LAYOUTWIDTH);
        int randomY = Random.Range(0, Board.LAYOUTHEIGHT);
        Card selectedCard = GameManager.instance.GetCardOnBoard(randomX, randomY);

        if (selectedCard != null && !selectedCard.IsFlipped)
        {
            selectedCard.Flip();
            GameManager.instance.CardSelected(selectedCard);
        }
    }

}
