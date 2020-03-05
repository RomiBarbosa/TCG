using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

enum StateGame {PLAYERSTURNS,COMBAT, ENDGAME};
public class Manager : MonoBehaviour
{
    public Player[] players;
    public int turn;
    StateGame actualState;
    public BattleSystem battle;

    public void EndTurn()
    {
        players[turn].myTurn = false;
        ChangeTurn();
        PlayTurn();
    }
    void ChangeTurn()
    {
        if (turn < (players.Length - 1))
        {
            turn++;
        }
        else { turn = 0; }
        //mod

    }
    void PlayTurn()
    {
        players[turn].PlayerTurn();
        
    }


    public void SettupBattle()
    {
        actualState = StateGame.COMBAT;
        StartCoroutine(StartCombat());
    }


    IEnumerator StartCombat()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (players[0].boardPlayer.units.Count == 0 && players[1].boardPlayer.units.Count == 0)
            {
                Debug.Log("EMPATE");
                break;

            }

            if (CheckWinners()) // (players[0].boardPlayer.units.Count == 0 || players[1].boardPlayer.units.Count == 0)
            {
                Debug.Log("Won! team ");
                TeamWinner();
                break;
            }
            else
            {
                battle.BattleMultiple(players[0].boardPlayer.units[Random.Range(0, players[0].boardPlayer.units.Count)],
                players[1].boardPlayer.units[Random.Range(0, players[1].boardPlayer.units.Count)]);
            }
        }

    }

    public bool CheckWinners()
    {
        return players.Any((board) => board.boardPlayer.units.Count == 0); //return false;
    }

    public int TeamWinner()
    {
        int result = 0;
        //for (int i = 0; i < players.Length; i++)
        //{
        //    if (players[i].boardPlayer.units.Count != 0)
        //    {
        //        result = players[i].boardPlayer.units.Sum((r) => r.damage);
        //        Debug.Log("Team " + i + "! damage to hero:" + result);
        //        PlayerTakeDamage(i,result);
        //    }
        //}
        if (players[0].boardPlayer.units.Count == 0)
        {
            result = players[1].boardPlayer.units.Sum((r) => r.damage);
            // PlayerTakeDamage(1, result);
            Debug.Log("Team 1! damage to hero:" + result);
            PlayerTakeDamage(0, result);
        }
        else
        {
            result = players[0].boardPlayer.units.Sum((r) => r.damage);
            //PlayerTakeDamage(0, result);
            Debug.Log("Team 0! damage to hero:" + result);
            PlayerTakeDamage(1, result);
        }
        actualState = StateGame.PLAYERSTURNS;
        EndTurn();
        return result;
    }

    public void PlayerTakeDamage(int index, int damage)
    {
        players[index].health -= damage;
    }


    void Start()
    {
        actualState = StateGame.PLAYERSTURNS;
        turn = Random.Range(0, 2);
        PlayTurn();
    }


}