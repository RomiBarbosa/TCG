using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Player[] players;

    public int turn;

    public Text p1, p2;

    public void EndTurn()
    {
       players[turn].myTurn = false;
       ChangeTurn();
       PlayTurn();

    }


     void ChangeTurn()
    {
        if (turn<(players.Length -1))
        {
            turn++;
        }
        else { turn = 0; }
        
    }

    void PlayTurn()
    {
        players[turn].PlayerTurn();
    }

    void Start()
    {
        turn = Random.Range(0,2);
        PlayTurn();
        //turn *
        // change turn*
        //when change turn, add card to hand*
        //coin +1*
        //show coins *
        //enable inputs to player 
        //container hand *
        //table 
        //cost card, can play the card if you have coins *
        //comparing cost and make the substraction of the player cost*
        //inputs: can do a click on the card and disappear *
        //health player * 
        //con un booleano no pueda ver al otro jugador*
        //deberia ser random quien empieza*
        //Si saco la carta 2 la 3 y 4 deberian cambiar su indice uno menosLISTASSEÑORA
        //instanciar en mi board
        //hacer la diferenciacion de carta de hechizo con la carta de esbirros*
        //battle*
        //los hechizos empezar por los que see hacen con linq
        //hacer los dibujos*
        //Implemented the spell and soldier cards, fixed deck problems*

    }

    void Update()
    {
        ShowStats();
        for (int i = 0; i < 2; i++)
        {
            if (!players[i].isMyPlayer)
            {
                for (int j = 0; j < players[i].handCards.Count; j++)
                {
                    players[i].handCards[j].GetComponent<CardPlayer>().showCard= false;
                }
               
            }
        }
     
    }

    public void ShowStats()
    {
        p1.text = "Player 1: health:" + players[0].health + " coins:" + players[0].coins;
        p2.text = "Player 2: health:" + players[1].health + " coins:" + players[1].coins;
    }
}
