using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public CardPlayer cp;

    void Start()
    {
        InitializeDeck();
        Shuffle();

    }
    private void Update()
    {
    }
    public void InitializeDeck()
    {
        //  deck.Add(Card.CardInstance("Snake", "ssssssssss", 5/*, 2, 1*/));
        //  deck.Add(Card.CardInstance("Fish", "glu", 1/*, 1, 4*/));
        //  deck.Add(Card.CardInstance("Spider", "bu", 6/*, 8, 3*/));
       // deck.Add(SpellCard.CardInstance("COMETA","Damage +5",5,5,5));
    }

    public Card Discard(int index)
    {
        Card mycard = deck[index];
        deck.RemoveAt(index);
            return mycard;
    }

    public void Shuffle()
    {
       deck.Sort((x,y)=> Random.Range(-1,2));
    }

    public bool HaveCardsInDeck()
    {
        if (deck.Count > 0){ return true;} else { return false; }
    }

    int ind = 0;

    public Card GiveMeACard()
    {
        Card c = Discard(deck.Count-1);
        cp.cardInfo = c;
        cp.UpdateData();
        return c;
        //if (ind< deck.Count)
        //{
        //    Card c = Discard(deck.Count-1);
        //    cp.cardInfo = c;
        //    cp.UpdateData();
        //    //ind++;
        //    return c;
        //}
        //else { return null; }
    }


}
