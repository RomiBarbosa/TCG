using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public int health;
   // public List<Card> hand = new List<Card>();
    Deck myDeck;
    public int coins;
    public const int maxCoins = 5;
    //limite 3
    public bool isMyPlayer;
    public bool myTurn;

    public CardPlayer cp;

    public GameObject CardUI;
    public GameObject Panel;

    public List<GameObject> handCards = new List<GameObject>();
    public Board board;

    int indexHand;

    public int maxCards = 3;
    private void Start()
    {
       myDeck= gameObject.GetComponent<Deck>();
        health = 100;
    }

    public void AddCardToHand()
    {
        if (myDeck.HaveCardsInDeck()/* && maxCards< handCards.Count*/)
        {
            var card = myDeck.GiveMeACard();
            handCards.Add(CreateCardUI(card));
        }
}

   public void PlayerTurn()
    {
        myTurn = true;
        AddCardToHand();
        if (coins <maxCoins)
        {
            coins++;
        }

    }

    public void PlayCard(CardPlayer cardPlayer )
    {

        var card = cardPlayer.cardInfo;
        if (CanBuy(card.cost))
        {
            SubstractionCoins(card.cost);
            DiscardFromHand(cardPlayer);
            board.AddCardToBoard(card);
        }
    }

    public bool CanBuy(int cardcost)
    {
        if (cardcost < coins)
        {
            return true;
        }
        else{ return false; }
    }

    public void SubstractionCoins(int cardcost)
    {
        coins -= cardcost;
    }

    public void DiscardFromHand(CardPlayer card)
    {
        for (int i = 0; i < handCards.Count; i++)
        {
            if (handCards[i].GetComponent<CardPlayer>() == card)
            {
                handCards[i].GetComponent<CardPlayer>().Destroy();
                handCards.Remove(handCards[i]);
               
            }
        }
    }
    public void InputPlayer()
    {
        if (myTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {

               // Board.boardIns.AddCardToBoard();
            }
            //me pueddo mover
           
        }
    }

    public GameObject CreateCardUI(Card card)
    {
        GameObject go = Instantiate(CardUI, new Vector3(0, 0, 0), Quaternion.identity);
        go.transform.SetParent(Panel.transform);
        go.GetComponent<CardPlayer>().cardInfo = card;
        go.GetComponent<CardPlayer>().indexHand = indexHand;
        go.GetComponent<CardPlayer>().myPlayer = this;
            indexHand++;
        return go;
    }
}
