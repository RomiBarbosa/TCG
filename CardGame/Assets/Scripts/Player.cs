using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public string namePlayer;
   public Deck myDeck;
    public int coins;
    public const int maxCoins = 5;
    public bool isMyPlayer;
    public bool myTurn;
    public CardPlayer cp;
    public GameObject CardUI;
    public GameObject Panel;

    public List<GameObject> handCards = new List<GameObject>();

    int indexHand;

    public int maxCards = 3;

    public Text healthText, coinsText, nameText;
    public BoardPlayer boardPlayer; 

    public void ShowStats()
    {
        healthText.text = health.ToString();
        coinsText.text = coins.ToString() + "/5";
        nameText.text = namePlayer;
    }

    private void Update()
    {
        ShowStats();
    }


    private void Start()
    {
        myDeck = gameObject.GetComponent<Deck>();
        health = 45;
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
        if (coins < maxCoins)
        {
            coins++;
        }

    }

    public void PlayCard(CardPlayer cardPlayer)
    {

        var card = cardPlayer.cardInfo;
        if (CanBuy(card.cost))
        {
            SubstractionCoins(card.cost);
            DiscardFromHand(cardPlayer);
            boardPlayer.AddCard(card);
           // board.AddCardToBoard(card);
        }
    }

    public bool CanBuy(int cardcost)
    {
        if (cardcost <= coins)
        {
            return true;
        }
        else { return false; }
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
