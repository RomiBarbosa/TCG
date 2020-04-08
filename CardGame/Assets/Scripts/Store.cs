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
        player = gameObject.GetComponent<Player>();
        store.Clear();
        for (int i = 0; i < 3; i++)
        {
            var card = deck.GiveMeACard();
            store.Add(card);
        }
        for (int i = 0; i < 3; i++)
        {
            storeUI.Add(DrawCards());
        }
        UpdateDataCards();
    }
    public void Refresh()
    {
        
        if (!isLock && player.CanRefresh())
        {
            ChangeCards();
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

    public void ChangeCards()
    {
        //for (int i = 0; i < maxCards; i++)
        //{
        //    if (storeUI[i].activeSelf == true)
        //    {
        //        deck.AddCardToDeck(storeUI[i].GetComponent<StoreCard>().cardInfo);
        //        Debug.Log("agrego carta");
        //    }
            
        //}
        store.Clear();
        for (int i = 0; i < 3; i++)
        {
            var card = deck.GiveMeACard();
            store.Add(card);
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


    public GameObject CreateCardUI(Card card)
    {
        GameObject go = Instantiate(CardUI, new Vector3(0, 0, 0), Quaternion.identity);
        go.transform.SetParent(Panel.transform);
        go.GetComponent<StoreCard>().cardInfo = card;
        go.GetComponent<StoreCard>().myPlayer = player;
        return go;
    }

    public void SellCards(GameObject card)
    {
        //comprar nivel jugador
        //vender cartas
        //devolver al deck principal las cartas
        //deck deberia ser estatico
        //al recibir una carta devolverla al deck principal
        //y dar una moneda al jugador
        //tenes que usar la carta para poder venderla
    }
}
