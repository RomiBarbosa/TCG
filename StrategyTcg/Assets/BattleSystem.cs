using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum StateBattle { PLAYERTURN,ENEMYTURN}
public class BattleSystem : MonoBehaviour
{
    public Unit ataca;
    public Unit enemy;
    StateBattle Battle;

    void Start()
    {
       // StartCoroutine(SettupBattle());
        Battle = StateBattle.PLAYERTURN;
    }


    IEnumerator SettupBattle()
    {
        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    public void BattleMultiple(Unit a, Unit d)
    {
        ataca = a;
        enemy = d;
        StartCoroutine(PlayerAttack());
        Debug.Log("Multiple battle");
    }


   public void PlayerTurn()
    {
       StartCoroutine(PlayerAttack());
       Debug.Log("Jugador turno");
    }

    IEnumerator PlayerAttack()
    {
        if (Battle== StateBattle.PLAYERTURN)
        {
            enemy.TakeDamage(ataca.damage);
            Debug.Log( ataca.title +" inflingio " + ataca.damage + "de daño a" + enemy.title);
        }
        if (Battle == StateBattle.ENEMYTURN)
        { ataca.TakeDamage(enemy.damage);
            Debug.Log(enemy.title + " inflingio " + enemy.damage + "de daño a" + ataca.title);
        }
     
        ChangeTurn();

        yield return new WaitForSeconds(2f);
    }

    public Unit TheBattle(Unit attacker, Unit defender)
    {
        defender.TakeDamage(attacker.damage);
        return defender;
    }

    private void ChangeTurn()
    {
        if (Battle == StateBattle.PLAYERTURN)
        {
            Battle = StateBattle.ENEMYTURN;
        } else { Battle = StateBattle.PLAYERTURN; }
    }
}
