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
        //Card c = Discard(deck.Count - 1);
        //cp.cardInfo = c;
        //cp.UpdateData();
        //return c; //the last card
        Card c = Discard(Random.Range(0,deck.Count));
        return c;
    }

    public void AddCardToDeck(Card card)
    {
        deck.Add(card);
    }
}
