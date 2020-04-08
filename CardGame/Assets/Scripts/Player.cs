using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public string namePlayer;
    //public Deck myDeck;
    public Store store;
    public int coins = 5;
    public int level = 0;
    public int xp = 0;
    public const int maxCoins = 5;
    public bool isMyPlayer;
    public bool myTurn;
    public CardPlayer cp;
    public GameObject CardUI;
    public GameObject Panel;

    public List<GameObject> handCards = new List<GameObject>();
    public List<Card> hand = new List<Card>();

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
        health = 45;
    }

    public void AddCardToHand(Card cardPlayer)
    {
        handCards.Add(CreateCardUI(cardPlayer));
    }

    public void PlayerTurn()
    {
        myTurn = true;
        if (coins < maxCoins)
        {
            coins++;
        }

    }

    public void PlayCard(CardPlayer cardPlayer)
    {
        var card = cardPlayer.cardInfo;
        DiscardFromHand(cardPlayer);
        boardPlayer.AddCard(card, this);
    }

    public bool BuyCard(StoreCard cardPlayer)
    {
        bool buy = false;
        var card = cardPlayer.cardInfo;
        if (CanBuy(card.cost))
        {
            SubstractionCoins(card.cost);
            hand.Add(card);
            AddCardToHand(card);
            Debug.Log("compro carta");
            buy = true;
        }
        return buy;
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

    public bool CanRefresh()
    {
        if (coins >= 1)
        {
            coins--;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyXP()
    {
        if (level<3 && coins>=1)
        {
            xp++;
            ManageLevel();
            coins--;
        }
        
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
            }
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

    public void ManageLevel()
    {
        if (xp >= 10 && xp < 20)
        {
            level = 2;
        }
        if (xp >= 20)
        {
            level = 3;
        }
    }
}
