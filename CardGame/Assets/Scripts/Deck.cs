using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public CardPlayer cp;

    void Start()
    {
        Shuffle();
        InitializeDeck();
      

    }
    private void Update()
    {

    }
    public void InitializeDeck()
    {
    }

    public Card Discard(int index)
    {
        Card mycard = deck[index];
        deck.RemoveAt(index);
        return mycard;
    }

    public void Shuffle()
    {
        deck.Sort((x, y) => Random.Range(-1, 2));
    }

    public bool HaveCardsInDeck()
    {
        if (deck.Count > 0) { return true; } else { return false; }
    }

    

    public Card GiveMeACard()
    {
        Card c = Discard(deck.Count - 1);
        cp.cardInfo = c;
        cp.UpdateData();
        return c;
    }


}
