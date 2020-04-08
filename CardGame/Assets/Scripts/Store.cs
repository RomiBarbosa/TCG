using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Deck deck;
    public List<Card> store;
    public List<GameObject> storeUI;
    public GameObject CardUI;
    public GameObject Panel;
    public Player player;
    public int maxCards = 3;
    public bool isLock;
    public Text textLock;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        player = gameObject.GetComponent<Player>();

        store.Clear();

        for (int i = 0; i < 3; i++)
        {
            GetCardsFromDeck();
        }
        for (int i = 0; i < 3; i++)
        {
            storeUI.Add(DrawCards()); //create the cards
        }
        UpdateDataCards();
    }

    public void Refresh()
    {
        deck.Shuffle();
        if (!isLock && player.CanRefresh())
        {
            ReloadCards();
            UpdateDataCards();
        }
      
    }

    public void LockStore()
    {
        if (isLock)
        {
            isLock = false;
            textLock.text = "Lock";
        }
        else
        {
            isLock = true;
            textLock.text = "Unlock";
        }

    }

    public void GetCardsFromDeck()
    {
        var card = deck.GiveMeACard();
        if (FilterCardByLevel(card))
        {
            store.Add(card);
        }
        else
        {
            GetCardsFromDeck();
            deck.AddCardToDeck(card);
        }

    }

    public void ReloadCards()
    {
        for (int i = 0; i < 3; i++)
        {
            if (storeUI[i].activeSelf == true)
            {
                deck.AddCardToDeck(storeUI[i].GetComponent<StoreCard>().cardInfo);
            }

        }
        store.Clear();
        for (int i = 0; i < 3; i++)
        {
            GetCardsFromDeck();
        }
    }



    public void UpdateDataCards()
    {
        for (int i = 0; i < 3; i++)
        {
            storeUI[i].gameObject.SetActive(true);
            storeUI[i].GetComponent<StoreCard>().cardInfo = store[i];
            storeUI[i].GetComponent<StoreCard>().myPlayer = player;
            storeUI[i].GetComponent<StoreCard>().UpdateData();
        }
    }

    public GameObject DrawCards()
    {
        GameObject go = Instantiate(CardUI, new Vector3(0, 0, 0), Quaternion.identity);
        go.transform.SetParent(Panel.transform);
        return go;
    }

    public void SellCards(Card card)
    {
        deck.AddCardToDeck(card);
        player.coins++;
    }

    public bool FilterCardByLevel(Card card)
    {
        if (card.level <=player.level)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyXP()
    {
        player.BuyXP();
    }
}
